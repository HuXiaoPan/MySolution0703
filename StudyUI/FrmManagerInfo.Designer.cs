namespace StudyUI
{
    partial class FrmManagerInfo
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
            this.gboxList = new System.Windows.Forms.GroupBox();
            this.gBoxControl = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gboxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxList
            // 
            this.gboxList.Controls.Add(this.dataGridView1);
            this.gboxList.Location = new System.Drawing.Point(12, 12);
            this.gboxList.Name = "gboxList";
            this.gboxList.Size = new System.Drawing.Size(390, 299);
            this.gboxList.TabIndex = 0;
            this.gboxList.TabStop = false;
            this.gboxList.Text = "列表";
            // 
            // gBoxControl
            // 
            this.gBoxControl.Location = new System.Drawing.Point(408, 12);
            this.gBoxControl.Name = "gBoxControl";
            this.gBoxControl.Size = new System.Drawing.Size(323, 299);
            this.gBoxControl.TabIndex = 1;
            this.gBoxControl.TabStop = false;
            this.gBoxControl.Text = "添加/修改";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MID,
            this.MName,
            this.MType});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(384, 279);
            this.dataGridView1.TabIndex = 0;
            // 
            // MID
            // 
            this.MID.HeaderText = "编号";
            this.MID.Name = "MID";
            this.MID.ReadOnly = true;
            // 
            // MName
            // 
            this.MName.HeaderText = "名称";
            this.MName.Name = "MName";
            this.MName.ReadOnly = true;
            // 
            // MType
            // 
            this.MType.HeaderText = "类型";
            this.MType.Name = "MType";
            this.MType.ReadOnly = true;
            // 
            // FrmManagerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 323);
            this.Controls.Add(this.gBoxControl);
            this.Controls.Add(this.gboxList);
            this.Name = "FrmManagerInfo";
            this.Text = "店员管理";
            this.gboxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MType;
        private System.Windows.Forms.GroupBox gBoxControl;
    }
}