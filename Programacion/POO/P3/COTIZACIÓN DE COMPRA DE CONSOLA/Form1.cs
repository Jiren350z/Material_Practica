using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COTIZACIÓN_DE_COMPRA_DE_CONSOLA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {

            int total = 0;
            int consola = 0;

            string Consolaelegida = null;
            string garantia = null;
            string accesorio = null;
            

            //Garantia Extendida
            if (rb1anio.Checked == true)
            {
                total += 54990;
                garantia = "Contrata Garantia Extendida por: 1 año";
            }
            if (rb2anio.Checked == true)
            {
                total += 60990;
                garantia = "Contrata Garantia Extendida por: 2 años";
            }
            if (rb3anio.Checked == true)
            {
                total += 89990;
                garantia = "Contrata Garantia Extendida por: 3 años";
            }

            //agregar accesorio
            if (cbxControl.Checked == true)
            {
                total += 50000;
                accesorio += "Agrega Control Inalambrico" + Environment.NewLine;
            }
            if (cbxAudifono.Checked == true)
            {
                total += 60000;
                accesorio += "Agrega Audifono Bluetooth" + Environment.NewLine;
            }
            if (cbxTransporte.Checked == true)
            {
                total += 30000;
                accesorio += "Agrega Bolso Transporte" + Environment.NewLine;
            }

            //elegir consola y mostrar en el textbox
            if (cbxConsola.SelectedIndex == 0)
            {
                consola = 1300000;
                total += 1300000;
                Consolaelegida = "Consola elegida: PlayStation 5";
                txtCosto.Text = $"{consola}";

            }
            else if (cbxConsola.SelectedIndex == 1)
            {
                consola = 600000;
                total += 600000;
                Consolaelegida = "Consola elegida: Xbox Series X";
                txtCosto.Text = $"{consola}";
            }
            else if (cbxConsola.SelectedIndex == 2)
            {
                consola = 700000;
                total += 700000;
                Consolaelegida = "Consola elegida: Nintendo Swicth";
                txtCosto.Text = $"{consola}";
            }

            //muestra los resultados de la cotizacion 
            //txtResultado.Text = $"Cotizacion de: {txtNombre.Text} {Consolaelegida} \nContrata Garantia Extendida por: {garantia} \nAgrega: {accesorio} \nCosto Total: {total}";
            txtResultado.Text = $"Cotizacion de: {txtNombre.Text}" + Environment.NewLine + $"{Consolaelegida}" + Environment.NewLine + $"{garantia}" + Environment.NewLine + $"{accesorio}Costo Total:{total}";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
               //Agregando consolas al combobox
               cbxConsola.Items.Add("PlayStation 5");
               cbxConsola.Items.Add("Xbox Series X");
               cbxConsola.Items.Add("Nintendo Switch");       
        }
    }
}
