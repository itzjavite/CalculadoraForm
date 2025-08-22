using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForm
{
    public partial class Form1 : Form
    {
        // Variáveis Globais:
        bool operadorClicado = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                string expressao = txbTela.Text;

                // Usa a função Compute da classe DataTable:
                var resultado = new DataTable().Compute(expressao, null).ToString();

                // Mostra o resultado:
                txbTela.Text = resultado.ToString();

                if (double.IsInfinity(Convert.ToDouble(resultado)))
                {
                    MessageBox.Show("Deu ruim Parsa! 8(");
                    txbTela.Text = "";
                    operadorClicado = true;
                }
                else
                {
                    txbTela.Text = resultado; // já é string
                }
            }
            catch (Exception ex)
            {
                // Caso a expressão esteja errada:
                MessageBox.Show("Erro ao calcular: " + ex.Message);
                txbTela.Text = "";
            }

        }

        private void numero_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando esse evento:
            Button botaoClicado = (Button)sender;

            // Adcionar o Text do botão clicado no TextBox:
            txbTela.Text += botaoClicado.Text;

            // "abaixar a bandeirinha"
            operadorClicado = false;
        }

        private void operador_Click(object sender, EventArgs e)
        {
            // Verifivar se o operador ainda não foi clicado:
            if(operadorClicado == false)
            {
                // Obter o botão que está chamando esse evento:
                Button botaoClicado = (Button)sender;

                // Adcionar o Text do botão clicado no TextBox:
                txbTela.Text += botaoClicado.Text;

                // Mudar o operadorClicado para true (levantar a bandeirinha):
                operadorClicado = true;
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar a tela:
            txbTela.Text = "";
            // Voltar o operador clicado para true:
            operadorClicado = true;
        }
    }
}
