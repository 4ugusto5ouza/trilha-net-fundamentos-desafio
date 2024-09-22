namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private decimal CalcularValorTotal(int horas)
        {
            return Math.Round(this.precoInicial + this.precoPorHora * horas, 2);
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = Console.ReadLine();

            if (!string.IsNullOrEmpty(placa))
            {
                if (!veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    this.veiculos.Add(placa);
                }
                else
                {
                    Console.WriteLine("Seu veículo já está estacionado.");
                }
            }
            else
            {
                Console.WriteLine("A placa informada não é válida.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                bool isNumber = int.TryParse(Console.ReadLine(), out horas);

                if (!isNumber)
                {
                    Console.WriteLine("O valor informado é inválido.");
                }
                else
                {
                    decimal valorTotal = this.CalcularValorTotal(horas);

                    string veiculo = veiculos.FirstOrDefault(x => x.ToUpper().Equals(placa.ToUpper()));
                    veiculos.Remove(veiculo);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"VAGA {i+1}: {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
