using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//importamos clase Model
using AppGym.Model;
//importamos clase ViewModel
using AppGym.ViewModel;
 

namespace AppGym.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientesView : ContentPage
    {
        public ClientesView()
        {
            InitializeComponent();
            AdminSQLite Conexion = new AdminSQLite();
            ListadoDeClientes.ItemsSource = Conexion.LeerDatos();
        }
        void OnListViewItemSelected
            (object sender, SelectedItemChangedEventArgs e)
        {
            Cliente ClienteSeleccionado = (Cliente)e.SelectedItem;
            Navigation.PushAsync(new RegistroCliente(ClienteSeleccionado));
        }
    }
}