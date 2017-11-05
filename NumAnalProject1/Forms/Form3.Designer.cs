namespace NumAnalProject1.Forms
{
    partial class Form3
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
            this.numericUpDownIntervalRow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownIntervalColumn = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelControlPointIndex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownIntervalRow
            // 
            this.numericUpDownIntervalRow.Location = new System.Drawing.Point(324, 43);
            this.numericUpDownIntervalRow.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numericUpDownIntervalRow.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownIntervalRow.Name = "numericUpDownIntervalRow";
            this.numericUpDownIntervalRow.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownIntervalRow.TabIndex = 8;
            this.numericUpDownIntervalRow.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownIntervalRow.ValueChanged += new System.EventHandler(this.numericUpDownIntervalRow_ValueChanged);
            // 
            // numericUpDownIntervalColumn
            // 
            this.numericUpDownIntervalColumn.Location = new System.Drawing.Point(324, 84);
            this.numericUpDownIntervalColumn.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numericUpDownIntervalColumn.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownIntervalColumn.Name = "numericUpDownIntervalColumn";
            this.numericUpDownIntervalColumn.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownIntervalColumn.TabIndex = 8;
            this.numericUpDownIntervalColumn.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownIntervalColumn.ValueChanged += new System.EventHandler(this.numericUpDownIntervalColumn_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "控制点行间隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "控制点列间隔";
            // 
            // labelControlPointIndex
            // 
            this.labelControlPointIndex.AutoSize = true;
            this.labelControlPointIndex.Location = new System.Drawing.Point(36, 150);
            this.labelControlPointIndex.Name = "labelControlPointIndex";
            this.labelControlPointIndex.Size = new System.Drawing.Size(68, 17);
            this.labelControlPointIndex.TabIndex = 10;
            this.labelControlPointIndex.Text = "正在初始化";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 586);
            this.Controls.Add(this.labelControlPointIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownIntervalColumn);
            this.Controls.Add(this.numericUpDownIntervalRow);
            this.Name = "Form3";
            this.Text = "Form3（B样条）";
            this.Controls.SetChildIndex(this.radioButtonNearestNeighbor, 0);
            this.Controls.SetChildIndex(this.radioButtonBilinear, 0);
            this.Controls.SetChildIndex(this.radioButtonBicubic, 0);
            this.Controls.SetChildIndex(this.pictureBoxPreview, 0);
            this.Controls.SetChildIndex(this.numericUpDownIntervalRow, 0);
            this.Controls.SetChildIndex(this.numericUpDownIntervalColumn, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.labelControlPointIndex, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownIntervalRow;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelControlPointIndex;
    }
}