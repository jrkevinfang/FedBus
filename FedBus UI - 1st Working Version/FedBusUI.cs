using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FedBusUI_New
{
    enum studentStatus { Accepted, Denied, AlreadyBoarded, AnotherBus, BoardedAnotherBus };

    public partial class FedBusUI : Form
    {
        private FedBus mybus;

        public FedBusUI()
        {
            InitializeComponent();
            mybus = RecoveryManager.makeFedBus(@"file://D:\Documents\xml.xml", @"file://D:\Documents\xml.xml", "http://rsp.icpls.com/log/");
            busID.Items.AddRange(mybus.BusList);
            mybus.currentBus = mybus.BusList[0];
            busID.SelectedItem = busID.Items[0];
            BoardCounter();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToLongTimeString();
        }

        private void BoardCounter()
        {
            Seats.Text = mybus.currentBus.BoardedCount.ToString() + " / " + mybus.currentBus.MaximumSeats;
        }

        private void busID_DropDown(object sender, EventArgs e)
        {
            MessageBox.Show("Changing Bus...");
        }

        private void busID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Active Bus = selection.busID;
            mybus.currentBus = (Bus)busID.SelectedItem;
            BoardCounter();
            Confirmation.Text = "";
        }

        private void studentID_TextChanged(object sender, EventArgs e)
        {
            if (studentID.Text.Length == 8)
            {
                // Set the current student being checked in to the ID scanned/entered manually.
                string currentStudent = studentID.Text;

                Seats.ForeColor = Color.Black;

                studentStatus currentIDStatus = mybus.studentCheckIn(studentID.Text);

                /* Cases: 1. Allowed
                 *        2. Already Boarded
                 *        3. Already Boarded Another Bus
                 *        4. Denied
                 */

                if (currentIDStatus == studentStatus.Accepted)
                {
                    mybus.currentBus.BoardedCount++;
                    Confirmation.ForeColor = Color.Green;
                    Confirmation.Text = "OK!";
                }
                else if (currentIDStatus == studentStatus.AlreadyBoarded)
                {
                    Confirmation.ForeColor = Color.Orange;
                    Confirmation.Text = "Already \nBoarded!";
                }
                else if (currentIDStatus == studentStatus.AnotherBus)
                {
                    Confirmation.ForeColor = Color.Orange;
                    Confirmation.Text = "Wrong \nBus!";
                }
                else if (currentIDStatus == studentStatus.BoardedAnotherBus)
                {
                    Confirmation.ForeColor = Color.Orange;
                    Confirmation.Text = "Boarded \nAnother!";
                }
                else if (currentIDStatus == studentStatus.Denied)
                {
                    Confirmation.ForeColor = Color.Red;
                    Confirmation.Text = "Denied!";
                }

                if (mybus.currentBus.BoardedCount.ToString() == mybus.currentBus.MaximumSeats)
                {
                    Seats.ForeColor = Color.Red;
                    Seats.Text = "Full \nLoad \nNext \nBus!";
                }

                BoardCounter();

                // Clear the field after reading is done.
                studentID.Text = "";

            }
        }
    }
}