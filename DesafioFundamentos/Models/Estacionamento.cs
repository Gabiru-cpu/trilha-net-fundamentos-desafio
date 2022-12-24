using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0, precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private List<string> modelos = new List<string>();
        private List<string> marcas = new List<string>();
        private List<string> proprietarios = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            bool validPlaca = false;
            do
            {
            //Console.Clear();
            Console.WriteLine("Digite a placa do veículo para estacionar (A PLACA DEVE SER VÁLIDA):");
            placa = Console.ReadLine();
            
            //validação de placa
            
                if (string.IsNullOrWhiteSpace(placa)) { validPlaca = false; }
                if (placa.Length > 8) { validPlaca = false; }

                placa = placa.Replace("-", "").Trim();

                if (char.IsLetter(placa, 4))
                {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                    validPlaca = padraoMercosul.IsMatch(placa);
                }
                else
                {
                    var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                    validPlaca = padraoNormal.IsMatch(placa);
                }

                if (validPlaca) { Console.WriteLine("A placa informada é válida"); }

                else { Console.WriteLine("A placa informada não é válida"); }
            } while (!validPlaca);

            veiculos.Add(placa);
            

            Console.WriteLine("Agora digite o modelo:");
            modelos.Add(Console.ReadLine());
            Console.WriteLine("Agora digite a marca:");
            marcas.Add(Console.ReadLine());
            Console.WriteLine("Agora digite o nome do proprietário:");
            proprietarios.Add(Console.ReadLine());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();
            placa = placa.Replace("-", "").Trim();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                veiculos.Remove(placa); marcas.Remove(placa); modelos.Remove(placa); proprietarios.Remove(placa);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                for(int contador = 0; contador < veiculos.Count; contador++)
                { 
                    Console.WriteLine($"Carro N. {contador + 1} = placa: {veiculos[contador]} | marca: {marcas[contador]} | modelo: {modelos[contador]} | dono(a): {proprietarios[contador]}"); 
                } 
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
