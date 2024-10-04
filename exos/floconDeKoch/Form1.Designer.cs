namespace floconDeKoch
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
            drawingPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            niveauControl = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)niveauControl).BeginInit();
            SuspendLayout();
            // 
            // drawingPanel
            // 
            drawingPanel.Location = new Point(67, 28);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(307, 197);
            drawingPanel.TabIndex = 0;
            drawingPanel.Paint += drawingPanel_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(442, 77);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 100);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // niveauControl
            // 
            niveauControl.Location = new Point(442, 28);
            niveauControl.Name = "niveauControl";
            niveauControl.Size = new Size(120, 23);
            niveauControl.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(niveauControl);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(drawingPanel);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)niveauControl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel drawingPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private NumericUpDown niveauControl;
    }
}
