using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//Importar carpeta Model
using AppGym.Model;
//Importamos la Carpeta ViewModel
using AppGym.ViewModel;
namespace AppGym.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroCliente : ContentPage
    {
        public AdminSQLite Conexion { get; set; }
        public RegistroCliente()
        {
            InitializeComponent();
            conectar();
        }
        public void conectar()
        {
            Conexion = new AdminSQLite();
        }
        public Cliente Actualizar { get; set; }
        public RegistroCliente(Cliente datos)
        {
            InitializeComponent();
            conectar();
            Actualizar = new Cliente();
            Actualizar = datos;
            BindingContext = datos;
            Button botonEliminar = new Button
            {
                Text = "Eliminar"
            };
            botonEliminar.Clicked += (sender, args) =>
            {
                StackParaBtnEliminar.Children.Add(botonEliminar);

                int Result = Conexion.Eliminar(Actualizar);
                if (Result == 1)
                {
                    DisplayAlert("Aviso", "Registro fue Eliminado", "Ok");
                }
                else
                {
                    DisplayAlert("Aviso", "Ocurrio un error", "Ok");
                }
                Navigation.PopAsync();
            };
           

        }
        private void Button_Clicked(object sender, EventArgs e)
        {

            
            //Creamos una instancia de la clase Cliente para guardar los datos de nuestro formulario
            Cliente Nuevo = new Cliente();

            //Asignamos los valores de nuestro formulario a las propiedades del nuevo objeto creado de la Clase Cliente
            Nuevo.Nombre = EntryNombre.Text;
            Nuevo.Edad = Convert.ToInt16( EntryEdad.Text);
            Nuevo.Sexo =  EntrySexo.Text;
            Nuevo.DUI = EntryDUI.Text;
            Nuevo.NIT = EntryNIT.Text;
            Nuevo.Fecha = DateTime.Now.ToString();
            Nuevo.Telefono = EntryTelefono.Text;
            Nuevo.Email = EntryEmail.Text;
            Nuevo.Direccion = EntryDireccion.Text;
            int resultado = 0;
            if (Actualizar != null) {
                Nuevo.IdCliente = Actualizar.IdCliente;
                //Insertamos los datos que anteriormente hemos guardado en el Objeto [Nuevo] de tipo Cliente
                 resultado = Conexion.Actualizar(Nuevo);
            }
            else
            {
                //Insertamos los datos que anteriormente hemos guardado en el Objeto [Nuevo] de tipo Cliente
                 resultado = Conexion.Insertar(Nuevo);
            }

            //Finalmente mostramos un mensaje al usuario 
            if (resultado == 1)
            {
                DisplayAlert("Mensaje", "Dato ingresado con exito", "ok");
            }
            else
            {
                DisplayAlert("Mensaje", "Hubo un error al ingresar dato", "ok");
            }
            Navigation.PopAsync();
        }
    }
}