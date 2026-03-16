using AutonomusParking.Data;
using AutonomusParking.Models;
using Estacionamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AutonomusParking.Services
{
    public class EstacionamentoService
    {
        private JsonRepository<Veiculo> repository;
        public List<Veiculo> ListVeiculo = [];
        public List<Vagas> Vaga = [];

        public decimal TotalFaturado { get; private set; }

        public EstacionamentoService()
        {
            CriarVagas();
            repository = new JsonRepository<Veiculo>("D:\\ProjetosGit\\AutonomusParking\\AutonomusParking\\DataFiles\\veiculos.json");

            ListVeiculo = repository.LerDados();

            AtualizarEstadoDasVagas();
        }
        private void AtualizarEstadoDasVagas()
        {
            foreach (var veiculo in ListVeiculo)
            {
                var vaga = Vaga.FirstOrDefault(v =>
                    v.Andar == veiculo.Vaga.Andar &&
                    v.Numero == veiculo.Vaga.Numero);

                if (vaga != null)
                {
                    vaga.Ocupada = true;
                }
            }
        }
        public void MostrarVagasDisponiveis()
        {
            var vagasPorAndar = Vaga
                .GroupBy(v => v.Andar)
                .OrderBy(g => g.Key);

            foreach (var andar in vagasPorAndar)
            {
                int livres = andar.Count(v => !v.Ocupada);

                Console.WriteLine($"Andar {andar.Key} - Vagas livres: {livres}");
            }
        }

        private void CriarVagas()
        {
            int vagasPorAndar = 10;
            int andares = 3;

            for (int andar = 1; andar <= andares; andar++)
            {
                for (int i = 1; i <= vagasPorAndar; i++)
                {
                    Vaga.Add(new Vagas(i, andar));
                }
            }
        }

        public void Estacionar(string placaDoVeiculo,TipoVeiculo tipoCarro, int andarEscolhido)
        {
            

            var vagaLivre = Vaga.FirstOrDefault(v => v.Andar == andarEscolhido && !v.Ocupada);

            if (vagaLivre == null)
            {
                Console.WriteLine("Estacionamento Lotado!!!");
                return;
            }
            vagaLivre.Ocupada = true;

            Veiculo veiculo = new Veiculo
            {
                Placa = placaDoVeiculo,
                TipoVeiculo = tipoCarro,
                HorarioDeChegada = DateTime.Now,
                Vaga = vagaLivre
            };


            ListVeiculo.Add(veiculo);

            repository.SalvarDados(ListVeiculo);

            Console.WriteLine($"Veículo estacionado no Andar {vagaLivre.Andar} - Vaga {vagaLivre.Numero}");
        }

        public void RetirarVeiculo(string placaDoVeiculo)
        {
            var veiculo = ListVeiculo.FirstOrDefault(v => v.Placa == placaDoVeiculo);

            if (veiculo == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }

            DateTime horaSaida = DateTime.Now;

            double horas = (horaSaida - veiculo.HorarioDeChegada).TotalHours;

            if (horas < 1)
                horas = 1;

            decimal valorHora = veiculo.TipoVeiculo == TipoVeiculo.Caminhonete ? 7 : 5;

            decimal total = (decimal)horas * valorHora;

            TotalFaturado += total;

            veiculo.Vaga.Ocupada = false;

            ListVeiculo.Remove(veiculo);
            repository.SalvarDados(ListVeiculo);

            Console.WriteLine($"Tempo estacionado: {Math.Ceiling(horas)} horas");
            Console.WriteLine($"Total a pagar: R${total}");
        }

        public void RelatoriosAdministrador()
        {
            int totalVagas = Vaga.Count;
            int vagasOcupadas = Vaga.Count(v => v.Ocupada);

            Console.WriteLine("\n===== RELATÓRIO =====");

            Console.WriteLine($"Vagas totais: {totalVagas}");
            Console.WriteLine($"Vagas ocupadas: {vagasOcupadas}");
            Console.WriteLine($"Vagas livres: {totalVagas - vagasOcupadas}");
            Console.WriteLine($"Faturamento total: R${TotalFaturado}");

            Console.WriteLine("\nVeículos estacionados:");

            foreach (var v in ListVeiculo)
            {
                Console.WriteLine($"Placa: {v.Placa} | Tipo: {v.TipoVeiculo} | Andar: {v.Vaga.Andar} | Vaga: {v.Vaga.Numero}");
            }
        }

    }
}
