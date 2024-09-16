namespace CSVPreview
{
    partial class CSVPreview
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSVPreview));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSkipFirstRows = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPreviewRows = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbColumnDelimiter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFirstRowHasHeader = new System.Windows.Forms.CheckBox();
            this.txtTextQualifier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.analizeColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkipFirstRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSkipFirstRows);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbPreviewRows);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.cmbColumnDelimiter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkFirstRowHasHeader);
            this.panel1.Controls.Add(this.txtTextQualifier);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2411, 49);
            this.panel1.TabIndex = 0;
            // 
            // txtSkipFirstRows
            // 
            this.txtSkipFirstRows.Location = new System.Drawing.Point(1255, 8);
            this.txtSkipFirstRows.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtSkipFirstRows.Name = "txtSkipFirstRows";
            this.txtSkipFirstRows.Size = new System.Drawing.Size(120, 26);
            this.txtSkipFirstRows.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1126, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Skip First Rows:";
            // 
            // cmbPreviewRows
            // 
            this.cmbPreviewRows.FormattingEnabled = true;
            this.cmbPreviewRows.Items.AddRange(new object[] {
            "100",
            "500",
            "1000"});
            this.cmbPreviewRows.Location = new System.Drawing.Point(124, 8);
            this.cmbPreviewRows.Name = "cmbPreviewRows";
            this.cmbPreviewRows.Size = new System.Drawing.Size(171, 28);
            this.cmbPreviewRows.TabIndex = 9;
            this.cmbPreviewRows.Text = "100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Preview Rows:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1399, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 31);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbColumnDelimiter
            // 
            this.cmbColumnDelimiter.FormattingEnabled = true;
            this.cmbColumnDelimiter.Items.AddRange(new object[] {
            "Semicolon {;}",
            "Colon {:}",
            "Comma {,}",
            "Tab {t}",
            "Vertical Bar {|}"});
            this.cmbColumnDelimiter.Location = new System.Drawing.Point(932, 7);
            this.cmbColumnDelimiter.Name = "cmbColumnDelimiter";
            this.cmbColumnDelimiter.Size = new System.Drawing.Size(171, 28);
            this.cmbColumnDelimiter.TabIndex = 6;
            this.cmbColumnDelimiter.Text = "Vertical Bar {|}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(798, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Column Delimiter:";
            // 
            // chkFirstRowHasHeader
            // 
            this.chkFirstRowHasHeader.AutoSize = true;
            this.chkFirstRowHasHeader.Checked = true;
            this.chkFirstRowHasHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFirstRowHasHeader.Location = new System.Drawing.Point(577, 9);
            this.chkFirstRowHasHeader.Name = "chkFirstRowHasHeader";
            this.chkFirstRowHasHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFirstRowHasHeader.Size = new System.Drawing.Size(196, 24);
            this.chkFirstRowHasHeader.TabIndex = 4;
            this.chkFirstRowHasHeader.Text = "First Row Has Header ";
            this.chkFirstRowHasHeader.UseVisualStyleBackColor = true;
            // 
            // txtTextQualifier
            // 
            this.txtTextQualifier.Location = new System.Drawing.Point(448, 8);
            this.txtTextQualifier.Name = "txtTextQualifier";
            this.txtTextQualifier.Size = new System.Drawing.Size(79, 26);
            this.txtTextQualifier.TabIndex = 3;
            this.txtTextQualifier.Text = "\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text qualifier:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 16;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(2411, 1141);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizeColumnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 36);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // analizeColumnToolStripMenuItem
            // 
            this.analizeColumnToolStripMenuItem.Name = "analizeColumnToolStripMenuItem";
            this.analizeColumnToolStripMenuItem.Size = new System.Drawing.Size(207, 32);
            this.analizeColumnToolStripMenuItem.Text = "Analize Column";
            this.analizeColumnToolStripMenuItem.Click += new System.EventHandler(this.analizeColumnToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1487, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Format:";
            // 
            // cmbFormat
            // 
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Items.AddRange(new object[] {
            "Delimited",
            "Fixed Width"});
            this.cmbFormat.Location = new System.Drawing.Point(1551, 227);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(171, 28);
            this.cmbFormat.TabIndex = 1;
            this.cmbFormat.Text = "Delimited";
            // 
            // CSVPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2411, 1190);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CSVPreview";
            this.Text = "CSV Preview";
            this.Load += new System.EventHandler(this.CSVPreview_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSkipFirstRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFirstRowHasHeader;
        private System.Windows.Forms.TextBox txtTextQualifier;
        private System.Windows.Forms.ComboBox cmbColumnDelimiter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPreviewRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtSkipFirstRows;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem analizeColumnToolStripMenuItem;
    }
}

