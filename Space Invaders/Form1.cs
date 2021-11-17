using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight;
        int spaceshipSpeed = 10;
        int alienSpeed = 5;
        int score = 0;
        int alienBulletTimer = 300;

        PictureBox[] aliensArray;

        bool isShooting;
        bool isGameOver;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameSetup()
        {

        }

        private void gameOver()
        {

        }

        private void removeAll()
        {

        }

        private void makeBullet()
        {

        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Space && !isShooting)
            {
                isShooting = true;
                makeBullet();
            }
            if (e.KeyCode == Keys.Enter)
            {
                removeAll();
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

        }
    }
}