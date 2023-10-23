using Microsoft.VisualBasic;
using Park.Aplicacao.Infra;
using Park.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Aplicacao
{
    public static class MenuSistema
    {
        public static void Menu(Estacionamento parking)
        {
            int menuOption = 0;
            while (!menuOption.Equals(6))
            {
                Console.Clear();

                Console.WriteLine("################## CONSULTAS DOS VEÍCULOS ##################");
                Console.WriteLine("1 - Consultar todos os veículos");
                Console.WriteLine("2 - Consultar veículo por placa");
                Console.WriteLine("3 - Consultar o total de vagas no estacionamento");
                Console.WriteLine("4 - Consultar o total de vagas vazias no estacionamento");
                Console.WriteLine("5 - Consultar o total de vagas vazias por tipo de Veículo");
                Console.WriteLine("6 - Retornar ao menu anterior");

                menuOption = EntradaConsole.ValorInteiroLinha();
                switch (menuOption)
                {
                    case 1:

                        var vehicleList = parking.GetAllParkedVehicle();

                        foreach (var vehicle in vehicleList)
                            Console.WriteLine(vehicle);

                        WaitNextCommand();
                        break;

                    case 2:
                        Console.WriteLine("Informe a placa que deseja buscar");
                        var plate = EntradaConsole.LeituraLinha();

                        Console.WriteLine(parking.BuscaVeiculoPorPlaca(plate));
                        WaitNextCommand();
                        break;

                    case 3:
                        Console.WriteLine("Total de {0} vagas.", parking.BuscarVagasTotal());
                        WaitNextCommand();
                        break;

                    case 4:
                        Console.WriteLine("O estacionamento possui {0} vagas vazias.", parking.BuscarVagasTotal(true));
                        WaitNextCommand();
                        break;

                    case 5:
                        var VehicleType = TipoVeiculo.Menu();

                        Console.WriteLine("O estacionamento possui {0} vagas de {1} vazias.", parking.BuscarVagasVaziasTotal(VehicleType), VehicleType);
                        WaitNextCommand();
                        break;

                    default:
                        Console.WriteLine(MensagemErro.OpcaoInvalida);
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
