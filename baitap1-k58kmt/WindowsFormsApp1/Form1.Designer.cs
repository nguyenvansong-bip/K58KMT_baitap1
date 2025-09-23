namespace WindowsFormsApp1   // phải trùng với Form1.cs
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.comboBoxAction = new System.Windows.Forms.ComboBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.pictureBoxSignature = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSignature)).BeginInit();
            this.SuspendLayout();

            // textBoxInput
            this.textBoxInput.Location = new System.Drawing.Point(20, 20);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(300, 20);

            // textBoxOutput
            this.textBoxOutput.Location = new System.Drawing.Point(20, 100);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(300, 80);

            // textBoxKey
            this.textBoxKey.Location = new System.Drawing.Point(20, 60);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(300, 20);

            // comboBoxAction
            this.comboBoxAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAction.Location = new System.Drawing.Point(340, 20);
            this.comboBoxAction.Name = "comboBoxAction";
            this.comboBoxAction.Size = new System.Drawing.Size(150, 20);

            // buttonRun
            this.buttonRun.Location = new System.Drawing.Point(340, 60);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(150, 25);
            this.buttonRun.Text = "Run";
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);

            // pictureBoxSignature
            this.pictureBoxSignature.Location = new System.Drawing.Point(20, 200);
            this.pictureBoxSignature.Name = "pictureBoxSignature";
            this.pictureBoxSignature.Size = new System.Drawing.Size(470, 200);
            this.pictureBoxSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // Form1
            this.ClientSize = new System.Drawing.Size(550, 420);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.comboBoxAction);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.pictureBoxSignature);
            this.Name = "Form1";
            this.Text = "MultiTool WinFormsClient";

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSignature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.ComboBox comboBoxAction;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.PictureBox pictureBoxSignature;
    }
}
