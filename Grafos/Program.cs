using System;

namespace CPE4
{
    class Program
    {
        static void Main(string[] args)
        {


            //primer grafo, seran personas puede representar amistad
            Grafo grafoAmigos = new Grafo();
            GrafoDeAmigos(grafoAmigos);
            //segundo grafo, representa conexiones entre algunas empresas conocidas
            Grafo grafoEmpresas = new Grafo();
            GrafoDeEmpresas(grafoEmpresas);
            

        
            bool salir = false;//Para el while



            //Caratula-Encabezado
            Console.WriteLine("<><><<><><><><><><><><><><><><><><><>><><><><><><><>");
            Console.WriteLine("<><><<><><><><><><><><><><><><><><><>><><><><><><><>");
            Console.WriteLine("<><><><><> Universidad Estatal Amazónica <><><><><>");
            Console.WriteLine("<><><<><><><><><><><><><><><><><><><>><><><><><><><>");
            Console.WriteLine("<><><<><><><><><><><><><><><><><><><>><><><><><><><>");
            Console.WriteLine();




            while (salir == false)
            {
                Console.WriteLine("=== GRAFOS ===");
                Console.WriteLine("1. Mostrar grafo N.1");
                Console.WriteLine("2. Mostrar grafo N.2");
                Console.WriteLine("3. Salir del programa");
                Console.Write("Seleccione una opción: ");
                
                string? opcionDeUsuario = Console.ReadLine();
                
                // Llamar a cada funcion segun el numero que nos de el usuario
                switch (opcionDeUsuario)
                {
                    case "1":
                        MostrarGrafoAmigos(grafoAmigos);
                        break;
                    case "2":
                        MostrarGrafoEmpresas(grafoEmpresas);
                        break;
                    case "3":
                        salir = true;//true para salir
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine("Cerrando el programa.....");
        }





        static void GrafoDeAmigos(Grafo grafo)
        {
            // Agregar algunas personas al grafo de amigos
            grafo.AgregarNodo("Carlitos");
            grafo.AgregarNodo("Messi");
            grafo.AgregarNodo("Luis");
            grafo.AgregarNodo("Kevin");
            grafo.AgregarNodo("David");
            grafo.AgregarNodo("Ricardo");
            
            // Hacer conexiones random entre todos
            // al final van a tener conexiones unos con otros como pasa en la vida real
            grafo.AgregarConexion("Carlitos", "Messi");
            grafo.AgregarConexion("Carlitos", "Luis");
            grafo.AgregarConexion("Messi", "Kevin");
            grafo.AgregarConexion("Luis", "David");
            grafo.AgregarConexion("Kevin", "David");
            grafo.AgregarConexion("Kevin", "Ricardo");
            grafo.AgregarConexion("David", "Ricardo");
        }
        



        static void GrafoDeEmpresas(Grafo grafo)
        {
            // empresas random solo para el ejemplo
            grafo.AgregarNodo("Google");
            grafo.AgregarNodo("Microsoft");
            grafo.AgregarNodo("Xiaomi");
            grafo.AgregarNodo("Asus");
            grafo.AgregarNodo("Motorola");
            grafo.AgregarNodo("Sony");
            grafo.AgregarNodo("CloudFlare");
            
            // Tal y como en la vida real algunas empresas hacen alianzas para crecer
            //es lo que vamos a simular
            grafo.AgregarConexion("Google", "Microsoft");
            grafo.AgregarConexion("Google", "Asus");
            grafo.AgregarConexion("Microsoft", "Xiaomi");
            grafo.AgregarConexion("Xiaomi", "Motorola");
            grafo.AgregarConexion("Asus", "Sony");
            grafo.AgregarConexion("Motorola", "CloudFlare");
            grafo.AgregarConexion("Sony", "CloudFlare");
            grafo.AgregarConexion("Google", "Motorola");
        }
        
  
  

        static void MostrarGrafoAmigos(Grafo grafo)
        {
            Console.WriteLine("||||||||| GRAFO 1 |||||||||\n");
            Console.WriteLine("Representación en lista de adyacencia:");
            grafo.VisualizarGrafo();//este metodo muestra el grafo con los nombres correspondientes
        }
        
        // Muestra el grafo empresarial con formato
        static void MostrarGrafoEmpresas(Grafo grafo)
        {
            Console.WriteLine("||||||||| GRAFO 2 |||||||||\n");
            Console.WriteLine("Representación en lista de adyacencia:");
            grafo.VisualizarGrafo();//le hice un formato diferente que creo que se ve bien y claro sobretodo
        }
    }





    class Grafo
    {
        // Almacena las relaciones usando diccionario
        private Dictionary<string, List<string>> listaAdyacencia;
        
        public Grafo()
        {
            // Inicializar la estructura de almacenamiento
            listaAdyacencia = new Dictionary<string, List<string>>();
        }




        
        // Método para añadir nodos al grafo
        public void AgregarNodo(string nodo)
        {
            // Evitar duplicados verificando existencia previa
            if (!listaAdyacencia.ContainsKey(nodo))
            {
                listaAdyacencia[nodo] = new List<string>();
            }
        }




        
        // Método para crear conexiones entre nodos
        public void AgregarConexion(string origen, string destino)
        {
            // esto es para asegurar que ambos nodos existan antes de conectarlos
            AgregarNodo(origen);
            AgregarNodo(destino);
            
            // Crear conexiones
            if (!listaAdyacencia[origen].Contains(destino))
            {
                listaAdyacencia[origen].Add(destino);
            }
            
            if (!listaAdyacencia[destino].Contains(origen))
            {
                listaAdyacencia[destino].Add(origen);
            }
        }





        //Hice un formato que me parece que es mas visual y se lo puede entender mejor a simple vista
        public void VisualizarGrafo()
        {
            Console.WriteLine("\nRepresentación del grafo:\n");
            
            // Recorrer cada nodo y mostrar sus conexiones
            foreach (var nodo in listaAdyacencia.Keys)
            {
                Console.WriteLine();
                Console.WriteLine($"{nodo} tiene conexión con:");//muestra uno a uno los nodos 
                
                // Listar todos los nodos conectados
                foreach (var conexion in listaAdyacencia[nodo])//recorre todas las conexiones y las pone en el formato
                {
                    Console.WriteLine($"|");
                    Console.WriteLine($"|---> {conexion}");//muestra una a una las conexiones 
                }
                
                Console.WriteLine();//espacio para que no se junte con el menu 



            }
        }
    }
}