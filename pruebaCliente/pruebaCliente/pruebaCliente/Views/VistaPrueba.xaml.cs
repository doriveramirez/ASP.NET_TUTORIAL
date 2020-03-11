using pruebaCliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pruebaCliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaPrueba : ContentPage
    {
        VistaPruebaViewModel Context;
        public VistaPrueba()
        {
            InitializeComponent();
            Context = new VistaPruebaViewModel(Navigation);
            BindingContext = Context;
        }
    }
}