using System;
using System.IO;
using System.Windows.Forms;

namespace CryptTools
{
    public partial class Form1 : Form
    {
        // Enum for determining file extension on save
        public enum LastOperation
        {
            MD5,
            SHA256,
            Erase,
            Other
        }

        public static LastOperation operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnMD5hash_Click(object sender, EventArgs e)
        {
            if (txbFileName.Text == "")
            { MessageBox.Show("You need to select a file"); }
            else if (!File.Exists(txbFileName.Text))
            { MessageBox.Show("File does not exist anymore"); }
            else {
                operation = LastOperation.MD5;
                txbOutput.Text = Hashing.GetMD5HashFromFile(txbFileName.Text);
            }
        }

        private void btnSHA256hash_Click(object sender, EventArgs e)
        {
            if (txbFileName.Text == "")
            { MessageBox.Show("You need to select a file"); }
            else if (!File.Exists(txbFileName.Text))
            { MessageBox.Show("File does not exist anymore"); }
            else
            {
                operation = LastOperation.SHA256;
                txbOutput.Text = Hashing.GetSHA256HashFromFile(txbFileName.Text);
            }
        }

        private void btnEraseContents_Click(object sender, EventArgs e)
        {
            if (txbFileName.Text == "")
            { MessageBox.Show("You need to select a file"); }
            else if (!File.Exists(txbFileName.Text))
            { MessageBox.Show("File does not exist anymore"); }
            else
            {
                operation = LastOperation.Erase;
                // Read file to be erased and create array of same size
                byte[] content = File.ReadAllBytes(txbFileName.Text);
                byte[] output = new byte[content.Length];
                // Every byte in the new array gets set to 0
                for (int i = 0; i < content.Length; i++)
                    output[i] = 0;
                // Overwrite the file contents
                File.WriteAllBytes(txbFileName.Text, output);
                txbOutput.Text = "Erased Contents of " + txbFileName.Text;
            }
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Multiselect = false;
            ofd.Title = "Select File";
            if (ofd.ShowDialog() == DialogResult.OK)
                txbFileName.Text = ofd.FileName;
        }

        private void btnSaveOut_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            // Determine what file extension should be used
            if (operation == LastOperation.MD5)
                sfd.Filter = "Hash Files|*.md5";
            else if (operation == LastOperation.SHA256)
                sfd.Filter = "Hash Files|*.sha256";
            else
                sfd.Filter = "Text Files|*.txt";

            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, txbOutput.Text);
        }

        private void btnCompareMD5_Click(object sender, EventArgs e)
        {
            if (txbFileName.Text == "")
            { MessageBox.Show("You need to select a file"); }
            else if (!File.Exists(txbFileName.Text))
            { MessageBox.Show("File does not exist anymore"); }
            else if (txbHash.Text == "")
            { MessageBox.Show("You need to input a Hash"); }
            else
            {
                operation = LastOperation.Other;
                if (txbHash.Text == Hashing.GetMD5HashFromFile(txbFileName.Text))
                {
                    txbOutput.Text = "File Hash: " + Hashing.GetMD5HashFromFile(txbFileName.Text)
                                   + "\r\nYour Hash: " + txbHash.Text
                                   + "\r\n\r\nValidated: " + "Success";
                }
                else
                {
                    txbOutput.Text = "File Hash: " + Hashing.GetMD5HashFromFile(txbFileName.Text)
                                   + "\r\nYour Hash: " + txbHash.Text
                                   + "\r\n\r\nValidated: " + "Failure";
                }
            }
        }

        private void btnCompareSHA256_Click(object sender, EventArgs e)
        {
            operation = LastOperation.Other;
            if (txbFileName.Text == "")
            { MessageBox.Show("You need to select a file"); }
            else if (!File.Exists(txbFileName.Text))
            { MessageBox.Show("File does not exist anymore"); }
            else if (txbHash.Text == "")
            { MessageBox.Show("You need to input a Hash"); }
            else
            {
                if (txbHash.Text == Hashing.GetSHA256HashFromFile(txbFileName.Text))
                {
                    txbOutput.Text = "File Hash: " + Hashing.GetSHA256HashFromFile(txbFileName.Text)
                                   + "\r\nYour Hash: " + txbHash.Text
                                   + "\r\n\r\nValidated: " + "Success";
                }
                else
                {
                    txbOutput.Text = "File Hash: " + Hashing.GetSHA256HashFromFile(txbFileName.Text)
                                   + "\r\nYour Hash: " + txbHash.Text
                                   + "\r\n\r\nValidated: " + "Failure";
                }
            }
        }
    }
}
