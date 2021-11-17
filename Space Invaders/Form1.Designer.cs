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
            ((System.ComponentModel.ISupportInitialize)(this.spaceship)).BeginInit();
            this.panelGameBoard.SuspendLayout();
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
            this.panelGameBoard.Controls.Add(this.scorePoints);
            this.panelGameBoard.Controls.Add(this.spaceship);
            this.panelGameBoard.Controls.Add(this.scoreLabel);
            this.panelGameBoard.Location = new System.Drawing.Point(320, 180);
            this.panelGameBoard.Margin = new System.Windows.Forms.Padding(0);
            this.panelGameBoard.Name = "panelGameBoard";
            this.panelGameBoard.Size = new System.Drawing.Size(1280, 720);
            this.panelGameBoard.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panelGameBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.spaceship)).EndInit();
            this.panelGameBoard.ResumeLayout(false);
            this.panelGameBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox spaceship;
        private Label scoreLabel;
        private Label scorePoints;
        private System.Windows.Forms.Timer gameTimer;
        private Panel panelGameBoard;
    }
}