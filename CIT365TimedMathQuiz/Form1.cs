using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIT365TimedMathQuiz
{
    public partial class Form1 : Form
    {

        /* Create a Random object called randomizer
           which will generate random numbers*/

        Random randomizer = new Random();

        //The variables that store the numbers for addition
        int addend1;
        int addend2;

        //The variables that store the numbers for difference
        int diffend1;
        int diffend2;

        //The variables that store the numbers for product
        int prodend1;
        int prodend2;

        //The variables that store the numbers for quotient
        int dividend;
        int divisor;

        //Declare variable to hold remaining time value
        int timeLeft;

        public void StartTheQuiz()
        {
            /*--------------- Addition ------------*/

            /*Add the code to fill in the addition problem
              Generate numbers and convert to String*/
            addend1 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();

            addend2 = randomizer.Next(51);
            plusRightLabel.Text = addend2.ToString();
                        
            //Initialize Sum to zero
            sum.Value = 0;

            /*--------------- Difference ------------*/

            /*Add the code to fill in the difference problem
              Generate numbers and convert to String*/
            diffend1 = randomizer.Next(1, 101); 
            minusLeftLabel.Text = diffend1.ToString();

            diffend2 = randomizer.Next(1, diffend1);
            minusRightLabel.Text = diffend2.ToString();

            //Initialize Difference to zero
            difference.Value = 0;

            /*--------------- Product ------------*/

            /*Add the code to fill in the product problem
              Generate numbers and convert to String*/
            prodend1 = randomizer.Next(2, 11);
            timeLeftLabel.Text = prodend1.ToString();

            prodend2 = randomizer.Next(2, 11);
            timesRightLabel.Text = prodend2.ToString();

            //Initialize Product to zero
            product.Value = 0;

            /*--------------- Quotient ------------*/

            /*Add the code to fill in the Quotient problem
              Generate numbers and convert to String*/
            divisor = randomizer.Next(2, 11);
            dividedRightLabel.Text = divisor.ToString();

            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();

            //Initialize Quotient to zero
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 40;
            timeLabel.Text = "40 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            /*--------------- Addition ------------*/

            if ((addend1 + addend2 == sum.Value) && (diffend1 - diffend2 == difference.Value) && (prodend1 * prodend2 == product.Value) && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
           
            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                if (timeLeft <= 5)
                    timeLabel.BackColor = Color.Red;

                // If CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";

            
            }
            
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = diffend1 - diffend2;
                product.Value = prodend1 * prodend2;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {

            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox2 = sender as NumericUpDown;

            if (answerBox2 != null)
            {
                int lengthOfAnswer = answerBox2.Value.ToString().Length;
                answerBox2.Select(0, lengthOfAnswer);
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
    }
}
