using Park.Dominio.Infra;
using Park.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Dominio.Entidades
{
    public class Estacionamento
    {
        public bool EstacionamentoAberto { get; private set; }
        public int TotalMotos { get; private set; }
        public int TotalCarros { get; private set; }
        public int TotalVan { get; private set; }
        public List<Veiculos> Veiculos { get; private set; }

        public Estacionamento(int motorCycleParkingSpaceNumber, int carParkingSpaceNumber, int vanParkingSpaceNumber)
        {
            EstacionamentoAberto = true;
            TotalMotos = motorCycleParkingSpaceNumber;
            TotalCarros = carParkingSpaceNumber;
            TotalVan = vanParkingSpaceNumber;
            Veiculos = new List<Veiculos>();
        }

        public void SetIsOpenFalse()
        {
            EstacionamentoAberto = false;
        }

        public int BuscarVagasTotal(bool vagasVazias = false)
        {
            var totalVeiculo = TotalMotos + TotalCarros + TotalVan;

            if (vagasVazias)
            {
                var totalVazio = BuscarVagasVaziasTotal(TipoVeiculosEnum.Motos);
                totalVazio += BuscarVagasVaziasTotal(TipoVeiculosEnum.Carros);
                totalVazio += BuscarVagasVaziasTotal(TipoVeiculosEnum.Vans);

                return totalVazio;
            }

            return totalVeiculo;
        }

        public int BuscarVagasVaziasTotal(TipoVeiculosEnum tipoVeiculo)
        {
            var espacoTotalPorVeiculo = Veiculos.Where(x => x.TipoVagaVeiculo == tipoVeiculo).Count();

            if (tipoVeiculo.Equals(TipoVeiculosEnum.Motos))
                return TotalMotos - espacoTotalPorVeiculo;

            else if (tipoVeiculo.Equals(TipoVeiculosEnum.Carros))
            {
                espacoTotalPorVeiculo = Veiculos.Where(x => x.TipoVeiculos != TipoVeiculosEnum.Vans).Where(x => x.TipoVagaVeiculo == tipoVeiculo).Count();
                var vanInCarParkingSpace = Veiculos.Where(x => x.TipoVeiculos == TipoVeiculosEnum.Vans).Where(x => x.TipoVagaVeiculo == tipoVeiculo).Count() * 3;
                return TotalCarros - espacoTotalPorVeiculo - vanInCarParkingSpace;
            }

            else
                return TotalVan - espacoTotalPorVeiculo;
        }

        public List<string> GetAllParkedVehicle()
        {
            if (!Veiculos.Any())
                throw new Exception(MensagemErro.EstacionamentoVazio);

            List<string> vehiclesList = new();

            foreach (var vehicle in Veiculos)
                vehiclesList.Add(BuscaVeiculoPorPlaca(vehicle.Placa));

            return vehiclesList;
        }

        public string BuscaVeiculoPorPlaca(string plate)
        {
            var vehicleDetail = Veiculos.FirstOrDefault(x => x.Placa.Equals(plate));

            if (vehicleDetail == null)
                throw new Exception(MensagemErro.PlacaNaoEncontrada);

            return vehicleDetail.ToString();
        }

        public string AdicionarVeiculo(Veiculos veiculo)
        {
            if (!veiculo.ValidaPlaca(veiculo.Placa))
                throw new Exception(MensagemErro.PlacaIncorreta);

            if (Veiculos.Exists(x => x.Placa == veiculo.Placa))
                throw new Exception(MensagemErro.EstacionamentoCheio);

            if (BuscarVagasTotal() <= 0)
                throw new Exception(MensagemErro.EstacionamentoCheio);

            veiculo.RegistrarTipoVeiculo(BuscarVeiculosPorTipo(veiculo.TipoVagaVeiculo));

            Veiculos.Add(veiculo);
            return veiculo.ToString();
        }

        public string RemoverVeiculo(string placa)
        {
            if (!Veiculos.Any())
                throw new Exception(MensagemErro.EstacionamentoVazio);

            var vehicle = Veiculos.FirstOrDefault(x => x.Placa.Equals(placa));
            if (vehicle == null)
                throw new Exception(MensagemErro.PlacaNaoEncontrada);

            vehicle.RegistrarSaida();

            Veiculos.Remove(vehicle);
            return vehicle.ToString();
        }

        private TipoVeiculosEnum BuscarVeiculosPorTipo(TipoVeiculosEnum vehicleType)
        {
            var motorCycleFreeParkingSpaces = BuscarVagasVaziasTotal(TipoVeiculosEnum.Motos);
            var carFreeParkingSpaces = BuscarVagasVaziasTotal(TipoVeiculosEnum.Carros);
            var vanFreeParkingSpaces = BuscarVagasVaziasTotal(TipoVeiculosEnum.Vans);

            if (motorCycleFreeParkingSpaces > 0 && vehicleType.Equals(TipoVeiculosEnum.Motos))
                return TipoVeiculosEnum.Motos;

            else if (carFreeParkingSpaces > 0 && (vehicleType.Equals(TipoVeiculosEnum.Motos) || vehicleType.Equals(TipoVeiculosEnum.Carros)))
                return TipoVeiculosEnum.Carros;

            else if (vanFreeParkingSpaces <= 0 && carFreeParkingSpaces >= 3 && vehicleType.Equals(TipoVeiculosEnum.Vans))
                return TipoVeiculosEnum.Carros;

            else if (vanFreeParkingSpaces > 0)
                return TipoVeiculosEnum.Vans;

            else
                throw new Exception(MensagemErro.SemVagas);
        }
    }
}
