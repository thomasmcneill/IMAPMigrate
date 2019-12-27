using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.IO;
using System.Threading;

namespace IMAPMigrate
{
    public partial class Form1 : Form
    {
        TreeNode root = new TreeNode("Root");
        String SelectedPath = "";
        String Src_Server = "";
        String Src_User = "";
        String Src_Pass = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void GetFolders(IMailFolder personal, TreeNode tn)
        {
            foreach (var folder in personal.GetSubfolders(false))
            {
                try
                {
                    folder.Open(FolderAccess.ReadWrite);
                    String text = String.Format("{0}({1})", folder.Name, folder.Count.ToString());
                    TreeNode t = new TreeNode(text);
                    MailFolderHelper mfh = new MailFolderHelper();
                    mfh.FullPath = folder.FullName;
                    mfh.Path = folder.Name;

                    var uids = folder.Search(SearchQuery.All);

                    foreach (var uid in uids)
                    {
                        mfh.MailGUID.Add(uid);

                    }



                    t.Tag = mfh;
                    t.Checked = true;

                    TreeNodeAppend(tn, t);
                    folder.Close();
                    GetFolders(folder, t);

                }
                catch  {
                    LogAppend("Failed to open Folder " + folder.FullName);
                }






            }

        }
        private void button_GetSourceFolders_Click(object sender, EventArgs e)
        {
            progressBarSetSpeed(30);
            treeView_Source.Nodes.Clear();
            root.Checked = true;
            treeView_Source.Nodes.Add(root);
            root.ExpandAll();

            Src_Pass = textBox_SourcePassword.Text;
            Src_Server = textBox_SourceServer.Text;
            Src_User = textBox_SourceUser.Text;

            Thread thr = new Thread(new ThreadStart(ThreadGetFolders));
            thr.Start();



        }
        void ThreadGetFolders()
        { 
            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, ex) => true;

                client.Connect(Src_Server, 993, true);
                try
                {
                    client.Authenticate(Src_User, Src_Pass);

                }
                catch (MailKit.Security.AuthenticationException mex)
                {
                    MessageBox.Show("Source Authentication error: " + mex.ToString());
                    return;
                }


                // The Inbox folder is always available on all IMAP servers...
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                TreeNode tn_Inbox = new TreeNode(String.Format("{0}({1})", inbox.Name, inbox.Count.ToString()));

                MailFolderHelper mfh = new MailFolderHelper();
                mfh.Path = inbox.Name;
                mfh.FullPath = inbox.FullName;

                tn_Inbox.Tag = mfh;
                tn_Inbox.Checked = true;
                TreeNodeAppend(root, tn_Inbox);

                GetFolders(inbox, tn_Inbox);




                var personal = client.GetFolder(client.PersonalNamespaces[0]);

                GetFolders(personal, root);


                client.Disconnect(true);
            }
            progressBarSetSpeed(0);

            MessageBox.Show("Get Folders complete");

        }

        void ProcessTreeNode(ImapClient Src_client, ImapClient Dst_client,TreeNode treenode, String LocalPath)
        {
            foreach (TreeNode tn in treenode.Nodes)
            {
                if (tn.Checked)
                {

                    MailFolderHelper mfh = (MailFolderHelper)tn.Tag; 

                    String IMAP_Path = mfh.FullPath;
                    String local = LocalPath + "\\" + IMAP_Path.Replace('/','\\');

                    Directory.CreateDirectory(local);


                    var IMAP_Folder = Src_client.GetFolder(IMAP_Path);
                    IMAP_Folder.Open(FolderAccess.ReadOnly);

                    foreach(MailKit.UniqueId uid in mfh.MailGUID.Reverse<MailKit.UniqueId>())
                    { 
                        var message = IMAP_Folder.GetMessage(uid);

                        //MessageBox.Show(message.Subject);
                        //Folder.Append()
                        LogAppend( IMAP_Path + " " + message.MessageId + " " + message.Subject );
                        if (Dst_client == null)
                        {
                            String Filename = string.Format("{0}\\{1}.eml", local, uid);
                            message.WriteTo(Filename);
                            LogAppend("Saved to: " + Filename );
                        }

                        mfh.MailGUID.Remove(uid);
                        TreeNodeChangeText(tn, String.Format("{0}({1})", mfh.Path, mfh.MailGUID.Count));
                    }


                }
                if (tn.Nodes.Count > 0)
                    ProcessTreeNode(Src_client, Dst_client, tn, LocalPath);
            }

        }
        
        private void button_Go_Click(object sender, EventArgs e)
        {
            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, ex) => true;

                client.Connect(textBox_SourceServer.Text, 993, true);
                try
                {
                    client.Authenticate(textBox_SourceUser.Text, textBox_SourcePassword.Text);

                }
                catch (MailKit.Security.AuthenticationException mex)
                {
                    MessageBox.Show("Source Authentication error: " + mex.ToString());
                    return;
                }

                ProcessTreeNode(client,null, root,"");
            }
        }

        private void button_Dump_Click(object sender, EventArgs e)
        {
            progressBarSetSpeed(30);

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Src_Pass = textBox_SourcePassword.Text;
                    Src_Server = textBox_SourceServer.Text;
                    Src_User = textBox_SourceUser.Text;

                    SelectedPath = fbd.SelectedPath;
                    Thread thr = new Thread(new ThreadStart(DoDumpThread));



                }
            }

        }
        private void DoDumpThread()
        {
            using (var client = new ImapClient())
            {
                // For demo-purposes, accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, ex) => true;

                client.Connect(Src_Server, 993, true);
                try
                {
                    client.Authenticate(Src_User, Src_Pass);

                }
                catch (MailKit.Security.AuthenticationException mex)
                {
                    MessageBox.Show("Source Authentication error: " + mex.ToString());
                    return;
                }

                ProcessTreeNode(client, null, root, SelectedPath);
            }
            progressBarSetSpeed(0);

            MessageBox.Show("Dump complete");
        }
        void LogAppend(String text)
        {
            text += "\r\n";
            if (textBox_Log.InvokeRequired)
            {
                textBox_Log.Invoke((MethodInvoker)delegate { textBox_Log.Text += text; });

            }
            else
            {
                textBox_Log.Text += text;
            }
        }
        void TreeNodeChangeText(TreeNode tn, String text)
        {
            if (treeView_Source.InvokeRequired)
            {
                treeView_Source.Invoke((MethodInvoker)delegate { tn.Text += text; });

            }
            else
            {
                tn.Text += text;
            }
        }
        void TreeNodeAppend(TreeNode Parent, TreeNode Child)
        {
            if (treeView_Source.InvokeRequired)
            {
                treeView_Source.Invoke((MethodInvoker)delegate { Parent.Nodes.Add(Child); Parent.ExpandAll(); });

            }
            else
            {
                Parent.Nodes.Add(Child);
                Parent.ExpandAll();
            }
        }
        void progressBarSetSpeed(int t)
        {
            if (progressBar_Status.InvokeRequired)
            {
                progressBar_Status.Invoke((MethodInvoker)delegate { progressBar_Status.MarqueeAnimationSpeed = t; });

            }
            else
            {
                progressBar_Status.MarqueeAnimationSpeed = t;
            }
        }

        private void treeView_Source_AfterCheck(object sender, TreeViewEventArgs e)
        {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    tn.Checked = e.Node.Checked;
                }
        }
    }
}
