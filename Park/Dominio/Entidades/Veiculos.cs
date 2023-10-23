using Park.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Park.Dominio.Entidades
{
    public class Veiculos
    {
        public string Placa { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public TipoVeiculosEnum TipoVeiculos { get; private set; }
        public TipoVeiculosEnum TipoVagaVeiculo { get; private set; }
        public DateTime HoraEntrada { get; private set; }
        public DateTime? HoraSaida { get; private set; }
        public TimeSpan? TempoPermanencia { get; private set; }

        public Veiculos(string placa, string marca, string modelo, TipoVeiculosEnum tipoVeiculo)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            TipoVeiculos = tipoVeiculo;
            HoraEntrada = DateTime.Now;
        }

        public void RegistrarTipoVeiculo(TipoVeiculosEnum tipoVeiculo)
        {
            TipoVagaVeiculo = tipoVeiculo;
        }

        public void RegistrarSaida()
        {
            TempoPermanencia = DateTime.Now - HoraEntrada;
            HoraSaida = DateTime.Now;
        }

        public bool ValidaPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa) || placa.Length != 8)
                return false;

            var regularPlate = new Regex("[A-Z]{3}-[0-9]{4}");
            var mercosulPlate = new Regex("[A-Z]{3}-[0-9]{1}[A-Z]{1}[0-9]{2}");

            if (!regularPlate.IsMatch(placa.ToUpper()) && !mercosulPlate.IsMatch(placa.ToUpper()))
                return false;

            return true;
        }

        public override string ToString()
        {
            TimeSpan tempoPermanencia = new();
            if (!TempoPermanencia.HasValue)
                tempoPermanencia = DateTime.Now - HoraEntrada;

            return String.Format("\nPlaca: {0} \nMarca: {1} \nModelo: {2} \nTipo de Veículo: {3} \nEstacionado em Vaga do Tipo: {4} " +
                "\nHora de Entrada: {5} \nHora de Saída: {6} \nPermanência: {7}",
                Placa, Marca, Modelo, TipoVeiculos, TipoVagaVeiculo, HoraEntrada.ToString(), HoraSaida.ToString(), TempoPermanencia?.ToString("hh\\:mm\\:ss") ?? tempoPermanencia.ToString("hh\\:mm\\:ss"));
        }
    }
}
