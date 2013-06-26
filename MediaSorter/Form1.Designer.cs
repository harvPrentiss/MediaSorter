namespace MediaSorter
{
    partial class Form1
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
            this.txtSortDir = new System.Windows.Forms.TextBox();
            this.txtDestDir = new System.Windows.Forms.TextBox();
            this.btnSortBrowse = new System.Windows.Forms.Button();
            this.btnDestBrowse = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSortDir
            // 
            this.txtSortDir.Location = new System.Drawing.Point(138, 29);
            this.txtSortDir.Name = "txtSortDir";
            this.txtSortDir.Size = new System.Drawing.Size(152, 20);
            this.txtSortDir.TabIndex = 0;
            // 
            // txtDestDir
            // 
            this.txtDestDir.Location = new System.Drawing.Point(138, 91);
            this.txtDestDir.Name = "txtDestDir";
            this.txtDestDir.Size = new System.Drawing.Size(152, 20);
            this.txtDestDir.TabIndex = 1;
            // 
            // btnSortBrowse
            // 
            this.btnSortBrowse.Location = new System.Drawing.Point(296, 29);
            this.btnSortBrowse.Name = "btnSortBrowse";
            this.btnSortBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSortBrowse.TabIndex = 2;
            this.btnSortBrowse.Text = "Browse";
            this.btnSortBrowse.UseVisualStyleBackColor = true;
            this.btnSortBrowse.Click += new System.EventHandler(this.btnSortBrowse_Click);
            // 
            // btnDestBrowse
            // 
            this.btnDestBrowse.Location = new System.Drawing.Point(296, 89);
            this.btnDestBrowse.Name = "btnDestBrowse";
            this.btnDestBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDestBrowse.TabIndex = 3;
            this.btnDestBrowse.Text = "Browse";
            this.btnDestBrowse.UseVisualStyleBackColor = true;
            this.btnDestBrowse.Click += new System.EventHandler(this.btnDestBrowse_Click);
            // 
            // lstResults
            // 
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(12, 188);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(584, 251);
            this.lstResults.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(521, 445);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Directory to be sorted:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destination directory:";
            // 
            // btnSort
            // 
            this.btnSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSort.Location = new System.Drawing.Point(482, 139);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(114, 43);
            this.btnSort.TabIndex = 9;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 477);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnDestBrowse);
            this.Controls.Add(this.btnSortBrowse);
            this.Controls.Add(this.txtDestDir);
            this.Controls.Add(this.txtSortDir);
            this.Name = "Form1";
            this.Text = "Media Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSortDir;
        private System.Windows.Forms.TextBox txtDestDir;
        private System.Windows.Forms.Button btnSortBrowse;
        private System.Windows.Forms.Button btnDestBrowse;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSort;
    }
}

