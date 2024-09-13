namespace WebApplication2.Models
{
    public class Reserva
    {
        public List<Pessoa> pessoaList = new List<Pessoa>();
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva(Suite suite, List<Pessoa> pessoaList, int diasReservados)
        {
            this.Suite = suite;
            this.pessoaList = pessoaList;
            this.DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                Pessoa pessoa = new Pessoa();

                Console.WriteLine($"Digite o nome do {i + 1}º hóspede: ");
                pessoa.Nome = Console.ReadLine();

                Console.WriteLine($"Digite o sobrenome do {i + 1}º hóspede: ");
                pessoa.Sobrenome = Console.ReadLine();

                pessoaList.Add(pessoa);
            }
        }

      
        public int ObterQtedadeDeHospedes()
        {
            return pessoaList.Count;
        }

       
        public decimal CalcularValorDiaria()
        {
            decimal precoTotal = Suite.ValorDiaria * DiasReservados;

            if (DiasReservados > 10)
            {
                precoTotal -= precoTotal * 0.10m; 
            }

            return precoTotal;
        }
    }

}
