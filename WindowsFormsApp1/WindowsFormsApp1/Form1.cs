using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Lanterna l = new Lanterna();
        public Bateria b = new Bateria();

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Ligar";
            l.Status = "Desligado";
            label1.Text = $"{b.Porcentagem} %";
            label1.ForeColor = Color.Green;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (b.Porcentagem > 0)
            {
                if (l.Status == "Desligado")
                {
                    this.LigarLanterna();
                }
                else
                {
                    this.DesligarLanterna();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.RecarregarBateria();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b.Porcentagem -= 1;
            label1.Text = $"{b.Porcentagem} %";

            if (b.Porcentagem == 0)
            {
                label2.Text = "Acabou a bateria";
                label2.ForeColor = Color.Red;
                label2.Visible = true;
                this.DesligarLanterna();
            }
        }

        private void LigarLanterna()
        {
            button1.Text = "Ligar";
            l.Status = "Ligando";
            Form1.ActiveForm.BackColor = Color.White;
            timer1.Enabled = true;
        }
        private void DesligarLanterna()
        {
            button1.Text = "Desligar";
            l.Status = "Desligado";
            Form1.ActiveForm.BackColor = Color.Black;
            timer1.Enabled = false;
        }

       private void RecarregarBateria()
        {
            b.Porcentagem = 100;
            label1.Text = $"{b.Porcentagem} %";
            label2.Visible = false;
        }
    }
}
