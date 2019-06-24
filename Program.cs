using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploGreedy
{

    //declaración de la estructura que almacenara los datos
    class Actividad : IComparable<Actividad>
    {
        public string nombre;
        public int tiempoInicio;
        public int tiempoFin;

        public Actividad()
        {
            nombre = "Actividad 1";
            tiempoInicio = 10;
            tiempoFin = 11;
        }

        public Actividad(string n, int i, int f)
        {
            nombre = n;
            tiempoInicio = i;
            tiempoFin = f;
        }


        //funcion de la Interfaz "IComparable" que permite que una actividad pueda compararse con otra bajo un criterio
        public int CompareTo(Actividad actividad2)
        {
            if (this.tiempoFin > actividad2.tiempoFin)
                return 1;
            else if (this.tiempoFin < actividad2.tiempoFin)
                return -1;
            else

                return 0;
        }
        public override string ToString()
        {
            return nombre +"["+tiempoInicio +"-"+tiempoFin+"]";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //declaramos el vector de actividades por medio de una lista
            List<Actividad> listaActividades;
            int n,i,j;
            //lectura de la cantidad de actividades a evaluar
            n = int.Parse(Console.ReadLine());
            //instanciamos el vector de actividades del tamaño leido
            listaActividades = new List<Actividad>(n);
            for( i = 0; i<n; i++)
            {
                //creamos una actividad y asignamos sus datos a su atributos
                Actividad act = new Actividad();
                act.nombre = Console.ReadLine();
                act.tiempoInicio = int.Parse(Console.ReadLine());
                act.tiempoFin = int.Parse(Console.ReadLine());
                //agregamos el objeto creado a nuestro vector
                listaActividades.Add(act);
            }

            //ordenamos nuestras actividades por el criterio del tiempo final
            //recuerde que para que una lista pueda ordenar, necesita que sus objetos sean "comparables",
            //por ello la clase 'Actividad' implemento la interfaz Comparable y personalizo la forma de comparar objetos "Actividad"
            //por medio de su atributo "tiempoFin"
            listaActividades.Sort();


            //imprimimos las actividades ordenadas por el tiempoFin
            for (i = 0; i < n; i++)
            {
                Console.WriteLine(listaActividades[i]);
            }


            //imprimimos la maxima cantidad e actividades que se pueden hacer.
            Console.WriteLine("Actividades a realizar : ");
            //printf("%d ", i);
            i = 0;
            Console.Write(listaActividades[i].nombre);

            
            for ( j = 1; j < n; j++)
            {
                // If this activity has start time greater than or 
                // equal to the finish time of previously selected 
                // activity, then select it 
                if (listaActividades[j].tiempoInicio >= listaActividades[i].tiempoFin)
                {
                    Console.Write( ",  "+listaActividades[j].nombre);
                    i = j;
                }
            }

            Console.ReadKey();

        }
    }
}
