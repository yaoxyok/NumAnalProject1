namespace NumAnalProject1.Forms
{
    partial class Form2
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
            this.hScrollBarPhi = new System.Windows.Forms.HScrollBar();
            this.hScrollBarRho = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBarTheta
            // 
            this.hScrollBarTheta.Location = new System.Drawing.Point(200, 90);
            this.hScrollBarTheta.Maximum = 360;
            this.hScrollBarTheta.Name = "hScrollBarTheta";
            this.hScrollBarTheta.Size = new System.Drawing.Size(250, 17);
            this.hScrollBarTheta.TabIndex = 9;
            this.hScrollBarTheta.ValueChanged += new System.EventHandler(this.Refresh);
            // 
            // hScrollBarPhi
            // 
            this.hScrollBarPhi.Location = new System.Drawing.Point(200, 59);
            this.hScrollBarPhi.Maximum = 360;
            this.hScrollBarPhi.Minimum = -360;
            this.hScrollBarPhi.Name = "hScrollBarPhi";
            this.hScrollBarPhi.Size = new System.Drawing.Size(250, 17);
            this.hScrollBarPhi.TabIndex = 10;
            this.hScrollBarPhi.ValueChanged += new System.EventHandler(this.Refresh);
            // 
            // hScrollBarRho
            // 
            this.hScrollBarRho.Location = new System.Drawing.Point(200, 23);
            this.hScrollBarRho.Maximum = 360;
            this.hScrollBarRho.Minimum = -360;
            this.hScrollBarRho.Name = "hScrollBarRho";
            this.hScrollBarRho.Size = new System.Drawing.Size(250, 17);
            this.hScrollBarRho.TabIndex = 11;
            this.hScrollBarRho.ValueChanged += new System.EventHandler(this.Refresh);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "ρ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "φ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "θ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "ρ 取值范围 -10π ~ 10π";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "φ 取值范围 -π ~ π";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "θ 取值范围 0 ~ 1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 586);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hScrollBarRho);
            this.Controls.Add(this.hScrollBarPhi);
            this.Controls.Add(this.hScrollBarTheta);
            this.Name = "Form2";
            this.Text = "Form2（水波纹扭曲）";
            this.Controls.SetChildIndex(this.radioButtonNearestNeighbor, 0);
            this.Controls.SetChildIndex(this.radioButtonBilinear, 0);
            this.Controls.SetChildIndex(this.radioButtonBicubic, 0);
            this.Controls.SetChildIndex(this.pictureBoxPreview, 0);
            this.Controls.SetChildIndex(this.hScrollBarTheta, 0);
            this.Controls.SetChildIndex(this.hScrollBarPhi, 0);
            this.Controls.SetChildIndex(this.hScrollBarRho, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar hScrollBarTheta;
        private System.Windows.Forms.HScrollBar hScrollBarPhi;
        private System.Windows.Forms.HScrollBar hScrollBarRho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}