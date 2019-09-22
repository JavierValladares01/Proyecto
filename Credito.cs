using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nuevoobligatorio2
{
    public class Credito : Tarjeta
    {
        //ATRIBUTOS
        private string Categoria;
        private int CreditoLimite;

        //PROPIEDADES
        public string _categoria
        {
            get { return Categoria; }
            set { Categoria = value; }
        }

        public int _creditoLimite
        {
            get { return CreditoLimite; }
            set
            {
                if (value > 0)
                    CreditoLimite = value;
                else
                    throw new Exception("Error - Limite de credito incorrecto");
            }
        }

        //CONSTRUCTOR
        public Credito(string pCategoria, int pCreditoLimite, int pNumero, bool pPersonalizada)
            : base(pNumero, pPersonalizada)
        {
            _categoria = pCategoria;
            _creditoLimite = pCreditoLimite;
        }

    }
}
