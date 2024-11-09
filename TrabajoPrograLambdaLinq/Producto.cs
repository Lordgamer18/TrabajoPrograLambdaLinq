using System;

namespace TrabajoPrograLambdaLinq
{
    public class Producto
    {
        public string Nombre_del_producto { get; set; }
        public double Precio_del_producto { get; set; }
       
        public Producto(string nombre_del_producto, double precio_del_producto) {
        
          Nombre_del_producto = nombre_del_producto;
          Precio_del_producto = precio_del_producto;
        
        }   

        public void MostrarInformacion() {

            Console.WriteLine($"Producto: {Nombre_del_producto}");
            Console.WriteLine($"Precio: {Precio_del_producto:C}");
        
        }

    }
}
