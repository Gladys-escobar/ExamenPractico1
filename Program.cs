using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MENU_GENERAL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bandera = true;
            int valorSeleccionado;

            while (bandera)
            {
                Console.WriteLine("Bienvenido al menú principal");
                Console.WriteLine("Selecciona una opción: ");
                Console.WriteLine("1. Ver El Costo de las llamadas");
                Console.WriteLine("2. Registro de biblioteca");
                Console.WriteLine("3. Salir del sistema");
                valorSeleccionado = int.Parse(Console.ReadLine());
                switch (valorSeleccionado)
                {
                    case 1:
                        RegistroLlamadas();
                        break;
                    case 2:
                        Biblioteca();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del sistema");
                        bandera = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no encontrada");
                        break;
                }
            }
            Console.ReadKey();
        }
        static void RegistroLlamadas()
        {
            //Declaracion de variables

            double CostoPagar;
            int Claveporzona, minutos;

            //Ingreso de datos
            Console.WriteLine("Ingrese la clave a utilizar: ");
            Claveporzona = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la cantidad de minutos utilizados: ");
            minutos = int.Parse(Console.ReadLine());

            if (Claveporzona == 12)
            {
                CostoPagar = minutos * 2;
                Console.WriteLine("El total a pagar por llamada en America del norte es: " + CostoPagar);
            }
            else if (Claveporzona == 15)
            {
                CostoPagar = minutos * 2.2;
                Console.WriteLine("El total a pagar por llamada en America central es: " + CostoPagar);
            }
            else if (Claveporzona == 18)
            {
                CostoPagar = minutos * 4.5;
                Console.WriteLine("El total a pagar por llamada en America del sur es: " + CostoPagar);
            }
            else if (Claveporzona == 19)
            {
                CostoPagar = minutos * 3.5;
                Console.WriteLine("El total a pagar por llamada en Europa es: " + CostoPagar);
            }
            else if (Claveporzona == 23)
            {
                CostoPagar = minutos * 6;
                Console.WriteLine("El total a pagar por llamada en Asia es: " + CostoPagar);
            }
            else
            {
                Console.WriteLine("La clave ingresada no esta en el rango.");
            }

            Console.ReadKey();
        }

        struct Libro
        {
            public int Codigo;
            public string Titulo;
            public string ISBN;
            public int Edicion;
            public string Autor;
        }
        // La biblioteca puede almacenar hasta 10 libros.
        static Libro[] biblioteca = new Libro[10];
        static int contadorLibros = 0;
        static void Biblioteca()
        {
            bool bandera = true;

            while (bandera)
            {
                Console.WriteLine("Bienvenido al menú");
                Console.WriteLine("Selecciona una opción: ");
                Console.WriteLine("1. Agregar un libro");
                Console.WriteLine("2. Mostrar listado de libros");
                Console.WriteLine("3. Buscar libro por código");
                Console.WriteLine("4. Editar la información de un libro buscado por código");
                Console.WriteLine("5. Salir del sistema");
                int valorSeleccionado = int.Parse(Console.ReadLine());
                switch (valorSeleccionado)
                {
                    case 1:
                        AgregarLibro();
                        break;
                    case 2:
                        MostrarListado();
                        break;
                    case 3:
                        BuscarLibro();
                        break;
                    case 4:
                        EditarLibro();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del sistema");
                        bandera = false;
                        break;
                    default:
                        Console.WriteLine("Opcion no encontrada");
                        break;
                }
            }
        }
        static void AgregarLibro()
        {
            if (contadorLibros < biblioteca.Length)
            {
                Console.WriteLine("Ingrese los datos: ");

                Console.WriteLine("Codigo del libro: ");
                int codigo = int.Parse(Console.ReadLine());

                Console.WriteLine("Titulo del libro: ");
                string titulo = Console.ReadLine();

                Console.WriteLine("ISBN del libro: ");
                string isbn = Console.ReadLine();

                Console.WriteLine("Edición del libro: ");
                int edicion = int.Parse(Console.ReadLine());

                Console.WriteLine("Autor del libro: ");
                string autor = Console.ReadLine();

                Libro nuevoLibro = new Libro
                {
                    Codigo = codigo,
                    Titulo = titulo,
                    ISBN = isbn,
                    Edicion = edicion,
                    Autor = autor,
                };
                biblioteca[contadorLibros] = nuevoLibro;
                contadorLibros++;

                Console.WriteLine("El libro se agrego exitosamente.");
            }
            else
            {
                Console.WriteLine("El espacio de almacenamiento esta agotado");
            }
        }
        static void MostrarListado()
        {
            if (contadorLibros > 0)
            {
                Console.WriteLine("Listado de libros: ");
                Console.WriteLine("|Código\t\t| Titulo\t\t| ISBN\t\t| Edición\t\t| Autor");
                Console.WriteLine("--------------------------------------------------------------------------------");

                for (int i = 0; i < contadorLibros; i++)
                {
                    Console.WriteLine($"|{biblioteca[i].Codigo}\t\t| {biblioteca[i].Titulo}\t\t| {biblioteca[i].ISBN}\t\t| {biblioteca[i].Edicion}\t\t| {biblioteca[i].Autor}");
                }
            }
            else
            {
                Console.WriteLine("No se encuentran libros en la biblioteca.");
            }
        }
        static void BuscarLibro()
        {
            Console.WriteLine("Ingrese el código del libro a buscar");
            int CodigoBuscar = int.Parse(Console.ReadLine());
            bool realizado = true;
            for (int i = 0; i < contadorLibros; i++)
            {
                if (biblioteca[i].Codigo == CodigoBuscar)
                {
                    Console.WriteLine("Libro encontrado.");
                    Console.WriteLine("|Código\t\t| Titulo\t\t| ISBN\t\t| Edición\t\t| Autor");
                    Console.WriteLine("------------------------------------------------------------------------------------------");
                    Console.WriteLine($"|{biblioteca[i].Codigo}\t\t| {biblioteca[i].Titulo}\t\t| {biblioteca[i].ISBN}\t\t| {biblioteca[i].Edicion}\t\t| {biblioteca[i].Autor}");
                    realizado = false;
                    break;
                }
            }
        }
        static void EditarLibro()
        {
            Console.WriteLine("Ingrese el codigo del libro que desea editar: ");
            int CodigoEditar = int.Parse(Console.ReadLine());

            bool realizados = true;

            for (int i = 0; i < contadorLibros; i++)
            {
                if (biblioteca[i].Codigo == CodigoEditar)
                {
                    Console.WriteLine("Edite los siguientes datos del libro: ");

                    Console.WriteLine("Titulo del libro: ");
                    string titulo = Console.ReadLine();

                    Console.WriteLine("ISBN del libro: ");
                    string isbn = Console.ReadLine();

                    Console.WriteLine("Edición del libro: ");
                    int edicion = int.Parse(Console.ReadLine());

                    Console.WriteLine("Autor del libro: ");
                    string autor = Console.ReadLine();

                    biblioteca[i].Titulo = titulo;
                    biblioteca[i].ISBN = isbn;
                    biblioteca[i].Edicion = edicion;
                    biblioteca[i].Autor = autor;

                    Console.WriteLine("Libro editado satisfactoriamente.");
                    realizados = false;
                    break;
                }
                else
                {
                    Console.WriteLine("El libro que desea editar no se a encontrado.");
                }
            }
        }
    }
}