using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Dominio.Infra
{
    public static class MensagemErro
    {
        public const string EstacionamentoVazio = "O Estacionamento está vazio.";
        public const string EstacionamentoCheio = "O Estacionamento está cheio.";
        public const string SemVagas = "Não há vagas de estacionamento disponíveis para este veículo.";
        public const string PlacaNaoEncontrada = "Não foi encontrado nenhum veículo com esta placa.";
        public const string PlacaExistente = "Já existe um veículo com esta placa no estacionamento.";
        public const string PlacaIncorreta = "Insira uma placa nos padrões corretos (Ex.: AAA-0A00 ou AAA-0000).";
    }
}
