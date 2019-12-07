using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeerArchivo
{
    public class Menu
    {
        //Lista publica para utilizar metodos
        public List<Album> disco;
        
        //Constructor de la lista
        public Menu() 
        {
            disco = ObtenerAlbum();
        }
        
        //Se llama al main para la bienvenida
        internal void Principal() 
        {
            Console.WriteLine("Bienvenido a la lista de Albums");
            Console.ReadKey();
            Console.Clear();
           
            MenuOp();
        }

        //Menu con dos opciones
        public void MenuOp()
        {
            //Al usar sintaxis indebida sale
            try
            {
                MostrarAlbums();//metodo de despliegue de la lista de objetos
                Console.WriteLine("\nSeleccione opcion: \n1.- Detallar Album.\n2.- Salir.");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1://si el usuario quiere detallar ira al metodo despues de limpiar
                        Console.Clear();
                        
                        //Metodo para acceder al detallado de objeto
                        DetallesAlbum();

                        break;

                    case 2:
                        //Salir del programa
                        System.Environment.Exit(-1);

                        break;

                    default:
                       
                        Console.Clear();
                        Console.WriteLine("Seleccione una opcion valida, por favor.");
                        Console.ReadKey();
                        Console.Clear();

                        MenuOp();
                        break;
                }

            }

            catch (Exception ) //es un segundo default, porque solo pedimos numeros
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opcion valida, por favor.");
                Console.ReadKey();
                Console.Clear();
                MenuOp();
            }
        }
        //metodo para desplegar la lista publica
        public void MostrarAlbums() 
        {
            Console.WriteLine("Albums: ");
            //foreach para cada elemento de la lista
            foreach (var item in disco)
            {
                Console.WriteLine("{0}.- {1}", item.ID, item.Nombre);
            }

        }
        //es metodo tipo lista de string,se saca la info del txt
        public List<string> ObtenerLineas(string path)
        {
            List<string> lineas = new List<string>();//creas tu lista
            if (File.Exists(path))//buscas en el file si existe
            {
                //creas un array de datos que sacara su info del txt
                string[] datos = File.ReadAllLines(path);
                foreach (var item in datos)//foreach para buscar en el array
                {
                    lineas.Add(item);
                }
            }
            else
            {
                //si no hay archivo se devuelve un null
                Console.WriteLine("El archivo no existe");
                return null;
            }
            return lineas;//cuando se llene la lista de strings se devuelve al metodo que sigue
        }

        public List<Album> ObtenerAlbum()
        {
            Album a = new Album();//instancia de shinobi para manejar objetos
            var lineas = ObtenerLineas("Lista.txt");//jalas tu lista con un var para optimizar
            List<Album> al = new List<Album>();
            //foreach para buscar en la lista de strings
            foreach (var item in lineas)
            {
                //dividir elementos
                string[] datos = item.Split(',');
                al.Add(new Album { ID = int.Parse(datos[0]), Nombre = datos[1], Artista = datos[2], Empresa = datos[3], Years = int.Parse(datos[4]) });//cada que llenes tu arreglo de 5 elementos, los conviertes en atributos del objeto y los agregas a la lista 
            }
            return al;//devuelves la lista de objetos
        }
        public void DetallesAlbum() 
        {
            //limpias para remover el menu
            Console.Clear();
            
            //muestras lista para que el usuario sepa que busca
            MostrarAlbums();
            
            //Para mostar los datos
            foreach (Album d in disco)
            {
                Console.WriteLine("Nombre Album:" + d.Nombre + " El artista es:\n" + d.Artista);
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine("");
                Console.ReadKey();
            }


        }
    }
}