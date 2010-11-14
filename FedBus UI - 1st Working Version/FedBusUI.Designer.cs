namespace FedBusUI_New
{
    partial class FedBusUI
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.studentID = new System.Windows.Forms.TextBox();
            this.busID = new System.Windows.Forms.ComboBox();
            this.SeatLabel = new System.Windows.Forms.Label();
            this.Seats = new System.Windows.Forms.Label();
            this.Clock = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Confirmation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // studentID
            // 
            this.studentID.Location = new System.Drawing.Point(47, 81);
            this.studentID.MaxLength = 8;
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(200, 20);
            this.studentID.TabIndex = 1;
            this.studentID.TextChanged += new System.EventHandler(this.studentID_TextChanged);
            // 
            // busID
            // 
            this.busID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busID.FormattingEnabled = true;
            this.busID.Location = new System.Drawing.Point(342, 20);
            this.busID.Name = "busID";
            this.busID.Size = new System.Drawing.Size(277, 21);
            this.busID.TabIndex = 3;
            this.busID.DropDown += busID_DropDown;
            this.busID.SelectedIndexChanged += busID_SelectedIndexChanged;
            // 
            // SeatLabel
            // 
            this.SeatLabel.AutoSize = true;
            this.SeatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeatLabel.ForeColor = System.Drawing.Color.Red;
            this.SeatLabel.Location = new System.Drawing.Point(374, 72);
            this.SeatLabel.Name = "SeatLabel";
            this.SeatLabel.Size = new System.Drawing.Size(195, 29);
            this.SeatLabel.TabIndex = 4;
            this.SeatLabel.Text = "Boarded / Total";
            // 
            // Seats
            // 
            this.Seats.AutoSize = true;
            this.Seats.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seats.Location = new System.Drawing.Point(395, 101);
            this.Seats.Name = "Seats";
            this.Seats.Size = new System.Drawing.Size(0, 73);
            this.Seats.TabIndex = 0;
            // 
            // Clock
            // 
            this.Clock.AutoSize = true;
            this.Clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clock.Location = new System.Drawing.Point(49, 20);
            this.Clock.Name = "Clock";
            this.Clock.Size = new System.Drawing.Size(0, 42);
            this.Clock.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Confirmation
            // 
            this.Confirmation.AutoSize = true;
            this.Confirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirmation.Location = new System.Drawing.Point(30, 126);
            this.Confirmation.Name = "Confirmation";
            this.Confirmation.Size = new System.Drawing.Size(0, 73);
            this.Confirmation.TabIndex = 0;
            // 
            // FedBusUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 553);
            this.Controls.Add(this.Confirmation);
            this.Controls.Add(this.Seats);
            this.Controls.Add(this.Clock);
            this.Controls.Add(this.SeatLabel);
            this.Controls.Add(this.busID);
            this.Controls.Add(this.studentID);
            this.Name = "FedBusUI";
            this.Text = "FedBusUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox studentID;
        private System.Windows.Forms.ComboBox busID;
        private System.Windows.Forms.Label SeatLabel;
        private System.Windows.Forms.Label Seats;
        private System.Windows.Forms.Label Clock;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Confirmation;
    }
}