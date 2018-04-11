using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Matematica {
    public partial class Divisao : Form {
        Timer relogio = new Timer();
        int Resultado1, Resultado2, Resultado3;
        bool TempoAcabou;

        bool PodeDividir(int x, int y)
        {
            if (x % y == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Divisao_FormClosed(object sender, FormClosedEventArgs e)
        {
            relogio.Stop();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            this.Close();
            new Divisao().Show();
        }

        public Divisao()
        {
            InitializeComponent();
            relogio.Interval = 1000;
            int tempo = 120;

            relogio.Tick += delegate
            {
                tempo -= 1;
                Tempo.Text = tempo.ToString();
                if (tempo == 0)
                {
                    bool TempoAcabou = true;
                    this.TempoAcabou = TempoAcabou;
                    relogio.Stop();

                    MessageBox.Show("Acabou o Tempo!");
                    if (Resp1.Text == null)
                    {
                        Resp1.Text = "0";
                    }
                    if (Resp2.Text == null)
                    {
                        Resp2.Text = "0";
                    }
                    if (Resp3.Text == null)
                    {
                        Resp3.Text = "0";
                    }
                    Resp1.ReadOnly = true;
                    Resp2.ReadOnly = true;
                    Resp3.ReadOnly = true;
                }
            };

            relogio.Start();
            Random Random = new Random();
            int numero1, numero2, numero3, numero4, numero5, numero6;
            numero1 = Random.Next(1, 9);
            numero2 = Random.Next(1, 9);
            while (!PodeDividir(numero1, numero2) || numero2 == numero1)
            {
                numero1 = Random.Next(1, 9);
                numero2 = Random.Next(1, 9);
            }
            numero3 = Random.Next(1, 9);
            numero4 = Random.Next(1, 9);
            while (!PodeDividir(numero3, numero4) || numero4 == numero3)
            {
                numero3 = Random.Next(1, 9);
                numero4 = Random.Next(1, 9);
            }
            numero5 = Random.Next(1, 9);
            numero6 = Random.Next(1, 9);
            while (!PodeDividir(numero5, numero6) || numero6 == numero5)
            {
                numero5 = Random.Next(1, 9);
                numero6 = Random.Next(1, 9);
            }

            Numero1.Text = numero1.ToString();
            Numero2.Text = numero2.ToString();
            Numero3.Text = numero3.ToString();
            Numero4.Text = numero4.ToString();
            Numero5.Text = numero5.ToString();
            Numero6.Text = numero6.ToString();
            int Resultado1 = numero1 / numero2;
            int Resultado2 = numero3 / numero4;
            int Resultado3 = numero5 / numero6;
            this.Resultado1 = Resultado1;
            this.Resultado2 = Resultado2;
            this.Resultado3 = Resultado3;
        }

        private void Ok_Click(object sender, EventArgs e)
        {

            int Tentativa1, Tentativa2, Tentativa3;
            relogio.Stop();
            Resp1.ReadOnly = true;
            Resp2.ReadOnly = true;
            Resp3.ReadOnly = true;
            bool Pode;
            Pode = int.TryParse(Resp1.Text, out Tentativa1);
            Pode = int.TryParse(Resp2.Text, out Tentativa2);
            Pode = int.TryParse(Resp3.Text, out Tentativa3);
            if (!Pode)
            {
                MessageBox.Show("Entrada Inválida!");
            }
            else
            {
                Tentativa1 = int.Parse(Resp1.Text);
                Tentativa2 = int.Parse(Resp2.Text);
                Tentativa3 = int.Parse(Resp3.Text);
            }

            if (Resp1.Text == null)
            {
                Resp1.Text = "0";
            }
            if (Resp2.Text == null)
            {
                Resp2.Text = "0";
            }
            if (Resp3.Text == null)
            {
                Resp3.Text = "0";
            }
            else
            {
                List<string> Lista = new List<string>();
                int ponto = 0;
                string[] mensagens = new string[3];
                if (Resultado1 == Tentativa1)
                {
                    Res1.Text = "Certo!";
                    Res1.ForeColor = Color.Green;
                    ponto++;
                }
                else
                {
                    Res1.Text = "Errado!";
                    Res1.ForeColor = Color.Red;
                    string erro = "Resposta da questão 1: " + Resultado1.ToString();
                    Lista.Add(erro);

                }
                if (Resultado2 == Tentativa2)
                {
                    Res2.Text = "Certo!";
                    Res2.ForeColor = Color.Green;
                    ponto++;
                }
                else
                {
                    Res2.Text = "Errado!";
                    Res2.ForeColor = Color.Red;
                    string erro = "Resposta da questão 2: " + Resultado2.ToString();
                    Lista.Add(erro);

                }
                if (Resultado3 == Tentativa3)
                {
                    Res3.Text = "Certo!";
                    Res3.ForeColor = Color.Green;
                    ponto++;

                }
                else
                {
                    Res3.Text = "Errado!";
                    Res3.ForeColor = Color.Red;
                    string erro = "Resposta da questão 3: " + Resultado3.ToString();
                    Lista.Add(erro);
                }
                if (ponto == 3)
                {
                    MessageBox.Show("Muito bem! Você acertou todas as questões :D");
                }
                else
                {
                    string s = "Oops, parece que houveram alguns erros! Veja-os abaixo: \n";
                    foreach (string x in Lista)
                    {
                        s += x + "\n";
                    }
                    MessageBox.Show(s);
                }
            }

        }
    }
}
