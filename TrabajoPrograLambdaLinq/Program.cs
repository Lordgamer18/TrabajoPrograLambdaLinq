using System;

namespace TrabajoPrograLambdaLinq
{
    class Program
    {
        public static void Main(string[] args)
        {
            Inventario inventario = new Inventario();
            Actualizacion_De_Precio_O_Eliminacion_De_producto actualizacion = new Actualizacion_De_Precio_O_Eliminacion_De_producto(inventario);

            Console.WriteLine("Bienvenido al sistema de gestión de inventario");

            Console.WriteLine("¿Cuántos productos desea ingresar?");
            int cantidad_de_productos = int.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------");

            for (int i = 0; i < cantidad_de_productos; i++)
            {
                Console.WriteLine($"Producto {i + 1}");
                string nombre_del_producto;
                do
                {
                    Console.Write("Nombre: ");
                    nombre_del_producto = Console.ReadLine();
                    if (string.IsNullOrEmpty(nombre_del_producto))
                    {
                        Console.WriteLine("Ingresa el nombre del producto, por favor.");
                    }
                } while (string.IsNullOrEmpty(nombre_del_producto));

                double precio_del_producto;
                do
                {
                    Console.Write("Precio: ");
                    precio_del_producto = Convert.ToDouble(Console.ReadLine());
                    if (precio_del_producto <= 0)
                    {
                        Console.WriteLine("El precio debe ser mayor a 0, ingresa un precio válido.");
                    }
                } while (precio_del_producto <= 0);

                Console.WriteLine("----------------------------------------------");

                Producto producto = new Producto(nombre_del_producto, precio_del_producto);
                inventario.AgregarProducto(producto);
            }

            // Mostrar el menú de actualización
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Menú Principal ---");
                Console.WriteLine("1. Generar reporte del inventario");
                Console.WriteLine("2. Filtrar productos por precio");
                Console.WriteLine("3. Actualizar o eliminar un producto");
                Console.WriteLine("4. Salir");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        inventario.GenerarReporte();
                        break;
                    case "2":
                        Console.Write("Ingrese el precio mínimo para filtrar los productos: ");
                        double precioMinimo = Convert.ToDouble(Console.ReadLine());
                        var productosFiltrados = inventario.FiltrarYordenarProductos(precioMinimo);
                        Console.WriteLine("\nProductos filtrados y ordenados:");
                        foreach (var producto in productosFiltrados)
                        {
                            producto.MostrarInformacion();
                        }
                        break;
                    case "3":
                        actualizacion.MenuDeActualizacion();
                        break;
                    case "4":
                        salir = true;
                        Console.WriteLine("Gracias por usar el sistema de gestión de inventario.");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
