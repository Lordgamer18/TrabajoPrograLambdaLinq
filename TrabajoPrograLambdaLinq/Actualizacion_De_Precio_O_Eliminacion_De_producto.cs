using System;
using System.Linq;

namespace TrabajoPrograLambdaLinq
{
    public class Actualizacion_De_Precio_O_Eliminacion_De_producto
    {
        private Inventario inventario;

        public Actualizacion_De_Precio_O_Eliminacion_De_producto(Inventario inventario)
        {
            this.inventario = inventario;
        }

        public void ActualizarPrecio()
        {
            Console.Write("Ingrese el nombre del producto cuyo precio desea actualizar: ");
            string nombre = Console.ReadLine();

            var producto = inventario.productos.FirstOrDefault(p => p.Nombre_del_producto.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (producto != null)
            {
                Console.Write($"Ingrese el nuevo precio para '{producto.Nombre_del_producto}': ");
                if (double.TryParse(Console.ReadLine(), out double nuevoPrecio) && nuevoPrecio > 0)
                {
                    producto.Precio_del_producto = nuevoPrecio;
                    Console.WriteLine($"Precio de '{nombre}' actualizado a {nuevoPrecio:C}");
                }
                else
                {
                    Console.WriteLine("Precio inválido. Debe ser un número mayor a 0.");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto()
        {
            Console.Write("Ingrese el nombre del producto que desea eliminar: ");
            string nombre = Console.ReadLine();

            var producto = inventario.productos.FirstOrDefault(p => p.Nombre_del_producto.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (producto != null)
            {
                inventario.productos.Remove(producto);
                Console.WriteLine($"Producto '{nombre}' eliminado del inventario.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void MenuDeActualizacion()
        {
            Console.WriteLine("\n--- Menú de Actualización de Producto ---");
            Console.WriteLine("1. Actualizar precio de un producto");
            Console.WriteLine("2. Eliminar un producto");
            Console.WriteLine("3. Volver al menú principal");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ActualizarPrecio();
                    break;
                case "2":
                    EliminarProducto();
                    break;
                case "3":
                    Console.WriteLine("Regresando al menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    MenuDeActualizacion();
                    break;
            }
        }
    }
}
