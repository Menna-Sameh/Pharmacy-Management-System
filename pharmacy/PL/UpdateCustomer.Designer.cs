namespace pharmacy
{
    partial class UpdateCustomer
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
            panel2 = new Panel();
            label6 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();

            // panel2
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(97, 121);
            panel2.Name = "panel2";
            panel2.Size = new Size(370, 412);
            panel2.TabIndex = 7;

            // label6
            label6.AutoSize = true;
            label6.Location = new Point(40, 224);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 12;
            label6.Text = "Phone :";

            // label7
            label7.AutoSize = true;
            label7.Location = new Point(40, 134);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 11;
            label7.Text = "Address :";

            // textBox1
            textBox1.Location = new Point(40, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(264, 23);
            textBox1.TabIndex = 5;

            // button1
            button1.BackColor = Color.Teal;
            button1.ForeColor = Color.White;
            button1.Location = new Point(118, 317);
            button1.Name = "button1";
            button1.Size = new Size(138, 74);
            button1.TabIndex = 8;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;

            // textBox3
            textBox3.Location = new Point(48, 256);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(264, 23);
            textBox3.TabIndex = 7;

            // textBox2
            textBox2.Location = new Point(48, 167);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(264, 23);
            textBox2.TabIndex = 6;

            // label2
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 43);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 0;
            label2.Text = "Name :";

            // panel1
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(564, 102);
            panel1.TabIndex = 8;

            // label1
            label1.AutoSize = true;
            label1.BackColor = Color.Teal;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(201, 32);
            label1.TabIndex = 0;
            label1.Text = "Update Customer";

            // DelUpdateCustomer
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 563);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DelUpdateCustomer";
            Text = "DelUpdateCustomer";
            Load += UpdateCustomer_Load_1;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private Label label7;
        private Label label6;
    }
}
