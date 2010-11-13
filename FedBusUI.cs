using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    enum studentStatus { Accepted, Denied, AlreadyBoarded, AnotherBus, BoardedAnotherBus };

    public partial class Form1 : Form
    {
        private int seatsRemain = 48;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToLongTimeString();
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            if (studentID.Text.Length == 8)
            {
                // Set the current student being checked in to the ID scanned/entered manually.
                string currentStudent = studentID.Text;
                Seats.ForeColor = Color.Black;
              
                studentStatus currentIDStatus;

                /* Cases: 1. Allowed
                 *        2. Already Boarded
                 *        3. Already Boarded Another Bus
                 *        4. Denied
                 */

                if (currentIDStatus == studentStatus.Accepted)
                {
                    seatsRemain -= 1;
                    Seats.Text = seatsRemain.ToString();
                    Confirmation.ForeColor = Color.Green;
                    Confirmation.Text = "OK!";
                }
                else if (currentIDStatus == studentStatus.AlreadyBoarded)
                {
                    Seats.Text = seatsRemain.ToString();
                    Confirmation.ForeColor = Color.Orange;
                    Confirmation.Text = "Already Boarded!";
                }
                else if (currentIDStatus == studentStatus.AnotherBus)
                {
                    Seats.Text = seatsRemain.ToString();
                    Confirmation.ForeColor = Color.Orange;
                    Confirmation.Text = "Another Bus!";
                }
                else if (currentIDStatus == studentStatus.BoardedAnotherBus)
                {
                    Seats.Text = seatsRemain.ToString();
                    Confirmation.ForeColor = Color.Orange;
                    Confirmation.Text = "Boarded Another Bus!";
                }
                else if (currentIDStatus == studentStatus.Denied)
                {
                    Seats.Text = seatsRemain.ToString();
                    Confirmation.ForeColor = Color.Red;
                    Confirmation.Text = "Denied!";
                }


                if (seatsRemain == 0)
                {
                    Seats.ForeColor = Color.Red;
                    Seats.Text = "0 \nLoad \nNext \nBus!";
                  
                    // Load new bus ID, set seatsRemain to the seatsTotal of the new bus
                    // seatsRemain = busID->nextBus().seats;
                }

                // Clear the field after reading is done.
                studentID.Text = " ";
            }
        }
    }
}