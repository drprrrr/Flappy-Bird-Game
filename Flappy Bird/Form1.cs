using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 11;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            pipeBottom1.Left -= pipeSpeed;
            pipeBottom2.Left -= pipeSpeed;
            pipeBottom3.Left -= pipeSpeed;
            pipeBottom4.Left -= pipeSpeed;
            pipeTop1.Left -= pipeSpeed;
            pipeTop2.Left -= pipeSpeed;
            pipeTop3.Left -= pipeSpeed;
            ScoreText.Text = "Счет: " + score;
            if (pipeBottom1.Left < -100)
            {
                pipeBottom1.Left = 1300;
                score++;
            }
            if (pipeBottom2.Left < -100)
            {
                pipeBottom2.Left = 1300;
                score++;
            }
            if (pipeBottom3.Left < -100)
            {
                pipeBottom3.Left = 1300;
                score++;
            }
            if (pipeBottom4.Left < -100)
            {
                pipeBottom4.Left = 1300;
                score++;
            }
            if (pipeTop1.Left < -110)
            {
                pipeTop1.Left = 1000;
                score++;
            }
            if (pipeTop2.Left < -110)
            {
                pipeTop2.Left = 1000;
                score++;
            }
            if (pipeTop3.Left < -110)
            {
                pipeTop3.Left = 1000;
                score++;
            }
            if (Bird.Bounds.IntersectsWith(pipeBottom1.Bounds) ||
                Bird.Bounds.IntersectsWith(pipeBottom2.Bounds) ||
                Bird.Bounds.IntersectsWith(pipeBottom3.Bounds) ||
                Bird.Bounds.IntersectsWith(pipeBottom4.Bounds) ||
                Bird.Bounds.IntersectsWith(pipeTop1.Bounds) ||
                Bird.Bounds.IntersectsWith(pipeTop2.Bounds) || 
                Bird.Bounds.IntersectsWith(pipeTop3.Bounds) || 
                Bird.Bounds.IntersectsWith(Ground.Bounds) || 
                Bird.Top < -15)
            {
                endGame();
            }
            if (score > 5)
            {
                pipeSpeed = 13;
            }
            if (score > 10)
            {
                pipeSpeed = 18;
            }
            if (score > 20)
            {
                pipeSpeed = 24;
            }
            if (score > 40)
            {
                pipeSpeed = 30;
            }
            if (score > 50)
            {
                pipeSpeed = 40 ;
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 13;
            }
        }
        
        private void endGame()
        {
            gameTimer.Stop();
            DialogResult result = MessageBox.Show("Ваш счет " + score + "\n" + "Попробовать снова?", "ИГРА ОКОНЧЕНА!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Restart(); 
            if (result == DialogResult.No)
                this.Close();
        }
    }
}
