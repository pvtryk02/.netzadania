using System;
using System.Windows.Forms;

namespace KalkulatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeGUI();
        }

        private void przyciskNumer_Click(object sender, EventArgs e)
        {
            Button przycisk = (Button)sender;
            poleWynik.Text += przycisk.Text;
        }

        private void przyciskCzysc_Click(object sender, EventArgs e)
        {
            poleWynik.Text = string.Empty;
        }

        private void przyciskOblicz_Click(object sender, EventArgs e)
        {
            try
            {
                var obliczenie = new System.Data.DataTable().Compute(poleWynik.Text, null);
                poleWynik.Text = obliczenie.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd obliczeniowy: {ex.Message}", "Błąd Obliczeń", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
