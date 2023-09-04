namespace ConsoleEXAMEN
{
    internal class Program
    {
 

   
    
        static void Main(string[] args)




        //Crear el menu principal
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1. Calcular costo de llamada telefónica internacional");
                Console.WriteLine("2. Gestionar biblioteca de libros");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            CalcularCostoLlamada();
                            break;
                        case 2:
                            GestionarBibliotecaLibros();
                            break;
                        case 3:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduzca un número.");
                }

            }
        }
        //Creando funcion para ingresar los datos solicitados
        static void CalcularCostoLlamada()
        {
            Console.WriteLine("Ejercicio 1: Calcular costo de llamada telefónica internacional");
            Dictionary<int, string> zonas = new Dictionary<int, string>()
        {
            { 12, "América del norte" },
            { 15, "América central" },
            { 18, "América del sur" },
            { 19, "Europa" },
            { 23, "Asia" }
        };

            Console.Write("Ingrese la clave de la zona (12,15,18,19,23): ");
            int clave = int.Parse(Console.ReadLine());

            //Procesando los datos con la utilizacion de condiciones
            if (zonas.ContainsKey(clave))
            {
                Console.Write("Ingrese el número de minutos hablados: ");
                double minutos = double.Parse(Console.ReadLine());

                double precioPorMinuto = ObtenerPrecioPorMinuto(clave);
                double costoLlamada = minutos * precioPorMinuto;

                Console.WriteLine($"El costo de la llamada a {zonas[clave]} por {minutos} minutos es de {costoLlamada:C}");
            }
            else
            {
                Console.WriteLine("Clave de zona no válida.");
            }

        }


        //Procedimiento para la obtencion del precio por llamada
        static double ObtenerPrecioPorMinuto(int clave)
        {
            switch (clave)
            {
                case 12:
                    return 2.0;
                case 15:
                    return 2.2;
                case 18:
                    return 4.5;
                case 19:
                    return 3.5;
                case 23:
                    return 6.0;
                default:
                    return 0.0;
            }
        }
        //Declaracion de los datos utilizados en la libreria
        struct Libro
        {
            public int Codigo;
            public String Titulo;
            public String ISBN;
            public int Edicion;
            public String Autor;
        }

        static Libro[] biblioteca = new Libro[100];
        static int contadorLibros = 0;

        //Menu principal de la libreria
        static void GestionarBibliotecaLibros()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nGestión de Biblioteca de Libros:");
                Console.WriteLine("1. Agregar libro");
                Console.WriteLine("2. Mostrar listado de libros");
                Console.WriteLine("3. Buscar libro por código");
                Console.WriteLine("4. Editar información de un libro");
                Console.WriteLine("5. Regresar al Menú Principal");
                Console.Write("Seleccione una opción: ");


                //Creando los casos que seran utilizados
                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarLibro();
                            break;
                        case 2:
                            MostrarListadoLibros();
                            break;
                        case 3:
                            BuscarLibroPorCodigo();
                            break;
                        case 4:
                            EditarLibroPorCodigo();
                            break;
                        case 5:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduzca un número.");
                }
            }
        }
        //Funcion para la agregacion de libros
        static void AgregarLibro()
        {
            if (contadorLibros < biblioteca.Length)
            {
                Console.WriteLine("Agregar un nuevo libro:");

                Libro nuevoLibro;
                Console.Write("Código: ");
                nuevoLibro.Codigo = int.Parse(Console.ReadLine());
                Console.Write("Título: ");
                nuevoLibro.Titulo = Console.ReadLine();
                Console.Write("ISBN: ");
                nuevoLibro.ISBN = Console.ReadLine();
                Console.Write("Edición: ");
                nuevoLibro.Edicion = int.Parse(Console.ReadLine());
                Console.Write("Autor: ");
                nuevoLibro.Autor = Console.ReadLine();

                biblioteca[contadorLibros] = nuevoLibro;
                contadorLibros++;

                Console.WriteLine("Libro agregado con éxito.");
            }
            else
            {
                Console.WriteLine("La biblioteca está llena. No se pueden agregar más libros.");
            }
        }
        //Funcion para mostrar libros
        static void MostrarListadoLibros()
        {
            if (contadorLibros == 0)
            {
                Console.WriteLine("La biblioteca está vacía. No hay libros para mostrar.");
                return;
            }

            Console.WriteLine("Listado de Libros:");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("| Código | Título           | ISBN          | Edición | Autor        |");
            Console.WriteLine("----------------------------------------------------------------------");

            for (int i = 0; i < contadorLibros; i++)
            {
                Console.WriteLine($"| {biblioteca[i].Codigo,-6} | {biblioteca[i].Titulo,-17} | {biblioteca[i].ISBN,-13} | {biblioteca[i].Edicion,-7} | {biblioteca[i].Autor,-13} |");
            }

            Console.WriteLine("---------------------------------------------------------");
        }
        //Funcion para buscar libros por el codigo
        static void BuscarLibroPorCodigo()
        {
            if (contadorLibros == 0)
            {
                Console.WriteLine("La biblioteca está vacía. No hay libros para buscar.");
                return;
            }

            Console.Write("Ingrese el código del libro a buscar: ");
            int codigoBuscado = int.Parse(Console.ReadLine());

            for (int i = 0; i < contadorLibros; i++)
            {
                if (biblioteca[i].Codigo == codigoBuscado)
                {
                    Console.WriteLine("Libro encontrado:");
                    Console.WriteLine($"Código: {biblioteca[i].Codigo}");
                    Console.WriteLine($"Título: {biblioteca[i].Titulo}");
                    Console.WriteLine($"ISBN: {biblioteca[i].ISBN}");
                    Console.WriteLine($"Edición: {biblioteca[i].Edicion}");
                    Console.WriteLine($"Autor: {biblioteca[i].Autor}");
                    return;
                }
            }

            Console.WriteLine("Libro no encontrado.");
        }
        //Funcion para editar libros por el codigo
        static void EditarLibroPorCodigo()
        {
            if (contadorLibros == 0)
            {
                Console.WriteLine("La biblioteca está vacía. No hay libros para editar.");
                return;
            }

            Console.Write("Ingrese el código del libro a editar: ");
            int codigoBuscado = int.Parse(Console.ReadLine());

            for (int i = 0; i < contadorLibros; i++)
            {
                if (biblioteca[i].Codigo == codigoBuscado)
                {
                    Console.WriteLine("Editar información del libro:");
                    Console.Write("Nuevo Título: ");
                    biblioteca[i].Titulo = Console.ReadLine();
                    Console.Write("Nuevo ISBN: ");
                    biblioteca[i].ISBN = Console.ReadLine();
                    Console.Write("Nueva Edición: ");
                    biblioteca[i].Edicion = int.Parse(Console.ReadLine());
                    Console.Write("Nuevo Autor: ");
                    biblioteca[i].Autor = Console.ReadLine();

                    Console.WriteLine("Información del libro actualizada con éxito.");
                    return;
                }
            }

            Console.WriteLine("Libro no encontrado. No se pudo editar.");
        }
    }


}
