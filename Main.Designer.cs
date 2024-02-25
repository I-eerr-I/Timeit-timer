namespace Timeit
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutTimeouts = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTimeoutsMore = new System.Windows.Forms.Button();
            this.buttonTimeoutsLess = new System.Windows.Forms.Button();
            this.labelTimeoutsCounter = new System.Windows.Forms.Label();
            this.tableLayoutTitleBar = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.trackBarMinOpacity = new System.Windows.Forms.TrackBar();
            this.tableLayoutTimer = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSeconds = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelTimerSeparator = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.textBoxMinutes = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerTimeoutAnimation = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerFadingAnimation = new System.Windows.Forms.Timer(this.components);
            this.toolTipOpacity = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutTimeouts.SuspendLayout();
            this.tableLayoutTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMinOpacity)).BeginInit();
            this.tableLayoutTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 1;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.Controls.Add(this.tableLayoutTimeouts, 0, 2);
            this.tableLayoutMain.Controls.Add(this.tableLayoutTitleBar, 0, 0);
            this.tableLayoutMain.Controls.Add(this.tableLayoutTimer, 0, 1);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutMain.Size = new System.Drawing.Size(180, 100);
            this.tableLayoutMain.TabIndex = 0;
            this.tableLayoutMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseDown);
            this.tableLayoutMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseMove);
            this.tableLayoutMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseUp);
            // 
            // tableLayoutTimeouts
            // 
            this.tableLayoutTimeouts.ColumnCount = 3;
            this.tableLayoutTimeouts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutTimeouts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutTimeouts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutTimeouts.Controls.Add(this.buttonTimeoutsMore, 2, 0);
            this.tableLayoutTimeouts.Controls.Add(this.buttonTimeoutsLess, 0, 0);
            this.tableLayoutTimeouts.Controls.Add(this.labelTimeoutsCounter, 1, 0);
            this.tableLayoutTimeouts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTimeouts.Location = new System.Drawing.Point(0, 73);
            this.tableLayoutTimeouts.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutTimeouts.Name = "tableLayoutTimeouts";
            this.tableLayoutTimeouts.RowCount = 1;
            this.tableLayoutTimeouts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTimeouts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutTimeouts.Size = new System.Drawing.Size(180, 27);
            this.tableLayoutTimeouts.TabIndex = 3;
            // 
            // buttonTimeoutsMore
            // 
            this.buttonTimeoutsMore.BackgroundImage = global::Timeit.Properties.Resources.arrow_right;
            this.buttonTimeoutsMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonTimeoutsMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonTimeoutsMore.FlatAppearance.BorderSize = 0;
            this.buttonTimeoutsMore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.buttonTimeoutsMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.buttonTimeoutsMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTimeoutsMore.Location = new System.Drawing.Point(136, 0);
            this.buttonTimeoutsMore.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTimeoutsMore.Name = "buttonTimeoutsMore";
            this.buttonTimeoutsMore.Size = new System.Drawing.Size(44, 27);
            this.buttonTimeoutsMore.TabIndex = 3;
            this.buttonTimeoutsMore.TabStop = false;
            this.buttonTimeoutsMore.UseVisualStyleBackColor = true;
            this.buttonTimeoutsMore.Visible = false;
            this.buttonTimeoutsMore.Click += new System.EventHandler(this.buttonTimeoutsMore_Click);
            this.buttonTimeoutsMore.MouseEnter += new System.EventHandler(this.buttonTimeoutsMore_MouseEnter);
            this.buttonTimeoutsMore.MouseLeave += new System.EventHandler(this.buttonTimeoutsMore_MouseLeave);
            // 
            // buttonTimeoutsLess
            // 
            this.buttonTimeoutsLess.BackgroundImage = global::Timeit.Properties.Resources.arrow_left;
            this.buttonTimeoutsLess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonTimeoutsLess.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonTimeoutsLess.FlatAppearance.BorderSize = 0;
            this.buttonTimeoutsLess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.buttonTimeoutsLess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.buttonTimeoutsLess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTimeoutsLess.Location = new System.Drawing.Point(0, 0);
            this.buttonTimeoutsLess.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTimeoutsLess.Name = "buttonTimeoutsLess";
            this.buttonTimeoutsLess.Size = new System.Drawing.Size(43, 27);
            this.buttonTimeoutsLess.TabIndex = 2;
            this.buttonTimeoutsLess.TabStop = false;
            this.buttonTimeoutsLess.UseVisualStyleBackColor = true;
            this.buttonTimeoutsLess.Visible = false;
            this.buttonTimeoutsLess.Click += new System.EventHandler(this.buttonTimeoutsLess_Click);
            this.buttonTimeoutsLess.MouseEnter += new System.EventHandler(this.buttonTimeoutsLess_MouseEnter);
            this.buttonTimeoutsLess.MouseLeave += new System.EventHandler(this.buttonTimeoutsLess_MouseLeave);
            // 
            // labelTimeoutsCounter
            // 
            this.labelTimeoutsCounter.AutoSize = true;
            this.labelTimeoutsCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimeoutsCounter.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.labelTimeoutsCounter.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelTimeoutsCounter.Location = new System.Drawing.Point(43, 0);
            this.labelTimeoutsCounter.Margin = new System.Windows.Forms.Padding(0);
            this.labelTimeoutsCounter.Name = "labelTimeoutsCounter";
            this.labelTimeoutsCounter.Size = new System.Drawing.Size(93, 27);
            this.labelTimeoutsCounter.TabIndex = 0;
            this.labelTimeoutsCounter.Text = "o o o o o o o";
            this.labelTimeoutsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTimeoutsCounter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseDown);
            this.labelTimeoutsCounter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseMove);
            this.labelTimeoutsCounter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseUp);
            // 
            // tableLayoutTitleBar
            // 
            this.tableLayoutTitleBar.ColumnCount = 3;
            this.tableLayoutTitleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutTitleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutTitleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutTitleBar.Controls.Add(this.buttonEdit, 0, 0);
            this.tableLayoutTitleBar.Controls.Add(this.buttonClose, 2, 0);
            this.tableLayoutTitleBar.Controls.Add(this.trackBarMinOpacity, 1, 0);
            this.tableLayoutTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTitleBar.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutTitleBar.Name = "tableLayoutTitleBar";
            this.tableLayoutTitleBar.RowCount = 1;
            this.tableLayoutTitleBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTitleBar.Size = new System.Drawing.Size(180, 27);
            this.tableLayoutTitleBar.TabIndex = 0;
            this.tableLayoutTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseDown);
            this.tableLayoutTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseMove);
            this.tableLayoutTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseUp);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackgroundImage = global::Timeit.Properties.Resources.edit;
            this.buttonEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.buttonEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Location = new System.Drawing.Point(0, 0);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(43, 27);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.TabStop = false;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            this.buttonEdit.MouseEnter += new System.EventHandler(this.buttonEdit_MouseEnter);
            this.buttonEdit.MouseLeave += new System.EventHandler(this.buttonEdit_MouseLeave);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::Timeit.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(136, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(44, 27);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            // 
            // trackBarMinOpacity
            // 
            this.trackBarMinOpacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarMinOpacity.Location = new System.Drawing.Point(43, 5);
            this.trackBarMinOpacity.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.trackBarMinOpacity.Maximum = 100;
            this.trackBarMinOpacity.Minimum = 10;
            this.trackBarMinOpacity.Name = "trackBarMinOpacity";
            this.trackBarMinOpacity.Size = new System.Drawing.Size(93, 17);
            this.trackBarMinOpacity.TabIndex = 1;
            this.trackBarMinOpacity.TabStop = false;
            this.trackBarMinOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMinOpacity.Value = 10;
            this.trackBarMinOpacity.Visible = false;
            this.trackBarMinOpacity.ValueChanged += new System.EventHandler(this.trackBarMinOpacity_ValueChanged);
            // 
            // tableLayoutTimer
            // 
            this.tableLayoutTimer.ColumnCount = 5;
            this.tableLayoutTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTimer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutTimer.Controls.Add(this.textBoxSeconds, 3, 0);
            this.tableLayoutTimer.Controls.Add(this.buttonReset, 4, 0);
            this.tableLayoutTimer.Controls.Add(this.labelTimerSeparator, 2, 0);
            this.tableLayoutTimer.Controls.Add(this.buttonPlay, 0, 0);
            this.tableLayoutTimer.Controls.Add(this.textBoxMinutes, 1, 0);
            this.tableLayoutTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTimer.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutTimer.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutTimer.Name = "tableLayoutTimer";
            this.tableLayoutTimer.RowCount = 1;
            this.tableLayoutTimer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutTimer.Size = new System.Drawing.Size(180, 46);
            this.tableLayoutTimer.TabIndex = 1;
            this.tableLayoutTimer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseDown);
            this.tableLayoutTimer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseMove);
            this.tableLayoutTimer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseUp);
            // 
            // textBoxSeconds
            // 
            this.textBoxSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBoxSeconds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSeconds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSeconds.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.textBoxSeconds.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxSeconds.Location = new System.Drawing.Point(102, 3);
            this.textBoxSeconds.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.textBoxSeconds.MaxLength = 2;
            this.textBoxSeconds.Name = "textBoxSeconds";
            this.textBoxSeconds.Size = new System.Drawing.Size(39, 45);
            this.textBoxSeconds.TabIndex = 2;
            this.textBoxSeconds.Text = "00";
            this.textBoxSeconds.WordWrap = false;
            this.textBoxSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateKeyPress);
            this.textBoxSeconds.Validated += new System.EventHandler(this.textBoxSeconds_Validated);
            // 
            // buttonReset
            // 
            this.buttonReset.BackgroundImage = global::Timeit.Properties.Resources.reset;
            this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonReset.Location = new System.Drawing.Point(141, 10);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(0, 10, 8, 10);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(31, 26);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.TabStop = false;
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            this.buttonReset.MouseEnter += new System.EventHandler(this.buttonReset_MouseEnter);
            this.buttonReset.MouseLeave += new System.EventHandler(this.buttonReset_MouseLeave);
            // 
            // labelTimerSeparator
            // 
            this.labelTimerSeparator.AutoSize = true;
            this.labelTimerSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimerSeparator.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.labelTimerSeparator.ForeColor = System.Drawing.Color.Silver;
            this.labelTimerSeparator.Location = new System.Drawing.Point(78, 5);
            this.labelTimerSeparator.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelTimerSeparator.Name = "labelTimerSeparator";
            this.labelTimerSeparator.Size = new System.Drawing.Size(24, 41);
            this.labelTimerSeparator.TabIndex = 2;
            this.labelTimerSeparator.Text = ":";
            this.labelTimerSeparator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseDown);
            this.labelTimerSeparator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseMove);
            this.labelTimerSeparator.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onWindowDragMouseUp);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::Timeit.Properties.Resources.play;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlay.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.buttonPlay.Location = new System.Drawing.Point(8, 10);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(8, 10, 0, 10);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(31, 26);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.TabStop = false;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            this.buttonPlay.MouseEnter += new System.EventHandler(this.buttonPlay_MouseEnter);
            this.buttonPlay.MouseLeave += new System.EventHandler(this.buttonPlay_MouseLeave);
            // 
            // textBoxMinutes
            // 
            this.textBoxMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBoxMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMinutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMinutes.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.textBoxMinutes.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxMinutes.Location = new System.Drawing.Point(39, 3);
            this.textBoxMinutes.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.textBoxMinutes.MaxLength = 2;
            this.textBoxMinutes.Name = "textBoxMinutes";
            this.textBoxMinutes.Size = new System.Drawing.Size(39, 45);
            this.textBoxMinutes.TabIndex = 0;
            this.textBoxMinutes.Text = "00";
            this.textBoxMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxMinutes.WordWrap = false;
            this.textBoxMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.validateKeyPress);
            this.textBoxMinutes.Validated += new System.EventHandler(this.textBoxMinutes_Validated);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerTimeoutAnimation
            // 
            this.timerTimeoutAnimation.Interval = 1000;
            this.timerTimeoutAnimation.Tick += new System.EventHandler(this.timerTimeoutAnimation_Tick);
            // 
            // timerFadingAnimation
            // 
            this.timerFadingAnimation.Interval = 10;
            this.timerFadingAnimation.Tick += new System.EventHandler(this.timerFadingAnimation_Tick);
            // 
            // toolTipOpacity
            // 
            this.toolTipOpacity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolTipOpacity.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolTipOpacity.ToolTipTitle = "Change minimum window opacity";
            // 
            // Main
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(180, 100);
            this.Controls.Add(this.tableLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(180, 100);
            this.MinimumSize = new System.Drawing.Size(180, 100);
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Deactivate += new System.EventHandler(this.Main_Deactivate);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutTimeouts.ResumeLayout(false);
            this.tableLayoutTimeouts.PerformLayout();
            this.tableLayoutTitleBar.ResumeLayout(false);
            this.tableLayoutTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMinOpacity)).EndInit();
            this.tableLayoutTimer.ResumeLayout(false);
            this.tableLayoutTimer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTitleBar;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTimer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxMinutes;
        private System.Windows.Forms.TextBox textBoxSeconds;
        private System.Windows.Forms.Label labelTimerSeparator;
        private System.Windows.Forms.TableLayoutPanel tableLayoutTimeouts;
        private System.Windows.Forms.Button buttonTimeoutsMore;
        private System.Windows.Forms.Button buttonTimeoutsLess;
        private System.Windows.Forms.Label labelTimeoutsCounter;
        private System.Windows.Forms.Timer timerTimeoutAnimation;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerFadingAnimation;
        private System.Windows.Forms.TrackBar trackBarMinOpacity;
        private System.Windows.Forms.ToolTip toolTipOpacity;
    }
}

