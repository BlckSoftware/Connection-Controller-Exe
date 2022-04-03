
namespace connection_controller
{
    partial class connection_controller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(connection_controller));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.start_button = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tarih_label = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Cihazadı_TextBox = new System.Windows.Forms.TextBox();
            this.CihazIP_TextBox = new System.Windows.Forms.TextBox();
            this.add_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.info_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.log_textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.start_button, "start_button");
            this.start_button.Name = "start_button";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.Exit_Button, "Exit_Button");
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // tarih_label
            // 
            resources.ApplyResources(this.tarih_label, "tarih_label");
            this.tarih_label.Name = "tarih_label";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // Cihazadı_TextBox
            // 
            resources.ApplyResources(this.Cihazadı_TextBox, "Cihazadı_TextBox");
            this.Cihazadı_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.Cihazadı_TextBox.Name = "Cihazadı_TextBox";
            this.Cihazadı_TextBox.Enter += new System.EventHandler(this.Cihazadı_TextBox_Enter);
            this.Cihazadı_TextBox.Leave += new System.EventHandler(this.Cihazadı_TextBox_Leave);
            // 
            // CihazIP_TextBox
            // 
            resources.ApplyResources(this.CihazIP_TextBox, "CihazIP_TextBox");
            this.CihazIP_TextBox.ForeColor = System.Drawing.Color.Silver;
            this.CihazIP_TextBox.Name = "CihazIP_TextBox";
            this.CihazIP_TextBox.Tag = "";
            this.CihazIP_TextBox.Enter += new System.EventHandler(this.CihazIP_TextBox_Enter);
            this.CihazIP_TextBox.Leave += new System.EventHandler(this.CihazIP_TextBox_Leave);
            // 
            // add_button
            // 
            resources.ApplyResources(this.add_button, "add_button");
            this.add_button.Name = "add_button";
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // update_button
            // 
            this.update_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.update_button, "update_button");
            this.update_button.Name = "update_button";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // save_button
            // 
            this.save_button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.save_button, "save_button");
            this.save_button.Name = "save_button";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // info_button
            // 
            resources.ApplyResources(this.info_button, "info_button");
            this.info_button.Name = "info_button";
            this.info_button.UseVisualStyleBackColor = true;
            this.info_button.Click += new System.EventHandler(this.info_button_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // log_textbox
            // 
            this.log_textbox.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.log_textbox, "log_textbox");
            this.log_textbox.Name = "log_textbox";
            // 
            // connection_controller
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.log_textbox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.info_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.CihazIP_TextBox);
            this.Controls.Add(this.Cihazadı_TextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tarih_label);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.start_button);
            this.MaximizeBox = false;
            this.Name = "connection_controller";
            this.Load += new System.EventHandler(this.connection_controller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button Exit_Button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label tarih_label;
        private System.Windows.Forms.TextBox Cihazadı_TextBox;
        private System.Windows.Forms.TextBox CihazIP_TextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button info_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox log_textbox;
    }
}

