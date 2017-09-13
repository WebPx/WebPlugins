namespace WebPx.Web.Design
{
    partial class IconCssClassForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.UXIconClassName = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.UXOK = new System.Windows.Forms.Button();
            this.UXCancel = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Icon Class Name:";
            // 
            // UXIconClassName
            // 
            this.UXIconClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UXIconClassName.Location = new System.Drawing.Point(108, 12);
            this.UXIconClassName.Name = "UXIconClassName";
            this.UXIconClassName.Size = new System.Drawing.Size(299, 20);
            this.UXIconClassName.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(131, 182);
            this.treeView1.TabIndex = 2;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(260, 182);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // UXOK
            // 
            this.UXOK.Location = new System.Drawing.Point(251, 226);
            this.UXOK.Name = "UXOK";
            this.UXOK.Size = new System.Drawing.Size(75, 23);
            this.UXOK.TabIndex = 4;
            this.UXOK.Text = "OK";
            this.UXOK.UseVisualStyleBackColor = true;
            // 
            // UXCancel
            // 
            this.UXCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UXCancel.Location = new System.Drawing.Point(332, 226);
            this.UXCancel.Name = "UXCancel";
            this.UXCancel.Size = new System.Drawing.Size(75, 23);
            this.UXCancel.TabIndex = 5;
            this.UXCancel.Text = "Cancel";
            this.UXCancel.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 38);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(395, 182);
            this.splitContainer1.SplitterDistance = 131;
            this.splitContainer1.TabIndex = 6;
            // 
            // IconCssClassForm
            // 
            this.AcceptButton = this.UXOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.UXCancel;
            this.ClientSize = new System.Drawing.Size(419, 261);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.UXCancel);
            this.Controls.Add(this.UXOK);
            this.Controls.Add(this.UXIconClassName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IconCssClassForm";
            this.Text = "Icon Selector Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UXIconClassName;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button UXOK;
        private System.Windows.Forms.Button UXCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}