using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomusParking.Models;

public class Vagas
{    public int Numero { get; set; }
    public int Andar { get; set; }
    public bool Ocupada { get; set; }

    public Vagas(int numero, int andar)
    {
        Numero = numero;
        Andar = andar;
        Ocupada = false;
    }
}
