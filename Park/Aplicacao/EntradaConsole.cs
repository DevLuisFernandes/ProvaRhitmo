using Park.Aplicacao.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Aplicacao
{
    public static class EntradaConsole
    {

        public static int ValorInteiroLinha()
        {
            try
            {
                var consoleInput = int.TryParse(Console.ReadLine(), out int parseResult);

                if (!consoleInput)
                {
                    throw new Exception(MensagemErro.ValidacaoInteiro);
                }

                return parseResult;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ValorInteiroLinha();
            }
        }

        public static string LeituraLinha()
        {
            try
            {
                var consoleInput = Console.ReadLine();

                if (string.IsNullOrEmpty(consoleInput))
                {
                    throw new Exception(MensagemErro.ValorVazio);
                }

                return consoleInput;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return LeituraLinha();
            }
        }


    }
}
