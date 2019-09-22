using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nuevoobligatorio2
{

    public class Debito : Tarjeta
    {
        //ATRIBUTOS
        private int SaldoDisponible;
        private int CantCuentas;

        //PROPIEDADES

        public int _saldoDisponible
        {
            get { return SaldoDisponible; }
            set
            {
                if (value >= 0)
                    SaldoDisponible = value;
                else
                    throw new Exception("Error - Saldo disponible incorrecto");
            }
        }

        public int _cantCuentas
        {
            get { return CantCuentas; }
            set { _cantCuentas = _cantCuentas++;}
            
        }

        //CONSTRUCTOR
        public Debito(int pSaldoDisponible, int pCantCuentas, int pNumero, bool pPersonalizada)
            : base(pNumero, pPersonalizada)
        {
            SaldoDisponible = pSaldoDisponible;
            CantCuentas = pCantCuentas;
        }


    }
}
