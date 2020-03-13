using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using pruebaCliente.Models;
using pruebaCliente.Views;
using pruebaCliente.Services;
using System.Collections.Generic;

namespace pruebaCliente.ViewModels
{
    class VistaPruebaViewModel : BaseViewModel
    {

        vistaPruebaService service = new vistaPruebaService();

        INavigation Navigation;

        public string Url { get; set; }

        public Command IpCommand { get; set; }

        public Connection Con { get; set; }

        public VistaPruebaViewModel(INavigation Nav)
        {
            Navigation = Nav;
            IpCommand = new Command(async () => await IP(), () => !IsBusy);

        }

        private async Task IP()
        {
            bool successful;
            IsBusy = true;
            Con = new Connection()
            {
                Url = Url
            };
            if (string.IsNullOrEmpty(Con.Url))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "La dirección no puede ser nula", "Aceptar");
            }
            else
            {
                Console.WriteLine(Con.Url);
                successful = await service.SaveLocalAsync(Con);
                if (successful)
                {
                    await Application.Current.MainPage.DisplayAlert("Felicidades", "Se ha conectado satisfactoriamente a la url: " + Con.Url, "Aceptar");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se ha podido conectar a la url: " + Con.Url, "Aceptar");
                }
            }
            await Task.Delay(2000);
            IsBusy = false;
        }
    }

}