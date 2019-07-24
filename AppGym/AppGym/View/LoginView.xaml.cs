using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGym.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            //Condiciones para Login: Para efectos de prueba, los usuarios los hemos dejado
            //Usuario: admin
            //Clave: admin
            if(EntryUsuario.Text =="admin" && EntryClave.Text == "admin")
            {
                Navigation.PushAsync(new PrincipalView());
            }
            else
            {
                DisplayAlert("Notificacion","Clave incorrecta","Cerrar");
            }
        }
    }
}