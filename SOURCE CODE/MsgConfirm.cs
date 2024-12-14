using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Puspula
{
    public partial class MsgConfirm : Form
    {
        private bool isPTBR = false;
        public MsgConfirm()
        {
            InitializeComponent();
        }

        private void buttonTraductor_Click(object sender, EventArgs e)
        {
            if (isPTBR)
            {
                buttonExitApp.Text = "NO. EXIT!!";
                buttonYesOps.Text = "YES";
                textBoxWarn.Text = "Warning: The software you are about to run is malware that may cause data\r\nloss on your system and potentially permanently damage your computer.\r\n\r\nDo you really want to continue with this execution?";
                this.Text = "Púspula - Created by CYBERWARE";
            }
            else
            {
                buttonExitApp.Text = "NÃO. SAIR!!";
                buttonYesOps.Text = "SIM";
                textBoxWarn.Text = "Aviso: O software que você está prestes a executar é um malware que pode causar perda\r\nde dados em seu sistema e, como consequência, danificar permanentemente seu computador.\r\n\r\nDeseja realmente continuar com essa execução?";
                this.Text = "Púspula - Criado por CYBERWARE";
            }

            isPTBR = !isPTBR;
        }

        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            this.Close();
            Environment.Exit(0);
        }

        private void buttonYesOps_Click(object sender, EventArgs e)
        {
            this.Close();
        }



/*=========================================================================================*/
                       /* Effects */
        private void buttonYesOps_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Font = new Font(button.Font.FontFamily, button.Font.Size + 6, FontStyle.Bold);
        }

        private void buttonYesOps_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Font = new Font(button.Font.FontFamily, button.Font.Size - 6, FontStyle.Bold);
        }

        private void buttonExitApp_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Font = new Font(button.Font.FontFamily, button.Font.Size + 6, FontStyle.Bold);
        }

        private void buttonExitApp_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Font = new Font(button.Font.FontFamily, button.Font.Size - 6, FontStyle.Bold);
        }

        private void textBoxWarn_MouseEnter(object sender, EventArgs e)
        {
            Label text = sender as Label;
            text.Font = new Font(text.Font.FontFamily, text.Font.Size + 2, FontStyle.Bold);
        }

        private void textBoxWarn_MouseLeave(object sender, EventArgs e)
        {
            Label text = sender as Label;
            text.Font = new Font(text.Font.FontFamily, text.Font.Size - 2, FontStyle.Bold);
        }
/*=========================================================================================*/

    }
}
