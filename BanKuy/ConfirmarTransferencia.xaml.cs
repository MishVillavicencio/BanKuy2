﻿using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmarTransferencia : ContentPage
    {
        public int idCuentaa;
        public int cuentaVerificadaa;
        public double valorconvertido;
        public ConfirmarTransferencia(string idCuenta,string cuentaVerificada,string monto)
        {
            InitializeComponent();
            dinero.Text = monto.ToString();
            origenCuenta.Text = idCuenta.ToString();
            destinoCuenta.Text=cuentaVerificada.ToString();
            string Monto = monto;
            this.valorconvertido = double.Parse(Monto);
            string idcuenta = idCuenta;
             this.idCuentaa = int.Parse(idcuenta);
            string cuentaverificada = cuentaVerificada;
             this.cuentaVerificadaa = int.Parse(cuentaverificada);
        }

        private async void btnConfirmarTransferencia_Clicked(object sender, EventArgs e)
        {









            transferencia transferencia = new transferencia
            {
                cuentaOrigen = this.idCuentaa,
                monto = this.valorconvertido,
                cuentaDestino=this.cuentaVerificadaa,
               
            };

            Uri URL = new Uri("https://apibankuy-production.up.railway.app/cuentas");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(transferencia);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(URL, contentJson);


            if (response.StatusCode == HttpStatusCode.OK)
            {

                await Navigation.PushAsync(new ComprobanteTransferencia());

            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                await DisplayAlert("Error", "Correo electronico ya registrado", "Ok");
            }




        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}