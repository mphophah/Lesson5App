using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson5App
{
    public partial class LoanForm : Form
    {
        public LoanForm()
        {
            InitializeComponent();
        }

        private void saveLoanButton_Click(object sender, EventArgs e)
        {
            string fullname = fullNameTextBox.Text;
            string idNumber = idNumberTextBox.Text;
            double amount = Convert.ToDouble(amountTextBox.Text);
            double interestRate = Convert.ToDouble(interestRateTextBox.Text);

            double calculatedLoan1 = 0;

            calculatedLoan1 = calculateLoan(amount, interestRate);
            message(calculatedLoan1.ToString());


        }

        private void message(string message)
        {
            MessageBox.Show(message);
        }

        private double calculateLoan(double amount, double interestRate)
        {
            double totalLoan = 0;

            totalLoan = amount + (amount * interestRate / 100);

            return totalLoan;
        }
    }
}
