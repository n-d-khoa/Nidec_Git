﻿namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    partial class InventoryReasonMasterForm : FormCommonMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryReasonMasterForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.InventoryReasonCode_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InventoryReasonCode_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.InventoryReasonName_txt = new Com.Nidec.Mes.Framework.TextBoxCommon();
            this.InventoryReasonName_lbl = new Com.Nidec.Mes.Framework.LabelCommon();
            this.Add_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Search_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.InventoryReasonDetails_dgv = new Com.Nidec.Mes.Framework.DataGridViewCommon();
            this.colInventoryReasonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventoryReasonCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInventoryReasonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exit_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Delete_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Update_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            this.Clear_btn = new Com.Nidec.Mes.Framework.ButtonCommon();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryReasonDetails_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryReasonCode_txt
            // 
            this.InventoryReasonCode_txt.ControlId = null;
            resources.ApplyResources(this.InventoryReasonCode_txt, "InventoryReasonCode_txt");
            this.InventoryReasonCode_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InventoryReasonCode_txt.Name = "InventoryReasonCode_txt";
            // 
            // InventoryReasonCode_lbl
            // 
            resources.ApplyResources(this.InventoryReasonCode_lbl, "InventoryReasonCode_lbl");
            this.InventoryReasonCode_lbl.ControlId = null;
            this.InventoryReasonCode_lbl.Name = "InventoryReasonCode_lbl";
            // 
            // InventoryReasonName_txt
            // 
            this.InventoryReasonName_txt.ControlId = null;
            resources.ApplyResources(this.InventoryReasonName_txt, "InventoryReasonName_txt");
            this.InventoryReasonName_txt.InputType = Com.Nidec.Mes.Framework.TextBoxCommon.InputTypeList.All;
            this.InventoryReasonName_txt.Name = "InventoryReasonName_txt";
            // 
            // InventoryReasonName_lbl
            // 
            resources.ApplyResources(this.InventoryReasonName_lbl, "InventoryReasonName_lbl");
            this.InventoryReasonName_lbl.ControlId = null;
            this.InventoryReasonName_lbl.Name = "InventoryReasonName_lbl";
            // 
            // Add_btn
            // 
            this.Add_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Add_btn.ControlId = null;
            resources.ApplyResources(this.Add_btn, "Add_btn");
            this.Add_btn.Name = "Add_btn";
            this.Add_btn.UseVisualStyleBackColor = true;
            this.Add_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Search_btn.ControlId = null;
            resources.ApplyResources(this.Search_btn, "Search_btn");
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // InventoryReasonDetails_dgv
            // 
            this.InventoryReasonDetails_dgv.AllowUserToAddRows = false;
            this.InventoryReasonDetails_dgv.AllowUserToDeleteRows = false;
            this.InventoryReasonDetails_dgv.AllowUserToOrderColumns = true;
            this.InventoryReasonDetails_dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.InventoryReasonDetails_dgv, "InventoryReasonDetails_dgv");
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryReasonDetails_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InventoryReasonDetails_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InventoryReasonDetails_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInventoryReasonId,
            this.colInventoryReasonCode,
            this.colInventoryReasonName});
            this.InventoryReasonDetails_dgv.ControlId = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InventoryReasonDetails_dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.InventoryReasonDetails_dgv.EnableHeadersVisualStyles = false;
            this.InventoryReasonDetails_dgv.MultiSelect = false;
            this.InventoryReasonDetails_dgv.Name = "InventoryReasonDetails_dgv";
            this.InventoryReasonDetails_dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryReasonDetails_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.InventoryReasonDetails_dgv.RowHeadersVisible = false;
            this.InventoryReasonDetails_dgv.RowTemplate.Height = 21;
            this.InventoryReasonDetails_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InventoryReasonDetails_dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventoryReasonDetails_dgv_CellClick);
            this.InventoryReasonDetails_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventoryReasonDetails_dgv_CellDoubleClick);
            // 
            // colInventoryReasonId
            // 
            this.colInventoryReasonId.DataPropertyName = "InventoryReasonId";
            resources.ApplyResources(this.colInventoryReasonId, "colInventoryReasonId");
            this.colInventoryReasonId.Name = "colInventoryReasonId";
            this.colInventoryReasonId.ReadOnly = true;
            // 
            // colInventoryReasonCode
            // 
            this.colInventoryReasonCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInventoryReasonCode.DataPropertyName = "InventoryReasonCode";
            resources.ApplyResources(this.colInventoryReasonCode, "colInventoryReasonCode");
            this.colInventoryReasonCode.Name = "colInventoryReasonCode";
            this.colInventoryReasonCode.ReadOnly = true;
            // 
            // colInventoryReasonName
            // 
            this.colInventoryReasonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInventoryReasonName.DataPropertyName = "InventoryReasonName";
            resources.ApplyResources(this.colInventoryReasonName, "colInventoryReasonName");
            this.colInventoryReasonName.Name = "colInventoryReasonName";
            this.colInventoryReasonName.ReadOnly = true;
            // 
            // Exit_btn
            // 
            resources.ApplyResources(this.Exit_btn, "Exit_btn");
            this.Exit_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Exit_btn.ControlId = null;
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // Delete_btn
            // 
            resources.ApplyResources(this.Delete_btn, "Delete_btn");
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Delete_btn.ControlId = null;
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // Update_btn
            // 
            resources.ApplyResources(this.Update_btn, "Update_btn");
            this.Update_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Update_btn.ControlId = null;
            this.Update_btn.Name = "Update_btn";
            this.Update_btn.UseVisualStyleBackColor = true;
            this.Update_btn.Click += new System.EventHandler(this.Update_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Clear_btn.ControlId = null;
            resources.ApplyResources(this.Clear_btn, "Clear_btn");
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.UseVisualStyleBackColor = true;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // InventoryReasonMasterForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlId = "bpmf006";
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Update_btn);
            this.Controls.Add(this.InventoryReasonDetails_dgv);
            this.Controls.Add(this.Add_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.InventoryReasonName_txt);
            this.Controls.Add(this.InventoryReasonName_lbl);
            this.Controls.Add(this.InventoryReasonCode_txt);
            this.Controls.Add(this.InventoryReasonCode_lbl);
            this.Name = "InventoryReasonMasterForm";
            this.TitleText = "FormCommon";
            this.Load += new System.EventHandler(this.InventoryReasonMasterForm_Load);
            this.Controls.SetChildIndex(this.InventoryReasonCode_lbl, 0);
            this.Controls.SetChildIndex(this.InventoryReasonCode_txt, 0);
            this.Controls.SetChildIndex(this.InventoryReasonName_lbl, 0);
            this.Controls.SetChildIndex(this.InventoryReasonName_txt, 0);
            this.Controls.SetChildIndex(this.Search_btn, 0);
            this.Controls.SetChildIndex(this.Add_btn, 0);
            this.Controls.SetChildIndex(this.InventoryReasonDetails_dgv, 0);
            this.Controls.SetChildIndex(this.Update_btn, 0);
            this.Controls.SetChildIndex(this.Delete_btn, 0);
            this.Controls.SetChildIndex(this.Exit_btn, 0);
            this.Controls.SetChildIndex(this.Clear_btn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryReasonDetails_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Com.Nidec.Mes.Framework.TextBoxCommon InventoryReasonCode_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InventoryReasonCode_lbl;
        private Com.Nidec.Mes.Framework.TextBoxCommon InventoryReasonName_txt;
        private Com.Nidec.Mes.Framework.LabelCommon InventoryReasonName_lbl;
        private Com.Nidec.Mes.Framework.ButtonCommon Add_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Search_btn;
        internal Com.Nidec.Mes.Framework.DataGridViewCommon InventoryReasonDetails_dgv;
        private Com.Nidec.Mes.Framework.ButtonCommon Exit_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Delete_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Update_btn;
        private Com.Nidec.Mes.Framework.ButtonCommon Clear_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryReasonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryReasonCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInventoryReasonName;
    }
}