using Estacionamento.Models;
using System;

namespace AutonomusParking.Models
{
    public class Veiculo
    {
 
        public string Placa { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public DateTime HorarioDeChegada { get; set; }
        public Vagas Vaga { get; set; }
    }
}
