using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace nuevoobligatorio2
{
    public class EntFinanciera
    {
        //ATRIBUTOS
        private int _rut;
        private string _nombre;
        List<Tarjeta> ListaTarjetas;
        List<Cliente> ListaClientes;


        //  SOLAMENTE VECTOR TIPO TARJETA PARA ALMACENAR LAS TARJETAS ???? O TAMBIEN VECTOR TIPO CLIENTE PARA ALMACENAR CLIENTES ???

        //PROPIEDADES
        public int rut //EL RUT SE PUEDE HARDCODEAR
        {
            get { return _rut; }
            set
            {
                if (value <= 0)
                    throw new Exception("RUT invalido");
                else
                    _rut = value;
            }

        }

        public string nombre //EL NOMBRE TAMBIEN SE PUEDE HARDCODEAR
        {
            set
            {
                if (value.Trim().Length > 0)
                    _nombre = value;
                else
                    throw new Exception("No hay nombre");
            }
            get { return _nombre; }
        }



        //CONSTRUCTOR COMPLETO
        public EntFinanciera(int pRut, string pNombre) //falta parametro del atributo asociativo
        {
            rut = pRut;
            nombre = pNombre;
            ListaTarjetas = new List<Tarjeta>();
            ListaClientes = new List<Cliente>();

        }

        // OPERACIONES TARJETAS------------------------------------------------

        public Tarjeta BuscarTarjeta(int numero)
        {
            foreach (Tarjeta T in ListaTarjetas)
            {
                if (T._numero == numero)
                    return (T);
            }
            return null;
        }
        public bool AgregarTarjeta(Tarjeta unaTarjeta)
        {
            if (BuscarTarjeta(unaTarjeta._numero) == null)
            {
                ListaTarjetas.Add(unaTarjeta);
                return (true);
            }

            return (false);
        }

        public bool EliminarTarjeta(Tarjeta unaTarjeta)
        {
            return ListaTarjetas.Remove(unaTarjeta);
        }

        public bool ModificarTarjeta(Tarjeta unaTarjeta)
        {
            if (EliminarTarjeta(unaTarjeta))
            {
                AgregarTarjeta(unaTarjeta);
                return (true);
            }

            return (false);
        }

        public List<Tarjeta> _ListaTarjetas()
        {
            return ListaTarjetas;
        }

        //OPERACIONES CLIENTES -------------------------------------------

        public Cliente BuscarCliente(int cedula)
        {
            foreach (Cliente C in ListaClientes)
            {
                if (C.CI == cedula)
                    return (C);
            }
            return (null);
        }

        public bool AgregarCliente(Cliente unC)
        {
            if (BuscarCliente(unC.CI) == null)
            {
                ListaClientes.Add(unC);
                return (true);
            }
            return (false);
        }

        public bool EliminarCliente(Cliente unC)
        {
            return (ListaClientes.Remove(unC));
        }

        public bool ModificarCliente(Cliente unC)
        {
            if (EliminarCliente(unC))
                return (AgregarCliente(unC));
            else
                return false;
        }

        public List<Cliente> _ListaClientes()
        {
            return ListaClientes;
        }

    }
}