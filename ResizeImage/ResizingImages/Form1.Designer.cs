namespace ResizingImages
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
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonChoose = new System.Windows.Forms.Button();
            this.pictureBoxReady = new System.Windows.Forms.PictureBox();
            this.pictureBoxChosen = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReady)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosen)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(5, 278);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(160, 27);
            this.buttonChange.TabIndex = 7;
            this.buttonChange.Text = "Resize";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.ButtonChange_Click);
            // 
            // buttonChoose
            // 
            this.buttonChoose.Location = new System.Drawing.Point(5, 191);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(160, 34);
            this.buttonChoose.TabIndex = 6;
            this.buttonChoose.Text = "Choose Image";
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.ButtonChoose_Click);
            // 
            // pictureBoxReady
            // 
            this.pictureBoxReady.Location = new System.Drawing.Point(171, 25);
            this.pictureBoxReady.Name = "pictureBoxReady";
            this.pictureBoxReady.Size = new System.Drawing.Size(640, 640);
            this.pictureBoxReady.TabIndex = 5;
            this.pictureBoxReady.TabStop = false;
            // 
            // pictureBoxChosen
            // 
            this.pictureBoxChosen.Location = new System.Drawing.Point(5, 25);
            this.pictureBoxChosen.Name = "pictureBoxChosen";
            this.pictureBoxChosen.Size = new System.Drawing.Size(160, 160);
            this.pictureBoxChosen.TabIndex = 4;
            this.pictureBoxChosen.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(5, 231);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(160, 41);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 675);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonChoose);
            this.Controls.Add(this.pictureBoxReady);
            this.Controls.Add(this.pictureBoxChosen);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReady)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChosen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.PictureBox pictureBoxReady;
        private System.Windows.Forms.PictureBox pictureBoxChosen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

