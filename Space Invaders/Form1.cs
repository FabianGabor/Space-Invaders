using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {   
        private bool goLeft, goRight;
        private int spaceshipSpeed = 5;

        private int alienSpeed;
        private int alienBulletTimer;
        private Aliens aliens;
        

        private int score = 0;
        private bool isShooting;
        private bool isGameOver;   

        public Form1()
        {
            InitializeComponent();
            GameSetup();            
        }

        private void GameSetup()
        {
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;

            score = 0;
            scorePoints.Text = score.ToString();
            isGameOver = false;
            alienBulletTimer = Aliens.ALIENBULLETTIMER;
            alienSpeed = Aliens.ALIENSPEED;
            isShooting = false;            
            MakeInvadersMatrix();
            spaceship.Left = (panelGameBoard.Width - spaceship.Width) / 2;
            gameTimer.Start();
        }

        private void GameOver(String msg)
        {
            isGameOver = true;
            gameTimer.Stop();
            scorePoints.Text = score.ToString() + " " + msg;
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
                    if ((Tags)control.Tag == Tags.laser || (Tags)control.Tag == Tags.laserAlien)
                    {
                        panelGameBoard.Controls.Remove(control);
                    }
                }
            }
        }

        private void MakeBullet(Tags laserTag)
        {
            PictureBox laser = new PictureBox();
            laser.Image = Properties.Resources.laser;
            laser.Size = new Size(5, 20);
            laser.Tag = laserTag;
            laser.Left = spaceship.Left + spaceship.Width / 2;

            if ((Tags)laser.Tag == Tags.laser)
            {
                laser.Top = spaceship.Top - laser.Size.Height;
            } else if ((Tags)laser.Tag == Tags.laserAlien)
            {
                // TODO generate arrays of bottom aliens and select 1 random from those

                int randomX = new Random().Next(Aliens.ROWS);
                int randomY = new Random().Next(Aliens.COLUMNS);
                laser.Left = aliens.grid[randomX, randomY].Left + (aliens.grid[randomX, randomY].Width / 2);
                laser.Top = aliens.grid[randomX, randomY].Top + (aliens.grid[randomX, randomY].Height);
            }

            panelGameBoard.Controls.Add(laser);
            laser.BringToFront();
        }

        private void MakeInvadersMatrix()
        {
            this.aliens = new Aliens();
            aliens.grid = new PictureBox[Aliens.ROWS, Aliens.COLUMNS];            
            
            int top = 0;

            for (int i = 0; i < Aliens.ROWS; i++)
            {
                int left = (panelGameBoard.Width - Aliens.ALIENGROUPWIDTH) / 2;

                for (int j = 0; j < Aliens.COLUMNS; j++)
                {

                    aliens.grid[i,j] = new PictureBox
                    {
                        Size = new Size(60, 45),
                        Margin = new Padding(Aliens.ALIENMARGIN),
                        Image = Properties.Resources.alien,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Top = top,
                        Left = left,
                        Tag = Tags.alien
                    };
                    panelGameBoard.Controls.Add(aliens.grid[i,j]);
                    left += aliens.grid[i,j].Size.Width + Aliens.ALIENMARGIN;
                }
                top += aliens.grid[i, 0].Size.Height + Aliens.ALIENMARGIN;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Escape) Application.Exit();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Space && !isShooting)
            {
                isShooting = true;
                MakeBullet(Tags.laser);
            }
            if (e.KeyCode == Keys.Enter)
            {
                RemoveAll();
                GameSetup();
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            
            scorePoints.Text = score.ToString();
            if (goLeft) spaceship.Left -= spaceshipSpeed;
            if (goRight) spaceship.Left += spaceshipSpeed;

            
            if (alienBulletTimer < 1)
            {
                alienBulletTimer = Aliens.ALIENBULLETTIMER;
                MakeBullet(Tags.laserAlien);
            }
            else
            {
                alienBulletTimer -= 10;                
            }
            

            
            foreach (Control control in panelGameBoard.Controls)
            {
                if (control is PictureBox && control.Tag != null && (Tags)control.Tag == Tags.alien)
                {
                    
                    if (control.Bounds.IntersectsWith(spaceship.Bounds))
                    {
                        GameOver("You died!");
                    }
                    

                    
                    foreach (Control control2 in panelGameBoard.Controls)
                    {
                        if (control2 is PictureBox && control2.Tag != null && ((Tags)control2.Tag) == Tags.laser)
                        {
                            if (control2.Bounds.IntersectsWith(control.Bounds))
                            {
                                panelGameBoard.Controls.Remove(control);
                                panelGameBoard.Controls.Remove(control2);
                                score += 1;
                                isShooting = false;
                            }
                        }
                    }
                    
                }


                
                if (control is PictureBox && control.Tag != null && ((Tags)control.Tag) == Tags.laser)
                {
                    control.Top += 10;

                    if (control.Top < panelGameBoard.Top)
                    {
                        panelGameBoard.Controls.Remove(control);
                        isShooting = false;
                    }
                }
                
                

                
                if (control is PictureBox && control.Tag != null && ((Tags)control.Tag) == Tags.laserAlien)
                {
                    control.Top += 10;

                    if (control.Top > panelGameBoard.Bottom)
                    {
                        panelGameBoard.Controls.Remove(control);                        
                    }
                    if (control.Bounds.IntersectsWith(spaceship.Bounds))
                    {
                        panelGameBoard.Controls.Remove(control);
                        GameOver("You died!");
                    }
                }
                
            }


            //animating the bullets and removing them when the have left the scene
            foreach (Control y in panelGameBoard.Controls)
            {
                if (y is PictureBox && y.Tag != null && (Tags)y.Tag == Tags.laser)
                {
                    y.Top -= 20;

                    if (((PictureBox)y).Top < 0)
                    {
                        panelGameBoard.Controls.Remove(y);
                        isShooting = false;
                    }
                    
                }
            }
            // end of animating the bullets. 


            // bullet and enemy collision start            
            foreach (Control i in panelGameBoard.Controls)
            {
                foreach (Control j in panelGameBoard.Controls)
                {
                    if (i is PictureBox && i.Tag != null && (Tags)i.Tag == Tags.alien)
                    {
                        if (j is PictureBox && j.Tag != null && (Tags)j.Tag == Tags.laser)
                        {

                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                panelGameBoard.Controls.Remove(i);
                                panelGameBoard.Controls.Remove(j);
                                isShooting = false;
                            }
                        }
                    }
                }
            }
            

            if (score == aliens.grid.Length)
            {
                GameOver("You won!");
            }
            
        }
    }
}