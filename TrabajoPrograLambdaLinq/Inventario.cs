using System;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoPrograLambdaLinq
{
    public class Inventario
    {
        public List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public IEnumerable<Producto> FiltrarYordenarProductos(double precioMinimo)
        {
            return productos
                .Where(p => p.Precio_del_producto > precioMinimo)
                .OrderBy(p => p.Precio_del_producto);
        }

        public void GenerarReporte()
        {
            if (!productos.Any())
            {
                Console.WriteLine("No hay productos en el inventario.");
                return;
            }

            int menoresA100 = productos.Count(p => p.Precio_del_producto < 100);
            int entre100y500 = productos.Count(p => p.Precio_del_producto >= 100 && p.Precio_del_producto <= 500);
            int mayoresA500 = productos.Count(p => p.Precio_del_producto > 500);

            int totalProductos = productos.Count;

            double precioPromedio = productos.Average(p => p.Precio_del_producto);

            var productoMasCaro = productos.OrderByDescending(p => p.Precio_del_producto).First();
            var productoMasBarato = productos.OrderBy(p => p.Precio_del_producto).First();

            Console.WriteLine("\n--- Reporte del Inventario ---");
            Console.WriteLine($"Número total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de los productos: {precioPromedio:C}");
            Console.WriteLine($"Producto más caro: {productoMasCaro.Nombre_del_producto} (${productoMasCaro.Precio_del_producto:C})");
            Console.WriteLine($"Producto más barato: {productoMasBarato.Nombre_del_producto} (${productoMasBarato.Precio_del_producto:C})");
            Console.WriteLine("\nDistribución de productos por rango de precios:");
            Console.WriteLine($"Menores a $100: {menoresA100}");
            Console.WriteLine($"Entre $100 y $500: {entre100y500}");
            Console.WriteLine($"Mayores a $500: {mayoresA500}");
        }
    }
}
