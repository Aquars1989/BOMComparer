
namespace BOMComparer
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filePanel2 = new BOMComparer.Controls.FilePanel();
            this.filePanel1 = new BOMComparer.Controls.FilePanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inkExportLog = new System.Windows.Forms.LinkLabel();
            this.inkMarkExcel = new System.Windows.Forms.LinkLabel();
            this.lnkClear1 = new System.Windows.Forms.LinkLabel();
            this.lnkClear2 = new System.Windows.Forms.LinkLabel();
            this.grid_id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_item_number1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_action1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_level1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_quantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_reference_designator1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_item_number2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_action2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_level2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_quantity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grid_reference_designator2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "File A";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(940, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "File B";
            // 
            // filePanel2
            // 
            this.filePanel2.AllowDrop = true;
            this.filePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filePanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filePanel2.Location = new System.Drawing.Point(696, 51);
            this.filePanel2.Name = "filePanel2";
            this.filePanel2.Size = new System.Drawing.Size(314, 50);
            this.filePanel2.TabIndex = 5;
            this.filePanel2.Text = "filePanel2";
            this.filePanel2.FileSelected += new System.EventHandler(this.filePanel2_FileSelected);
            // 
            // filePanel1
            // 
            this.filePanel1.AllowDrop = true;
            this.filePanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filePanel1.Location = new System.Drawing.Point(16, 51);
            this.filePanel1.Name = "filePanel1";
            this.filePanel1.Size = new System.Drawing.Size(314, 50);
            this.filePanel1.TabIndex = 4;
            this.filePanel1.Text = "filePanel1";
            this.filePanel1.FileSelected += new System.EventHandler(this.filePanel1_FileSelected);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grid_id1,
            this.grid_item_number1,
            this.grid_action1,
            this.grid_level1,
            this.grid_quantity1,
            this.grid_reference_designator1,
            this.grid_id2,
            this.grid_item_number2,
            this.grid_action2,
            this.grid_level2,
            this.grid_quantity2,
            this.grid_reference_designator2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 446);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Consolas", 13F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 39);
            this.label3.TabIndex = 7;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.inkMarkExcel);
            this.panel1.Controls.Add(this.inkExportLog);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(362, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 69);
            this.panel1.TabIndex = 8;
            this.panel1.Visible = false;
            // 
            // inkExportLog
            // 
            this.inkExportLog.AutoSize = true;
            this.inkExportLog.Font = new System.Drawing.Font("Consolas", 12F);
            this.inkExportLog.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.inkExportLog.Location = new System.Drawing.Point(13, 39);
            this.inkExportLog.Name = "inkExportLog";
            this.inkExportLog.Size = new System.Drawing.Size(99, 19);
            this.inkExportLog.TabIndex = 8;
            this.inkExportLog.TabStop = true;
            this.inkExportLog.Text = "Export Log";
            this.inkExportLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.inkExportLog_LinkClicked);
            // 
            // inkMarkExcel
            // 
            this.inkMarkExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.inkMarkExcel.AutoSize = true;
            this.inkMarkExcel.Font = new System.Drawing.Font("Consolas", 12F);
            this.inkMarkExcel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.inkMarkExcel.Location = new System.Drawing.Point(194, 39);
            this.inkMarkExcel.Name = "inkMarkExcel";
            this.inkMarkExcel.Size = new System.Drawing.Size(99, 19);
            this.inkMarkExcel.TabIndex = 9;
            this.inkMarkExcel.TabStop = true;
            this.inkMarkExcel.Text = "Mark Excel";
            this.inkMarkExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.inkMarkExcel_LinkClicked);
            // 
            // lnkClear1
            // 
            this.lnkClear1.AutoSize = true;
            this.lnkClear1.Font = new System.Drawing.Font("Consolas", 12F);
            this.lnkClear1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkClear1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lnkClear1.Location = new System.Drawing.Point(266, 25);
            this.lnkClear1.Name = "lnkClear1";
            this.lnkClear1.Size = new System.Drawing.Size(54, 19);
            this.lnkClear1.TabIndex = 9;
            this.lnkClear1.TabStop = true;
            this.lnkClear1.Text = "Clear";
            this.lnkClear1.Visible = false;
            this.lnkClear1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear1_LinkClicked);
            // 
            // lnkClear2
            // 
            this.lnkClear2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkClear2.AutoSize = true;
            this.lnkClear2.Font = new System.Drawing.Font("Consolas", 12F);
            this.lnkClear2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkClear2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lnkClear2.Location = new System.Drawing.Point(702, 25);
            this.lnkClear2.Name = "lnkClear2";
            this.lnkClear2.Size = new System.Drawing.Size(54, 19);
            this.lnkClear2.TabIndex = 10;
            this.lnkClear2.TabStop = true;
            this.lnkClear2.Text = "Clear";
            this.lnkClear2.Visible = false;
            this.lnkClear2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear2_LinkClicked);
            // 
            // grid_id1
            // 
            this.grid_id1.DataPropertyName = "id1";
            this.grid_id1.HeaderText = "Id";
            this.grid_id1.Name = "grid_id1";
            this.grid_id1.ReadOnly = true;
            this.grid_id1.Visible = false;
            // 
            // grid_item_number1
            // 
            this.grid_item_number1.DataPropertyName = "item_number1";
            this.grid_item_number1.FillWeight = 140F;
            this.grid_item_number1.HeaderText = "Item Number";
            this.grid_item_number1.Name = "grid_item_number1";
            this.grid_item_number1.ReadOnly = true;
            this.grid_item_number1.Width = 140;
            // 
            // grid_action1
            // 
            this.grid_action1.DataPropertyName = "action1";
            this.grid_action1.FillWeight = 130F;
            this.grid_action1.HeaderText = "Action";
            this.grid_action1.Name = "grid_action1";
            this.grid_action1.ReadOnly = true;
            this.grid_action1.Width = 130;
            // 
            // grid_level1
            // 
            this.grid_level1.DataPropertyName = "level1";
            this.grid_level1.FillWeight = 50F;
            this.grid_level1.HeaderText = "Lvl";
            this.grid_level1.Name = "grid_level1";
            this.grid_level1.ReadOnly = true;
            this.grid_level1.Width = 50;
            // 
            // grid_quantity1
            // 
            this.grid_quantity1.DataPropertyName = "quantity1";
            this.grid_quantity1.FillWeight = 80F;
            this.grid_quantity1.HeaderText = "Quantity";
            this.grid_quantity1.Name = "grid_quantity1";
            this.grid_quantity1.ReadOnly = true;
            this.grid_quantity1.Width = 80;
            // 
            // grid_reference_designator1
            // 
            this.grid_reference_designator1.DataPropertyName = "reference_designator1";
            this.grid_reference_designator1.DividerWidth = 2;
            this.grid_reference_designator1.HeaderText = "Reference";
            this.grid_reference_designator1.Name = "grid_reference_designator1";
            this.grid_reference_designator1.ReadOnly = true;
            // 
            // grid_id2
            // 
            this.grid_id2.DataPropertyName = "id2";
            this.grid_id2.HeaderText = "Id";
            this.grid_id2.Name = "grid_id2";
            this.grid_id2.ReadOnly = true;
            this.grid_id2.Visible = false;
            // 
            // grid_item_number2
            // 
            this.grid_item_number2.DataPropertyName = "item_number2";
            this.grid_item_number2.FillWeight = 140F;
            this.grid_item_number2.HeaderText = "Item Number";
            this.grid_item_number2.Name = "grid_item_number2";
            this.grid_item_number2.ReadOnly = true;
            this.grid_item_number2.Width = 140;
            // 
            // grid_action2
            // 
            this.grid_action2.DataPropertyName = "action2";
            this.grid_action2.FillWeight = 130F;
            this.grid_action2.HeaderText = "Action";
            this.grid_action2.Name = "grid_action2";
            this.grid_action2.ReadOnly = true;
            this.grid_action2.Width = 130;
            // 
            // grid_level2
            // 
            this.grid_level2.DataPropertyName = "level2";
            this.grid_level2.FillWeight = 50F;
            this.grid_level2.HeaderText = "Lvl";
            this.grid_level2.Name = "grid_level2";
            this.grid_level2.ReadOnly = true;
            this.grid_level2.Width = 50;
            // 
            // grid_quantity2
            // 
            this.grid_quantity2.DataPropertyName = "quantity2";
            this.grid_quantity2.FillWeight = 80F;
            this.grid_quantity2.HeaderText = "Quantity";
            this.grid_quantity2.Name = "grid_quantity2";
            this.grid_quantity2.ReadOnly = true;
            this.grid_quantity2.Width = 80;
            // 
            // grid_reference_designator2
            // 
            this.grid_reference_designator2.DataPropertyName = "reference_designator2";
            this.grid_reference_designator2.HeaderText = "Reference";
            this.grid_reference_designator2.Name = "grid_reference_designator2";
            this.grid_reference_designator2.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1022, 569);
            this.Controls.Add(this.lnkClear2);
            this.Controls.Add(this.lnkClear1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.filePanel2);
            this.Controls.Add(this.filePanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "BOMComparer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.FilePanel filePanel1;
        private Controls.FilePanel filePanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel inkMarkExcel;
        private System.Windows.Forms.LinkLabel inkExportLog;
        private System.Windows.Forms.LinkLabel lnkClear1;
        private System.Windows.Forms.LinkLabel lnkClear2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_item_number1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_action1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_level1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_quantity1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_reference_designator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_item_number2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_action2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_level2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_quantity2;
        private System.Windows.Forms.DataGridViewTextBoxColumn grid_reference_designator2;
    }
}

