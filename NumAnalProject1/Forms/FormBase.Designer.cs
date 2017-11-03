namespace NumAnalProject1.Forms
{
    partial class FormBase
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
            this.radioButtonNearestNeighbor = new System.Windows.Forms.RadioButton();
            this.radioButtonBilinear = new System.Windows.Forms.RadioButton();
            this.radioButtonBicubic = new System.Windows.Forms.RadioButton();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonRawImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonNearestNeighbor
            // 
            this.radioButtonNearestNeighbor.AutoSize = true;
            this.radioButtonNearestNeighbor.Location = new System.Drawing.Point(493, 32);
            this.radioButtonNearestNeighbor.Name = "radioButtonNearestNeighbor";
            this.radioButtonNearestNeighbor.Size = new System.Drawing.Size(86, 21);
            this.radioButtonNearestNeighbor.TabIndex = 0;
            this.radioButtonNearestNeighbor.TabStop = true;
            this.radioButtonNearestNeighbor.Text = "最近邻插值";
            this.radioButtonNearestNeighbor.UseVisualStyleBackColor = true;
            this.radioButtonNearestNeighbor.CheckedChanged += new System.EventHandler(this.radioButtonNearestNeighbor_CheckedChanged);
            // 
            // radioButtonBilinear
            // 
            this.radioButtonBilinear.AutoSize = true;
            this.radioButtonBilinear.Location = new System.Drawing.Point(493, 59);
            this.radioButtonBilinear.Name = "radioButtonBilinear";
            this.radioButtonBilinear.Size = new System.Drawing.Size(86, 21);
            this.radioButtonBilinear.TabIndex = 1;
            this.radioButtonBilinear.TabStop = true;
            this.radioButtonBilinear.Text = "双线性插值";
            this.radioButtonBilinear.UseVisualStyleBackColor = true;
            this.radioButtonBilinear.CheckedChanged += new System.EventHandler(this.radioButtonBilinear_CheckedChanged);
            // 
            // radioButtonBicubic
            // 
            this.radioButtonBicubic.AutoSize = true;
            this.radioButtonBicubic.Location = new System.Drawing.Point(493, 86);
            this.radioButtonBicubic.Name = "radioButtonBicubic";
            this.radioButtonBicubic.Size = new System.Drawing.Size(86, 21);
            this.radioButtonBicubic.TabIndex = 2;
            this.radioButtonBicubic.TabStop = true;
            this.radioButtonBicubic.Text = "双三次插值";
            this.radioButtonBicubic.UseVisualStyleBackColor = true;
            this.radioButtonBicubic.CheckedChanged += new System.EventHandler(this.radioButtonBicubic_CheckedChanged);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(39, 43);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(110, 64);
            this.buttonOpenFile.TabIndex = 5;
            this.buttonOpenFile.Text = "打开图片";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(200, 150);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 6;
            this.pictureBoxPreview.TabStop = false;
            // 
            // buttonRawImage
            // 
            this.buttonRawImage.Location = new System.Drawing.Point(627, 43);
            this.buttonRawImage.Name = "buttonRawImage";
            this.buttonRawImage.Size = new System.Drawing.Size(110, 64);
            this.buttonRawImage.TabIndex = 7;
            this.buttonRawImage.Text = "查看原图";
            this.buttonRawImage.UseVisualStyleBackColor = true;
            this.buttonRawImage.Click += new System.EventHandler(this.buttonRawImage_Click);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 586);
            this.Controls.Add(this.buttonRawImage);
            this.Controls.Add(this.pictureBoxPreview);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.radioButtonBicubic);
            this.Controls.Add(this.radioButtonBilinear);
            this.Controls.Add(this.radioButtonNearestNeighbor);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormBase";
            this.Text = "旋转扭曲";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonRawImage;
        protected System.Windows.Forms.RadioButton radioButtonNearestNeighbor;
        protected System.Windows.Forms.RadioButton radioButtonBilinear;
        protected System.Windows.Forms.RadioButton radioButtonBicubic;
        protected System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}