using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nuevoobligatorio2
{

    public class Cliente
    {
        //ATRIBUTOS

        private int _CI;
        private string _nombre;
        private string _apellido;
        private int _telefono;

        //PROPIEDADES

        public int CI
        {
            get { return _CI; }

            set
            {
                if (value <= 99999999)
                    _CI = value;
                else
                    throw new Exception("Numero de documento invalido!");

            }
        }
        public string nombre
        {
            get { return _nombre; }

            set
            {
                if (value.Trim().Length > 3)
                    _nombre = value;
                else
                    throw new Exception("Nombre invalido! Ingrese su nombre completo");
            }
        }
        public string apellido
        {
            get { return _apellido; }

            set
            {
                if (value.Trim().Length > 3)
                    _apellido
 = value;
                else
                    throw new Exception("Nombre invalido! Ingrese su nombre completo");
            }
        }

        public int telefono
        {
            get { return _telefono; }
            set
            {
                if (value <= 99999999)
                    _telefono = value;
                else
                    throw new Exception("Numero de telefono invalido!");
            }
        }

        //CONSTRUCTOR COMPLETO

        public Cliente(int pCI, string pNombre, string pApellido, int pTelefono)
        {
            CI = pCI;
            nombre = pNombre;
            apellido = pApellido;
            telefono = pTelefono;

        }

        public string DatosCliente()
        {
            return "Nombre completo: " + this._nombre + " " + " CI: " + this._CI + " Telf: " + this._telefono;
        }
    }
}

