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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
			this.rtbDeltaProductPositive = new System.Windows.Forms.RichTextBox();
			this.rtbDeltaGoalPositive = new System.Windows.Forms.RichTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.rtbDeltaProductNegitive = new System.Windows.Forms.RichTextBox();
			this.rtbDeltaGoalNegative = new System.Windows.Forms.RichTextBox();
			this.btnQuadraticResidue = new System.Windows.Forms.Button();
			this.timerQuadraticSearch = new System.Windows.Forms.Timer(this.components);
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label12 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.cbClearChart = new System.Windows.Forms.CheckBox();
			this.btnStep1 = new System.Windows.Forms.Button();
			this.numericStepSize = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.tbGraphClickLocation = new System.Windows.Forms.TextBox();
			this.tbList1 = new System.Windows.Forms.TextBox();
			this.tbList2 = new System.Windows.Forms.TextBox();
			this.tbList3 = new System.Windows.Forms.TextBox();
			this.tbList4 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.btnDisplayMax = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQ)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericTimerDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericStepSize)).BeginInit();
			this.SuspendLayout();
			// 
			// tbSemiPrime
			// 
			this.tbSemiPrime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSemiPrime.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSemiPrime.Location = new System.Drawing.Point(6, 20);
			this.tbSemiPrime.Margin = new System.Windows.Forms.Padding(0);
			this.tbSemiPrime.Multiline = true;
			this.tbSemiPrime.Name = "tbSemiPrime";
			this.tbSemiPrime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSemiPrime.Size = new System.Drawing.Size(544, 41);
			this.tbSemiPrime.TabIndex = 0;
			this.tbSemiPrime.Text = "\r\n";
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
			this.label3.Location = new System.Drawing.Point(6, 172);
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
			this.label4.Location = new System.Drawing.Point(20, 121);
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
			this.label5.Location = new System.Drawing.Point(20, 141);
			this.label5.Margin = new System.Windows.Forms.Padding(0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 14);
			this.label5.TabIndex = 4;
			this.label5.Text = "Q";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDownP
			// 
			this.numericUpDownP.Location = new System.Drawing.Point(548, 118);
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
			this.numericUpDownQ.Location = new System.Drawing.Point(548, 138);
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
			this.tbSquareRoot.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSquareRoot.HideSelection = false;
			this.tbSquareRoot.Location = new System.Drawing.Point(38, 86);
			this.tbSquareRoot.Margin = new System.Windows.Forms.Padding(0);
			this.tbSquareRoot.Name = "tbSquareRoot";
			this.tbSquareRoot.Size = new System.Drawing.Size(512, 18);
			this.tbSquareRoot.TabIndex = 14;
			// 
			// tbSemiPrime0
			// 
			this.tbSemiPrime0.BackColor = System.Drawing.Color.Silver;
			this.tbSemiPrime0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSemiPrime0.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbSemiPrime0.HideSelection = false;
			this.tbSemiPrime0.Location = new System.Drawing.Point(38, 63);
			this.tbSemiPrime0.Margin = new System.Windows.Forms.Padding(0);
			this.tbSemiPrime0.Name = "tbSemiPrime0";
			this.tbSemiPrime0.ReadOnly = true;
			this.tbSemiPrime0.Size = new System.Drawing.Size(512, 18);
			this.tbSemiPrime0.TabIndex = 18;
			this.tbSemiPrime0.WordWrap = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Consolas", 9F);
			this.label6.Location = new System.Drawing.Point(20, 199);
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
			this.rtbP.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbP.HideSelection = false;
			this.rtbP.Location = new System.Drawing.Point(38, 118);
			this.rtbP.Margin = new System.Windows.Forms.Padding(0);
			this.rtbP.Multiline = false;
			this.rtbP.Name = "rtbP";
			this.rtbP.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbP.Size = new System.Drawing.Size(510, 20);
			this.rtbP.TabIndex = 30;
			this.rtbP.Text = "";
			this.rtbP.WordWrap = false;
			// 
			// rtbQ
			// 
			this.rtbQ.BackColor = System.Drawing.SystemColors.Control;
			this.rtbQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbQ.DetectUrls = false;
			this.rtbQ.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbQ.HideSelection = false;
			this.rtbQ.Location = new System.Drawing.Point(38, 138);
			this.rtbQ.Margin = new System.Windows.Forms.Padding(0);
			this.rtbQ.Multiline = false;
			this.rtbQ.Name = "rtbQ";
			this.rtbQ.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbQ.Size = new System.Drawing.Size(510, 20);
			this.rtbQ.TabIndex = 31;
			this.rtbQ.Text = "";
			this.rtbQ.WordWrap = false;
			// 
			// rtbProduct
			// 
			this.rtbProduct.BackColor = System.Drawing.SystemColors.Control;
			this.rtbProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbProduct.DetectUrls = false;
			this.rtbProduct.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbProduct.HideSelection = false;
			this.rtbProduct.Location = new System.Drawing.Point(38, 158);
			this.rtbProduct.Margin = new System.Windows.Forms.Padding(0);
			this.rtbProduct.Multiline = false;
			this.rtbProduct.Name = "rtbProduct";
			this.rtbProduct.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbProduct.Size = new System.Drawing.Size(526, 38);
			this.rtbProduct.TabIndex = 35;
			this.rtbProduct.Text = "";
			this.rtbProduct.WordWrap = false;
			// 
			// rtbSemiPrime
			// 
			this.rtbSemiPrime.BackColor = System.Drawing.SystemColors.Control;
			this.rtbSemiPrime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtbSemiPrime.DetectUrls = false;
			this.rtbSemiPrime.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbSemiPrime.HideSelection = false;
			this.rtbSemiPrime.Location = new System.Drawing.Point(38, 196);
			this.rtbSemiPrime.Margin = new System.Windows.Forms.Padding(0);
			this.rtbSemiPrime.Multiline = false;
			this.rtbSemiPrime.Name = "rtbSemiPrime";
			this.rtbSemiPrime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbSemiPrime.Size = new System.Drawing.Size(526, 20);
			this.rtbSemiPrime.TabIndex = 36;
			this.rtbSemiPrime.Text = "";
			this.rtbSemiPrime.WordWrap = false;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(452, 415);
			this.btnReset.Margin = new System.Windows.Forms.Padding(1);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(114, 23);
			this.btnReset.TabIndex = 46;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// btnSaveProgress
			// 
			this.btnSaveProgress.Location = new System.Drawing.Point(454, 236);
			this.btnSaveProgress.Name = "btnSaveProgress";
			this.btnSaveProgress.Size = new System.Drawing.Size(112, 23);
			this.btnSaveProgress.TabIndex = 44;
			this.btnSaveProgress.Text = "Save Progress...";
			this.btnSaveProgress.UseVisualStyleBackColor = true;
			// 
			// btnAutomateSearch
			// 
			this.btnAutomateSearch.Location = new System.Drawing.Point(456, 392);
			this.btnAutomateSearch.Margin = new System.Windows.Forms.Padding(1);
			this.btnAutomateSearch.Name = "btnAutomateSearch";
			this.btnAutomateSearch.Size = new System.Drawing.Size(98, 23);
			this.btnAutomateSearch.TabIndex = 43;
			this.btnAutomateSearch.Text = "Auto search";
			this.btnAutomateSearch.UseVisualStyleBackColor = true;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(454, 216);
			this.btnOpen.Margin = new System.Windows.Forms.Padding(1);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(112, 23);
			this.btnOpen.TabIndex = 45;
			this.btnOpen.Text = "Open Progress...";
			this.btnOpen.UseVisualStyleBackColor = true;
			// 
			// numericTimerDelay
			// 
			this.numericTimerDelay.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.numericTimerDelay.Location = new System.Drawing.Point(496, 323);
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
			this.numericTimerDelay.Size = new System.Drawing.Size(69, 20);
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
			this.label16.Location = new System.Drawing.Point(496, 344);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(70, 11);
			this.label16.TabIndex = 58;
			this.label16.Text = "Delay (ms)";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rtbDeltaProductPositive
			// 
			this.rtbDeltaProductPositive.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaProductPositive.DetectUrls = false;
			this.rtbDeltaProductPositive.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaProductPositive.HideSelection = false;
			this.rtbDeltaProductPositive.Location = new System.Drawing.Point(0, 260);
			this.rtbDeltaProductPositive.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaProductPositive.Multiline = false;
			this.rtbDeltaProductPositive.Name = "rtbDeltaProductPositive";
			this.rtbDeltaProductPositive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaProductPositive.Size = new System.Drawing.Size(240, 20);
			this.rtbDeltaProductPositive.TabIndex = 41;
			this.rtbDeltaProductPositive.Text = "";
			this.rtbDeltaProductPositive.WordWrap = false;
			// 
			// rtbDeltaGoalPositive
			// 
			this.rtbDeltaGoalPositive.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaGoalPositive.DetectUrls = false;
			this.rtbDeltaGoalPositive.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaGoalPositive.HideSelection = false;
			this.rtbDeltaGoalPositive.Location = new System.Drawing.Point(0, 280);
			this.rtbDeltaGoalPositive.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaGoalPositive.Multiline = false;
			this.rtbDeltaGoalPositive.Name = "rtbDeltaGoalPositive";
			this.rtbDeltaGoalPositive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaGoalPositive.Size = new System.Drawing.Size(240, 20);
			this.rtbDeltaGoalPositive.TabIndex = 42;
			this.rtbDeltaGoalPositive.Text = "";
			this.rtbDeltaGoalPositive.WordWrap = false;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(92, 243);
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
			this.label11.Location = new System.Drawing.Point(100, 300);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(49, 14);
			this.label11.TabIndex = 50;
			this.label11.Text = "Δ(Φ) ↑";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// rtbDeltaProductNegitive
			// 
			this.rtbDeltaProductNegitive.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaProductNegitive.DetectUrls = false;
			this.rtbDeltaProductNegitive.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaProductNegitive.HideSelection = false;
			this.rtbDeltaProductNegitive.Location = new System.Drawing.Point(240, 260);
			this.rtbDeltaProductNegitive.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaProductNegitive.Multiline = false;
			this.rtbDeltaProductNegitive.Name = "rtbDeltaProductNegitive";
			this.rtbDeltaProductNegitive.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaProductNegitive.Size = new System.Drawing.Size(240, 20);
			this.rtbDeltaProductNegitive.TabIndex = 51;
			this.rtbDeltaProductNegitive.Text = "";
			this.rtbDeltaProductNegitive.WordWrap = false;
			// 
			// rtbDeltaGoalNegative
			// 
			this.rtbDeltaGoalNegative.BackColor = System.Drawing.SystemColors.Control;
			this.rtbDeltaGoalNegative.DetectUrls = false;
			this.rtbDeltaGoalNegative.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbDeltaGoalNegative.HideSelection = false;
			this.rtbDeltaGoalNegative.Location = new System.Drawing.Point(240, 280);
			this.rtbDeltaGoalNegative.Margin = new System.Windows.Forms.Padding(0);
			this.rtbDeltaGoalNegative.Multiline = false;
			this.rtbDeltaGoalNegative.Name = "rtbDeltaGoalNegative";
			this.rtbDeltaGoalNegative.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.rtbDeltaGoalNegative.Size = new System.Drawing.Size(240, 20);
			this.rtbDeltaGoalNegative.TabIndex = 52;
			this.rtbDeltaGoalNegative.Text = "";
			this.rtbDeltaGoalNegative.WordWrap = false;
			// 
			// btnQuadraticResidue
			// 
			this.btnQuadraticResidue.Location = new System.Drawing.Point(38, 216);
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
			chartArea1.Area3DStyle.WallWidth = 0;
			chartArea1.AxisX.IsLabelAutoFit = false;
			chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.AxisX.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.Wave;
			chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
			chartArea1.AxisX.ScaleBreakStyle.Spacing = 1D;
			chartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea1.AxisX2.IsLabelAutoFit = false;
			chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8F, System.Drawing.FontStyle.Bold);
			chartArea1.AxisX2.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisX2.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.Wave;
			chartArea1.AxisX2.ScaleBreakStyle.Enabled = true;
			chartArea1.AxisX2.ScaleBreakStyle.Spacing = 1D;
			chartArea1.AxisX2.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.Maroon;
			chartArea1.AxisY.IsLabelAutoFit = false;
			chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8F);
			chartArea1.AxisY.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.Wave;
			chartArea1.AxisY.ScaleBreakStyle.Enabled = true;
			chartArea1.AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 3;
			chartArea1.AxisY.ScaleBreakStyle.Spacing = 1D;
			chartArea1.AxisY.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea1.AxisY2.IsLabelAutoFit = false;
			chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Cambria Math", 8F);
			chartArea1.AxisY2.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.LightGray;
			chartArea1.AxisY2.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.Wave;
			chartArea1.AxisY2.ScaleBreakStyle.Enabled = true;
			chartArea1.AxisY2.ScaleBreakStyle.MaxNumberOfBreaks = 3;
			chartArea1.AxisY2.ScaleBreakStyle.Spacing = 1D;
			chartArea1.AxisY2.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
			chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.Maroon;
			chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
			chartArea1.BorderColor = System.Drawing.Color.DarkGray;
			chartArea1.BorderWidth = 0;
			chartArea1.CursorX.IsUserEnabled = true;
			chartArea1.CursorX.IsUserSelectionEnabled = true;
			chartArea1.CursorX.LineColor = System.Drawing.Color.GreenYellow;
			chartArea1.CursorX.SelectionColor = System.Drawing.Color.LightCyan;
			chartArea1.CursorY.IsUserEnabled = true;
			chartArea1.CursorY.IsUserSelectionEnabled = true;
			chartArea1.CursorY.LineColor = System.Drawing.Color.GreenYellow;
			chartArea1.CursorY.SelectionColor = System.Drawing.Color.LightCyan;
			chartArea1.Name = "ChartArea1";
			chartArea1.Position.Auto = false;
			chartArea1.Position.Height = 100F;
			chartArea1.Position.Width = 100F;
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
			this.chart1.IsSoftShadows = false;
			this.chart1.Location = new System.Drawing.Point(568, 3);
			this.chart1.Margin = new System.Windows.Forms.Padding(0);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
			series1.Name = "Series1";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
			series2.Name = "Series2";
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.Size = new System.Drawing.Size(474, 606);
			this.chart1.SuppressExceptions = true;
			this.chart1.TabIndex = 64;
			this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
			this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(332, 246);
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
			this.label14.Location = new System.Drawing.Point(340, 300);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(48, 14);
			this.label14.TabIndex = 66;
			this.label14.Text = "Δ(Φ) ￬";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(403, 3);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(150, 13);
			this.label13.TabIndex = 67;
			this.label13.Text = "(Ctrl+P to save image of Chart)";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbClearChart
			// 
			this.cbClearChart.AutoSize = true;
			this.cbClearChart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cbClearChart.Checked = true;
			this.cbClearChart.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbClearChart.Location = new System.Drawing.Point(452, 304);
			this.cbClearChart.Name = "cbClearChart";
			this.cbClearChart.Size = new System.Drawing.Size(115, 17);
			this.cbClearChart.TabIndex = 68;
			this.cbClearChart.Text = "Clear chart on start";
			this.cbClearChart.UseVisualStyleBackColor = true;
			// 
			// btnStep1
			// 
			this.btnStep1.Location = new System.Drawing.Point(553, 392);
			this.btnStep1.Margin = new System.Windows.Forms.Padding(1);
			this.btnStep1.Name = "btnStep1";
			this.btnStep1.Size = new System.Drawing.Size(12, 23);
			this.btnStep1.TabIndex = 69;
			this.btnStep1.Text = "1";
			this.btnStep1.UseVisualStyleBackColor = true;
			// 
			// numericStepSize
			// 
			this.numericStepSize.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.numericStepSize.Location = new System.Drawing.Point(496, 359);
			this.numericStepSize.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
			this.numericStepSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericStepSize.Name = "numericStepSize";
			this.numericStepSize.Size = new System.Drawing.Size(70, 20);
			this.numericStepSize.TabIndex = 70;
			this.numericStepSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericStepSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericStepSize.ValueChanged += new System.EventHandler(this.numericStepSize_ValueChanged);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Consolas", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(496, 380);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 11);
			this.label8.TabIndex = 71;
			this.label8.Text = "Step Size";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbOutput.Location = new System.Drawing.Point(456, 440);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(108, 241);
			this.tbOutput.TabIndex = 72;
			// 
			// tbGraphClickLocation
			// 
			this.tbGraphClickLocation.Location = new System.Drawing.Point(0, 320);
			this.tbGraphClickLocation.Multiline = true;
			this.tbGraphClickLocation.Name = "tbGraphClickLocation";
			this.tbGraphClickLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbGraphClickLocation.Size = new System.Drawing.Size(496, 40);
			this.tbGraphClickLocation.TabIndex = 73;
			// 
			// tbList1
			// 
			this.tbList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbList1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbList1.Location = new System.Drawing.Point(0, 360);
			this.tbList1.Multiline = true;
			this.tbList1.Name = "tbList1";
			this.tbList1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbList1.Size = new System.Drawing.Size(112, 249);
			this.tbList1.TabIndex = 74;
			// 
			// tbList2
			// 
			this.tbList2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbList2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbList2.Location = new System.Drawing.Point(112, 360);
			this.tbList2.Multiline = true;
			this.tbList2.Name = "tbList2";
			this.tbList2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbList2.Size = new System.Drawing.Size(112, 249);
			this.tbList2.TabIndex = 75;
			// 
			// tbList3
			// 
			this.tbList3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbList3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbList3.Location = new System.Drawing.Point(228, 360);
			this.tbList3.Multiline = true;
			this.tbList3.Name = "tbList3";
			this.tbList3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbList3.Size = new System.Drawing.Size(112, 249);
			this.tbList3.TabIndex = 76;
			// 
			// tbList4
			// 
			this.tbList4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbList4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbList4.Location = new System.Drawing.Point(344, 360);
			this.tbList4.Multiline = true;
			this.tbList4.Name = "tbList4";
			this.tbList4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbList4.Size = new System.Drawing.Size(112, 249);
			this.tbList4.TabIndex = 77;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 78;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btnDisplayMax
			// 
			this.btnDisplayMax.Location = new System.Drawing.Point(488, 268);
			this.btnDisplayMax.Name = "btnDisplayMax";
			this.btnDisplayMax.Size = new System.Drawing.Size(75, 23);
			this.btnDisplayMax.TabIndex = 79;
			this.btnDisplayMax.Text = "Display Max";
			this.btnDisplayMax.UseVisualStyleBackColor = true;
			this.btnDisplayMax.Click += new System.EventHandler(this.btnDisplayMax_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1044, 611);
			this.Controls.Add(this.btnDisplayMax);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbList4);
			this.Controls.Add(this.tbList3);
			this.Controls.Add(this.tbList2);
			this.Controls.Add(this.tbList1);
			this.Controls.Add(this.tbGraphClickLocation);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.numericStepSize);
			this.Controls.Add(this.btnStep1);
			this.Controls.Add(this.cbClearChart);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.btnQuadraticResidue);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.numericTimerDelay);
			this.Controls.Add(this.rtbDeltaGoalNegative);
			this.Controls.Add(this.rtbDeltaProductNegitive);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnSaveProgress);
			this.Controls.Add(this.btnAutomateSearch);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.rtbDeltaGoalPositive);
			this.Controls.Add(this.rtbDeltaProductPositive);
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
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQ)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericTimerDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericStepSize)).EndInit();
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
		private System.Windows.Forms.RichTextBox rtbDeltaProductPositive;
		private System.Windows.Forms.RichTextBox rtbDeltaGoalPositive;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.RichTextBox rtbDeltaProductNegitive;
		private System.Windows.Forms.RichTextBox rtbDeltaGoalNegative;
		private System.Windows.Forms.Button btnQuadraticResidue;
		private System.Windows.Forms.Timer timerQuadraticSearch;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox cbClearChart;
		private System.Windows.Forms.Button btnStep1;
		private System.Windows.Forms.NumericUpDown numericStepSize;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TextBox tbGraphClickLocation;
        private System.Windows.Forms.TextBox tbList1;
        private System.Windows.Forms.TextBox tbList2;
        private System.Windows.Forms.TextBox tbList3;
        private System.Windows.Forms.TextBox tbList4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnDisplayMax;
	}
}

