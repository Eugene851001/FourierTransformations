
namespace FourierTransform
{
    partial class tbN
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
            this.btRun = new System.Windows.Forms.Button();
            this.rbGarmonic = new System.Windows.Forms.RadioButton();
            this.rbPolygarmonic = new System.Windows.Forms.RadioButton();
            this.btLFFilter = new System.Windows.Forms.Button();
            this.btHFFilter = new System.Windows.Forms.Button();
            this.tbFilterFrequency = new System.Windows.Forms.TextBox();
            this.chFFT = new System.Windows.Forms.CheckBox();
            this.tbFrequency = new System.Windows.Forms.TextBox();
            this.btSetN = new System.Windows.Forms.Button();
            this.pnControls = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(65, 117);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(94, 29);
            this.btRun.TabIndex = 0;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // rbGarmonic
            // 
            this.rbGarmonic.AutoSize = true;
            this.rbGarmonic.Location = new System.Drawing.Point(65, 23);
            this.rbGarmonic.Name = "rbGarmonic";
            this.rbGarmonic.Size = new System.Drawing.Size(94, 24);
            this.rbGarmonic.TabIndex = 1;
            this.rbGarmonic.TabStop = true;
            this.rbGarmonic.Text = "Garmonic";
            this.rbGarmonic.UseVisualStyleBackColor = true;
            // 
            // rbPolygarmonic
            // 
            this.rbPolygarmonic.AutoSize = true;
            this.rbPolygarmonic.Location = new System.Drawing.Point(65, 65);
            this.rbPolygarmonic.Name = "rbPolygarmonic";
            this.rbPolygarmonic.Size = new System.Drawing.Size(120, 24);
            this.rbPolygarmonic.TabIndex = 2;
            this.rbPolygarmonic.TabStop = true;
            this.rbPolygarmonic.Text = "Polygarmonic";
            this.rbPolygarmonic.UseVisualStyleBackColor = true;
            // 
            // btLFFilter
            // 
            this.btLFFilter.Location = new System.Drawing.Point(65, 242);
            this.btLFFilter.Name = "btLFFilter";
            this.btLFFilter.Size = new System.Drawing.Size(94, 29);
            this.btLFFilter.TabIndex = 3;
            this.btLFFilter.Text = "LF Filter";
            this.btLFFilter.UseVisualStyleBackColor = true;
            this.btLFFilter.Click += new System.EventHandler(this.btLFFilter_Click);
            // 
            // btHFFilter
            // 
            this.btHFFilter.Location = new System.Drawing.Point(65, 295);
            this.btHFFilter.Name = "btHFFilter";
            this.btHFFilter.Size = new System.Drawing.Size(94, 29);
            this.btHFFilter.TabIndex = 4;
            this.btHFFilter.Text = "HF Filter";
            this.btHFFilter.UseVisualStyleBackColor = true;
            this.btHFFilter.Click += new System.EventHandler(this.btHFFilter_Click);
            // 
            // tbFilterFrequency
            // 
            this.tbFilterFrequency.Location = new System.Drawing.Point(65, 189);
            this.tbFilterFrequency.Name = "tbFilterFrequency";
            this.tbFilterFrequency.Size = new System.Drawing.Size(125, 27);
            this.tbFilterFrequency.TabIndex = 5;
            // 
            // chFFT
            // 
            this.chFFT.AutoSize = true;
            this.chFFT.Location = new System.Drawing.Point(224, 24);
            this.chFFT.Name = "chFFT";
            this.chFFT.Size = new System.Drawing.Size(53, 24);
            this.chFFT.TabIndex = 6;
            this.chFFT.Text = "FFT";
            this.chFFT.UseVisualStyleBackColor = true;
            // 
            // tbFrequency
            // 
            this.tbFrequency.Location = new System.Drawing.Point(65, 354);
            this.tbFrequency.Name = "tbFrequency";
            this.tbFrequency.Size = new System.Drawing.Size(125, 27);
            this.tbFrequency.TabIndex = 7;
            // 
            // btSetN
            // 
            this.btSetN.Location = new System.Drawing.Point(65, 399);
            this.btSetN.Name = "btSetN";
            this.btSetN.Size = new System.Drawing.Size(94, 29);
            this.btSetN.TabIndex = 8;
            this.btSetN.Text = "Set N";
            this.btSetN.UseVisualStyleBackColor = true;
            this.btSetN.Click += new System.EventHandler(this.btSetN_Click);
            // 
            // pnControls
            // 
            this.pnControls.Controls.Add(this.label2);
            this.pnControls.Controls.Add(this.label1);
            this.pnControls.Controls.Add(this.rbGarmonic);
            this.pnControls.Controls.Add(this.btRun);
            this.pnControls.Controls.Add(this.btSetN);
            this.pnControls.Controls.Add(this.rbPolygarmonic);
            this.pnControls.Controls.Add(this.tbFrequency);
            this.pnControls.Controls.Add(this.btLFFilter);
            this.pnControls.Controls.Add(this.chFFT);
            this.pnControls.Controls.Add(this.btHFFilter);
            this.pnControls.Controls.Add(this.tbFilterFrequency);
            this.pnControls.Location = new System.Drawing.Point(657, 2);
            this.pnControls.Name = "pnControls";
            this.pnControls.Size = new System.Drawing.Size(295, 492);
            this.pnControls.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "F";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "N";
            // 
            // tbN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 573);
            this.Controls.Add(this.pnControls);
            this.Name = "tbN";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.tbN_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.pnControls.ResumeLayout(false);
            this.pnControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.RadioButton rbGarmonic;
        private System.Windows.Forms.RadioButton rbPolygarmonic;
        private System.Windows.Forms.Button btLFFilter;
        private System.Windows.Forms.Button btHFFilter;
        private System.Windows.Forms.TextBox tbFilterFrequency;
        private System.Windows.Forms.CheckBox chFFT;
        private System.Windows.Forms.TextBox tbFrequency;
        private System.Windows.Forms.Button btSetN;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

