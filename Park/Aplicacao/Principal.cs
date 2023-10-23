using Park.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Park.Aplicacao
{
    public static class Principal
    {
        public static void Menu()
        {
            Console.WriteLine("################## RHITMOPARK ##################");

            Console.WriteLine("");
            Console.WriteLine("Informe o número de vagas para Motos:");
            var motorCycleParkingSpaces = EntradaConsole.ValorInteiroLinha();

            Console.WriteLine("");
            Console.WriteLine("Informe o número de vagas para Carros:");
            var carParkingSpaces = EntradaConsole.ValorInteiroLinha();

            Console.WriteLine("");
            Console.WriteLine("Informe o número de vagas para Vans:");
            var vanParkingSpaces = EntradaConsole.ValorInteiroLinha();
            Estacionamento parking = new(motorCycleParkingSpaces, carParkingSpaces, vanParkingSpaces);


            Console.WriteLine("");
            while (parking.EstacionamentoAberto)
            {
                Console.WriteLine("##################  RHITMOPARK ##################");
                Console.WriteLine("TOTAL DE {0} VAGAS.", parking.BuscarVagasTotal());
                Console.WriteLine("");
                Console.WriteLine("1 - Informar entrada de veículo");
                Console.WriteLine("2 - Informar saída de veículo");
                Console.WriteLine("3 - Consultar veículos");
                Console.WriteLine("4 - Sair do Sistema");

                var menuOption = EntradaConsole.ValorInteiroLinha();
                switch (menuOption)
                {
                    case 1:
                        Console.WriteLine("Informe a Placa do Veículo (Ex.: AAA-0A00 ou AAA-0000)");
                        var plate = EntradaConsole.LeituraLinha();
                        Console.WriteLine("");

                        Console.WriteLine("Informe a Marca do Veículo");
                        var brand = EntradaConsole.LeituraLinha();
                        Console.WriteLine("");

                        Console.WriteLine("Informe o Modelo do Veículo");
                        var model = EntradaConsole.LeituraLinha();
                        Console.WriteLine("");

                        Console.WriteLine("Informe o Tipo do Veículo de acordo com o abaixo:");
                        Console.WriteLine("");
                        var vehicleType = TipoVeiculo.Menu();

                        Veiculos vehicle = new(plate, brand, model, vehicleType);

                        Console.WriteLine(parking.AdicionarVeiculo(vehicle));

                        WaitNextCommand();
                        break;

                    case 2:
                        Console.WriteLine("Informe a Placa do Veículo que deseja retirar do estacionamento:");
                        Console.WriteLine(parking.RemoverVeiculo(EntradaConsole.LeituraLinha()));

                        WaitNextCommand();
                        break;

                    case 3:
                        MenuSistema.Menu(parking);
                        break;

                    case 4:
                        Console.WriteLine("Sistema Encerrado!");
                        parking.SetIsOpenFalse();
                        break;

                    default:
                        Console.WriteLine(Park.Aplicacao.Infra.MensagemErro.OpcaoInvalida);
                        break;
                }


            }

        }


        private static void WaitNextCommand()
        {
            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.ReadLine();
        }
    }
}
