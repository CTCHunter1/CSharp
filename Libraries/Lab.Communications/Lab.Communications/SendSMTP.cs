using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;



namespace Lab.Communications
{
    public partial class SendSMTP : Form
    {
        bool bSubForm = false;

        public SendSMTP()
        {
            InitializeComponent();
        }

        private void sendEmail_Click(object sender, EventArgs e)
        {
            SendMessage(subjectTextBox.Text, messageTextBox.Text);
        }

        public void SendMessage(String subject, String message)
        {
            SmtpClient smtpClient = new SmtpClient(serverTextBox.Text, 26);
            NetworkCredential nc = new NetworkCredential(userNameTextBox.Text, passwordTextBox.Text);

            smtpClient.Credentials = nc;

            smtpClient.Send(userNameTextBox.Text, recipentTextBox.Text,
                subject, message);
            
        }

        // set to true if this a subform of a larger program
        public bool IsSubForm
        {
            get
            {
                return (bSubForm);
            }
            set
            {
                bSubForm = value;
            }
        }

        private void SendSMTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bSubForm == true)
            {
                this.Hide();
                e.Cancel = true; // cancel dispose
            } 
        }

    }
}
