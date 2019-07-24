using System;
using System.Collections.Generic;
using System.Text;
//Importamos paquete SQLite
using SQLite;

namespace AppGym.Model
{

    //Especificamos el nombre de nuestra tabla
    [Table("Cliente")]
    //[Table(nameof(Cliente))]

    //Agregamos la clase como publica
    public class Cliente
    {
        //Especificamos el campo IdCliente como llave primaria y autoincrementable
        [PrimaryKey,AutoIncrement,NotNull]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        //public string Foto { get; set; }
        public string Fecha { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
