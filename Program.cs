using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nuevoobligatorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            EntFinanciera EF = new EntFinanciera(346522, "Mi Banco");
            
            Menu(EF);
            /* while (opcion != 0)
            {
                Menu();
                opcion = PidoOpcion();
                // ========Switch basado en opcion ===========
                switch (opcion)
                {
                    case 1:
                        {*/

        }
        //Despliego el Menu
        private static void Menu(EntFinanciera unaEmpresa)
        {
            //variables
            int Opcion = 1;

            //Despliego Menu hasta que el usuario quiera salir
            while (Opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("                     " + unaEmpresa.nombre + ", rut: " + unaEmpresa.rut);
                Console.WriteLine("                        MENU PRINCIPAL ");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("1- Mantenimiento de clientes");
                Console.WriteLine("2- Solicitar tarjeta de Credito ");
                Console.WriteLine("3- Solicitar tarjeta de Debito");
                Console.WriteLine("4- Cargar saldo (Debito)");
                Console.WriteLine("5 - Pago de tarjeta (Credito)");
                Console.WriteLine("6 - Listado de Clientes");
                Console.WriteLine("7 - Listado de Pagos");
                Console.WriteLine("0- Salir");
                Console.Write("\n Ingrese opcion: ");

                try
                {
                    Opcion = Convert.ToInt32(Console.ReadLine());
                    Proceso(unaEmpresa, Opcion);

                    //pausa visual
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Opcion invalida (0 - 5)");
                    Console.ReadLine();
                }
            }
        }
        //procesa la opcion seleccionada por el usuario------------------------------
        private static void Proceso(EntFinanciera unaEmpresa, int OpcionMenu)
        {
            switch (OpcionMenu)
            {
                case 1:
                    {
                        MantenimientoClientes(unaEmpresa);
                        break;
                    }
                case 2:
                    {
                        AltaCredito(unaEmpresa);
                        break;
                    }
                case 3:
                    {
                        AltaDebito(unaEmpresa);
                        break;
                    }
                case 4:
                    {

                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 0:
                    {
                        //Esto queda asi nomas porque al hacer break sale del switch y termina la ejecucion del programa
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\n Opcion de Menu Invalida");
                        break;
                    }
            }
        }
        
        public static void AltaCliente(EntFinanciera unaEmpresa)
        {
            Cliente unCliente;
            int ci;
            string nombre;
            string apellido;
            int telefono;

            try
            {
                Console.Write("Ingrese nombre de cliente: ");
                nombre = Console.ReadLine();
                Console.Write("Ingrese apellido de ciente: ");
                apellido = Console.ReadLine();
                Console.Write("Ingrese Nro de Cedula: ");
                ci = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese Nro de telefono: ");
                telefono = Convert.ToInt32(Console.ReadLine());

                unCliente = new Cliente(ci, nombre, apellido, telefono);
                Console.Clear();

                if (unaEmpresa.AgregarCliente(unCliente))
                    Console.WriteLine("Se agrego cliente");
                else
                    Console.WriteLine("No se agrego cliente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);

                Console.ReadLine();
            }
        }
            

        public static void MantenimientoClientes(EntFinanciera unaEmpresa)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                Mantenimiento Clientes");
            Console.WriteLine("----------------------------------------------------------");

            try
            {
                //obtengo cedula
                Console.Write("Ingrese Cedula: ");
                int cedula = Convert.ToInt32(Console.ReadLine().Trim());

                //busco
                Cliente unCliente = unaEmpresa.BuscarCliente(cedula);

                //determino accion
                if (unCliente  == null)
                    AltaCliente(cedula, unaEmpresa);
                else
                {
                    string _opcion = "0";
                    bool _bandera = false;

                    while (!_bandera)
                    {
                        Console.WriteLine("\n\n");
                        Console.WriteLine(" 1 - Modificar Cliente");
                        Console.WriteLine(" 2 - Eliminar Cliente");
                        Console.WriteLine(" 3 - Salir a Menu Principal");

                        _opcion = Console.ReadLine().Trim();

                        switch (_opcion)
                        {
                            case "1":
                                ModificarCliente(unCliente, unaEmpresa);
                                _bandera = true;
                                break;
                            case "2":
                                EliminarCliente(unCliente, unaEmpresa);
                                _bandera = true;
                                break;
                            case "3":
                                _bandera = true;
                                break;
                            default:
                                Console.WriteLine("Error - Opcion de Menu Invalida");
                                Console.ReadLine();
                                break;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        public static void AltaCliente(int cedula, EntFinanciera unaEmpresa)
        {
            string nombre = "";
            string apellido = "";
            int telefono = 0;

            Console.Write("Ingrese nombre: ");
            nombre = Console.ReadLine().Trim();
            Console.Write("Ingrese apellido: ");
            apellido = Console.ReadLine().Trim();
            Console.Write("Ingrese Nro de telefono: ");
            telefono = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            try
            {
                //creo objeto
                Cliente unCliente = new Cliente(cedula, nombre, apellido, telefono);

                //agrego
                if (unaEmpresa.AgregarCliente(unCliente))
                {
                    Console.WriteLine("Se ha agregado el Cliente!");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - Cliente no agregado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void ModificarCliente(Cliente unCliente, EntFinanciera unaEmpresa)
        {
            string nombre = "";
            string apellido = "";
            int telefono = 0;
            
            Console.Write("Ingrese nuevo Nombre: ");
            nombre = Console.ReadLine().Trim();
            Console.Write("Ingrese nuevo apellido: ");
            apellido = Console.ReadLine().Trim();
            Console.Write("Ingrese nuevo nro. de telefono: ");
            telefono = Convert.ToInt32(Console.ReadLine());

            try
            {
                //modifico objeto
                unCliente.nombre = nombre;
                unCliente.apellido = apellido;
                unCliente.telefono = telefono;


                //agrego
                if (unaEmpresa.ModificarCliente(unCliente))
                {
                    Console.WriteLine("Los datos del cliente han sido actualizados!");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - Los datos no han podido ser modificados");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void EliminarCliente(Cliente unCliente, EntFinanciera unaEmpresa)
        {
            try
            {
                //elimino
                if (unaEmpresa.EliminarCliente(unCliente))
                {
                    Console.WriteLine("Se ha eliminado el cliente!");
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - El cliente no ha podido ser eliminado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void AltaCredito (EntFinanciera unaEmpresa)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                Solicitar tarjeta de credito");
            Console.WriteLine("---------------------------------------------------------\n\n");

            try
            {
                              
                Console.Write("Ingrese cedula cliente: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                Cliente unCliente = unaEmpresa.BuscarCliente(cedula);

                Console.WriteLine();

                if (unCliente == null)
                {
                    Console.WriteLine("Cliente no encontrado!");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.Write("Ingrese categoria: CLASICA / PLATA / ORO / PLATINIUM: ");
                    string categoria = Console.ReadLine().ToUpper();

                    Console.Write("Desea solicitar una tarjeta personalizada? <S/N> : ");
                    bool personalizada = ("S" == Console.ReadLine().ToUpper());

                    int credito = 50000;
                    int numTarjeta = 1;

                    Credito tarjetaCredito = new Credito(categoria, credito, numTarjeta, personalizada);
                    Console.WriteLine();

                    //agrego
                    if (unaEmpresa.AgregarTarjeta(tarjetaCredito))
                    {
                        Console.WriteLine("Tarjeta solicitada con exito!");
                        Console.ReadLine();
                    }
                    else
                    {
                        throw new Exception("Error - No se ha podido solicitar la tarjeta");
                    }

                }
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                Console.ReadLine();
            }


        }

        public static void AltaDebito(EntFinanciera unaEmpresa)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                Solicitar tarjeta de debito");
            Console.WriteLine("---------------------------------------------------------\n\n");

            try
            {
                
                Console.Write("Ingrese cedula cliente: ");
                int cedula = Convert.ToInt32(Console.ReadLine());

                Cliente unCliente = unaEmpresa.BuscarCliente(cedula);

                Console.WriteLine();

                if (unCliente == null)
                {
                    Console.WriteLine("Cliente no encontrado!");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.Write("Desea solicitar una tarjeta personalizada? <S/N> : ");
                    bool personalizada = ("S" == Console.ReadLine().ToUpper());

                    int saldo = 0;
                    int numTarjeta = 1;
                    int cantCuentas = 1;

                    Debito tarjetaDebito = new Debito(saldo, cantCuentas, numTarjeta, personalizada);
                    Console.WriteLine();

                    //agrego
                    if (unaEmpresa.AgregarTarjeta(tarjetaDebito))
                    {
                        Console.WriteLine("Tarjeta solicitada con exito!");
                        Console.ReadLine();
                    }
                    else
                    {
                        throw new Exception("Error - No se ha podido solicitar la tarjeta");
                    }

                }
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                Console.ReadLine();
            }


        }
            
        }
    }

