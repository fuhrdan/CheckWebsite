namespace CheckWebsite;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
        private void InitializeComponent()
        {
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.checkLinkButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // URL TextBox
            this.urlTextBox.Location = new System.Drawing.Point(10, 10);
            this.urlTextBox.Width = 400;
            this.urlTextBox.PlaceholderText = "Enter URL here...";

            // Output TextBox
            this.outputTextBox.Location = new System.Drawing.Point(10, 50);
            this.outputTextBox.Width = 400;
            this.outputTextBox.PlaceholderText = "Select output file...";

            // Check Link Button
            this.checkLinkButton.Location = new System.Drawing.Point(420, 10);
            this.checkLinkButton.Text = "Check Link";

            // Select File Button
            this.selectFileButton.Location = new System.Drawing.Point(420, 50);
            this.selectFileButton.Text = "Select Output File";

            // Form Settings
            this.ClientSize = new System.Drawing.Size(600, 100);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.checkLinkButton);
            this.Controls.Add(this.selectFileButton);
            this.Text = "Check Website";

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button checkLinkButton;
        private System.Windows.Forms.Button selectFileButton;
        
    #endregion
}