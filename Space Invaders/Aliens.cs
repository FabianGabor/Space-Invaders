using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class Aliens
    {
        public const int COLUMNS = 11;
        public const int ROWS = 1;
        public const int ALIENCOUNT = ROWS * COLUMNS;
        public const int ALIENSPEED = 5;
        public const int ALIENBULLETTIMER = 300;
        public const int ALIENMARGIN = 30;        
        public const int ALIENGROUPWIDTH = 960;
        
        public PictureBox[,] grid;
        //public Alien[,] alien;

        public Aliens()
        {
            grid = new PictureBox[ROWS, COLUMNS];            
        }

        public void CreateAliens(Panel panelGameBoard)
        {
            int top = 0;
            for (int i = 0; i < ROWS; i++)
            {
                int left = (panelGameBoard.Width - Aliens.ALIENGROUPWIDTH) / 2;

                for (int j = 0; j < COLUMNS; j++)
                {                    
                    grid[i, j] = new PictureBox
                    {
                        Size = new Size(60, 45),
                        Margin = new Padding(Aliens.ALIENMARGIN),
                        Image = Properties.Resources.alien,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Top = top,
                        Left = left,
                        Tag = new Property(Tags.alien, i, j)
                };                                       
                    left += grid[i, j].Size.Width + ALIENMARGIN;                    
                }
                top += grid[i, 0].Size.Height + ALIENMARGIN;                
            }
        }        
    }
}
