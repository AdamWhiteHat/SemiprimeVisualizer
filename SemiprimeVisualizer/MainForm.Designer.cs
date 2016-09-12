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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.tbSemiPrime = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDownP = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownQ = new System.Windows.Forms.NumericUpDown();
			this.tbSquareRoot = new System.Windows.Forms.TextBox();
			this.tbSemiPrime0 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.timerAutoStep = new System.Windows.Forms.Timer(this.components);
			this.rtbP = new System.Windows.Forms.RichTextBox();
			this.rtbQ = new System.Windows.Forms.RichTextBox();
			this.rtbProduct = new System.Windows.Forms.RichTextBox();
			this.rtbSemiPrime = new System.Windows.Forms.RichTextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnSaveProgress = new System.Windows.Forms.Button();
			this.btnAutomateSearch = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.numericTimerDelay = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.rtbDeltaP = new System.Windows.Forms.RichTextBox();
			this.rtbDeltaQ = new System.Windows.Forms.RichTextBox();
			this.rtbDeltaProductPositive = new System.Windows.Forms.RichTextBox();
			this.rtbDeltaGoalPositive = new System.Windows.Forms.RichTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.rtbDeltaProductNegitive = new System.Windows.Forms.RichTextBox();
			this.rtbDeltaGoalNegative = new System.Windows.Forms.RichTextBox();
			this.tbNumbersSolved = new System.Windows.Forms.TextBox();
			this.btnQuadraticResidue = new System.Windows.Forms.Button();
			this.timerQuadraticSearch = new System.Windows.Forms.Timer(this.components);
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label12 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericTimerDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbSemiPrime
			// 
			this.tbSemiPrime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSemiPrime.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSemiPrime.Location = new System.Drawing.Point(6, 20);
			this.tbSemiPrime.Margin = new System.Windows.Forms.Padding(0);
			this.tbSemiPrime.Multiline = true;
			this.tbSemiPrime.Name = "tbSemiPrime";
			this.tbSemiPrime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSemiPrime.Size = new System.Drawing.Size(544, 41);
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
			this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(3, 90);
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
			this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(6, 175);
			this.label3.Margin = new System.Windows.Forms.Padding(0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 14);
			this.label3.TabIndex = 3;
			this.label3.Text = "P*Q";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(20, 124);
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
			this.label5.Location = new System.Drawing.Point(20, 144);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 14);
			this.label5.TabIndex = 4;
			this.label5.Text = "Q";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDownP
			// 
			this.numericUpDownP.Location = new System.Drawing.Point(531, 121);
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
			// 
			// numericUpDownQ
			// 
			this.numericUpDownQ.Location = new System.Drawing.Point(531, 141);
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
			// 
			// tbSquareRoot
			// 
			this.tbSquareRoot.BackColor = System.Drawing.SystemColors.Control;
			this.tbSquareRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSquareRoot.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSquareRoot.HideSelection = false;
			this.tbSquareRoot.Location = new System.Drawing.Point(38, 86);
			this.tbSquareRoot.Margin = new System.Windows.Forms.Padding(0);
			this.tbSquareRoot.Name = "tbSquareRoot";
			this.tbSquareRoot.ShortcutsEnabled = false;
			this.tbSquareRoot.Size = new System.Drawing.Size(512, 21);
			this.tbSquareRoot.TabIndex = 14;
			// 
			// tbSemiPrime0
			// 
			this.tbSemiPrime0.BackColor = System.Drawing.Color.Silver;
			this.tbSemiPrime0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSemiPrime0.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSemiPrime0.HideSelection = false;
			this.tbSemiPrime0.Location = new System.Drawing.Point(38, 63);
			this.tbSemiPrime0.Margin = new System.Windows.Forms.Padding(0);
			this.tbSemiPrime0.Name = "tbSemiPrime0";
			this.tbSemiPrime0.ReadOnly = true;
			this.tbSemiPrime0.ShortcutsEnabled = false;
			this.tbSemiPrime0.Size = new System.Drawing.Size(512, 21);
			this.tbSemiPrime0.TabIndex = 18;
			this.tbSemiPrime0.WordWrap = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Consolas", 9F);
			this.label6.Location = new System.Drawing.Point(20, 202);
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
			this.label7.Location = new System.Drawing.Point(20, 66);
			this.label7.Margin = new System.Windows.Forms.Padding(0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 14);
			this.label7.TabIndex = 21;
			this.label7.Text = "Φ";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// timerAutoStep
			// 
			this.timerAutoStep.Interval = 1;
			// 
			// rtbP
			// 
			this.rtbP.BackColor = System.Drawing.SystemColors.Control;
			this.rtbP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbP.CausesValidation = false;
			this.rtbP.DetectUrls = false;
			this.rtbP.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbP.HideSelection = false;
			this.rtbP.Location = new System.Drawing.Point(38, 121);
			this.rtbP.Margin = new System.Windows.Forms.Padding(0);
			this.rtbP.Multiline = false;
			this.rtbP.Name = "rtbP";
			this.rtbP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbP.Size = new System.Drawing.Size(494, 20);
			this.rtbP.TabIndex = 30;
			this.rtbP.Text = "";
			this.rtbP.WordWrap = false;
			// 
			// rtbQ
			// 
			this.rtbQ.BackColor = System.Drawing.SystemColors.Control;
			this.rtbQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbQ.DetectUrls = false;
			this.rtbQ.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbQ.HideSelection = false;
			this.rtbQ.Location = new System.Drawing.Point(38, 141);
			this.rtbQ.Margin = new System.Windows.Forms.Padding(0);
			this.rtbQ.Multiline = false;
			this.rtbQ.Name = "rtbQ";
			this.rtbQ.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbQ.Size = new System.Drawing.Size(494, 20);
			this.rtbQ.TabIndex = 31;
			this.rtbQ.Text = "";
			this.rtbQ.WordWrap = false;
			// 
			// rtbProduct
			// 
			this.rtbProduct.BackColor = System.Drawing.SystemColors.Control;
			this.rtbProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbProduct.DetectUrls = false;
			this.rtbProduct.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbProduct.HideSelection = false;
			this.rtbProduct.Location = new System.Drawing.Point(38, 161);
			this.rtbProduct.Margin = new System.Windows.Forms.Padding(0);
			this.rtbProduct.Multiline = false;
			this.rtbProduct.Name = "rtbProduct";
			this.rtbProduct.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbProduct.ShortcutsEnabled = false;
			this.rtbProduct.Size = new System.Drawing.Size(512, 38);
			this.rtbProduct.TabIndex = 35;
			this.rtbProduct.Text = "";
			this.rtbProduct.WordWrap = false;
			// 
			// rtbSemiPrime
			// 
			this.rtbSemiPrime.BackColor = System.Drawing.SystemColors.Control;
			this.rtbSemiPrime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbSemiPrime.DetectUrls = false;
			this.rtbSemiPrime.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbSemiPrime.HideSelection = false;
			this.rtbSemiPrime.Location = new System.Drawing.Point(38, 199);
			this.rtbSemiPrime.Margin = new System.Windows.Forms.Padding(0);
			this.rtbSemiPrime.Multiline = false;
			this.rtbSemiPrime.Name = "rtbSemiPrime";
			this.rtbSemiPrime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbSemiPrime.ShortcutsEnabled = false;
			this.rtbSemiPrime.Size = new System.Drawing.Size(512, 20);
			this.rtbSemiPrime.TabIndex = 36;
			this.rtbSemiPrime.Text = "";
			this.rtbSemiPrime.WordWrap = false;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(466, 305);
			this.btnReset.Margin = new System.Windows.Forms.Padding(1);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(84, 23);
			this.btnReset.TabIndex = 46;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// btnSaveProgress
			// 
			this.btnSaveProgress.Location = new System.Drawing.Point(380, 246);
			this.btnSaveProgress.Name = "btnSaveProgress";
			this.btnSaveProgress.Size = new System.Drawing.Size(84, 23);
			this.btnSaveProgress.TabIndex = 44;
			this.btnSaveProgress.Text = "Save...";
			this.btnSaveProgress.UseVisualStyleBackColor = true;
			// 
			// btnAutomateSearch
			// 
			this.btnAutomateSearch.Location = new System.Drawing.Point(466, 220);
			this.btnAutomateSearch.Margin = new System.Windows.Forms.Padding(1);
			this.btnAutomateSearch.Name = "btnAutomateSearch";
			this.btnAutomateSearch.Size = new System.Drawing.Size(84, 23);
			this.btnAutomateSearch.TabIndex = 43;
			this.btnAutomateSearch.Text = "Auto search";
			this.btnAutomateSearch.UseVisualStyleBackColor = true;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(380, 220);
			this.btnOpen.Margin = new System.Windows.Forms.Padding(1);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(84, 23);
			this.btnOpen.TabIndex = 45;
			this.btnOpen.Text = "Open...";
			this.btnOpen.UseVisualStyleBackColor = true;
			// 
			// numericTimerDelay
			// 
			this.numericTimerDelay.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.numericTimerDelay.Location = new System.Drawing.Point(466, 271);
			this.numericTimerDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericTimerDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericTimerDelay.Name = "numericTimerDelay";
			this.numericTimerDelay.Size = new System.Drawing.Size(84, 20);
			this.numericTimerDelay.TabIndex = 57;
			this.numericTimerDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericTimerDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(466, 292);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(84, 11);
			this.label16.TabIndex = 58;
			this.label16.Text = "Delay (ms)";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rtbDeltaP
			// 
			this.rtbDeltaP.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaP.DetectUrls = false;
			this.rtbDeltaP.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaP.HideSelection = false;
			this.rtbDeltaP.Location = new System.Drawing.Point(38, 231);
			this.rtbDeltaP.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaP.Multiline = false;
			this.rtbDeltaP.Name = "rtbDeltaP";
			this.rtbDeltaP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaP.ShortcutsEnabled = false;
			this.rtbDeltaP.Size = new System.Drawing.Size(314, 20);
			this.rtbDeltaP.TabIndex = 39;
			this.rtbDeltaP.Text = "";
			this.rtbDeltaP.WordWrap = false;
			// 
			// rtbDeltaQ
			// 
			this.rtbDeltaQ.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaQ.DetectUrls = false;
			this.rtbDeltaQ.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaQ.HideSelection = false;
			this.rtbDeltaQ.Location = new System.Drawing.Point(38, 251);
			this.rtbDeltaQ.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaQ.Multiline = false;
			this.rtbDeltaQ.Name = "rtbDeltaQ";
			this.rtbDeltaQ.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaQ.ShortcutsEnabled = false;
			this.rtbDeltaQ.Size = new System.Drawing.Size(314, 20);
			this.rtbDeltaQ.TabIndex = 40;
			this.rtbDeltaQ.Text = "";
			this.rtbDeltaQ.WordWrap = false;
			// 
			// rtbDeltaProductPositive
			// 
			this.rtbDeltaProductPositive.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaProductPositive.DetectUrls = false;
			this.rtbDeltaProductPositive.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaProductPositive.HideSelection = false;
			this.rtbDeltaProductPositive.Location = new System.Drawing.Point(1, 289);
			this.rtbDeltaProductPositive.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaProductPositive.Multiline = false;
			this.rtbDeltaProductPositive.Name = "rtbDeltaProductPositive";
			this.rtbDeltaProductPositive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaProductPositive.ShortcutsEnabled = false;
			this.rtbDeltaProductPositive.Size = new System.Drawing.Size(231, 20);
			this.rtbDeltaProductPositive.TabIndex = 41;
			this.rtbDeltaProductPositive.Text = "";
			this.rtbDeltaProductPositive.WordWrap = false;
			// 
			// rtbDeltaGoalPositive
			// 
			this.rtbDeltaGoalPositive.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaGoalPositive.DetectUrls = false;
			this.rtbDeltaGoalPositive.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaGoalPositive.HideSelection = false;
			this.rtbDeltaGoalPositive.Location = new System.Drawing.Point(1, 309);
			this.rtbDeltaGoalPositive.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaGoalPositive.Multiline = false;
			this.rtbDeltaGoalPositive.Name = "rtbDeltaGoalPositive";
			this.rtbDeltaGoalPositive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaGoalPositive.ShortcutsEnabled = false;
			this.rtbDeltaGoalPositive.Size = new System.Drawing.Size(231, 20);
			this.rtbDeltaGoalPositive.TabIndex = 42;
			this.rtbDeltaGoalPositive.Text = "";
			this.rtbDeltaGoalPositive.WordWrap = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("LM Sans Demi Cond 10", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(10, 252);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 17);
			this.label8.TabIndex = 47;
			this.label8.Text = "Δq";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("LM Sans Demi Cond 10", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(10, 232);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 17);
			this.label9.TabIndex = 48;
			this.label9.Text = "Δp";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(93, 272);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 14);
			this.label10.TabIndex = 49;
			this.label10.Text = "Δ(P*Q) ↑";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(101, 329);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 14);
			this.label11.TabIndex = 50;
			this.label11.Text = "Δ(Φ) ￬";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// rtbDeltaProductNegitive
			// 
			this.rtbDeltaProductNegitive.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaProductNegitive.DetectUrls = false;
			this.rtbDeltaProductNegitive.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaProductNegitive.HideSelection = false;
			this.rtbDeltaProductNegitive.Location = new System.Drawing.Point(233, 289);
			this.rtbDeltaProductNegitive.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaProductNegitive.Multiline = false;
			this.rtbDeltaProductNegitive.Name = "rtbDeltaProductNegitive";
			this.rtbDeltaProductNegitive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaProductNegitive.ShortcutsEnabled = false;
			this.rtbDeltaProductNegitive.Size = new System.Drawing.Size(231, 20);
			this.rtbDeltaProductNegitive.TabIndex = 51;
			this.rtbDeltaProductNegitive.Text = "";
			this.rtbDeltaProductNegitive.WordWrap = false;
			// 
			// rtbDeltaGoalNegative
			// 
			this.rtbDeltaGoalNegative.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaGoalNegative.DetectUrls = false;
			this.rtbDeltaGoalNegative.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaGoalNegative.HideSelection = false;
			this.rtbDeltaGoalNegative.Location = new System.Drawing.Point(233, 309);
			this.rtbDeltaGoalNegative.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaGoalNegative.Multiline = false;
			this.rtbDeltaGoalNegative.Name = "rtbDeltaGoalNegative";
			this.rtbDeltaGoalNegative.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaGoalNegative.ShortcutsEnabled = false;
			this.rtbDeltaGoalNegative.Size = new System.Drawing.Size(231, 20);
			this.rtbDeltaGoalNegative.TabIndex = 52;
			this.rtbDeltaGoalNegative.Text = "";
			this.rtbDeltaGoalNegative.WordWrap = false;
			// 
			// tbNumbersSolved
			// 
			this.tbNumbersSolved.BackColor = System.Drawing.SystemColors.Control;
			this.tbNumbersSolved.Enabled = false;
			this.tbNumbersSolved.Location = new System.Drawing.Point(355, 231);
			this.tbNumbersSolved.Name = "tbNumbersSolved";
			this.tbNumbersSolved.Size = new System.Drawing.Size(24, 20);
			this.tbNumbersSolved.TabIndex = 61;
			// 
			// btnQuadraticResidue
			// 
			this.btnQuadraticResidue.Location = new System.Drawing.Point(466, 246);
			this.btnQuadraticResidue.Name = "btnQuadraticResidue";
			this.btnQuadraticResidue.Size = new System.Drawing.Size(84, 23);
			this.btnQuadraticResidue.TabIndex = 63;
			this.btnQuadraticResidue.Text = "Quadratic Res";
			this.btnQuadraticResidue.UseVisualStyleBackColor = true;
			this.btnQuadraticResidue.Click += new System.EventHandler(this.btnQuadraticResidue_Click);
			// 
			// timerQuadraticSearch
			// 
			this.timerQuadraticSearch.Interval = 50;
			this.timerQuadraticSearch.Tick += new System.EventHandler(this.timerQuadraticSearch_Tick);
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chart1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
			this.chart1.BorderlineWidth = 0;
			this.chart1.BorderSkin.BorderColor = System.Drawing.Color.White;
			this.chart1.BorderSkin.BorderWidth = 0;
			chartArea2.AxisX.IsLabelAutoFit = false;
			chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea2.AxisX.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
			chartArea2.AxisX.ScaleBreakStyle.Enabled = true;
			chartArea2.AxisX.ScaleBreakStyle.Spacing = 1D;
			chartArea2.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea2.AxisX2.IsLabelAutoFit = false;
			chartArea2.AxisX2.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8F, System.Drawing.FontStyle.Bold);
			chartArea2.AxisX2.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisX2.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
			chartArea2.AxisX2.ScaleBreakStyle.Enabled = true;
			chartArea2.AxisX2.ScaleBreakStyle.Spacing = 1D;
			chartArea2.AxisX2.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.Maroon;
			chartArea2.AxisY.IsLabelAutoFit = false;
			chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8F);
			chartArea2.AxisY.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
			chartArea2.AxisY.ScaleBreakStyle.Enabled = true;
			chartArea2.AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 3;
			chartArea2.AxisY.ScaleBreakStyle.Spacing = 1D;
			chartArea2.AxisY.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea2.AxisY2.IsLabelAutoFit = false;
			chartArea2.AxisY2.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8F);
			chartArea2.AxisY2.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY2.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea2.AxisY2.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
			chartArea2.AxisY2.ScaleBreakStyle.Enabled = true;
			chartArea2.AxisY2.ScaleBreakStyle.MaxNumberOfBreaks = 3;
			chartArea2.AxisY2.ScaleBreakStyle.Spacing = 1D;
			chartArea2.AxisY2.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.Maroon;
			chartArea2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
			chartArea2.BorderColor = System.Drawing.Color.DarkGray;
			chartArea2.BorderWidth = 0;
			chartArea2.CursorX.LineColor = System.Drawing.Color.Black;
			chartArea2.CursorY.LineColor = System.Drawing.Color.Black;
			chartArea2.Name = "ChartArea1";
			chartArea2.Position.Auto = false;
			chartArea2.Position.Height = 100F;
			chartArea2.Position.Width = 100F;
			this.chart1.ChartAreas.Add(chartArea2);
			this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
			this.chart1.IsSoftShadows = false;
			this.chart1.Location = new System.Drawing.Point(556, 3);
			this.chart1.Margin = new System.Windows.Forms.Padding(0);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
			series3.BorderWidth = 0;
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
			series3.EmptyPointStyle.BorderWidth = 0;
			series3.EmptyPointStyle.LabelBorderWidth = 0;
			series3.EmptyPointStyle.LabelForeColor = System.Drawing.Color.White;
			series3.EmptyPointStyle.MarkerBorderWidth = 0;
			series3.IsVisibleInLegend = false;
			series3.LabelBorderWidth = 0;
			series3.LabelForeColor = System.Drawing.Color.Empty;
			series3.MarkerBorderWidth = 0;
			series3.MarkerColor = System.Drawing.Color.MediumBlue;
			series3.MarkerSize = 2;
			series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series3.Name = "Series1";
			series3.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.DarkGray;
			series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
			series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
			series4.BorderWidth = 0;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
			series4.EmptyPointStyle.BorderWidth = 0;
			series4.EmptyPointStyle.LabelBorderWidth = 0;
			series4.EmptyPointStyle.MarkerBorderWidth = 0;
			series4.IsVisibleInLegend = false;
			series4.LabelBorderWidth = 0;
			series4.LabelForeColor = System.Drawing.Color.Empty;
			series4.MarkerBorderWidth = 0;
			series4.MarkerColor = System.Drawing.Color.DarkRed;
			series4.MarkerSize = 2;
			series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
			series4.Name = "Series2";
			series4.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.DarkGray;
			series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
			series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
			this.chart1.Series.Add(series3);
			this.chart1.Series.Add(series4);
			this.chart1.Size = new System.Drawing.Size(486, 606);
			this.chart1.TabIndex = 64;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(333, 275);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(62, 14);
			this.label12.TabIndex = 65;
			this.label12.Text = "Δ(P*Q) ￬";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(341, 329);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(48, 14);
			this.label14.TabIndex = 66;
			this.label14.Text = "Δ(Φ) ￬";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1044, 611);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.btnQuadraticResidue);
			this.Controls.Add(this.tbNumbersSolved);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.numericTimerDelay);
			this.Controls.Add(this.rtbDeltaGoalNegative);
			this.Controls.Add(this.rtbDeltaProductNegitive);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnSaveProgress);
			this.Controls.Add(this.btnAutomateSearch);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.rtbDeltaGoalPositive);
			this.Controls.Add(this.rtbDeltaProductPositive);
			this.Controls.Add(this.rtbDeltaQ);
			this.Controls.Add(this.rtbDeltaP);
			this.Controls.Add(this.rtbSemiPrime);
			this.Controls.Add(this.rtbProduct);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbSemiPrime0);
			this.Controls.Add(this.tbSquareRoot);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbSemiPrime);
			this.Controls.Add(this.numericUpDownP);
			this.Controls.Add(this.numericUpDownQ);
			this.Controls.Add(this.rtbP);
			this.Controls.Add(this.rtbQ);
			this.DoubleBuffered = true;
			this.Name = "MainForm";
			this.Text = "Factor Semi-prime";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericTimerDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
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
		private System.Windows.Forms.TextBox tbSquareRoot;
        private System.Windows.Forms.TextBox tbSemiPrime0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Timer timerAutoStep;
		private System.Windows.Forms.RichTextBox rtbP;
		private System.Windows.Forms.RichTextBox rtbQ;
		private System.Windows.Forms.RichTextBox rtbProduct;
		private System.Windows.Forms.RichTextBox rtbSemiPrime;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnSaveProgress;
		private System.Windows.Forms.Button btnAutomateSearch;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.NumericUpDown numericTimerDelay;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.RichTextBox rtbDeltaP;
		private System.Windows.Forms.RichTextBox rtbDeltaQ;
		private System.Windows.Forms.RichTextBox rtbDeltaProductPositive;
		private System.Windows.Forms.RichTextBox rtbDeltaGoalPositive;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.RichTextBox rtbDeltaProductNegitive;
		private System.Windows.Forms.RichTextBox rtbDeltaGoalNegative;
		private System.Windows.Forms.TextBox tbNumbersSolved;
		private System.Windows.Forms.Button btnQuadraticResidue;
		private System.Windows.Forms.Timer timerQuadraticSearch;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
	}
}

