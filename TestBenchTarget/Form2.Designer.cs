using System.Windows.Forms;

namespace TestBenchTarget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            LabelTime = new Label();
            ButtonAddDate = new Button();
            DataGridView1 = new DataGridView();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnProcedure = new DataGridViewTextBoxColumn();
            ColumnPoints = new DataGridViewTextBoxColumn();
            ColumnDelegate = new DataGridViewTextBoxColumn();
            DomainUpDownDate = new DomainUpDown();
            TextBoxProcedure = new TextBox();
            TextBoxPoints = new TextBox();
            TextBoxDelegate = new TextBox();
            ButtonOpenFolder = new Button();
            LabelDate = new Label();
            LabelDelegate = new Label();
            LabelProcedure = new Label();
            LabelPoints = new Label();
            ButtonLoadData = new Button();
            ButtonSaveData = new Button();
            ButtonRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // LabelTime
            // 
            LabelTime.Location = new Point(28, 9);
            LabelTime.Margin = new Padding(6, 0, 6, 0);
            LabelTime.Name = "LabelTime";
            LabelTime.Size = new Size(183, 42);
            LabelTime.TabIndex = 13;
            LabelTime.Text = "00:00:00";
            // 
            // ButtonAddDate
            // 
            ButtonAddDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonAddDate.Cursor = Cursors.Hand;
            ButtonAddDate.Location = new Point(750, 324);
            ButtonAddDate.Margin = new Padding(20, 15, 20, 15);
            ButtonAddDate.Name = "ButtonAddDate";
            ButtonAddDate.Size = new Size(220, 42);
            ButtonAddDate.TabIndex = 14;
            ButtonAddDate.Text = "Add to table";
            ButtonAddDate.UseVisualStyleBackColor = true;
            ButtonAddDate.Click += ButtonAddDate_Click;
            // 
            // DataGridView1
            // 
            DataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnDate, ColumnProcedure, ColumnPoints, ColumnDelegate });
            DataGridView1.Cursor = Cursors.Hand;
            DataGridView1.Location = new Point(15, 57);
            DataGridView1.Margin = new Padding(6);
            DataGridView1.Name = "DataGridView1";
            DataGridView1.Size = new Size(709, 597);
            DataGridView1.TabIndex = 12;
            DataGridView1.KeyDown += DataGridView1_KeyDown;
            // 
            // ColumnDate
            // 
            ColumnDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnDate.HeaderText = "Date";
            ColumnDate.Name = "ColumnDate";
            ColumnDate.ToolTipText = "dd.MM.yyyy - date format only";
            // 
            // ColumnProcedure
            // 
            ColumnProcedure.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnProcedure.HeaderText = "Procedure";
            ColumnProcedure.Name = "ColumnProcedure";
            ColumnProcedure.ToolTipText = "String of characters";
            // 
            // ColumnPoints
            // 
            ColumnPoints.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnPoints.HeaderText = "Points";
            ColumnPoints.Name = "ColumnPoints";
            ColumnPoints.ToolTipText = "Numbers only";
            // 
            // ColumnDelegate
            // 
            ColumnDelegate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnDelegate.HeaderText = "Delegate";
            ColumnDelegate.Name = "ColumnDelegate";
            ColumnDelegate.ToolTipText = "String of characters";
            // 
            // DomainUpDownDate
            // 
            DomainUpDownDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DomainUpDownDate.Cursor = Cursors.Hand;
            DomainUpDownDate.Location = new Point(750, 76);
            DomainUpDownDate.Margin = new Padding(6, 0, 6, 6);
            DomainUpDownDate.Name = "DomainUpDownDate";
            DomainUpDownDate.Size = new Size(220, 29);
            DomainUpDownDate.TabIndex = 11;
            // 
            // TextBoxProcedure
            // 
            TextBoxProcedure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TextBoxProcedure.Cursor = Cursors.IBeam;
            TextBoxProcedure.Location = new Point(750, 142);
            TextBoxProcedure.Margin = new Padding(6);
            TextBoxProcedure.Name = "TextBoxProcedure";
            TextBoxProcedure.Size = new Size(220, 29);
            TextBoxProcedure.TabIndex = 10;
            // 
            // TextBoxPoints
            // 
            TextBoxPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TextBoxPoints.Cursor = Cursors.IBeam;
            TextBoxPoints.Location = new Point(750, 208);
            TextBoxPoints.Margin = new Padding(6);
            TextBoxPoints.Name = "TextBoxPoints";
            TextBoxPoints.Size = new Size(220, 29);
            TextBoxPoints.TabIndex = 9;
            // 
            // TextBoxDelegate
            // 
            TextBoxDelegate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TextBoxDelegate.Cursor = Cursors.IBeam;
            TextBoxDelegate.Location = new Point(750, 274);
            TextBoxDelegate.Margin = new Padding(6);
            TextBoxDelegate.Name = "TextBoxDelegate";
            TextBoxDelegate.Size = new Size(220, 29);
            TextBoxDelegate.TabIndex = 8;
            // 
            // ButtonOpenFolder
            // 
            ButtonOpenFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonOpenFolder.Cursor = Cursors.Hand;
            ButtonOpenFolder.Location = new Point(750, 612);
            ButtonOpenFolder.Margin = new Padding(20, 15, 20, 15);
            ButtonOpenFolder.Name = "ButtonOpenFolder";
            ButtonOpenFolder.Size = new Size(220, 42);
            ButtonOpenFolder.TabIndex = 7;
            ButtonOpenFolder.Text = "Open folder";
            ButtonOpenFolder.UseVisualStyleBackColor = true;
            ButtonOpenFolder.Click += ButtonOpenFolder_Click;
            // 
            // LabelDate
            // 
            LabelDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelDate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LabelDate.Location = new Point(766, 58);
            LabelDate.Margin = new Padding(0, 15, 0, 0);
            LabelDate.Name = "LabelDate";
            LabelDate.Size = new Size(72, 17);
            LabelDate.TabIndex = 6;
            LabelDate.Text = "Date";
            // 
            // LabelDelegate
            // 
            LabelDelegate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelDelegate.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LabelDelegate.Location = new Point(766, 258);
            LabelDelegate.Margin = new Padding(0, 15, 0, 0);
            LabelDelegate.Name = "LabelDelegate";
            LabelDelegate.Size = new Size(72, 17);
            LabelDelegate.TabIndex = 5;
            LabelDelegate.Text = "Delegate";
            // 
            // LabelProcedure
            // 
            LabelProcedure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelProcedure.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LabelProcedure.Location = new Point(766, 126);
            LabelProcedure.Margin = new Padding(0, 15, 0, 0);
            LabelProcedure.Name = "LabelProcedure";
            LabelProcedure.Size = new Size(72, 17);
            LabelProcedure.TabIndex = 4;
            LabelProcedure.Text = "Procedure";
            // 
            // LabelPoints
            // 
            LabelPoints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LabelPoints.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LabelPoints.Location = new Point(766, 192);
            LabelPoints.Margin = new Padding(0, 15, 0, 0);
            LabelPoints.Name = "LabelPoints";
            LabelPoints.Size = new Size(72, 17);
            LabelPoints.TabIndex = 3;
            LabelPoints.Text = "Points";
            // 
            // ButtonLoadData
            // 
            ButtonLoadData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonLoadData.Cursor = Cursors.Hand;
            ButtonLoadData.Location = new Point(750, 396);
            ButtonLoadData.Margin = new Padding(20, 15, 20, 15);
            ButtonLoadData.Name = "ButtonLoadData";
            ButtonLoadData.Size = new Size(220, 42);
            ButtonLoadData.TabIndex = 2;
            ButtonLoadData.Text = "Load data";
            ButtonLoadData.UseVisualStyleBackColor = true;
            ButtonLoadData.Click += ButtonLoadData_Click;
            // 
            // ButtonSaveData
            // 
            ButtonSaveData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonSaveData.Cursor = Cursors.Hand;
            ButtonSaveData.Location = new Point(750, 468);
            ButtonSaveData.Margin = new Padding(20, 15, 20, 15);
            ButtonSaveData.Name = "ButtonSaveData";
            ButtonSaveData.Size = new Size(220, 42);
            ButtonSaveData.TabIndex = 1;
            ButtonSaveData.Text = "Save data to file";
            ButtonSaveData.UseVisualStyleBackColor = true;
            ButtonSaveData.Click += ButtonSaveData_Click;
            // 
            // ButtonRemove
            // 
            ButtonRemove.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonRemove.Cursor = Cursors.Hand;
            ButtonRemove.Location = new Point(750, 540);
            ButtonRemove.Margin = new Padding(20, 15, 20, 15);
            ButtonRemove.Name = "ButtonRemove";
            ButtonRemove.Size = new Size(220, 42);
            ButtonRemove.TabIndex = 0;
            ButtonRemove.Text = "Delete data";
            ButtonRemove.UseVisualStyleBackColor = true;
            ButtonRemove.Click += ButtonRemove_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(998, 681);
            Controls.Add(ButtonRemove);
            Controls.Add(ButtonSaveData);
            Controls.Add(ButtonLoadData);
            Controls.Add(LabelPoints);
            Controls.Add(LabelProcedure);
            Controls.Add(LabelDelegate);
            Controls.Add(LabelDate);
            Controls.Add(ButtonOpenFolder);
            Controls.Add(TextBoxDelegate);
            Controls.Add(TextBoxPoints);
            Controls.Add(TextBoxProcedure);
            Controls.Add(DomainUpDownDate);
            Controls.Add(DataGridView1);
            Controls.Add(LabelTime);
            Controls.Add(ButtonAddDate);
            Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TestBench Target - Window2";
            ((System.ComponentModel.ISupportInitialize)DataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label LabelTime;
        private Button ButtonAddDate;
        private DataGridView DataGridView1;
        private DomainUpDown DomainUpDownDate;
        private TextBox TextBoxProcedure;
        private TextBox TextBoxPoints;
        private TextBox TextBoxDelegate;
        private Button ButtonOpenFolder;
        private Label LabelDate;
        private Label LabelDelegate;
        private Label LabelProcedure;
        private Label LabelPoints;
        private Button ButtonLoadData;
        private Button ButtonSaveData;
        private Button ButtonRemove;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnProcedure;
        private DataGridViewTextBoxColumn ColumnPoints;
        private DataGridViewTextBoxColumn ColumnDelegate;
    }
}
