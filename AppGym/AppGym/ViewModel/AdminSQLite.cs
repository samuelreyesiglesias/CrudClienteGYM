using System;
using System.Collections.Generic;
using System.Text;
//Importamos paquete SQLite en librerias.
using SQLite;
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//Importamos la libreria que nos permite hacer uso de Rutas. Necesaria para usar la clase Path
using System.IO;
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//Importamos carpeta Model
using AppGym.Model;

namespace AppGym.ViewModel
{

    //CLASE PARA REALIZAR LA CONEXION Y ADMINISTRACION DE BASE DATOS
    public class AdminSQLite
    {
        public SQLiteConnection MyDb { get; set; }

        //CONSTRUCTOR QUE INICIALIZA LA CONEXION A BASE DE DATOS
        public AdminSQLite()
        {
            string Ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GYM.db3");
            MyDb = new SQLiteConnection(Ruta);
            MyDb.CreateTable<Cliente>();
        }
        //ESCRIBIR UN METODO PARA INSERTAR DATO
        public int Insertar(Cliente datos)
        {
            return MyDb.Insert(datos);
        }
        public int Eliminar(Cliente datos)
        {
            return MyDb.Delete(datos);
        }
        public int Actualizar(Cliente datos)
        {
            return MyDb.Update(datos);
        }
       
        public Cliente Leer(int IdCliente)
        {
            return MyDb.Table<Cliente>().Where(n => n.IdCliente == IdCliente).FirstOrDefault();
        }
        public List<Cliente> LeerDatos()
        {
            return MyDb.Table<Cliente>().ToList();
        }
    }
}
