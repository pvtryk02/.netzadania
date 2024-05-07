using System;
using System.Windows.Forms;

namespace DzielenieLiczbApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponents();
        }

        private void przyciskDziel_Click(object sender, EventArgs e)
        {
            try
            {
                // Weryfikacja, czy dzielnik jest równy zero
                if (textBoxDzielnik.Text == "0")
                {
                    throw new DivideByZeroException("Dzielenie przez zero jest niedozwolone.");
                }

                // Obliczanie wyniku dzielenia
                double liczbaDoPodzielenia = double.Parse(textBoxDzielna.Text);
                double dzielnik = double.Parse(textBoxDzielnik.Text);
                double rezultat = liczbaDoPodzielenia / dzielnik;
                textBoxWynik.Text = rezultat.ToString("N2"); // formatowanie wyniku do dwóch miejsc po przecinku
            }
            catch (FormatException)
            {
                MessageBox.Show("Proszę wprowadzić poprawne wartości liczbowe.", "Błąd Formatu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException ex)
            {
                // Logowanie błędu dzielenia przez zero do systemowego dziennika zdarzeń
                System.Diagnostics.EventLog.WriteEntry("Application", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("Dzielenie przez zero! Proszę zmienić dzielnik.", "Błąd Dzielenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Logowanie innych błędów do dziennika zdarzeń systemowych
                System.Diagnostics.EventLog.WriteEntry("Application", ex.Message, System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("Wystąpił nieoczekiwany problem. Sprawdź dane wejściowe.", "Nieznany Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
