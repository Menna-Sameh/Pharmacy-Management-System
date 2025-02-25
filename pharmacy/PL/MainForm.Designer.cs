namespace pharmacy
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            backgroundPanel = new Panel();
            panel1.SuspendLayout();
            backgroundPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 128, 128);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 12, 10, 12);
            panel1.Size = new Size(900, 125);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 12);
            label1.Name = "label1";
            label1.Size = new Size(880, 101);
            label1.TabIndex = 0;
            label1.Text = "PharmaCare Management System";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 128, 128);
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(666, 243);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(200, 75);
            button1.TabIndex = 1;
            button1.Text = "Manage Data";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 128, 128);
            button2.Cursor = Cursors.Hand;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(666, 133);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(200, 75);
            button2.TabIndex = 2;
            button2.Text = "Import Excel";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // backgroundPanel
            // 
            backgroundPanel.BackColor = Color.Transparent;
            backgroundPanel.BackgroundImageLayout = ImageLayout.Stretch;
            backgroundPanel.Controls.Add(panel1);
            backgroundPanel.Controls.Add(button1);
            backgroundPanel.Controls.Add(button2);
            backgroundPanel.Dock = DockStyle.Fill;
            backgroundPanel.Location = new Point(0, 0);
            backgroundPanel.Margin = new Padding(3, 4, 3, 4);
            backgroundPanel.Name = "backgroundPanel";
            backgroundPanel.Size = new Size(900, 625);
            backgroundPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(900, 625);
            Controls.Add(backgroundPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PharmaCare System";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            backgroundPanel.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private Panel panel1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Panel backgroundPanel;
    }
}
