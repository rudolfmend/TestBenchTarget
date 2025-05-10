namespace TestBenchTarget
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            LabelTime = new Label();
            LabelToday = new Label();
            ButtonOpenApp = new Button();
            MenuStrip1 = new MenuStrip();
            HelpToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            MenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // LabelTime
            // 
            LabelTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelTime.AutoSize = true;
            LabelTime.BackColor = Color.Transparent;
            LabelTime.FlatStyle = FlatStyle.Popup;
            LabelTime.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LabelTime.ForeColor = Color.Black;
            LabelTime.Location = new Point(209, 106);
            LabelTime.Margin = new Padding(200, 40, 200, 40);
            LabelTime.Name = "LabelTime";
            LabelTime.Size = new Size(143, 37);
            LabelTime.TabIndex = 1;
            LabelTime.Text = "00:00:00";
            LabelTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LabelToday
            // 
            LabelToday.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelToday.AutoSize = true;
            LabelToday.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LabelToday.Location = new Point(190, 183);
            LabelToday.Margin = new Padding(0);
            LabelToday.Name = "LabelToday";
            LabelToday.Size = new Size(179, 37);
            LabelToday.TabIndex = 2;
            LabelToday.Text = "00.00.0000";
            // 
            // ButtonOpenApp
            // 
            ButtonOpenApp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ButtonOpenApp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonOpenApp.Cursor = Cursors.Hand;
            ButtonOpenApp.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            ButtonOpenApp.Location = new Point(0, 362);
            ButtonOpenApp.Margin = new Padding(26, 12, 26, 12);
            ButtonOpenApp.Name = "ButtonOpenApp";
            ButtonOpenApp.Size = new Size(584, 120);
            ButtonOpenApp.TabIndex = 3;
            ButtonOpenApp.Text = "Open Application";
            ButtonOpenApp.UseVisualStyleBackColor = true;
            ButtonOpenApp.Click += ButtonOpenApp_Click;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { HelpToolStripMenuItem });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Padding = new Padding(6, 8, 0, 8);
            MenuStrip1.Size = new Size(584, 48);
            MenuStrip1.TabIndex = 4;
            MenuStrip1.Text = "MenuStrip1";
            // 
            // HelpToolStripMenuItem
            // 
            HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutToolStripMenuItem });
            HelpToolStripMenuItem.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            HelpToolStripMenuItem.Padding = new Padding(0, 2, 1, 1);
            HelpToolStripMenuItem.Size = new Size(56, 32);
            HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(135, 30);
            AboutToolStripMenuItem.Text = "About";
            AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(584, 481);
            Controls.Add(ButtonOpenApp);
            Controls.Add(LabelToday);
            Controls.Add(LabelTime);
            Controls.Add(MenuStrip1);
            Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip1;
            Margin = new Padding(52, 24, 52, 24);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TestBench Target - Window1";
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelTime;
        private System.Windows.Forms.Label LabelToday;
        private System.Windows.Forms.Button ButtonOpenApp;
        private System.Windows.Forms.MenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
    }


}

