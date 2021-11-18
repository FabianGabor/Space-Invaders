namespace Space_Invaders
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
            this.components = new System.ComponentModel.Container();
            this.spaceship = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scorePoints = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.panelGameBoard = new System.Windows.Forms.Panel();
            this.labelPanelCoords = new System.Windows.Forms.Label();
            this.labelLaserCoords = new System.Windows.Forms.Label();
            this.labelMouse = new System.Windows.Forms.Label();
            this.labelPanel = new System.Windows.Forms.Label();
            this.panelEndgame = new System.Windows.Forms.Panel();
            this.labelEndgame = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spaceship)).BeginInit();
            this.panelEndgame.SuspendLayout();
            this.SuspendLayout();
            // 
            // spaceship
            // 
            this.spaceship.Image = global::Space_Invaders.Properties.Resources.spaceship;
            this.spaceship.Location = new System.Drawing.Point(610, 660);
            this.spaceship.Name = "spaceship";
            this.spaceship.Size = new System.Drawing.Size(60, 60);
            this.spaceship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spaceship.TabIndex = 0;
            this.spaceship.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.ForeColor = System.Drawing.Color.Lime;
            this.scoreLabel.Location = new System.Drawing.Point(0, 694);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(84, 26);
            this.scoreLabel.TabIndex = 12;
            this.scoreLabel.Text = "Score:";
            // 
            // scorePoints
            // 
            this.scorePoints.AutoSize = true;
            this.scorePoints.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scorePoints.ForeColor = System.Drawing.Color.Lime;
            this.scorePoints.Location = new System.Drawing.Point(90, 694);
            this.scorePoints.Name = "scorePoints";
            this.scorePoints.Size = new System.Drawing.Size(24, 26);
            this.scorePoints.TabIndex = 13;
            this.scorePoints.Text = "0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // panelGameBoard
            // 
            this.panelGameBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelGameBoard.BackColor = System.Drawing.Color.DimGray;
            this.panelGameBoard.Location = new System.Drawing.Point(480, 180);
            this.panelGameBoard.Name = "panelGameBoard";
            this.panelGameBoard.Size = new System.Drawing.Size(1280, 720);
            this.panelGameBoard.TabIndex = 0;
            // 
            // labelPanelCoords
            // 
            this.labelPanelCoords.AutoSize = true;
            this.labelPanelCoords.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPanelCoords.Location = new System.Drawing.Point(12, 9);
            this.labelPanelCoords.Name = "labelPanelCoords";
            this.labelPanelCoords.Size = new System.Drawing.Size(0, 15);
            this.labelPanelCoords.TabIndex = 1;
            // 
            // labelLaserCoords
            // 
            this.labelLaserCoords.AutoSize = true;
            this.labelLaserCoords.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelLaserCoords.Location = new System.Drawing.Point(0, 12);
            this.labelLaserCoords.Name = "labelLaserCoords";
            this.labelLaserCoords.Size = new System.Drawing.Size(0, 15);
            this.labelLaserCoords.TabIndex = 2;
            // 
            // labelMouse
            // 
            this.labelMouse.AutoSize = true;
            this.labelMouse.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelMouse.Location = new System.Drawing.Point(0, 27);
            this.labelMouse.Name = "labelMouse";
            this.labelMouse.Size = new System.Drawing.Size(0, 15);
            this.labelMouse.TabIndex = 3;
            // 
            // labelPanel
            // 
            this.labelPanel.AutoSize = true;
            this.labelPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPanel.Location = new System.Drawing.Point(0, 42);
            this.labelPanel.Name = "labelPanel";
            this.labelPanel.Size = new System.Drawing.Size(0, 15);
            this.labelPanel.TabIndex = 4;
            // 
            // panelEndgame
            // 
            this.panelEndgame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEndgame.Controls.Add(this.labelEndgame);
            this.panelEndgame.Controls.Add(this.labelPanel);
            this.panelEndgame.Controls.Add(this.labelMouse);
            this.panelEndgame.Controls.Add(this.labelLaserCoords);
            this.panelEndgame.Location = new System.Drawing.Point(12, 9);
            this.panelEndgame.Name = "panelEndgame";
            this.panelEndgame.Size = new System.Drawing.Size(1880, 1020);
            this.panelEndgame.TabIndex = 5;
            // 
            // labelEndgame
            // 
            this.labelEndgame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndgame.AutoSize = true;
            this.labelEndgame.Font = new System.Drawing.Font("Impact", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEndgame.ForeColor = System.Drawing.Color.Lime;
            this.labelEndgame.Location = new System.Drawing.Point(760, 367);
            this.labelEndgame.Name = "labelEndgame";
            this.labelEndgame.Size = new System.Drawing.Size(400, 117);
            this.labelEndgame.TabIndex = 5;
            this.labelEndgame.Text = "VICTORY!";
            this.labelEndgame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panelEndgame);
            this.Controls.Add(this.labelPanelCoords);
            this.Controls.Add(this.panelGameBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.spaceship)).EndInit();
            this.panelEndgame.ResumeLayout(false);
            this.panelEndgame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox spaceship;
        private Label scoreLabel;
        private Label scorePoints;
        private System.Windows.Forms.Timer gameTimer;
        
        private Panel panelGameBoard;
        private Label labelPanelCoords;
        private Label labelLaserCoords;
        private Label labelMouse;
        private Label labelPanel;
        private Panel panelEndgame;
        private Label labelEndgame;
    }
}