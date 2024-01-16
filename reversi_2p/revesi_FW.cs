using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reversi_2p
{
    public partial class revesi_FW : Form
    {
        Game MyGame=new Game();

        public revesi_FW()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyGame.ResetGame();
            SetBoardState();
        }

        private void Button_Pushed(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            MyGame.SetMove(btn.Name);
            SetBoardState();

        }

        private void SetBoardState()
        {
            string Name = "b";
            Turn.Text = MyGame.PlayerTurn.ToString();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Name = "b"+i + "_" + j;

                    var controls = this.Controls.Find(Name, true);
                    foreach (var control in controls)
                    {
                        if (control is Button)
                            control.Text = MyGame.GetBoardState(Name).ToString();
                        if (control is Button && (MyGame.GetBoardState(Name) == 'W' || MyGame.GetBoardState(Name) == 'B'))
                        {
                            if (MyGame.GetBoardState(Name) == 'W')
                                control.BackColor = Color.White;
                            if (MyGame.GetBoardState(Name) == 'B')
                                control.BackColor = Color.Black;
                            control.Enabled = false;
                        }
                        else if(control is Button)
                        {
                            control.Enabled = true;
                            control.Text = " ";
                            control.BackColor = SystemColors.Control;
                        }

                    }


                    
                }

            White_score.Text = MyGame.GameScore.White.ToString();
            Black_score.Text = MyGame.GameScore.Black.ToString();
        }

        private void Rest_Click(object sender, EventArgs e)
        {
            MyGame.ResetGame();
            SetBoardState();
        }
    }
}
