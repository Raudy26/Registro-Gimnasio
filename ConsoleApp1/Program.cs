using System;
using System.Collections.Generic;

namespace Gimnasio
{
    // Definición de la clase Cliente
    class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public Cliente(int id, string nombre, int edad, string email, string telefono)
        {
            ID = id;
            Nombre = nombre;
            Edad = edad;
            Email = email;
            Telefono = telefono;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Teléfono: {Telefono}");
        }
    }

    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static int nextID = 1; // Variable para asignar IDs automáticos

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n*** Registro de clientes del Gimnasio ***");
                Console.WriteLine("1. Dar de alta un cliente");
                Console.WriteLine("2. Mostrar detalles de un cliente");
                Console.WriteLine("3. Listar clientes");
                Console.WriteLine("4. Buscar cliente (Nombre)");
                Console.WriteLine("5. Dar de baja un cliente");
                Console.WriteLine("6. Modificar un cliente");
                Console.WriteLine("7. Salir");
                Console.Write("Selecciona una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        DarDeAltaCliente();
                        break;
                    case 2:
                        MostrarDetallesCliente();
                        break;
                    case 3:
                        ListarClientes();
                        break;
                    case 4:
                        BuscarCliente();
                        break;
                    case 5:
                        DarDeBajaCliente();
                        break;
                    case 6:
                        ModificarCliente();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 7);
        }

        static void DarDeAltaCliente()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            Cliente nuevoCliente = new Cliente(nextID, nombre, edad, email, telefono);
            clientes.Add(nuevoCliente);
            nextID++;

            Console.WriteLine("Cliente registrado exitosamente.");
        }

        static void MostrarDetallesCliente()
        {
            Console.Write("Introduce el ID del cliente: ");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.ID == id);

            if (cliente != null)
            {
                cliente.MostrarDetalles();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        static void ListarClientes()
        {
            if (clientes.Count > 0)
            {
                Console.WriteLine("\nLista de clientes:");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.ID}, Nombre: {cliente.Nombre}");
                }
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }

        static void BuscarCliente()
        {
            Console.Write("Introduce el nombre del cliente: ");
            string nombre = Console.ReadLine();

            var cliente = clientes.Find(c => c.Nombre.ToLower() == nombre.ToLower());

            if (cliente != null)
            {
                cliente.MostrarDetalles();
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        static void DarDeBajaCliente()
        {
            Console.Write("Introduce el ID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.ID == id);

            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        static void ModificarCliente()
        {
            Console.Write("Introduce el ID del cliente a modificar: ");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.ID == id);

            if (cliente != null)
            {
                Console.Write("Nuevo nombre (dejar en blanco para no cambiar): ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                {
                    cliente.Nombre = nuevoNombre;
                }

                Console.Write("Nueva edad (dejar en blanco para no cambiar): ");
                string nuevaEdad = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevaEdad))
                {
                    cliente.Edad = int.Parse(nuevaEdad);
                }

                Console.Write("Nuevo email (dejar en blanco para no cambiar): ");
                string nuevoEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoEmail))
                {
                    cliente.Email = nuevoEmail;
                }

                Console.Write("Nuevo teléfono (dejar en blanco para no cambiar): ");
                string nuevoTelefono = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoTelefono))
                {
                    cliente.Telefono = nuevoTelefono;
                }

                Console.WriteLine("Cliente modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}
