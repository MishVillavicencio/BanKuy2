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
    public partial class TransferenciaInterbancaria : ContentPage
    {
        public TransferenciaInterbancaria()
        {
            InitializeComponent();
        }

        private async void btnPichincha_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2());
        }

        private async void btnGuayaquil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2());
        }

        private async void btnPacifico_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2());
        }

        private async void btnAustro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2());
        }

        private async void btnProdubanco_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2());

        }
    }
}