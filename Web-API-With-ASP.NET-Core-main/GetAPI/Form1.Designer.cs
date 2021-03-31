
namespace GetAPI
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtReply = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btnpost = new System.Windows.Forms.Button();
            this.btnput = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(121, 40);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(322, 22);
            this.txtUrl.TabIndex = 0;
            // 
            // txtReply
            // 
            this.txtReply.Location = new System.Drawing.Point(121, 113);
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(316, 151);
            this.txtReply.TabIndex = 2;
            this.txtReply.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(581, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(598, 202);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(32, 22);
            this.txtid.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(598, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "btngetID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(121, 304);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(108, 22);
            this.txtusername.TabIndex = 6;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(121, 360);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(108, 22);
            this.txtpassword.TabIndex = 7;
            // 
            // btnpost
            // 
            this.btnpost.Location = new System.Drawing.Point(598, 314);
            this.btnpost.Name = "btnpost";
            this.btnpost.Size = new System.Drawing.Size(75, 42);
            this.btnpost.TabIndex = 8;
            this.btnpost.Text = "post";
            this.btnpost.UseVisualStyleBackColor = true;
            this.btnpost.Click += new System.EventHandler(this.btnpost_Click);
            // 
            // btnput
            // 
            this.btnput.Location = new System.Drawing.Point(617, 390);
            this.btnput.Name = "btnput";
            this.btnput.Size = new System.Drawing.Size(75, 23);
            this.btnput.TabIndex = 9;
            this.btnput.Text = "put";
            this.btnput.UseVisualStyleBackColor = true;
            this.btnput.Click += new System.EventHandler(this.btnput_Click);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(339, 314);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 22);
            this.id.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(509, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.id);
            this.Controls.Add(this.btnput);
            this.Controls.Add(this.btnpost);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.txtUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.RichTextBox txtReply;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btnpost;
        private System.Windows.Forms.Button btnput;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button button3;
    }
}

