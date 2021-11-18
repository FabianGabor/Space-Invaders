using System.Collections;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        private const bool DEBUG = false;

        private bool goLeft, goRight;
        private int spaceshipSpeed = 10;

        private int alienSpeed;
        private int alienBulletTimer;
        private Aliens aliens;

        private static int[] aliensRowCount = new int[Aliens.COLUMNS];

        private int score = 0;
        private bool isShooting;
        private bool isGameOver;
        private bool moveAlienDown = false;
        private bool moveAlienLeft = false;
        private bool moveAlienRight = true;

        public Form1()
        {
            InitializeComponent();
            GameSetup();
        }

        private void GameSetup()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            panelEndgame.Visible = false;
            labelEndgame.Visible = false;

            panelGameBoard.Location = new Point(
                this.ClientSize.Width / 2 - panelGameBoard.Size.Width / 2,
                this.ClientSize.Height / 2 - panelGameBoard.Size.Height / 2);
            panelGameBoard.Anchor = AnchorStyles.None;
            panelGameBoard.BackColor = Color.Black;

            panelGameBoard.Controls.Add(scoreLabel);
            panelGameBoard.Controls.Add(scorePoints);
            score = 0;
            scorePoints.Text = score.ToString();
            isGameOver = false;
            alienBulletTimer = Aliens.ALIENBULLETTIMER;
            alienSpeed = Aliens.ALIENSPEED;
            isShooting = false;            
            MakeInvaders();
            spaceship.Left = (panelGameBoard.Width - spaceship.Width) / 2;
            panelGameBoard.Controls.Add(spaceship);

            if (DEBUG)
            {
                labelPanelCoords.Text = panelGameBoard.Top.ToString();                
            }

            gameTimer.Start();
        }

        private void GameOver(bool victory)
        {
            isGameOver = true;
            gameTimer.Stop();
            //RemoveAll();

            panelEndgame.Visible = true;
            labelEndgame.Visible = true;

            if (victory)
            {
                EndgameSplash("Victory!", Color.Lime);
            }
            else
            {
                EndgameSplash("Invaded!", Color.Red);
            }            
        }

        private void EndgameSplash(String msg, Color c)
        {
            panelEndgame.Enabled = true;
            labelEndgame.Text = msg;
            labelEndgame.Enabled = true;
            labelEndgame.ForeColor = c;
        }

        private void RemoveAll()
        {
            foreach (PictureBox pictureBox in aliens.grid)
            {
                panelGameBoard.Controls.Remove(pictureBox);
            }

            foreach (Control control in panelGameBoard.Controls)
            {
                if (control is PictureBox)
                {                    
                    if (control.Tag != null && !control.Tag.GetType().Equals(typeof(Property)) && ((Tags)control.Tag == Tags.laser || (Tags)control.Tag == Tags.laserAlien))
                    {
                        panelGameBoard.Controls.Remove(control);
                    }
                }
            }
        }

        private void MakeBullet(Tags laserTag)
        {
            PictureBox laser = new()
            {
                Image = Properties.Resources.laser,
                Size = new Size(5, 20),
                Tag = laserTag,
                Left = spaceship.Left + spaceship.Width / 2
            };

            if ((Tags)laser.Tag == Tags.laser)
            {
                laser.Top = spaceship.Top - laser.Size.Height;
            } 
            else if ((Tags)laser.Tag == Tags.laserAlien)
            {
                int random;
                do
                {
                    random = new Random().Next(0, aliensRowCount.Length);
                } while (aliensRowCount[random] == 0);

                int randomY = random;
                int randomX = aliensRowCount[randomY]-1;

                laser.Left = aliens.grid[randomX, randomY].Left + (aliens.grid[randomX, randomY].Width / 2);
                laser.Top = aliens.grid[randomX, randomY].Top + (aliens.grid[randomX, randomY].Height);
            }

            panelGameBoard.Controls.Add(laser);
            laser.BringToFront();
        }

        private void MakeInvaders()
        {            
            this.aliens = new Aliens();
            this.aliens.CreateAliens(panelGameBoard);

            foreach (var alien in this.aliens.grid)
                panelGameBoard.Controls.Add(alien);

            for (int j = 0; j < Aliens.COLUMNS; j++)
            {   
                aliensRowCount[j] = Aliens.ROWS;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Space && !isShooting)
            {                
                MakeBullet(Tags.laser);
                isShooting = true;
            }
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;            
            if (e.KeyCode == Keys.Enter)
            {
                RemoveAll();
                GameSetup();
            }
        }

        private FarLeftRightAlien GetFarLeftRightAlien()
        {
            int farLeftAlien;
            int farRightAlien;

            int left = 0;
            while(left < aliensRowCount.Length && aliensRowCount[left] == 0)
            {
                left++;
            }
            farLeftAlien = aliens.grid[0, left].Left;

            int right= aliensRowCount.Length - 1;
            while (right > 0 && aliensRowCount[right] == 0)
            {
                right++;
            }
            farRightAlien = aliens.grid[0, right].Right;


            return new FarLeftRightAlien(farLeftAlien, farRightAlien);
        }

        private void CheckCollisionAlien(Control control)
        {
            if (control is PictureBox && control.Tag != null && control.Tag.GetType().Equals(typeof(Property)) && (control.Tag as Property).tag == Tags.alien)
            {
                if (control.Bounds.IntersectsWith(spaceship.Bounds))
                {
                    GameOver(false);
                }
            }
        }

        private void CheckAliensLocation()
        {
            FarLeftRightAlien farLeftRightAlien = GetFarLeftRightAlien();
            int farLeftAlien = farLeftRightAlien.farLeftAlien;
            int farRightAlien = farLeftRightAlien.farRightAlien;
            {
                if (farRightAlien > panelGameBoard.Width)
                {
                    moveAlienLeft = true;
                    moveAlienRight = false;
                    moveAlienDown = true;
                }
                if (farLeftAlien < 0)
                {
                    moveAlienLeft = false;
                    moveAlienRight = true;
                    moveAlienDown = true;
                }
            }
        }

        private void CheckAliensLocation(Control control)
        {
            if (control is PictureBox && control.Tag != null && control.Tag.GetType().Equals(typeof(Property)) && (control.Tag as Property).tag == Tags.alien)
            {
                if (((PictureBox)control).Right > panelGameBoard.Width)
                {
                    moveAlienLeft = true;
                    moveAlienRight = false;
                    moveAlienDown = true;
                }
                if (((PictureBox)control).Left < 0)
                {
                    moveAlienLeft = false;
                    moveAlienRight = true;
                    moveAlienDown = true;
                }
            }
        }

        private void MoveAliens(Control control)
        {
            if (control is PictureBox && control.Tag != null && control.Tag.GetType().Equals(typeof(Property)) && (control.Tag as Property).tag == Tags.alien)
            {
                if (moveAlienDown) ((PictureBox)control).Top += ((PictureBox)control).Height + Aliens.ALIENMARGIN;
                if (moveAlienLeft) ((PictureBox)control).Left -= alienSpeed;
                if (moveAlienRight) ((PictureBox)control).Left += alienSpeed;
            }
        }

        private void AnimateAlienLaser(Control control)
        {
            if (control is PictureBox && control.Tag != null && !control.Tag.GetType().Equals(typeof(Property)) && ((Tags)control.Tag) == Tags.laserAlien)
            {
                control.Top += 10;

                if (control.Top > panelGameBoard.Bottom)
                {
                    panelGameBoard.Controls.Remove(control);
                }                
            }
        }

        private void CheckAlienLaserCollision(Control control)
        {
            if (control is PictureBox && control.Tag != null && !control.Tag.GetType().Equals(typeof(Property)) && ((Tags)control.Tag) == Tags.laserAlien)
            {
                if (control.Bounds.IntersectsWith(spaceship.Bounds))
                {
                    panelGameBoard.Controls.Remove(control);
                    GameOver(false);
                }
            }
        }

        private void AnimateSpaceShipLaser(Control control)
        {
            if (control is PictureBox && control.Tag != null && !control.Tag.GetType().Equals(typeof(Property)) && ((Tags)control.Tag) == Tags.laser)
            {
                control.Top -= 20;
                if (DEBUG) labelLaserCoords.Text = control.Top.ToString();

                if (((PictureBox)control).Top < 1)
                {
                    panelGameBoard.Controls.Remove(control);
                    isShooting = false;
                }

            }
        }

        private void CheckLaserCollision(Control control)
        {
            if (control is PictureBox && control.Tag != null && !control.Tag.GetType().Equals(typeof(Property)) && ((Tags)control.Tag) == Tags.laser)
            {
                foreach (Control controlAlien in panelGameBoard.Controls)
                {
                    if (controlAlien is PictureBox && controlAlien.Tag != null && controlAlien.Tag.GetType().Equals(typeof(Property)) && ((Property)controlAlien.Tag).tag == Tags.alien)
                    {
                        if (controlAlien.Bounds.IntersectsWith(control.Bounds))
                        {
                            score++;
                            panelGameBoard.Controls.Remove(controlAlien);
                            panelGameBoard.Controls.Remove(control);
                            isShooting = false;
                            aliensRowCount[((Property)controlAlien.Tag).col]--;
                        }
                    }
                }
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (DEBUG)
            {
                labelMouse.Text = MousePosition.ToString();
                labelPanel.Text = panelGameBoard.Left.ToString() + " " + panelGameBoard.Top.ToString() + " " + panelGameBoard.Right.ToString() + " " + panelGameBoard.Bottom.ToString();
            }

            scorePoints.Text = score.ToString();
            if (goLeft) spaceship.Left -= spaceshipSpeed;
            if (goRight) spaceship.Left += spaceshipSpeed;


            if (alienBulletTimer < 1)
            {
                alienBulletTimer = Aliens.ALIENBULLETTIMER;

                if (!DEBUG)
                    MakeBullet(Tags.laserAlien);
            }
            else
            {
                alienBulletTimer -= 10;
            }

            CheckAliensLocation();
            foreach (Control control in panelGameBoard.Controls)
            {
                //CheckAliensLocation(control);
                CheckCollisionAlien(control);                
                AnimateAlienLaser(control);
                CheckAlienLaserCollision(control);                
                AnimateSpaceShipLaser(control);
                CheckLaserCollision(control);
                MoveAliens(control);
            }
            moveAlienDown = false;

            alienSpeed = Aliens.ALIENSPEED + score / (Aliens.ROWS * Aliens.COLUMNS / 2);

            if (score == aliens.grid.Length)
            {
                GameOver(true);
            }
        }
    }
}