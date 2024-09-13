using WebApplication2.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string tipoDeSuite;
int numeroDeHospedes = 0;
decimal precoPorDia = 0;
int numeroDias = 0;
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("Seja bem-vindo ao Sistema de Reservas do Hotel!");

Console.WriteLine("Digite o tipo de suíte desejada:");
tipoDeSuite = Console.ReadLine();

Console.WriteLine("Agora digite o número de hóspedes:");
numeroDeHospedes = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Agora digite o número de dias:");
numeroDias = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Digite o preço por dia:");
precoPorDia = Convert.ToDecimal(Console.ReadLine());

Suite suite = new Suite
{
    TipoDeSuite = tipoDeSuite,
    Capacidade = numeroDeHospedes,
    ValorDiaria = precoPorDia
};

Reserva reserva = new Reserva(suite, hospedes, numeroDias);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar Hóspedes");
    Console.WriteLine("2 - Exibir Quantidade de Hóspedes");
    Console.WriteLine("3 - Calcular Valor Total da Diária");
    Console.WriteLine("4 - Encerrar");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            reserva.CadastrarHospedes(numeroDeHospedes);
            break;
        case "2":
            Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQtedadeDeHospedes()}");
            Console.ReadLine();
            break;
        case "3":
            decimal valorTotal = reserva.CalcularValorDiaria();
            Console.WriteLine($"O valor total da reserva é: {valorTotal:C}");
            Console.ReadLine();
            break;
        case "4":
            exibirMenu = false;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            Console.ReadLine();
            break;
    }
}

app.Run();
