namespace neurosim
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
			neurosim.CountDownChart countDownChart2 = new neurosim.CountDownChart();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.btnPauseGo = new System.Windows.Forms.Button();
			this.btnStep = new System.Windows.Forms.Button();
			this.tcTabs = new System.Windows.Forms.TabControl();
			this.tpNeuron = new System.Windows.Forms.TabPage();
			this.lblRprrValue = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tbRprr = new System.Windows.Forms.TrackBar();
			this.lblHpOvershootValue = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbHpOvershoot = new System.Windows.Forms.TrackBar();
			this.lblRrrValue = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tbRrr = new System.Windows.Forms.TrackBar();
			this.lblApValueValue = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbApValue = new System.Windows.Forms.TrackBar();
			this.lblApThresholdValue = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbApThreshold = new System.Windows.Forms.TrackBar();
			this.lblRpValue = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbRp = new System.Windows.Forms.TrackBar();
			this.tpStudy = new System.Windows.Forms.TabPage();
			this.btnRemoveNeuron = new System.Windows.Forms.Button();
			this.btnAddNeuron = new System.Windows.Forms.Button();
			this.dgvStudy = new System.Windows.Forms.DataGridView();
			this.btnCreate = new System.Windows.Forms.Button();
			this.pnlNetwork = new neurosim.Network();
			this.pnlScope = new neurosim.Scope();
			this.tpNetwork = new System.Windows.Forms.TabPage();
			this.menuStrip1.SuspendLayout();
			this.tcTabs.SuspendLayout();
			this.tpNeuron.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbRprr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbHpOvershoot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRrr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApThreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRp)).BeginInit();
			this.tpStudy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudy)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(659, 42);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Scope:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(184, 38);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Neural Network";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1053, 28);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripMenuItem1,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripMenuItem2,
            this.mnuExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// mnuNew
			// 
			this.mnuNew.Name = "mnuNew";
			this.mnuNew.Size = new System.Drawing.Size(129, 24);
			this.mnuNew.Text = "&New";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(126, 6);
			// 
			// mnuOpen
			// 
			this.mnuOpen.Name = "mnuOpen";
			this.mnuOpen.Size = new System.Drawing.Size(129, 24);
			this.mnuOpen.Text = "&Open";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// mnuSave
			// 
			this.mnuSave.Name = "mnuSave";
			this.mnuSave.Size = new System.Drawing.Size(129, 24);
			this.mnuSave.Text = "&Save";
			this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
			// 
			// mnuSaveAs
			// 
			this.mnuSaveAs.Name = "mnuSaveAs";
			this.mnuSaveAs.Size = new System.Drawing.Size(129, 24);
			this.mnuSaveAs.Text = "Save &As";
			this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(126, 6);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(129, 24);
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// btnPauseGo
			// 
			this.btnPauseGo.Location = new System.Drawing.Point(961, 304);
			this.btnPauseGo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnPauseGo.Name = "btnPauseGo";
			this.btnPauseGo.Size = new System.Drawing.Size(75, 23);
			this.btnPauseGo.TabIndex = 5;
			this.btnPauseGo.Text = "Pause";
			this.btnPauseGo.UseVisualStyleBackColor = true;
			this.btnPauseGo.Click += new System.EventHandler(this.btnPauseGo_Click);
			// 
			// btnStep
			// 
			this.btnStep.Location = new System.Drawing.Point(961, 334);
			this.btnStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnStep.Name = "btnStep";
			this.btnStep.Size = new System.Drawing.Size(75, 23);
			this.btnStep.TabIndex = 6;
			this.btnStep.Text = "Step";
			this.btnStep.UseVisualStyleBackColor = true;
			this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
			// 
			// tcTabs
			// 
			this.tcTabs.Controls.Add(this.tpNeuron);
			this.tcTabs.Controls.Add(this.tpStudy);
			this.tcTabs.Controls.Add(this.tpNetwork);
			this.tcTabs.Location = new System.Drawing.Point(16, 366);
			this.tcTabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tcTabs.Name = "tcTabs";
			this.tcTabs.SelectedIndex = 0;
			this.tcTabs.Size = new System.Drawing.Size(1020, 321);
			this.tcTabs.TabIndex = 7;
			// 
			// tpNeuron
			// 
			this.tpNeuron.Controls.Add(this.lblRprrValue);
			this.tpNeuron.Controls.Add(this.label13);
			this.tpNeuron.Controls.Add(this.tbRprr);
			this.tpNeuron.Controls.Add(this.lblHpOvershootValue);
			this.tpNeuron.Controls.Add(this.label9);
			this.tpNeuron.Controls.Add(this.tbHpOvershoot);
			this.tpNeuron.Controls.Add(this.lblRrrValue);
			this.tpNeuron.Controls.Add(this.label11);
			this.tpNeuron.Controls.Add(this.tbRrr);
			this.tpNeuron.Controls.Add(this.lblApValueValue);
			this.tpNeuron.Controls.Add(this.label7);
			this.tpNeuron.Controls.Add(this.tbApValue);
			this.tpNeuron.Controls.Add(this.lblApThresholdValue);
			this.tpNeuron.Controls.Add(this.label5);
			this.tpNeuron.Controls.Add(this.tbApThreshold);
			this.tpNeuron.Controls.Add(this.lblRpValue);
			this.tpNeuron.Controls.Add(this.label3);
			this.tpNeuron.Controls.Add(this.tbRp);
			this.tpNeuron.Location = new System.Drawing.Point(4, 25);
			this.tpNeuron.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpNeuron.Name = "tpNeuron";
			this.tpNeuron.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpNeuron.Size = new System.Drawing.Size(1012, 292);
			this.tpNeuron.TabIndex = 0;
			this.tpNeuron.Text = "Neuron";
			this.tpNeuron.UseVisualStyleBackColor = true;
			// 
			// lblRprrValue
			// 
			this.lblRprrValue.Location = new System.Drawing.Point(388, 258);
			this.lblRprrValue.Name = "lblRprrValue";
			this.lblRprrValue.Size = new System.Drawing.Size(56, 23);
			this.lblRprrValue.TabIndex = 27;
			this.lblRprrValue.Text = "0";
			this.lblRprrValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(376, 27);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(87, 38);
			this.label13.TabIndex = 26;
			this.label13.Text = "RP Return Rate";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbRprr
			// 
			this.tbRprr.Location = new System.Drawing.Point(388, 68);
			this.tbRprr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbRprr.Maximum = 1000;
			this.tbRprr.Minimum = -1000;
			this.tbRprr.Name = "tbRprr";
			this.tbRprr.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRprr.Size = new System.Drawing.Size(56, 188);
			this.tbRprr.TabIndex = 25;
			this.tbRprr.TickFrequency = 200;
			this.tbRprr.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblHpOvershootValue
			// 
			this.lblHpOvershootValue.Location = new System.Drawing.Point(315, 258);
			this.lblHpOvershootValue.Name = "lblHpOvershootValue";
			this.lblHpOvershootValue.Size = new System.Drawing.Size(56, 23);
			this.lblHpOvershootValue.TabIndex = 18;
			this.lblHpOvershootValue.Text = "0";
			this.lblHpOvershootValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(301, 27);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(87, 38);
			this.label9.TabIndex = 17;
			this.label9.Text = "HP Overshoot";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbHpOvershoot
			// 
			this.tbHpOvershoot.Location = new System.Drawing.Point(315, 68);
			this.tbHpOvershoot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbHpOvershoot.Maximum = 1000;
			this.tbHpOvershoot.Minimum = -1000;
			this.tbHpOvershoot.Name = "tbHpOvershoot";
			this.tbHpOvershoot.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbHpOvershoot.Size = new System.Drawing.Size(56, 188);
			this.tbHpOvershoot.TabIndex = 16;
			this.tbHpOvershoot.TickFrequency = 200;
			this.tbHpOvershoot.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblRrrValue
			// 
			this.lblRrrValue.Location = new System.Drawing.Point(240, 258);
			this.lblRrrValue.Name = "lblRrrValue";
			this.lblRrrValue.Size = new System.Drawing.Size(56, 23);
			this.lblRrrValue.TabIndex = 15;
			this.lblRrrValue.Text = "0";
			this.lblRrrValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(228, 27);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(87, 38);
			this.label11.TabIndex = 14;
			this.label11.Text = "Ref. Rec. Rate";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbRrr
			// 
			this.tbRrr.Location = new System.Drawing.Point(240, 68);
			this.tbRrr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbRrr.Maximum = 1000;
			this.tbRrr.Minimum = -1000;
			this.tbRrr.Name = "tbRrr";
			this.tbRrr.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRrr.Size = new System.Drawing.Size(56, 188);
			this.tbRrr.TabIndex = 13;
			this.tbRrr.TickFrequency = 200;
			this.tbRrr.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblApValueValue
			// 
			this.lblApValueValue.Location = new System.Drawing.Point(165, 258);
			this.lblApValueValue.Name = "lblApValueValue";
			this.lblApValueValue.Size = new System.Drawing.Size(56, 23);
			this.lblApValueValue.TabIndex = 9;
			this.lblApValueValue.Text = "0";
			this.lblApValueValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(155, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 38);
			this.label7.TabIndex = 8;
			this.label7.Text = "AP Value";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbApValue
			// 
			this.tbApValue.Location = new System.Drawing.Point(165, 68);
			this.tbApValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbApValue.Maximum = 1000;
			this.tbApValue.Minimum = -1000;
			this.tbApValue.Name = "tbApValue";
			this.tbApValue.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbApValue.Size = new System.Drawing.Size(56, 188);
			this.tbApValue.TabIndex = 7;
			this.tbApValue.TickFrequency = 200;
			this.tbApValue.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblApThresholdValue
			// 
			this.lblApThresholdValue.Location = new System.Drawing.Point(92, 258);
			this.lblApThresholdValue.Name = "lblApThresholdValue";
			this.lblApThresholdValue.Size = new System.Drawing.Size(56, 23);
			this.lblApThresholdValue.TabIndex = 6;
			this.lblApThresholdValue.Text = "0";
			this.lblApThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(80, 27);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 38);
			this.label5.TabIndex = 5;
			this.label5.Text = "AP Threshold";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbApThreshold
			// 
			this.tbApThreshold.Location = new System.Drawing.Point(92, 68);
			this.tbApThreshold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbApThreshold.Maximum = 1000;
			this.tbApThreshold.Minimum = -1000;
			this.tbApThreshold.Name = "tbApThreshold";
			this.tbApThreshold.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbApThreshold.Size = new System.Drawing.Size(56, 188);
			this.tbApThreshold.TabIndex = 4;
			this.tbApThreshold.TickFrequency = 200;
			this.tbApThreshold.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblRpValue
			// 
			this.lblRpValue.Location = new System.Drawing.Point(19, 258);
			this.lblRpValue.Name = "lblRpValue";
			this.lblRpValue.Size = new System.Drawing.Size(56, 23);
			this.lblRpValue.TabIndex = 3;
			this.lblRpValue.Text = "0";
			this.lblRpValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 38);
			this.label3.TabIndex = 2;
			this.label3.Text = "Resting Potential";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbRp
			// 
			this.tbRp.Location = new System.Drawing.Point(19, 68);
			this.tbRp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbRp.Maximum = 1000;
			this.tbRp.Minimum = -1000;
			this.tbRp.Name = "tbRp";
			this.tbRp.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRp.Size = new System.Drawing.Size(56, 188);
			this.tbRp.TabIndex = 1;
			this.tbRp.TickFrequency = 200;
			this.tbRp.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// tpStudy
			// 
			this.tpStudy.Controls.Add(this.btnRemoveNeuron);
			this.tpStudy.Controls.Add(this.btnAddNeuron);
			this.tpStudy.Controls.Add(this.dgvStudy);
			this.tpStudy.Location = new System.Drawing.Point(4, 25);
			this.tpStudy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpStudy.Name = "tpStudy";
			this.tpStudy.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpStudy.Size = new System.Drawing.Size(1012, 292);
			this.tpStudy.TabIndex = 1;
			this.tpStudy.Text = "Study";
			this.tpStudy.UseVisualStyleBackColor = true;
			// 
			// btnRemoveNeuron
			// 
			this.btnRemoveNeuron.Location = new System.Drawing.Point(116, 7);
			this.btnRemoveNeuron.Margin = new System.Windows.Forms.Padding(4);
			this.btnRemoveNeuron.Name = "btnRemoveNeuron";
			this.btnRemoveNeuron.Size = new System.Drawing.Size(100, 28);
			this.btnRemoveNeuron.TabIndex = 2;
			this.btnRemoveNeuron.Text = "Delete";
			this.btnRemoveNeuron.UseVisualStyleBackColor = true;
			this.btnRemoveNeuron.Click += new System.EventHandler(this.btnRemoveNeuron_Click);
			// 
			// btnAddNeuron
			// 
			this.btnAddNeuron.Location = new System.Drawing.Point(8, 7);
			this.btnAddNeuron.Margin = new System.Windows.Forms.Padding(4);
			this.btnAddNeuron.Name = "btnAddNeuron";
			this.btnAddNeuron.Size = new System.Drawing.Size(100, 28);
			this.btnAddNeuron.TabIndex = 1;
			this.btnAddNeuron.Text = "Add Neuron";
			this.btnAddNeuron.UseVisualStyleBackColor = true;
			this.btnAddNeuron.Click += new System.EventHandler(this.btnAddNeuron_Click);
			// 
			// dgvStudy
			// 
			this.dgvStudy.AllowUserToAddRows = false;
			this.dgvStudy.AllowUserToDeleteRows = false;
			this.dgvStudy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvStudy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStudy.Location = new System.Drawing.Point(8, 38);
			this.dgvStudy.Margin = new System.Windows.Forms.Padding(4);
			this.dgvStudy.Name = "dgvStudy";
			this.dgvStudy.RowHeadersVisible = false;
			this.dgvStudy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvStudy.Size = new System.Drawing.Size(995, 245);
			this.dgvStudy.TabIndex = 0;
			this.dgvStudy.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudy_CellEndEdit);
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(961, 265);
			this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// pnlNetwork
			// 
			this.pnlNetwork.Chart = countDownChart2;
			this.pnlNetwork.Location = new System.Drawing.Point(16, 62);
			this.pnlNetwork.Margin = new System.Windows.Forms.Padding(4);
			this.pnlNetwork.Name = "pnlNetwork";
			this.pnlNetwork.Size = new System.Drawing.Size(461, 295);
			this.pnlNetwork.TabIndex = 2;
			// 
			// pnlScope
			// 
			this.pnlScope.Location = new System.Drawing.Point(485, 62);
			this.pnlScope.Margin = new System.Windows.Forms.Padding(4);
			this.pnlScope.Name = "pnlScope";
			this.pnlScope.Size = new System.Drawing.Size(400, 295);
			this.pnlScope.TabIndex = 1;
			// 
			// tpNetwork
			// 
			this.tpNetwork.Location = new System.Drawing.Point(4, 25);
			this.tpNetwork.Name = "tpNetwork";
			this.tpNetwork.Size = new System.Drawing.Size(1012, 292);
			this.tpNetwork.TabIndex = 2;
			this.tpNetwork.Text = "Network";
			this.tpNetwork.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1053, 698);
			this.Controls.Add(this.tcTabs);
			this.Controls.Add(this.btnStep);
			this.Controls.Add(this.btnPauseGo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnlNetwork);
			this.Controls.Add(this.pnlScope);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.btnCreate);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NeuroSim";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tcTabs.ResumeLayout(false);
			this.tpNeuron.ResumeLayout(false);
			this.tpNeuron.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbRprr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbHpOvershoot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRrr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApThreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRp)).EndInit();
			this.tpStudy.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStudy)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private Scope pnlScope;
		private Network pnlNetwork;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuNew;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuSave;
		private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.Button btnPauseGo;
		private System.Windows.Forms.Button btnStep;
		private System.Windows.Forms.TabControl tcTabs;
		private System.Windows.Forms.TabPage tpNeuron;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.TabPage tpStudy;
		private System.Windows.Forms.Label lblRprrValue;
		private System.Windows.Forms.TrackBar tbRprr;
		private System.Windows.Forms.Label lblHpOvershootValue;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TrackBar tbHpOvershoot;
		private System.Windows.Forms.Label lblRrrValue;
		private System.Windows.Forms.TrackBar tbRrr;
		private System.Windows.Forms.Label lblApValueValue;
		private System.Windows.Forms.TrackBar tbApValue;
		private System.Windows.Forms.Label lblApThresholdValue;
		private System.Windows.Forms.TrackBar tbApThreshold;
		private System.Windows.Forms.Label lblRpValue;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar tbRp;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGridView dgvStudy;
		private System.Windows.Forms.Button btnRemoveNeuron;
		private System.Windows.Forms.Button btnAddNeuron;
		private System.Windows.Forms.TabPage tpNetwork;
	}
}

