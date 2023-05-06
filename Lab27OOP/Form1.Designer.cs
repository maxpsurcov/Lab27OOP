namespace Lab27OOP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxFilterDirectories = new System.Windows.Forms.CheckBox();
            this.checkBoxFilterFiles = new System.Windows.Forms.CheckBox();
            this.textBoxFileContent = new System.Windows.Forms.TextBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.textBoxSecurity = new System.Windows.Forms.TextBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxFilterDirectories
            // 
            this.checkBoxFilterDirectories.AutoSize = true;
            this.checkBoxFilterDirectories.Location = new System.Drawing.Point(176, 126);
            this.checkBoxFilterDirectories.Name = "checkBoxFilterDirectories";
            this.checkBoxFilterDirectories.Size = new System.Drawing.Size(258, 29);
            this.checkBoxFilterDirectories.TabIndex = 0;
            this.checkBoxFilterDirectories.Text = "checkBoxFilterDirectories";
            this.checkBoxFilterDirectories.UseVisualStyleBackColor = true;
            // 
            // checkBoxFilterFiles
            // 
            this.checkBoxFilterFiles.AutoSize = true;
            this.checkBoxFilterFiles.Location = new System.Drawing.Point(176, 175);
            this.checkBoxFilterFiles.Name = "checkBoxFilterFiles";
            this.checkBoxFilterFiles.Size = new System.Drawing.Size(207, 29);
            this.checkBoxFilterFiles.TabIndex = 1;
            this.checkBoxFilterFiles.Text = "checkBoxFilterFiles";
            this.checkBoxFilterFiles.UseVisualStyleBackColor = true;
            // 
            // textBoxFileContent
            // 
            this.textBoxFileContent.Location = new System.Drawing.Point(176, 235);
            this.textBoxFileContent.Name = "textBoxFileContent";
            this.textBoxFileContent.Size = new System.Drawing.Size(258, 29);
            this.textBoxFileContent.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(499, 78);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(252, 88);
            this.treeView.TabIndex = 3;
            // 
            // textBoxSecurity
            // 
            this.textBoxSecurity.Location = new System.Drawing.Point(167, 397);
            this.textBoxSecurity.Name = "textBoxSecurity";
            this.textBoxSecurity.Size = new System.Drawing.Size(258, 29);
            this.textBoxSecurity.TabIndex = 4;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(482, 235);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(269, 191);
            this.pictureBoxImage.TabIndex = 5;
            this.pictureBoxImage.TabStop = false;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Location = new System.Drawing.Point(12, 36);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(130, 130);
            this.propertyGrid.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 622);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.textBoxSecurity);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.textBoxFileContent);
            this.Controls.Add(this.checkBoxFilterFiles);
            this.Controls.Add(this.checkBoxFilterDirectories);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxFilterDirectories;
        private System.Windows.Forms.CheckBox checkBoxFilterFiles;
        private System.Windows.Forms.TextBox textBoxFileContent;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox textBoxSecurity;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.PropertyGrid propertyGrid;
    }
}

