namespace Bank.Forms
{
    partial class frmVerification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerification));
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picj2Sign = new System.Windows.Forms.PictureBox();
            this.picJ1Sign = new System.Windows.Forms.PictureBox();
            this.picHSign = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picj2Photo = new System.Windows.Forms.PictureBox();
            this.picJ1Photo = new System.Windows.Forms.PictureBox();
            this.picHPhoto = new System.Windows.Forms.PictureBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picj2Sign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJ1Sign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHSign)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picj2Photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJ1Photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccNo
            // 
            this.txtAccNo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccNo.Location = new System.Drawing.Point(138, 22);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(121, 25);
            this.txtAccNo.TabIndex = 0;
            this.txtAccNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccNo_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 61;
            this.label1.Text = "Account No: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVerify
            // 
            this.btnVerify.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(325, 22);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(89, 25);
            this.btnVerify.TabIndex = 1;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picj2Sign);
            this.groupBox2.Controls.Add(this.picJ1Sign);
            this.groupBox2.Controls.Add(this.picHSign);
            this.groupBox2.Location = new System.Drawing.Point(255, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 310);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sign:";
            // 
            // picj2Sign
            // 
            this.picj2Sign.Location = new System.Drawing.Point(28, 214);
            this.picj2Sign.Name = "picj2Sign";
            this.picj2Sign.Size = new System.Drawing.Size(108, 85);
            this.picj2Sign.TabIndex = 2;
            this.picj2Sign.TabStop = false;
            // 
            // picJ1Sign
            // 
            this.picJ1Sign.Location = new System.Drawing.Point(28, 124);
            this.picJ1Sign.Name = "picJ1Sign";
            this.picJ1Sign.Size = new System.Drawing.Size(108, 84);
            this.picJ1Sign.TabIndex = 1;
            this.picJ1Sign.TabStop = false;
            // 
            // picHSign
            // 
            this.picHSign.Location = new System.Drawing.Point(28, 24);
            this.picHSign.Name = "picHSign";
            this.picHSign.Size = new System.Drawing.Size(108, 83);
            this.picHSign.TabIndex = 0;
            this.picHSign.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picj2Photo);
            this.groupBox1.Controls.Add(this.picJ1Photo);
            this.groupBox1.Controls.Add(this.picHPhoto);
            this.groupBox1.Location = new System.Drawing.Point(38, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 310);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Photo:";
            // 
            // picj2Photo
            // 
            this.picj2Photo.Location = new System.Drawing.Point(28, 214);
            this.picj2Photo.Name = "picj2Photo";
            this.picj2Photo.Size = new System.Drawing.Size(108, 85);
            this.picj2Photo.TabIndex = 2;
            this.picj2Photo.TabStop = false;
            // 
            // picJ1Photo
            // 
            this.picJ1Photo.Location = new System.Drawing.Point(28, 124);
            this.picJ1Photo.Name = "picJ1Photo";
            this.picJ1Photo.Size = new System.Drawing.Size(108, 84);
            this.picJ1Photo.TabIndex = 1;
            this.picJ1Photo.TabStop = false;
            // 
            // picHPhoto
            // 
            this.picHPhoto.Location = new System.Drawing.Point(28, 24);
            this.picHPhoto.Name = "picHPhoto";
            this.picHPhoto.Size = new System.Drawing.Size(108, 83);
            this.picHPhoto.TabIndex = 0;
            this.picHPhoto.TabStop = false;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(124, 71);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(59, 13);
            this.lblBalance.TabIndex = 67;
            this.lblBalance.Text = "Balance is ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Balance";
            // 
            // frmVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 442);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtAccNo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVerification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verification:";
            this.Load += new System.EventHandler(this.frmVerification_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picj2Sign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJ1Sign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHSign)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picj2Photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picJ1Photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picj2Sign;
        private System.Windows.Forms.PictureBox picJ1Sign;
        private System.Windows.Forms.PictureBox picHSign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picj2Photo;
        private System.Windows.Forms.PictureBox picJ1Photo;
        private System.Windows.Forms.PictureBox picHPhoto;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label2;
    }
}