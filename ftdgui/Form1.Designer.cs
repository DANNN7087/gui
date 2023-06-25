namespace ftdgui
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
            btnAdd = new Button();
            label1 = new Label();
            viewPanel = new Panel();
            btnAddInput = new Button();
            btnAddOutput = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(818, 30);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Name";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Names";
            // 
            // viewPanel
            // 
            viewPanel.BorderStyle = BorderStyle.FixedSingle;
            viewPanel.Location = new Point(12, 30);
            viewPanel.Name = "viewPanel";
            viewPanel.Size = new Size(800, 500);
            viewPanel.TabIndex = 4;
            viewPanel.MouseDown += viewPanel_MouseDown;
            viewPanel.MouseMove += viewPanel_MouseMove;
            viewPanel.MouseUp += viewPanel_MouseUp;
            // 
            // btnAddInput
            // 
            btnAddInput.Location = new Point(818, 59);
            btnAddInput.Name = "btnAddInput";
            btnAddInput.Size = new Size(100, 23);
            btnAddInput.TabIndex = 5;
            btnAddInput.Text = "Add Input";
            btnAddInput.UseVisualStyleBackColor = true;
            btnAddInput.Click += btnAddInput_Click;
            // 
            // btnAddOutput
            // 
            btnAddOutput.Location = new Point(818, 88);
            btnAddOutput.Name = "btnAddOutput";
            btnAddOutput.Size = new Size(100, 23);
            btnAddOutput.TabIndex = 6;
            btnAddOutput.Text = "Add Output";
            btnAddOutput.UseVisualStyleBackColor = true;
            btnAddOutput.Click += btnAddOutput_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(btnAddOutput);
            Controls.Add(btnAddInput);
            Controls.Add(viewPanel);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Names";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Label label1;
        public Panel viewPanel;
        private Button btnAddInput;
        private Button btnAddOutput;
    }
}