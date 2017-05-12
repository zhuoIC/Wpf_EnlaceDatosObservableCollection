using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------------------
using System.Collections.ObjectModel;

namespace NHJ.Wpf_DataContext_ClasePersonas
{
    public class ListaPersonas: ObservableCollection<Persona>
    {
        Random rnd = new Random();

        // Creo una lista con varias personas
        public ListaPersonas():base()
        {
            Add(new Persona("José", "Rodríguez", CrearFechaNacimiento(), CrearEstatura()));
            Add(new Persona("Sergio", "García", CrearFechaNacimiento(), CrearEstatura()));
            Add(new Persona("Isco", "Alarcón", CrearFechaNacimiento(), CrearEstatura()));
            Add(new Persona("Mateo", "Kovacic", CrearFechaNacimiento(), CrearEstatura()));
            Add(new Persona("Roberto", "Carlos", CrearFechaNacimiento(), CrearEstatura()));
        }

        private DateTime CrearFechaNacimiento()
        {
            // Crea una fecha aleatoria de los últimos 30 años
            DateTime fecha = new DateTime();
            fecha = DateTime.Now - TimeSpan.FromDays(rnd.Next(1, 365 * 30));
            return fecha;
        }

        private double CrearEstatura()
        {
            // Creo estatura emtre 1.50 y 2.10
            double estatura = rnd.Next(150, 211);
            estatura /= 100;
            return estatura;
        }
    }
}
