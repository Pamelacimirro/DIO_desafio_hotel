namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            Hospedes = new List<Pessoa>();
        }
        
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            Console.WriteLine("Digite o primeiro nome do hóspede:");
            Pessoa p1 = new Pessoa();
            string nome = Console.ReadLine();
            p1.Nome = nome;
            Console.WriteLine("Digite o sobrenome do hóspede:");
            string sobrenome = Console.ReadLine();
            p1.Sobrenome = sobrenome;
            hospedes.Add(p1);

            Console.WriteLine("Deseja adicionar mais hóspedes? (s/n)");
            string resposta = Console.ReadLine().ToLower();
            do
            {

                if (resposta == "s")
                {
                    Console.WriteLine("Digite o primeiro nome do próximo hóspede:");
                    Pessoa p2 = new Pessoa();
                    string nome2 = Console.ReadLine();
                    p2.Nome = nome2;
                    Console.WriteLine("Digite o sobrenome do próximo hóspede:");
                    string sobrenome2 = Console.ReadLine();
                    p2.Sobrenome = sobrenome2;
                    hospedes.Add(p2);
                }
                else if (resposta != "n")
                {
                    throw new Exception("Opção inválida. Digite 's' para sim ou 'n' para não.");
                }
                else
                {
                    Console.WriteLine($"Foram adicionados {hospedes.Count} hóspedes.");
                }

            }
            while (resposta == "s");
            

            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Capacidade da suíte é menor que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Console.WriteLine("Escolha a suíte para a reserva:");
            Console.WriteLine("1 - Simples");
            Console.WriteLine("2 - Luxo");
            Console.WriteLine("3 - Premium");
            int escolha_suite = int.Parse(Console.ReadLine());

            if (escolha_suite == 1)
            {
                suite = new Suite("Simples", 2, 100);
            }
            else if (escolha_suite == 2)
            {
                suite = new Suite("Luxo", 4, 200);
            }
            else if (escolha_suite == 3)
            {
                suite = new Suite("Premium", 5, 300);
            }
            else
            {
                throw new Exception("Opção de suíte inválida.");
            }
            Suite = suite;
            Console.Clear();
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            int total_hospedes = Hospedes.Count;
            return total_hospedes;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            Console.WriteLine($"O valor da diária é: {Suite.ValorDiaria}");

            if (Suite == null)
            {
                throw new Exception("Nenhuma suíte cadastrada.");
            }
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;
            
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.1m; // Aplicando desconto de 10%
                Console.WriteLine($"Valor total da reserva (com desconto de 10%): {valor}");
            }
            else
            {
                Console.WriteLine($"Valor total da reserva: {valor}");
            }
            return valor;
        }
    }
}