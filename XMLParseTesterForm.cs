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
    public partial class XMLParse: Form
    {
        // XMLParse members
        public event EventHandler Scan;

        public void getboarded() { }
        public bool getonbus()
        {
            if (radioButton1.Checked)
            {
                return true;
            }
            else if (radioButton2.Checked)
            {
                return false;
            }
            else
            {
                return (randomGenerator.Next(11) < 6);
            }
                
        }
        
        private Random randomGenerator;

        public XMLParse()
        {
            InitializeComponent();
            randomGenerator = new Random();
            this.Show();
        }

        private void XMLParseTesterForm_Load(object sender, EventArgs e)
        {

        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            this.Scan(this, null);
        }

         
    }
}
