
using AutonomusParking.Models;
using AutonomusParking.Services;
using Estacionamento.Models;



var estacionamento = new EstacionamentoService();
while (true)
{
    Console.Clear();
    Console.WriteLine("Bem-Vindo Ao AtonumusParking");
    Console.WriteLine("O que deseja? \n1 - Estacionar\n2 - Retirar Veiuclo\n3 - Acessar Relatórios");
    int escolha = int.Parse(Console.ReadLine());

    switch (escolha)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Estacionando....");
            Console.Write("Placa: ");
            string placa = Console.ReadLine();

            Console.WriteLine("Tipo do veículo:");
            Console.WriteLine("1 - Carro Popular");
            Console.WriteLine("2 - Caminhonete");

            TipoVeiculo tipo = (TipoVeiculo)int.Parse(Console.ReadLine());

            estacionamento.MostrarVagasDisponiveis();

            Console.Write("Escolha o andar: ");
            int andar = int.Parse(Console.ReadLine());

            estacionamento.Estacionar(placa, tipo, andar);
            Console.ReadLine();

            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Retirando Veiculo...");
            Console.Write("Placa: ");
            placa = Console.ReadLine();
            estacionamento.RetirarVeiculo(placa);
            Console.ReadLine();

            break;
        case 3:
            Console.Clear();
            if (AutenticarAdministrador())
            {
                estacionamento.RelatoriosAdministrador();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Senha incorreta.");
                Console.ReadLine();
            }
            break;
        case -1:
            return;
        default:
            Console.WriteLine("Opção Inválida");
            Console.ReadLine();
            break;
    }
}

static bool AutenticarAdministrador()
{
    Console.Write("Digite a senha do administrador: ");
    string senha = Console.ReadLine();

    return senha == "1234";
}