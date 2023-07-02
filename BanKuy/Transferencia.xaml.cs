using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Transferencia : ContentPage
    {
        public Transferencia(string idCuenta)
        {
            InitializeComponent();
            idcuenta.Text=idCuenta.ToString();
        }

        private async void btnDirecta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaDirecta(idcuenta.Text));
        }

        private async void btnInterbancaria_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria());
        }
    }
}