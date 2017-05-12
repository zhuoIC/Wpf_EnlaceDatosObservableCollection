using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-------------------------------
using System.ComponentModel;

namespace NHJ.Wpf_DataContext_ClasePersonas
{
    public class Persona: INotifyPropertyChanged
    {
        string _nombre;
        string _apellidos;
        DateTime _fechaNacimiento;
        double _estatura;

        public Persona()
        {
            _nombre = "Yo mismo";
            _apellidos = "Tu mismo";
            _fechaNacimiento = DateTime.Now;
            _estatura = 0.0;
        }

        public Persona(string nombre, string apellidos, DateTime fechaNacimiento, double estatura)
        {
            _nombre = nombre;
            _apellidos = apellidos;
            _fechaNacimiento = fechaNacimiento;
            _estatura = estatura;
        }

        public string Nombre 
        { 
            get { return _nombre; } 
            set 
            { 
                _nombre = value;
                MetodoAuxiliarCambio("Nombre");//this.Nombre.ToString()); Sincroniza los cambios
            } 
        }

        public string Apellidos 
        { 
            get { return _apellidos; } 
            set { _apellidos = value; } 
        }
        
        public DateTime FechaNacimiento 
        { 
            get { return _fechaNacimiento; } 
            set { _fechaNacimiento = value; } 
        }

        public double Estatura 
        { 
            get { return _estatura; } 
            set { _estatura = value; } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MetodoAuxiliarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}
