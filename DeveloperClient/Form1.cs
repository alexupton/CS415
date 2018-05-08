using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveloperClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkFields()
        {
            bool fieldsValid = true;
            string errorMessage = "The following fields were not filled or invalid:\n";
            if (userBox.Text == "")
            {
                fieldsValid = false;
                errorMessage += "UserName\n";
            }
            if (passBox.Text == "")
            {
                fieldsValid = false;
                errorMessage += "Password\n";
            }
            if (ideSelectorBox.SelectedIndex < 0 || ideSelectorBox.SelectedIndex >= ideSelectorBox.Items.Count)
            {
                fieldsValid = false;
                errorMessage += "IDE\n";
            }

            if (!fieldsValid)
            {
                MessageBox.Show(errorMessage, "Error");
            }
            return fieldsValid;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                Connection serverConn = new Connection(this);
                if (serverConn.Login(userBox.Text, passBox.Text, ideSelectorBox.SelectedItem.ToString().ToLower()))
                {
                    ExternalLauncher launcher = new ExternalLauncher();
                    launcher.Launch();
                }
            }
        }

        private void passBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
