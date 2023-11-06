using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        int numero1;
        string ultimoOp;
        bool apertouOperador = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            numero1 = 0;
            apertouOperador = false;
            txbaux.Clear();
            txbTela.Clear();
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento
            var botao = (Button)sender;
            if (apertouOperador == false && txbTela.Text != "")
            {
               
                numero1 = int.Parse(txbTela.Text);
                txbTela.Clear();
                txbaux.Text = numero1.ToString() + botao.Text;
                ultimoOp = botao.Text;
                apertouOperador = true;
            }
            else
            {
                if(txbaux.Text != "" && txbTela.Text != "")
                {
                    btnigual.PerformClick();
                    txbaux.Text = txbTela.Text + botao.Text;
                    numero1 = int.Parse(txbTela.Text);
                    txbTela.Text = "";
                    ultimoOp = botao.Text;
                }
                
            }
           
        }
        private void Numero_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
          
            if (txbTela.Text != "")
            {
                switch (ultimoOp)
                {
                    case "+":
                        txbaux.Clear();
                        txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();
                        break;

                    case "-":
                        txbaux.Clear();
                        txbTela.Text = (numero1 - int.Parse(txbTela.Text)).ToString();
                        break;

                    case "X":
                        txbaux.Clear();
                        txbTela.Text = (numero1 * int.Parse(txbTela.Text)).ToString();
                        break;

                    case "÷":
                        if (int.Parse(txbTela.Text) != 0)
                        {
                            txbaux.Clear();
                            txbTela.Text = (numero1 / int.Parse(txbTela.Text)).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Erro");
                        }
                        break;
                }
                
            }
            else
            {
                MessageBox.Show("Dados Inválidos");
            }
        }
    }
}
