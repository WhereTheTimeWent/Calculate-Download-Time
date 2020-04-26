using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speedrechner.CS {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            double dlSize, dlSpeed;
            
            //Catch empty speed
            if (comboBox1.Text == "") {
                MessageBox.Show("\"Speed in MB/s\" can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //Clear Textboxes
            TextBox[] textBoxes = new TextBox[] { textBox2, textBox3, textBox4 };
            foreach (TextBox textBox in textBoxes) {
                textBox.Text = "";
            }

            //Getting values from controls in double
            try {
                dlSize = Convert.ToDouble(textBox1.Text.Replace(".", ","));
            } catch (Exception) {
                MessageBox.Show("\"Size in MB\" has to be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                dlSpeed = Convert.ToDouble(comboBox1.Text.Replace(".", ","));
            } catch (Exception) {
                MessageBox.Show("\"Speed in MB/s\" has to be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Minutes
            string sMin = Convert.ToString(Math.Round((dlSize / dlSpeed / 60),2));
            string[] asMin = sMin.Split(',');
            if (asMin.Length == 2) {
                int iMin = Convert.ToInt32(asMin[1]);
                iMin = iMin * 60 / 100;
                textBox2.Text = asMin[0] + " Min " + iMin + " Sec";
            } else {
                textBox2.Text = asMin[0] + " Min";
            }

            //Hours
            string sHour = Convert.ToString(Math.Round((dlSize / dlSpeed / 60 / 60), 2));
            string[] asHour = sHour.Split(',');
            if (asHour.Length == 2) {
                int iHour = Convert.ToInt32(asHour[1]);
                iHour = iHour * 60 / 100;
                if (asHour[0] != "0") {
                    textBox3.Text = asHour[0] + " Hours " + iHour + " Min";
                }
            } else {
                if (asHour[0] != "0") {
                    textBox3.Text = asHour[0] + " Hours";
                }
            }

            //Days
            string sDay = Convert.ToString(Math.Round((dlSize / dlSpeed / 60 / 60 / 24), 2));
            string[] asDay = sDay.Split(',');
            if (asDay.Length == 2) {
                int iDay = Convert.ToInt32(asDay[1]);
                iDay = iDay * 24 / 100;
                if (asDay[0] != "0") {
                    textBox4.Text = asDay[0] + " Days " + iDay + " Hours";
                }
            } else {
                if (asDay[0] != "0") {
                    textBox4.Text = asDay[0] + " Days";
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                button1.PerformClick();
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                button1.PerformClick();
            }
        }
    }
}
