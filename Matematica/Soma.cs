using System;
using System.Drawing;
using System.Windows.Forms;

namespace Matematica {
    public partial class Soma : Form {
        int Resultado1, Resultado2, Resultado3;
        bool TempoAcabou;
        static Timer relogio = new Timer();

        public Soma()
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
            Numero1.Text = Random.Next(0, 99).ToString();
            Numero2.Text = Random.Next(0, 99).ToString();
            Numero3.Text = Random.Next(0, 99).ToString();
            Numero4.Text = Random.Next(0, 99).ToString();
            Numero5.Text = Random.Next(0, 99).ToString();
            Numero6.Text = Random.Next(0, 99).ToString();
            int Resultado1 = int.Parse(Numero1.Text) - int.Parse(Numero2.Text);
            int Resultado2 = int.Parse(Numero3.Text) - int.Parse(Numero4.Text);
            int Resultado3 = int.Parse(Numero5.Text) - int.Parse(Numero6.Text);
            this.Resultado1 = Resultado1;
            this.Resultado2 = Resultado2;
            this.Resultado3 = Resultado3;
            if (TempoAcabou)
            {
                Resp1.ReadOnly = true;
            }
        }

        private void Ok_Click_1(object sender, EventArgs e)
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
                    int ponto = 0;
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
                    }
                    if (ponto == 3)
                    {
                        MessageBox.Show("Muito bem! Você acertou todas as questões :D");
                    }
                }
            
        }
    }
}
