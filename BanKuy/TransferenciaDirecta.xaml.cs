using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferenciaDirecta : ContentPage
    {
        public int idCuentaa;
        public int txtCuentaa;
        public int vC;
        private readonly HttpClient client = new HttpClient();
        public TransferenciaDirecta(string idCuenta)
        {
            InitializeComponent();
            this.idCuentaa=int.Parse(idCuenta); 
            idcuenta.Text = idCuenta.ToString();
        }

        private async void btnContinuar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfirmarTransferencia(idcuenta.Text,txtNcuenta.Text,txtMonto.Text));
        }

        private async void btnValidar_Clicked(object sender, EventArgs e)
        {






            




            if (!string.IsNullOrEmpty(txtNcuenta.Text)){
               this.vC=int.Parse(txtNcuenta.Text);  
                
                string Uri = "https://apibankuy-production.up.railway.app/verificarCuenta/{0}";
                var uri = new Uri(string.Format(Uri, txtNcuenta.Text.ToString()));
                var content = await client.GetStringAsync(uri);
                List<verificarCuenta> post = JsonConvert.DeserializeObject<List<verificarCuenta>>(content);              
                
                
                
                if (content == "[]")
                {
                    cuentaVerificada.Text = "Cuenta no encontrada ingrese de nuevo";
                }
                else
                {
                    cuentaVerificada.Text = post[0].nombre + " " + post[0].primerApellido;
                }
           
            
            
            }
            else 
            {
                cuentaVerificada.Text = "Ingrese un valor por favor";
            }

             







        }
    }
}