namespace Singh_Creates_Library
{
    partial class Re_Issue
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.RE = new System.Windows.Forms.Button();
            this.txt_Return = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_St_Id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_U_Book_Id = new System.Windows.Forms.TextBox();
            this.txt_B_Id = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Issue_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U_Book_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_Lib_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issue_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Return_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Singh_Creates_Library.Properties.Resources.Background2;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.txt_Search);
            this.panel1.Controls.Add(this.RE);
            this.panel1.Controls.Add(this.txt_Return);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_St_Id);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_U_Book_Id);
            this.panel1.Controls.Add(this.txt_B_Id);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 420);
            this.panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Issue_Id,
            this.U_Book_Id,
            this.St_Lib_Id,
            this.Issue_Date,
            this.Return_Date});
            this.dataGridView1.Location = new System.Drawing.Point(508, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(521, 150);
            this.dataGridView1.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(525, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(421, 26);
            this.label5.TabIndex = 39;
            this.label5.Text = "SEARCH ISSUE BOOKS INFORMATION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(647, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "(Enter Book or Library ID for Search)";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(684, 345);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(100, 23);
            this.Search.TabIndex = 37;
            this.Search.Text = "SEARCH";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(606, 290);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(258, 20);
            this.txt_Search.TabIndex = 36;
            // 
            // RE
            // 
            this.RE.Location = new System.Drawing.Point(234, 290);
            this.RE.Name = "RE";
            this.RE.Size = new System.Drawing.Size(100, 23);
            this.RE.TabIndex = 35;
            this.RE.Text = "RE-ISSUE";
            this.RE.UseVisualStyleBackColor = true;
            this.RE.Click += new System.EventHandler(this.RE_Click);
            // 
            // txt_Return
            // 
            this.txt_Return.Location = new System.Drawing.Point(234, 228);
            this.txt_Return.Name = "txt_Return";
            this.txt_Return.Size = new System.Drawing.Size(100, 20);
            this.txt_Return.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "RETURN DATE";
            // 
            // txt_St_Id
            // 
            this.txt_St_Id.Location = new System.Drawing.Point(234, 172);
            this.txt_St_Id.Name = "txt_St_Id";
            this.txt_St_Id.Size = new System.Drawing.Size(100, 20);
            this.txt_St_Id.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "STUDENT ID";
            // 
            // txt_U_Book_Id
            // 
            this.txt_U_Book_Id.Location = new System.Drawing.Point(234, 117);
            this.txt_U_Book_Id.Name = "txt_U_Book_Id";
            this.txt_U_Book_Id.Size = new System.Drawing.Size(100, 20);
            this.txt_U_Book_Id.TabIndex = 28;
            // 
            // txt_B_Id
            // 
            this.txt_B_Id.AutoSize = true;
            this.txt_B_Id.Location = new System.Drawing.Point(31, 117);
            this.txt_B_Id.Name = "txt_B_Id";
            this.txt_B_Id.Size = new System.Drawing.Size(91, 13);
            this.txt_B_Id.TabIndex = 27;
            this.txt_B_Id.Text = "ENTER BOOK ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(29, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(335, 26);
            this.label10.TabIndex = 26;
            this.label10.Text = "ENTRY FOR RE-ISSUE BOOKS";
            // 
            // Issue_Id
            // 
            this.Issue_Id.DataPropertyName = "Issue_Id";
            this.Issue_Id.HeaderText = "Issue ID";
            this.Issue_Id.Name = "Issue_Id";
            // 
            // U_Book_Id
            // 
            this.U_Book_Id.DataPropertyName = "U_Book_Id";
            this.U_Book_Id.HeaderText = "Book Library ID";
            this.U_Book_Id.Name = "U_Book_Id";
            // 
            // St_Lib_Id
            // 
            this.St_Lib_Id.DataPropertyName = "St_Lib_Id";
            this.St_Lib_Id.HeaderText = "Student Library ID";
            this.St_Lib_Id.Name = "St_Lib_Id";
            // 
            // Issue_Date
            // 
            this.Issue_Date.DataPropertyName = "Issue_Date";
            this.Issue_Date.HeaderText = "Issue Date";
            this.Issue_Date.Name = "Issue_Date";
            // 
            // Return_Date
            // 
            this.Return_Date.DataPropertyName = "Return_Date";
            this.Return_Date.HeaderText = "Return Date";
            this.Return_Date.Name = "Return_Date";
            // 
            // Re_Issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1051, 447);
            this.Controls.Add(this.panel1);
            this.Name = "Re_Issue";
            this.Load += new System.EventHandler(this.Re_Issue_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Return;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_St_Id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_U_Book_Id;
        private System.Windows.Forms.Label txt_B_Id;
        private System.Windows.Forms.Button RE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issue_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn U_Book_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn St_Lib_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issue_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Return_Date;
    }
}
