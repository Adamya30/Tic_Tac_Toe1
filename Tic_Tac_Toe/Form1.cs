using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;
        static string Player1, Player2;
        public Form1()
        {
            InitializeComponent();
        }

        public static void set_player_names(string n1,string n2)
        {
            Player1 = n1;
            Player2 = n2;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Adamya Shukla", "About the App");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            check_for_winner();
        }

        private void check_for_winner()
        {
            bool there_is_a_winner = false;

            //HORIZONTAL CHECK
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) &&(!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            //VERTICAL CHECK
            else if((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //DIAGONAL CHECK

            else if((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if((C1.Text == B2.Text) && (B2.Text == A3.Text) && (!C1.Enabled))
                there_is_a_winner = true;


            if (there_is_a_winner)
            {
                disable_buttons();
                String winner = "";
                if (turn)
                {
                    winner = Player2;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                    refresh();
                }
                else
                {

                    winner = Player1;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                    refresh();
                }            
                MessageBox.Show("Player " + winner + " wins!!!", "Yay!!!");
            }
            else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show("It is a draw! Try again...", "Ooops!!!");
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    refresh();
                }
            }

        }

        private void disable_buttons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            
            foreach (Control c in Controls)
             {
                try
                {
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                }
                catch { }
        }
            
        }

        private void botton_enter(object sender, EventArgs e)
        {
           Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void botton_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetWinCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void refresh()
        {
            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch { }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = Player1 + " -> (X) :";
            label3.Text = Player2 +" -> (O) :";
        }
    }
}
