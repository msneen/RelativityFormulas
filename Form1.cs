using RelativityFormulas.Formulas;
using System;
using System.Windows.Forms;

namespace RelativityFormulas
{
    public partial class Form1 : Form
    {
        private const string VIMPS = "Velocity In Meters Per Second";
        private const string ERR = "Enter a proper value";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Text = "Velocity As Fraction Of Speed Of Light Beta";
            label8.Text = VIMPS;

            label1.Text = "Velocity Squared As Fraction Of Speed Of Light Squared Beta Squared";
            label2.Text = VIMPS;

            label12.Text = "Increase Due To Velocity LorentzFactor Gamma";
            label11.Text = VIMPS;

            label4.Text = "Decrease Due To Velocity Lorentz Denominator Gamma";
            label5.Text = VIMPS;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = (double.TryParse(textBox1.Text, out _))
                ? LorentzFormula.VelocitySquaredAsFractionOfSpeedOfLightSquared_BetaSquared(double.Parse(textBox1.Text)).ToString()
                : ERR;

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label3.Text = string.Empty;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 6)
            {
                label6.Text = (double.TryParse(textBox2.Text, out _))
                ? LorentzFormula.DecreaseDueToVelocity_LorentzDenominator_Gamma(double.Parse(textBox2.Text)).ToString()
                : ERR;

                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    label6.Text = string.Empty;
                }
            }
            else
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
            }            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label9.Text = (double.TryParse(textBox3.Text, out _))
                ? LorentzFormula.VelocityAsFractionOfSpeedOfLight_Beta(double.Parse(textBox3.Text)).ToString()
                : ERR;

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                label9.Text = string.Empty;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length < 6)
            {
                label10.Text = (double.TryParse(textBox4.Text, out _))
                    ? LorentzFormula.IncreaseDueToVelocity_LorentzFactor_Gamma(double.Parse(textBox4.Text)).ToString()
                    : ERR;

                if (string.IsNullOrEmpty(textBox4.Text))
                {
                    label10.Text = string.Empty;
                }
            }
            else
            {
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1, 1);
            }            
        }
    }
}
