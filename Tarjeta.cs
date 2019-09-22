using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nuevoobligatorio2
{
    public class Tarjeta
    {
        //ATRIBUTOS
        private int Numero = 0;
        private bool Personalizada;

        //PROPIEDADES
        public int _numero
        {
            get { return Numero; }
            set { _numero = _numero++; }
        }

        public bool _personalizada
        {
            get { return Personalizada; }
            set { _personalizada = value; }
        }

        //CONSTRUCTOR
        public Tarjeta(int pNumero, bool pPersonalizada)
        {
            Numero = pNumero;
            Personalizada = pPersonalizada;
        }
    }
}

