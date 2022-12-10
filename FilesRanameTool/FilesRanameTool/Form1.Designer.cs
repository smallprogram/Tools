namespace FilesRanameTool
{
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
            this.tb_path = new System.Windows.Forms.TextBox();
            this.lab_path = new System.Windows.Forms.Label();
            this.lab_exname = new System.Windows.Forms.Label();
            this.tb_exname = new System.Windows.Forms.TextBox();
            this.lab_renameRules = new System.Windows.Forms.Label();
            this.tb_renameRule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_oldnameRule = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_getpath = new System.Windows.Forms.Button();
            this.btn_starRename = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(112, 16);
            this.tb_path.Name = "tb_path";
            this.tb_path.ReadOnly = true;
            this.tb_path.Size = new System.Drawing.Size(699, 23);
            this.tb_path.TabIndex = 0;
            // 
            // lab_path
            // 
            this.lab_path.AutoSize = true;
            this.lab_path.Location = new System.Drawing.Point(15, 19);
            this.lab_path.Name = "lab_path";
            this.lab_path.Size = new System.Drawing.Size(80, 17);
            this.lab_path.TabIndex = 1;
            this.lab_path.Text = "文件夹路径：";
            // 
            // lab_exname
            // 
            this.lab_exname.AutoSize = true;
            this.lab_exname.Location = new System.Drawing.Point(15, 60);
            this.lab_exname.Name = "lab_exname";
            this.lab_exname.Size = new System.Drawing.Size(80, 17);
            this.lab_exname.TabIndex = 3;
            this.lab_exname.Text = "文件扩展名：";
            // 
            // tb_exname
            // 
            this.tb_exname.Location = new System.Drawing.Point(112, 57);
            this.tb_exname.Name = "tb_exname";
            this.tb_exname.Size = new System.Drawing.Size(60, 23);
            this.tb_exname.TabIndex = 2;
            // 
            // lab_renameRules
            // 
            this.lab_renameRules.AutoSize = true;
            this.lab_renameRules.Location = new System.Drawing.Point(15, 104);
            this.lab_renameRules.Name = "lab_renameRules";
            this.lab_renameRules.Size = new System.Drawing.Size(80, 17);
            this.lab_renameRules.TabIndex = 5;
            this.lab_renameRules.Text = "重命名规则：";
            // 
            // tb_renameRule
            // 
            this.tb_renameRule.Location = new System.Drawing.Point(112, 101);
            this.tb_renameRule.Name = "tb_renameRule";
            this.tb_renameRule.Size = new System.Drawing.Size(319, 23);
            this.tb_renameRule.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "说明：文件名$文件名，$为序号占位符";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "原文件名规则：";
            // 
            // tb_oldnameRule
            // 
            this.tb_oldnameRule.Location = new System.Drawing.Point(112, 141);
            this.tb_oldnameRule.Name = "tb_oldnameRule";
            this.tb_oldnameRule.Size = new System.Drawing.Size(319, 23);
            this.tb_oldnameRule.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(389, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "说明：文件名$文件名，$为序号占位符，空白或不含$符以默认顺序命名";
            // 
            // btn_getpath
            // 
            this.btn_getpath.Location = new System.Drawing.Point(214, 190);
            this.btn_getpath.Name = "btn_getpath";
            this.btn_getpath.Size = new System.Drawing.Size(101, 39);
            this.btn_getpath.TabIndex = 10;
            this.btn_getpath.Text = "获取路径";
            this.btn_getpath.UseVisualStyleBackColor = true;
            this.btn_getpath.Click += new System.EventHandler(this.btn_getpath_Click);
            // 
            // btn_starRename
            // 
            this.btn_starRename.Location = new System.Drawing.Point(523, 190);
            this.btn_starRename.Name = "btn_starRename";
            this.btn_starRename.Size = new System.Drawing.Size(169, 39);
            this.btn_starRename.TabIndex = 11;
            this.btn_starRename.Text = "批量重命名";
            this.btn_starRename.UseVisualStyleBackColor = true;
            this.btn_starRename.Click += new System.EventHandler(this.btn_starRename_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "说明：例如mp4,avi,jpeg,png等文件扩展名";
            // 
            // rtb_log
            // 
            this.rtb_log.Location = new System.Drawing.Point(15, 271);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.Size = new System.Drawing.Size(837, 373);
            this.rtb_log.TabIndex = 13;
            this.rtb_log.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "日志：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 656);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_starRename);
            this.Controls.Add(this.btn_getpath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_oldnameRule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_renameRules);
            this.Controls.Add(this.tb_renameRule);
            this.Controls.Add(this.lab_exname);
            this.Controls.Add(this.tb_exname);
            this.Controls.Add(this.lab_path);
            this.Controls.Add(this.tb_path);
            this.Name = "Form1";
            this.Text = "文件批量重命名";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tb_path;
        private Label lab_path;
        private Label lab_exname;
        private TextBox tb_exname;
        private Label lab_renameRules;
        private TextBox tb_renameRule;
        private Label label1;
        private Label label2;
        private TextBox tb_oldnameRule;
        private Label label3;
        private Button btn_getpath;
        private Button btn_starRename;
        private Label label4;
        private RichTextBox rtb_log;
        private Label label5;
    }
}