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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnCreate = new System.Windows.Forms.Button();
			this.pnlNetwork = new neurosim.Network();
			this.pnlScope = new neurosim.Scope();
			this.tbRp = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.lblRpValue = new System.Windows.Forms.Label();
			this.lblApThresholdValue = new System.Windows.Forms.Label();
			this.tbApThreshold = new System.Windows.Forms.TrackBar();
			this.lblApValueValue = new System.Windows.Forms.Label();
			this.tbApValue = new System.Windows.Forms.TrackBar();
			this.lblHpOvershootValue = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbHpOvershoot = new System.Windows.Forms.TrackBar();
			this.lblRrrValue = new System.Windows.Forms.Label();
			this.tbRrr = new System.Windows.Forms.TrackBar();
			this.lblRprrValue = new System.Windows.Forms.Label();
			this.tbRprr = new System.Windows.Forms.TrackBar();
			this.lblPsapValue = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.tbPsap = new System.Windows.Forms.TrackBar();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbRp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApThreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbHpOvershoot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRrr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRprr)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbPsap)).BeginInit();
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
			this.menuStrip1.Size = new System.Drawing.Size(897, 28);
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
			this.btnPauseGo.Location = new System.Drawing.Point(810, 364);
			this.btnPauseGo.Name = "btnPauseGo";
			this.btnPauseGo.Size = new System.Drawing.Size(75, 23);
			this.btnPauseGo.TabIndex = 5;
			this.btnPauseGo.Text = "Pause";
			this.btnPauseGo.UseVisualStyleBackColor = true;
			this.btnPauseGo.Click += new System.EventHandler(this.btnPauseGo_Click);
			// 
			// btnStep
			// 
			this.btnStep.Location = new System.Drawing.Point(810, 394);
			this.btnStep.Name = "btnStep";
			this.btnStep.Size = new System.Drawing.Size(75, 23);
			this.btnStep.TabIndex = 6;
			this.btnStep.Text = "Step";
			this.btnStep.UseVisualStyleBackColor = true;
			this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(16, 365);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(773, 321);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lblPsapValue);
			this.tabPage1.Controls.Add(this.label21);
			this.tabPage1.Controls.Add(this.tbPsap);
			this.tabPage1.Controls.Add(this.lblRprrValue);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.tbRprr);
			this.tabPage1.Controls.Add(this.lblHpOvershootValue);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.tbHpOvershoot);
			this.tabPage1.Controls.Add(this.lblRrrValue);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.tbRrr);
			this.tabPage1.Controls.Add(this.lblApValueValue);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.tbApValue);
			this.tabPage1.Controls.Add(this.lblApThresholdValue);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.tbApThreshold);
			this.tabPage1.Controls.Add(this.lblRpValue);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.tbRp);
			this.tabPage1.Controls.Add(this.btnCreate);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(765, 292);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Network";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(765, 292);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Study";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(684, 6);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 23);
			this.btnCreate.TabIndex = 0;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			// 
			// pnlNetwork
			// 
			this.pnlNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			// tbRp
			// 
			this.tbRp.Location = new System.Drawing.Point(18, 68);
			this.tbRp.Maximum = 1000;
			this.tbRp.Minimum = -1000;
			this.tbRp.Name = "tbRp";
			this.tbRp.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRp.Size = new System.Drawing.Size(56, 188);
			this.tbRp.TabIndex = 1;
			this.tbRp.TickFrequency = 200;
			this.tbRp.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 38);
			this.label3.TabIndex = 2;
			this.label3.Text = "Resting Potential";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblRpValue
			// 
			this.lblRpValue.Location = new System.Drawing.Point(18, 259);
			this.lblRpValue.Name = "lblRpValue";
			this.lblRpValue.Size = new System.Drawing.Size(56, 23);
			this.lblRpValue.TabIndex = 3;
			this.lblRpValue.Text = "0";
			this.lblRpValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblApThresholdValue
			// 
			this.lblApThresholdValue.Location = new System.Drawing.Point(92, 259);
			this.lblApThresholdValue.Name = "lblApThresholdValue";
			this.lblApThresholdValue.Size = new System.Drawing.Size(56, 23);
			this.lblApThresholdValue.TabIndex = 6;
			this.lblApThresholdValue.Text = "0";
			this.lblApThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbApThreshold
			// 
			this.tbApThreshold.Location = new System.Drawing.Point(92, 68);
			this.tbApThreshold.Maximum = 1000;
			this.tbApThreshold.Minimum = -1000;
			this.tbApThreshold.Name = "tbApThreshold";
			this.tbApThreshold.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbApThreshold.Size = new System.Drawing.Size(56, 188);
			this.tbApThreshold.TabIndex = 4;
			this.tbApThreshold.TickFrequency = 200;
			this.tbApThreshold.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblApValueValue
			// 
			this.lblApValueValue.Location = new System.Drawing.Point(166, 259);
			this.lblApValueValue.Name = "lblApValueValue";
			this.lblApValueValue.Size = new System.Drawing.Size(56, 23);
			this.lblApValueValue.TabIndex = 9;
			this.lblApValueValue.Text = "0";
			this.lblApValueValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbApValue
			// 
			this.tbApValue.Location = new System.Drawing.Point(166, 68);
			this.tbApValue.Maximum = 1000;
			this.tbApValue.Minimum = -1000;
			this.tbApValue.Name = "tbApValue";
			this.tbApValue.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbApValue.Size = new System.Drawing.Size(56, 188);
			this.tbApValue.TabIndex = 7;
			this.tbApValue.TickFrequency = 200;
			this.tbApValue.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblHpOvershootValue
			// 
			this.lblHpOvershootValue.Location = new System.Drawing.Point(314, 259);
			this.lblHpOvershootValue.Name = "lblHpOvershootValue";
			this.lblHpOvershootValue.Size = new System.Drawing.Size(56, 23);
			this.lblHpOvershootValue.TabIndex = 18;
			this.lblHpOvershootValue.Text = "0";
			this.lblHpOvershootValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(302, 27);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(87, 38);
			this.label9.TabIndex = 17;
			this.label9.Text = "HP Overshoot";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tbHpOvershoot
			// 
			this.tbHpOvershoot.Location = new System.Drawing.Point(314, 68);
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
			this.lblRrrValue.Location = new System.Drawing.Point(240, 259);
			this.lblRrrValue.Name = "lblRrrValue";
			this.lblRrrValue.Size = new System.Drawing.Size(56, 23);
			this.lblRrrValue.TabIndex = 15;
			this.lblRrrValue.Text = "0";
			this.lblRrrValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbRrr
			// 
			this.tbRrr.Location = new System.Drawing.Point(240, 68);
			this.tbRrr.Maximum = 1000;
			this.tbRrr.Minimum = -1000;
			this.tbRrr.Name = "tbRrr";
			this.tbRrr.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRrr.Size = new System.Drawing.Size(56, 188);
			this.tbRrr.TabIndex = 13;
			this.tbRrr.TickFrequency = 200;
			this.tbRrr.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblRprrValue
			// 
			this.lblRprrValue.Location = new System.Drawing.Point(388, 259);
			this.lblRprrValue.Name = "lblRprrValue";
			this.lblRprrValue.Size = new System.Drawing.Size(56, 23);
			this.lblRprrValue.TabIndex = 27;
			this.lblRprrValue.Text = "0";
			this.lblRprrValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbRprr
			// 
			this.tbRprr.Location = new System.Drawing.Point(388, 68);
			this.tbRprr.Maximum = 1000;
			this.tbRprr.Minimum = -1000;
			this.tbRprr.Name = "tbRprr";
			this.tbRprr.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbRprr.Size = new System.Drawing.Size(56, 188);
			this.tbRprr.TabIndex = 25;
			this.tbRprr.TickFrequency = 200;
			this.tbRprr.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lblPsapValue
			// 
			this.lblPsapValue.Location = new System.Drawing.Point(462, 259);
			this.lblPsapValue.Name = "lblPsapValue";
			this.lblPsapValue.Size = new System.Drawing.Size(56, 23);
			this.lblPsapValue.TabIndex = 33;
			this.lblPsapValue.Text = "0";
			this.lblPsapValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(450, 27);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(87, 38);
			this.label21.TabIndex = 32;
			this.label21.Text = "PS AP";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbPsap
			// 
			this.tbPsap.Location = new System.Drawing.Point(462, 68);
			this.tbPsap.Maximum = 1000;
			this.tbPsap.Minimum = -1000;
			this.tbPsap.Name = "tbPsap";
			this.tbPsap.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.tbPsap.Size = new System.Drawing.Size(56, 188);
			this.tbPsap.TabIndex = 31;
			this.tbPsap.TickFrequency = 200;
			this.tbPsap.TickStyle = System.Windows.Forms.TickStyle.Both;
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
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(228, 27);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(87, 38);
			this.label11.TabIndex = 14;
			this.label11.Text = "Ref. Rec. Rate";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(154, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 38);
			this.label7.TabIndex = 8;
			this.label7.Text = "AP Value";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(897, 698);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnStep);
			this.Controls.Add(this.btnPauseGo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnlNetwork);
			this.Controls.Add(this.pnlScope);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NeuroSim";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbRp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApThreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbApValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbHpOvershoot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRrr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRprr)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbPsap)).EndInit();
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
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label lblPsapValue;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TrackBar tbPsap;
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
	}
}

