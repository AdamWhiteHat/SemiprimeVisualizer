namespace SemiprimeVisualizer
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
			this.components = new System.ComponentModel.Container();
			this.tbSemiPrime = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDownP = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownQ = new System.Windows.Forms.NumericUpDown();
			this.tbSemiPrime1 = new System.Windows.Forms.TextBox();
			this.tbSquareRoot = new System.Windows.Forms.TextBox();
			this.tbProduct = new System.Windows.Forms.TextBox();
			this.tbSemiPrime0 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnAutomateSearch = new System.Windows.Forms.Button();
			this.timerAutoStep = new System.Windows.Forms.Timer(this.components);
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnStep = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.tbP = new System.Windows.Forms.RichTextBox();
			this.tbQ = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQ)).BeginInit();
			this.SuspendLayout();
			// 
			// tbSemiPrime
			// 
			this.tbSemiPrime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSemiPrime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSemiPrime.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tbSemiPrime.Location = new System.Drawing.Point(6, 20);
			this.tbSemiPrime.Multiline = true;
			this.tbSemiPrime.Name = "tbSemiPrime";
			this.tbSemiPrime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSemiPrime.Size = new System.Drawing.Size(1054, 69);
			this.tbSemiPrime.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Semi-prime:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.label2.Location = new System.Drawing.Point(-3, 116);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Sqrt";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Consolas", 13F);
			this.label3.Location = new System.Drawing.Point(4, 196);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 22);
			this.label3.TabIndex = 3;
			this.label3.Text = "=";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(8, 152);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(14, 14);
			this.label4.TabIndex = 5;
			this.label4.Text = "P";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(8, 171);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 14);
			this.label5.TabIndex = 4;
			this.label5.Text = "Q";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDownP
			// 
			this.numericUpDownP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownP.Location = new System.Drawing.Point(1042, 148);
			this.numericUpDownP.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownP.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownP.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
			this.numericUpDownP.Name = "numericUpDownP";
			this.numericUpDownP.Size = new System.Drawing.Size(18, 20);
			this.numericUpDownP.TabIndex = 11;
			this.numericUpDownP.ValueChanged += new System.EventHandler(this.numericUpDownP_ValueChanged);
			// 
			// numericUpDownQ
			// 
			this.numericUpDownQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownQ.Location = new System.Drawing.Point(1042, 168);
			this.numericUpDownQ.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownQ.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownQ.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
			this.numericUpDownQ.Name = "numericUpDownQ";
			this.numericUpDownQ.Size = new System.Drawing.Size(18, 20);
			this.numericUpDownQ.TabIndex = 12;
			this.numericUpDownQ.ValueChanged += new System.EventHandler(this.numericUpDownQ_ValueChanged);
			// 
			// tbSemiPrime1
			// 
			this.tbSemiPrime1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSemiPrime1.BackColor = System.Drawing.Color.Silver;
			this.tbSemiPrime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSemiPrime1.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tbSemiPrime1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tbSemiPrime1.HideSelection = false;
			this.tbSemiPrime1.Location = new System.Drawing.Point(24, 215);
			this.tbSemiPrime1.Name = "tbSemiPrime1";
			this.tbSemiPrime1.ReadOnly = true;
			this.tbSemiPrime1.Size = new System.Drawing.Size(1036, 20);
			this.tbSemiPrime1.TabIndex = 13;
			this.tbSemiPrime1.WordWrap = false;
			// 
			// tbSquareRoot
			// 
			this.tbSquareRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSquareRoot.BackColor = System.Drawing.SystemColors.Control;
			this.tbSquareRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSquareRoot.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tbSquareRoot.HideSelection = false;
			this.tbSquareRoot.Location = new System.Drawing.Point(24, 113);
			this.tbSquareRoot.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.tbSquareRoot.Name = "tbSquareRoot";
			this.tbSquareRoot.Size = new System.Drawing.Size(1036, 20);
			this.tbSquareRoot.TabIndex = 14;
			// 
			// tbProduct
			// 
			this.tbProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbProduct.BackColor = System.Drawing.Color.Gainsboro;
			this.tbProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbProduct.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tbProduct.HideSelection = false;
			this.tbProduct.Location = new System.Drawing.Point(24, 196);
			this.tbProduct.Name = "tbProduct";
			this.tbProduct.ReadOnly = true;
			this.tbProduct.Size = new System.Drawing.Size(1036, 20);
			this.tbProduct.TabIndex = 15;
			this.tbProduct.WordWrap = false;
			// 
			// tbSemiPrime0
			// 
			this.tbSemiPrime0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSemiPrime0.BackColor = System.Drawing.Color.Silver;
			this.tbSemiPrime0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSemiPrime0.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.tbSemiPrime0.HideSelection = false;
			this.tbSemiPrime0.Location = new System.Drawing.Point(24, 90);
			this.tbSemiPrime0.Name = "tbSemiPrime0";
			this.tbSemiPrime0.ReadOnly = true;
			this.tbSemiPrime0.Size = new System.Drawing.Size(1036, 20);
			this.tbSemiPrime0.TabIndex = 18;
			this.tbSemiPrime0.WordWrap = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Consolas", 9F);
			this.label6.Location = new System.Drawing.Point(7, 218);
			this.label6.Margin = new System.Windows.Forms.Padding(0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 14);
			this.label6.TabIndex = 20;
			this.label6.Text = "Φ";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Consolas", 9F);
			this.label7.Location = new System.Drawing.Point(7, 93);
			this.label7.Margin = new System.Windows.Forms.Padding(0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 14);
			this.label7.TabIndex = 21;
			this.label7.Text = "Φ";
			// 
			// btnAutomateSearch
			// 
			this.btnAutomateSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAutomateSearch.Location = new System.Drawing.Point(934, 239);
			this.btnAutomateSearch.Name = "btnAutomateSearch";
			this.btnAutomateSearch.Size = new System.Drawing.Size(126, 23);
			this.btnAutomateSearch.TabIndex = 23;
			this.btnAutomateSearch.Text = "Automate search...";
			this.btnAutomateSearch.UseVisualStyleBackColor = true;
			this.btnAutomateSearch.Click += new System.EventHandler(this.btnAutomate_Click);
			// 
			// timerAutoStep
			// 
			this.timerAutoStep.Interval = 50;
			// 
			// tbOutput
			// 
			this.tbOutput.AcceptsReturn = true;
			this.tbOutput.AcceptsTab = true;
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.BackColor = System.Drawing.SystemColors.Control;
			this.tbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbOutput.Location = new System.Drawing.Point(24, 239);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(904, 123);
			this.tbOutput.TabIndex = 24;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.label9.Location = new System.Drawing.Point(-1, 241);
			this.label9.Margin = new System.Windows.Forms.Padding(0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(25, 13);
			this.label9.TabIndex = 25;
			this.label9.Text = "Log";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnStep
			// 
			this.btnStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStep.Location = new System.Drawing.Point(934, 268);
			this.btnStep.Name = "btnStep";
			this.btnStep.Size = new System.Drawing.Size(126, 23);
			this.btnStep.TabIndex = 26;
			this.btnStep.Text = "Step 1";
			this.btnStep.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(934, 297);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(60, 23);
			this.btnSave.TabIndex = 28;
			this.btnSave.Text = "Save...";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpen.Location = new System.Drawing.Point(1000, 297);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(60, 23);
			this.btnOpen.TabIndex = 29;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// tbP
			// 
			this.tbP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbP.BackColor = System.Drawing.SystemColors.Control;
			this.tbP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbP.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbP.HideSelection = false;
			this.tbP.Location = new System.Drawing.Point(25, 148);
			this.tbP.Margin = new System.Windows.Forms.Padding(0);
			this.tbP.Multiline = false;
			this.tbP.Name = "tbP";
			this.tbP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.tbP.Size = new System.Drawing.Size(1017, 20);
			this.tbP.TabIndex = 30;
			this.tbP.Text = "";
			this.tbP.WordWrap = false;
			this.tbP.TextChanged += new System.EventHandler(this.tbQ_TextChanged);
			this.tbP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbQ_KeyUp);
			// 
			// tbQ
			// 
			this.tbQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbQ.BackColor = System.Drawing.SystemColors.Control;
			this.tbQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbQ.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbQ.HideSelection = false;
			this.tbQ.Location = new System.Drawing.Point(25, 168);
			this.tbQ.Margin = new System.Windows.Forms.Padding(0);
			this.tbQ.Multiline = false;
			this.tbQ.Name = "tbQ";
			this.tbQ.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.tbQ.Size = new System.Drawing.Size(1017, 20);
			this.tbQ.TabIndex = 31;
			this.tbQ.Text = "";
			this.tbQ.WordWrap = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1066, 365);
			this.Controls.Add(this.tbQ);
			this.Controls.Add(this.tbP);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnStep);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.btnAutomateSearch);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbSemiPrime0);
			this.Controls.Add(this.tbProduct);
			this.Controls.Add(this.tbSquareRoot);
			this.Controls.Add(this.tbSemiPrime1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbSemiPrime);
			this.Controls.Add(this.numericUpDownQ);
			this.Controls.Add(this.numericUpDownP);
			this.Name = "MainForm";
			this.Text = "Factor Semi-prime";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQ)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSemiPrime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownP;
        private System.Windows.Forms.NumericUpDown numericUpDownQ;
        private System.Windows.Forms.TextBox tbSemiPrime1;
        private System.Windows.Forms.TextBox tbSquareRoot;
        private System.Windows.Forms.TextBox tbProduct;
        private System.Windows.Forms.TextBox tbSemiPrime0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAutomateSearch;
        private System.Windows.Forms.Timer timerAutoStep;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.RichTextBox tbP;
		private System.Windows.Forms.RichTextBox tbQ;
	}
}

