namespace NumAnalProject1.Forms
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
            this.hScrollBarTheta = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBarTheta
            // 
            this.hScrollBarTheta.Location = new System.Drawing.Point(200, 86);
            this.hScrollBarTheta.Maximum = 360;
            this.hScrollBarTheta.Minimum = -360;
            this.hScrollBarTheta.Name = "hScrollBarTheta";
            this.hScrollBarTheta.Size = new System.Drawing.Size(250, 17);
            this.hScrollBarTheta.TabIndex = 8;
            this.hScrollBarTheta.ValueChanged += new System.EventHandler(this.Refresh);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "θ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "θ 取值范围 [-2π, 2π]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 586);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hScrollBarTheta);
            this.Name = "Form1";
            this.Text = "Form1（旋转扭曲）";
            this.Controls.SetChildIndex(this.radioButtonNearestNeighbor, 0);
            this.Controls.SetChildIndex(this.radioButtonBilinear, 0);
            this.Controls.SetChildIndex(this.radioButtonBicubic, 0);
            this.Controls.SetChildIndex(this.pictureBoxPreview, 0);
            this.Controls.SetChildIndex(this.hScrollBarTheta, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScrollBarTheta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}