
namespace SelectColorProject
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.theRTB = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.clearColBtn = new System.Windows.Forms.Button();
            this.clearTxtBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.addColBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lastColorBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStrip});
            this.statusStrip1.Location = new System.Drawing.Point(6, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(788, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStrip
            // 
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(16, 17);
            this.statusStrip.Text = "...";
            // 
            // theRTB
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.theRTB, 2);
            this.theRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theRTB.Location = new System.Drawing.Point(9, 9);
            this.theRTB.Name = "theRTB";
            this.theRTB.Size = new System.Drawing.Size(782, 356);
            this.theRTB.TabIndex = 0;
            this.theRTB.Text = "";
            this.theRTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theRTB_KeyDown);
            this.theRTB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.theRTB_KeyUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.Controls.Add(this.theRTB, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.clearColBtn);
            this.flowLayoutPanel1.Controls.Add(this.clearTxtBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 372);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(381, 41);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // clearColBtn
            // 
            this.clearColBtn.Location = new System.Drawing.Point(284, 3);
            this.clearColBtn.Name = "clearColBtn";
            this.clearColBtn.Size = new System.Drawing.Size(94, 38);
            this.clearColBtn.TabIndex = 0;
            this.clearColBtn.Text = "Clear all color";
            this.clearColBtn.UseVisualStyleBackColor = true;
            this.clearColBtn.Click += new System.EventHandler(this.clearColBtn_Click_1);
            // 
            // clearTxtBtn
            // 
            this.clearTxtBtn.Location = new System.Drawing.Point(184, 3);
            this.clearTxtBtn.Name = "clearTxtBtn";
            this.clearTxtBtn.Size = new System.Drawing.Size(94, 38);
            this.clearTxtBtn.TabIndex = 1;
            this.clearTxtBtn.Text = "Clear all text";
            this.clearTxtBtn.UseVisualStyleBackColor = true;
            this.clearTxtBtn.Click += new System.EventHandler(this.clearTxtBtn_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addColBtn);
            this.flowLayoutPanel2.Controls.Add(this.lastColorBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(397, 372);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(394, 41);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // addColBtn
            // 
            this.addColBtn.Location = new System.Drawing.Point(3, 3);
            this.addColBtn.Name = "addColBtn";
            this.addColBtn.Size = new System.Drawing.Size(94, 38);
            this.addColBtn.TabIndex = 0;
            this.addColBtn.Text = "Add color";
            this.addColBtn.UseVisualStyleBackColor = true;
            this.addColBtn.Click += new System.EventHandler(this.addColBtn_Click_1);
            // 
            // colorDialog1
            // 
            this.colorDialog1.ShowHelp = true;
            this.colorDialog1.HelpRequest += new System.EventHandler(this.colorDialog1_HelpRequest);
            // 
            // lastColorBtn
            // 
            this.lastColorBtn.Location = new System.Drawing.Point(103, 3);
            this.lastColorBtn.Name = "lastColorBtn";
            this.lastColorBtn.Size = new System.Drawing.Size(108, 38);
            this.lastColorBtn.TabIndex = 1;
            this.lastColorBtn.Text = "Add last color:";
            this.lastColorBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lastColorBtn.UseVisualStyleBackColor = true;
            this.lastColorBtn.Click += new System.EventHandler(this.lastColorBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Background Color Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip;
        private System.Windows.Forms.RichTextBox theRTB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button clearColBtn;
        private System.Windows.Forms.Button addColBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button clearTxtBtn;
        private System.Windows.Forms.Button lastColorBtn;
    }
}

