using System;
using System.Windows.Forms;

namespace AstroDecodeApp
{
    public class MainForm : Form
    {
        private TextBox inputBox;
        private Button askButton;
        private Label responseLabel;

        public MainForm()
        {
            this.Text = "Astro Decode";
            this.Width = 800;
            this.Height = 600;

            inputBox = new TextBox();
            inputBox.Width = 600;
            inputBox.Top = 20;
            inputBox.Left = 20;

            askButton = new Button();
            askButton.Text = "Ask";
            askButton.Top = 20;
            askButton.Left = 640;
            askButton.Click += AskButton_Click;

            responseLabel = new Label();
            responseLabel.Top = 70;
            responseLabel.Left = 20;
            responseLabel.Width = 740;
            responseLabel.Height = 400;
            responseLabel.Text = "Ask me anything about astrology...";

            this.Controls.Add(inputBox);
            this.Controls.Add(askButton);
            this.Controls.Add(responseLabel);
        }

        private void AskButton_Click(object sender, EventArgs e)
        {
            string question = inputBox.Text;
            string answer = AstrologyEngine.GetResponse(question);
            responseLabel.Text = "You asked: " + question + "\n\n" + answer;
        }
    }
}
