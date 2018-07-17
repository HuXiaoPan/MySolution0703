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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.MID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxControl = new System.Windows.Forms.GroupBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gBoxControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxList
            // 
            this.gboxList.Controls.Add(this.dgvList);
            this.gboxList.Location = new System.Drawing.Point(12, 12);
            this.gboxList.Name = "gboxList";
            this.gboxList.Size = new System.Drawing.Size(390, 299);
            this.gboxList.TabIndex = 0;
            this.gboxList.TabStop = false;
            this.gboxList.Text = "列表";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MID,
            this.MName,
            this.MType});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(384, 279);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvList_CellFormatting);
            this.dgvList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseDoubleClick);
            // 
            // MID
            // 
            this.MID.DataPropertyName = "MID";
            this.MID.HeaderText = "编号";
            this.MID.Name = "MID";
            this.MID.ReadOnly = true;
            // 
            // MName
            // 
            this.MName.DataPropertyName = "MName";
            this.MName.HeaderText = "名称";
            this.MName.Name = "MName";
            this.MName.ReadOnly = true;
            // 
            // MType
            // 
            this.MType.DataPropertyName = "MType";
            this.MType.HeaderText = "类型";
            this.MType.Name = "MType";
            this.MType.ReadOnly = true;
            // 
            // gBoxControl
            // 
            this.gBoxControl.Controls.Add(this.tbPwd);
            this.gBoxControl.Controls.Add(this.tbName);
            this.gBoxControl.Controls.Add(this.tbId);
            this.gBoxControl.Controls.Add(this.btnDelete);
            this.gBoxControl.Controls.Add(this.btnCancel);
            this.gBoxControl.Controls.Add(this.btnSave);
            this.gBoxControl.Controls.Add(this.rb2);
            this.gBoxControl.Controls.Add(this.rb1);
            this.gBoxControl.Controls.Add(this.label4);
            this.gBoxControl.Controls.Add(this.label3);
            this.gBoxControl.Controls.Add(this.label2);
            this.gBoxControl.Controls.Add(this.label1);
            this.gBoxControl.Location = new System.Drawing.Point(408, 12);
            this.gBoxControl.Name = "gBoxControl";
            this.gBoxControl.Size = new System.Drawing.Size(323, 299);
            this.gBoxControl.TabIndex = 1;
            this.gBoxControl.TabStop = false;
            this.gBoxControl.Text = "添加/修改";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(74, 86);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.Size = new System.Drawing.Size(243, 21);
            this.tbPwd.TabIndex = 11;
            this.tbPwd.UseSystemPasswordChar = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(74, 53);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(243, 21);
            this.tbName.TabIndex = 10;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(74, 22);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(243, 21);
            this.tbId.TabIndex = 9;
            this.tbId.Text = "添加时无编号";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(53, 244);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(196, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "删除选中员工";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(174, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(53, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "添加";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(154, 140);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(47, 16);
            this.rb2.TabIndex = 5;
            this.rb2.Text = "员工";
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(53, 140);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(47, 16);
            this.rb1.TabIndex = 4;
            this.rb1.TabStop = true;
            this.rb1.Text = "经理";
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号：";
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
            this.Load += new System.EventHandler(this.FrmManagerInfo_Load);
            this.gboxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gBoxControl.ResumeLayout(false);
            this.gBoxControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxList;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox gBoxControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn MID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MType;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}