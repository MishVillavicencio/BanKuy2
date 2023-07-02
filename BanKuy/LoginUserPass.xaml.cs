﻿using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUserPass : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public LoginUserPass()
        {
            InitializeComponent();
        }

        private async void btnIngresarUser_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtCedula.Text)){
                string Uri = "https://apibankuy-production.up.railway.app/login/{0}/{1}";
                var uri = new Uri(string.Format(Uri, txtCorreo.Text.ToString(), txtCedula.Text.ToString()));
                var content = await client.GetStringAsync(uri);
                List<login> post = JsonConvert.DeserializeObject<List<login>>(content);
                if (content == "[{}]")
                {
                    await DisplayAlert("Error", "Correo o contraseña incorrecta", "ok");
                }
                else if (content == "")
                {
                    await DisplayAlert("Alerta", "Cuenta Inactiva", "Ok");
                }
                else
                {
                    await Navigation.PushAsync(new PaginaPrincipal(post));
                }
            }
            else
            {
                await DisplayAlert("Error", "No ha ingresado ningun dato", "Ok");
            }
        }
    }
}