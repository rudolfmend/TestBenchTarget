using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestBenchTarget
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private float _dpiScaleFactor;

        public Form1()
        {
            InitializeComponent();
            LabelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            LabelToday.Text = DateTime.Now.ToString("dd.MM.yyyy");

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 sekunda
            timer.Tick += (s, e) =>
            {
                LabelTime.Text = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();

            // Nastavenie DPI škálovania - set DPI scaling
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void ButtonOpenApp_Click(object sender, EventArgs e)
        {
            var Form2 = new Form2();
            Form2.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
            base.OnFormClosing(e);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Vytvorenie a zobrazenie About dialogu  - create and show "About" dialog
            Form aboutForm = new Form()
            {
                Text = "About TestBench Target",
                Size = new System.Drawing.Size(600, 520),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                AutoScaleMode = AutoScaleMode.Dpi
            };

            // Pridanie obsahu do About okna  - add content to the "About" window
            Label titleLabel = new Label()
            {
                Text = "TestBench Target",
                Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };

            Label versionLabel = new Label()
            {
                Text = $"Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!.ToString()}",
                Location = new System.Drawing.Point(20, 50),
                AutoSize = true
            };

            System.Windows.Forms.TextBox descriptionBox = new System.Windows.Forms.TextBox()
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BorderStyle = BorderStyle.None,
                Font = new Font("Microsoft Sans Serif", 12),
                BackColor = aboutForm.BackColor,
                Location = new System.Drawing.Point(20, 80),
                Size = new System.Drawing.Size(580, 360),
                Text = @"  
A sample application designed to serve as a testing subject for developers creating monitoring, accessibility, or UI automation tools. 
This app provides predictable user interface elements and behaviors that developers can use to test their monitoring solutions. 
For Windows 10 and newer. 

    Main features:  
        - Small and fast application 
        - Tests opening a Windows directory 
        - Provides a target app for trying out monitoring and testing tools 
        - Simulates adding defined items to a table 
        - Simple chronological display of data in a table format 

Ideal for developers and testers who need a reliable target application when developing tools to monitor and test UI interactions. 
                "
            };

            Label copyrightLabel = new Label()
            {
                Text = "Copyright © 2025 Rudolf Mendzezof",
                Location = new System.Drawing.Point(20, 450), // Pozícia pod textBoxom  - position below the textBox
                AutoSize = true
            };

            System.Windows.Forms.Button closeButton = new System.Windows.Forms.Button()
            {
                Text = "Close",
                DialogResult = DialogResult.OK,
                Location = new System.Drawing.Point(476, 440),
                Size = new System.Drawing.Size(90, 30),
                Font = new Font("Microsoft Sans Serif", 10)
            };

            // Pridanie komponentov do formulára  - add components to the form
            aboutForm.Controls.Add(titleLabel);
            aboutForm.Controls.Add(versionLabel);
            aboutForm.Controls.Add(descriptionBox);
            aboutForm.Controls.Add(copyrightLabel);
            aboutForm.Controls.Add(closeButton);

            // Zobrazenie About okna ako modálneho dialógu - show "About dialog" as a modal dialog
            aboutForm.ShowDialog(this);
        }
    }
}
