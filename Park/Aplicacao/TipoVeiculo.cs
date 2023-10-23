using Park.Aplicacao.Infra;
using Park.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Aplicacao
{
    public static class TipoVeiculo
    {
        public static TipoVeiculosEnum Menu()
        {
            Console.WriteLine("################## MENU DE TIPOS DE VEÍCULOS ##################");
            Console.WriteLine("Informe o tipo de veículo que deseja utilizar:");
            Console.WriteLine("1 - Motos");
            Console.WriteLine("2 - Carros");
            Console.WriteLine("3 - Vans");

            return LeituraTipoVeiculo();
        }

        private static TipoVeiculosEnum LeituraTipoVeiculo()
        {
            var consoleInput = EntradaConsole.ValorInteiroLinha();

            if (consoleInput == 1)
                return TipoVeiculosEnum.Motos;

            else if (consoleInput == 2)
                return TipoVeiculosEnum.Carros;

            else if (consoleInput == 3)
                return TipoVeiculosEnum.Vans;

            else
            {
                Console.WriteLine(MensagemErro.InputIncorreto);
                return LeituraTipoVeiculo();
            }
        }
    }
}
