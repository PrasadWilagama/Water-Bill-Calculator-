using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Water_Bill_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            Boolean errors = false;
            int prevReading, currReading;

            prevReading = 0;
            currReading = 0;

            //Custormer Name field
            if (this.txt_customerName.Text == "")
            { 
             errors = true;

            }

            //previous Reading field
            if (this.txt_prevReading.Text == "" ||
                !Int32.TryParse(this.txt_prevReading.Text, out prevReading)) {
                errors = true;
            }

            //current reading field 
            if (this.txt_currentReading.Text == "" ||
                !Int32.TryParse(this.txt_currentReading.Text, out currReading)) {
                errors = true;
            }

            if (currReading < prevReading) { 
            errors = true;
            }
            if (!errors)
            {
                //Calculation
                int units = currReading - prevReading;

                //Fixed Charge Cal 
                int fixedCharge = 0;

                if (units > 75)
                {
                    fixedCharge = 1600;

                }

                else if (units >= 51)
                {
                    fixedCharge = 1000;
                }

                else if (units >= 41)
                {
                    fixedCharge = 650;
                }

                else if (units >= 31)
                {
                    fixedCharge = 400;
                }

                else if (units >= 26)
                {
                    fixedCharge = 200;

                }
                else if (units >= 21)
                {
                    fixedCharge = 100;
                }
                else if (units >= 16)
                {
                    fixedCharge = 80;
                }
                else if (units >= 11)
                {
                    fixedCharge = 70;
                }
                else if (units >= 6)
                {
                    fixedCharge = 65;
                }
                else {
                    fixedCharge = 50;
                }

                int remainingUnits = units;

                int total = 0;

                //Range 0-5
                if (remainingUnits > 5)
                {
                    total += (5 * 12);
                    remainingUnits -= 5;
                    this.dgv_breakdown.Rows.Add("0-5", "Rs.12.00", 5, "Rs." + (5 * 12).ToString());
                }
                else {
                    total += (remainingUnits * 12);
                    this.dgv_breakdown.Rows.Add("0-5", "Rs.12.00", remainingUnits, "Rs." + (remainingUnits * 12).ToString());
                    remainingUnits = 0;
                    
                }

                //Range 6-10
                if (remainingUnits > 5)
                {
                    total += (5 * 16);
                    remainingUnits -= 5;
                    this.dgv_breakdown.Rows.Add("6-10", "Rs.16.00", 5, "Rs." + (5 * 16).ToString());
                }
                else
                {
                    total += (remainingUnits * 16);
                    this.dgv_breakdown.Rows.Add("6-10", "Rs.16.00", remainingUnits, "Rs." + (remainingUnits * 16).ToString());
                    remainingUnits = 0;
                }

                //Range 11-15
                if (remainingUnits > 5)
                {
                    total += (5 * 20);
                    this.dgv_breakdown.Rows.Add("11-15", "Rs.20.00", 5, "Rs." + (5 * 20).ToString());
                    remainingUnits -= 5;
                   
                }
                else
                {
                    total += (remainingUnits * 20);
                    this.dgv_breakdown.Rows.Add("11-15", "Rs.20.00", remainingUnits, "Rs." + (remainingUnits * 20).ToString());

                    remainingUnits = 0;
                }

                //Range 16-20
                if (remainingUnits > 5)
                {
                    total += (5 * 40);
                    this.dgv_breakdown.Rows.Add("16-20", "Rs.40.00", 5, "Rs." + (5 * 40).ToString());
                    remainingUnits -= 5;
                    
                }
                else
                {
                    total += (remainingUnits * 40);
                    this.dgv_breakdown.Rows.Add("16-20", "Rs.40.00", remainingUnits, "Rs." + (remainingUnits * 40).ToString());

                    remainingUnits = 0;
                }
                //Range 21-25
                if (remainingUnits > 5)
                {
                    total += (5 * 58);
                    this.dgv_breakdown.Rows.Add("21-25", "Rs.58.00", 5, "Rs." + (5 * 58).ToString());
                    remainingUnits -= 5;
                    
                }
                else
                {
                    total += (remainingUnits * 58);
                    this.dgv_breakdown.Rows.Add("21-25", "Rs.58.00", remainingUnits, "Rs." + (remainingUnits * 58).ToString());

                    remainingUnits = 0;
                }
                //Range 26-30
                if (remainingUnits > 5)
                {
                    total += (5 * 88);
                    this.dgv_breakdown.Rows.Add("26-30", "Rs.88.00", 5, "Rs." + (5 * 88).ToString());
                    remainingUnits -= 5;
                    
                }
                else
                {
                    total += (remainingUnits * 88);
                    this.dgv_breakdown.Rows.Add("26-30", "Rs.88.00", remainingUnits, "Rs." + (remainingUnits * 88).ToString());

                    remainingUnits = 0;
                }

                //Range 31-40
                if (remainingUnits > 10)
                {
                    total += (10 * 105);
                    this.dgv_breakdown.Rows.Add("31-40", "Rs.105.00", 5, "Rs." + (5 * 105).ToString());
                    remainingUnits -= 10;
                    
                }
                else
                {
                    total += (remainingUnits * 105);
                    this.dgv_breakdown.Rows.Add("31-40", "Rs.105.00", remainingUnits, "Rs." + (remainingUnits * 105).ToString());

                    remainingUnits = 0;
                }
                //Range 41-50
                if (remainingUnits > 10)
                {
                    total += (10 * 120);
                    this.dgv_breakdown.Rows.Add("41-50", "Rs.120.00", 5, "Rs." + (5 * 120).ToString());
                    remainingUnits -= 10;
                    
                }
                else
                {
                    total += (remainingUnits * 120);
                    this.dgv_breakdown.Rows.Add("41-50", "Rs.120.00", remainingUnits, "Rs." + (remainingUnits * 120).ToString());

                    remainingUnits = 0;
                }
                //Range 51-75
                if (remainingUnits > 25)
                {
                    total += (25 * 130);
                    this.dgv_breakdown.Rows.Add("51-75", "Rs.130.00", 5, "Rs." + (5 * 130).ToString());
                    remainingUnits -= 25;
                   
                }
                else
                {
                    total += (remainingUnits * 130);
                    this.dgv_breakdown.Rows.Add("51-75", "Rs.130.00", remainingUnits, "Rs." + (remainingUnits * 130).ToString());

                    remainingUnits = 0;
                }


                // Range >75
                if (remainingUnits > 0)
                {
                    total += (remainingUnits * 140);
                    this.dgv_breakdown.Rows.Add("Over 75", "Rs.140.00", 5, "Rs." + (remainingUnits * 140).ToString());
                }


                this.txt_costForUnits.Text = total.ToString();
                this.txt_fixedCost.Text = fixedCharge.ToString();
                this.txt_totalCost.Text = (total+fixedCharge).ToString();







            }
            else {
                MessageBox.Show("Errors are in the program !");
            }

             
             
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
