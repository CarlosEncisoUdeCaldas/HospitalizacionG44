using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        //vamos a declarar e inicializar un objeto de tipo RepositorioPaciente
        //que sera un campo propio de la clase Program
        private static IRepositorioPaciente
            _repoPaciente =
                new RepositorioPaciente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            bool control = true;

            while (control)
            {
                System.Console.WriteLine();
                Console
                    .WriteLine("Bienvenido al programa Hospital en Casa G44");
                System.Console.WriteLine("#### Menu Principal ####");
                System.Console.WriteLine("1. Adicionar Paciente");
                System.Console.WriteLine("2. Borrar Paciente");
                System.Console.WriteLine("3. Buscar Paciente");
                System.Console.WriteLine("4. Asignar Medico");
                System.Console.WriteLine("5. Salir");
                System.Console.WriteLine("Digite su opcion");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AdicionarPaciente();
                        break;
                    case 2:
                        System
                            .Console
                            .WriteLine("Bienvenido a la opcion eliminar paciente");
                        System
                            .Console
                            .WriteLine("Digite el id del paciente a eliminar");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        EliminarPaciente (idEliminar);
                        break;
                    case 3:
                        System
                            .Console
                            .WriteLine("Bienvenido a la opcion buscar paciente");
                        System
                            .Console
                            .WriteLine("Digite el id del paciente a buscar");
                            int idBuscar = Convert.ToInt32(Console.ReadLine());

                        BuscarPaciente(idBuscar);

                        break;
                    case 4:
                        break;
                    case 5:
                        System
                            .Console
                            .WriteLine("Gracias por usar nuestro programa");
                        control = false;
                        break;
                    default:
                        System
                            .Console
                            .WriteLine("Opcion Invalida, digite nuevamente");
                        break;
                }
            }
        }

        //metodos para realizar el CRUD con la base de datos
        private static void AdicionarPaciente()
        {
            var paciente =
                new Paciente {
                    Nombre = "Bob",
                    Apellidos = "Esponja",
                    NumeroTelefono = "2223334455",
                    Genero = Genero.Masculino,
                    Direccion = "Casa Piña",
                    Longitud = 10.002F,
                    Latitud = 2.1212F,
                    Ciudad = "Arrecife",
                    FechaNacimiento = new DateTime(2005, 04, 16)
                };

            Console
                .WriteLine($"El paciente {paciente.Nombre} {paciente.Apellidos} será ingresado a la BD");
            _repoPaciente.AddPaciente (paciente);
            System.Console.WriteLine();
            Console
                .WriteLine($"El paciente {paciente.Nombre} {paciente.Apellidos} ha sido ingresado a la BD");
        }

        //metodo para eliminar paciente
        private static void EliminarPaciente(int idPaciente)
        {
            System
                .Console
                .WriteLine("¿Esta seguro de eliminar el paciente? \n1. Si \n2. No");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                System
                    .Console
                    .WriteLine($"El paciente con id {idPaciente} será eliminado");
                _repoPaciente.DeletePaciente (idPaciente);
                System.Console.WriteLine("Paciente eliminado con éxito");
            }
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            System
                .Console
                .WriteLine($"El paciente con id No {idPaciente} es {paciente.Nombre} {paciente.Apellidos}");
            System.Console.WriteLine($"Su informacion es:");
            System.Console.WriteLine($"Telefono: {paciente.NumeroTelefono}");
            System.Console.WriteLine($"Direccion: {paciente.Direccion}");
        }
    }
}
