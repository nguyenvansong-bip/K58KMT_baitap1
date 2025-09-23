using System;
using System.Drawing;
using System.Windows.Forms;
using MultiToolLib;
using System.Text;

namespace WindowsFormsApp1   // phải trùng với Designer
{
    public partial class Form1 : Form
    {
        private MultiTool tool = new MultiTool();

        public Form1()
        {
            InitializeComponent();  // do Designer sinh ra
            this.Text = "WinFormsClient - MultiTool by Văn Song Nguyễn";

            comboBoxAction.Items.AddRange(new string[] { "Solve", "Signature", "Cipher" });
            comboBoxAction.SelectedIndex = 0;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            string action = comboBoxAction.SelectedItem.ToString();
            string input = textBoxInput.Text;

            if (action == "Solve")
            {
                string json = tool.SolveExpression(input);
                textBoxOutput.Text = json;
            }
            else if (action == "Signature")
            {
                string sig = tool.GenerateSignature(input);
                textBoxOutput.Text = sig;
                DrawSignatureBitmap(sig);
            }
            else if (action == "Cipher")
            {
                string key = textBoxKey.Text;
                string res = tool.SongCipher(input, key);
                textBoxOutput.Text = res;
            }
        }

        private void DrawSignatureBitmap(string signature)
        {
            var lines = signature.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int width = 600;
            int height = Math.Max(200, lines.Length * 22);
            var bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                var f = new Font("Consolas", 12);
                int y = 5;
                foreach (var line in lines)
                {
                    g.DrawString(line, f, Brushes.Black, new PointF(5, y));
                    y += 20;
                }
                // chữ ký cá nhân
                g.DrawString("© Văn Song Nguyễn", new Font("Segoe UI", 8), Brushes.Gray, new PointF(width - 160, height - 20));
            }

            pictureBoxSignature.Image = bmp;
        }
    }
}
