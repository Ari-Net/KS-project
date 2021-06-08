using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiClipBoard
{
    public partial class Form1 : Form
    {
        private RemoteClipboard m_remoteClipboard;
        public Form1()
        {
            InitializeComponent();
			TcpChannel channel = new TcpChannel(4820);
			ChannelServices.RegisterChannel(channel, false);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteClipboard), "RiClipBoard", WellKnownObjectMode.Singleton);

			// set the callback for when an incoming clipboard event comes in
			RemoteClipboard.SetOnClipReceive(this, new ClipEventHandler(this.AddToClip));
			notifyIcon1.ContextMenuStrip = contextMenuStrip1;
		}

		// Activate an instance of the RemoteClipboard class on the remote computer
		private void InitRemoteObject()
		{
			try
			{
				string location = "tcp://" + computerName.Text + ":4820/RiClipBoard";
				m_remoteClipboard = (RemoteClipboard)Activator.GetObject(typeof(RemoteClipboard), location);
				computerName.Modified = false;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		// Callback for the RemoteClipboard class when an incoming cliboard event comes in.
		public void AddToClip(ArrayList theData)
		{
			if (!allowIncomingCB.Checked)
				throw new Exception("Remote computer has disabled clipboard sharing");

			try
			{
				DataObject dataObj = new DataObject();
				for (int i = 0; i < theData.Count; i++)
				{
					string format = (string)theData[i++];
					dataObj.SetData(format, theData[i]);
				}

				Clipboard.SetDataObject(dataObj, true);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		private void sendButton_Click(object sender, EventArgs e)
        {
			SendClipboardToRemote();
		}
		// Update the tooltip for the system tray icon to show the name of the computer
		// that the clipboard will be sent to
		private void UpdateTooltip()
		{
			string tooltip = "RiClipBoard";
			if (computerName.Text.Length > 0)
				tooltip += " (" + computerName.Text + ')';
			notifyIcon1.Text = tooltip;
		}
		private void SendClipboardToRemote()
		{
			try
			{
				if (computerName.Text.Length == 0)
				{
					MessageBox.Show(this, "Please specify the name of the computer to send the contents of the clipboard to.",
						"RiClipBoard", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}

				if (m_remoteClipboard == null || computerName.Modified)
				{
					UpdateTooltip();
					InitRemoteObject();
				}

				// The dataObject isn't serializable, so inspect each format on the clipboard and if
				// serializable, then add it to a collection to be sent.
				ArrayList dataObjects = new ArrayList();
				IDataObject clipboardData = Clipboard.GetDataObject();
				string[] formats = clipboardData.GetFormats();
				for (int i = 0; i < formats.Length; i++)
				{
					object clipboardItem = clipboardData.GetData(formats[i]);
					if (clipboardItem != null && clipboardItem.GetType().IsSerializable)
					{
						Console.WriteLine("sending {0}", formats[i]);
						// for each item, save the format string followed by the clipboard data
						dataObjects.Add(formats[i]);
						dataObjects.Add(clipboardItem);
					}
					else
						Console.WriteLine("ignoring {0}", formats[i]);
				}

				// Send the clipboard data in the array list if there is any
				if (dataObjects.Count > 0)
				{
					Cursor.Current = Cursors.WaitCursor;
					m_remoteClipboard.SendClipboard(dataObjects);
					Cursor.Current = Cursors.Default;
				}
				else
					MessageBox.Show(this, "Nothing on clipboard, or contents not supported", "RiClipBoard");
			}
			catch (Exception ex)
			{
				string message = String.Format("Unable to send data: {0}", ex.Message);
				MessageBox.Show(this, message, "RiClipBoard");
			}
		}

        private void allowIncomingCB_CheckedChanged(object sender, EventArgs e)
        {
			allowIncomingToolStripMenuItem.Checked = allowIncomingCB.Checked;
		}

        
		// keep context menu on system tray icon and checkbox on form in sync
		private void allowIncomingToolStripMenuItem_Click(object sender, EventArgs e)
        {
			allowIncomingToolStripMenuItem.Checked = !allowIncomingToolStripMenuItem.Checked;
			allowIncomingCB.Checked = allowIncomingToolStripMenuItem.Checked;
		}

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Show();
				this.WindowState = FormWindowState.Normal;
			}
			this.Focus();
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Close();
        }

        private void sendClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
			SendClipboardToRemote();
		}

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
			MessageBox.Show("This program helps to share information from clipboard with devices. " +
				"To share you need to copy text and enter name of computer you want to share it to. " +
				"You also need to run the program on both computers. Hope you will enjoy. "+
				"Created by AriNet", "Hello dear friend!");
		}
    }

    /// The RemoteClipboard class gets activated remotely to send clipboard data from one computer to another.
    /// The delegate is used to notify the form that clipboard data has been received.
    public delegate void ClipEventHandler(ArrayList clipData);
	public class RemoteClipboard : MarshalByRefObject
	{
		private static ClipEventHandler m_OnClipReceive;
		private static Form m_receiverForm;

		// set the object and method that gets a callback when a clipboard is sent.
		public static void SetOnClipReceive(Form receiver, ClipEventHandler theCallback)
		{
			m_receiverForm = receiver;
			m_OnClipReceive = theCallback;
		}

		// this is the method that will be invoked remotely by the other computer.
		public void SendClipboard(ArrayList clipData)
		{
			// Would be nice to be able to just call Clipboard.SetDataObject here, but this is invoked
			// in an MTA thread instead of STA, and doing any ole operation such as setData is not
			// allowed.  Calling invoke will get us back to the form's thread which is an [STAThread].
			//MessageBox.Show("Receiving Clipboard data");
			object[] clipObjects = { clipData };
			m_receiverForm.Invoke(m_OnClipReceive, clipObjects);
		}
	}
}
