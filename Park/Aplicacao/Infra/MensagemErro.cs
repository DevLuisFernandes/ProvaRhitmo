using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Aplicacao.Infra
{
    public static class MensagemErro
    {
        public const string InputIncorreto = "Você informou um valor diferente do esperado, favor informar um valor correto.";

        public const string ValorVazio = "Foi informado um valor vazio no console, favor informar um valor correto.";

        public const string ValidacaoInteiro = "Este campo só aceita valores do tipo inteiro, favor informar um valor correto.";

        public const string OpcaoInvalida = "Escolha uma opção válida.";
    }
}
