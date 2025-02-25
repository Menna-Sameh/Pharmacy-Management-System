namespace pharmacy
{
    partial class AddOrder
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
            label5 = new Label();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label6 = new Label();
            textBox4 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            label1 = new Label();

            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();

            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(102, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(454, 488);
            panel2.TabIndex = 9;

            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(38, 18);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 11;
            label6.Text = "Order Date :";

            // 
            // textBox4
            // 
            textBox4.Location = new Point(38, 53);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(329, 23);
            textBox4.TabIndex = 10;

            // 
            // textBox1
            // 
            textBox1.Location = new Point(51, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(316, 23);
            textBox1.TabIndex = 5;

            // 
            // button1
            // 
            button1.BackColor = Color.Teal;
            button1.ForeColor = Color.White;
            button1.Location = new Point(51, 445);
            button1.Name = "button1";
            button1.Size = new Size(89, 40);
            button1.TabIndex = 8;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;

            // 
            // textBox3
            // 
            textBox3.Location = new Point(51, 311);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(316, 23);
            textBox3.TabIndex = 7;

            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 269);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 2;
            label4.Text = "Total Amount :";

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 186);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 1;
            label3.Text = "Customer Id :";

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 94);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 0;
            label2.Text = "Status :";

            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(675, 102);
            panel1.TabIndex = 10;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Teal;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(130, 32);
            label1.TabIndex = 0;
            label1.Text = "New Order";

            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(51, 399);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(316, 23);
            comboBox1.TabIndex = 12;

            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(51, 227);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(316, 23);
            comboBox2.TabIndex = 13;

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 355);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 14;
            label5.Text = "Employee Id :";

            // 
            // AddOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 710);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AddOrder";
            Text = "AddOrder";
            Load += AddOrder_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label6;
        private TextBox textBox4;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private Label label5;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
    }
}
