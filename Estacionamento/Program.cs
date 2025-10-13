using System.Globalization;
using Estacionamento.Entities;

namespace Estacionamento;

public class Program
{
    static void Main(string[] args)
    {
        var cars = new List<Car>();
        
        Console.WriteLine("==============Bem vino ao sistema de Estacionamento!===========\n");

        Console.Write("Digite o preço inicial: R$");
        var initialPrice = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

        Console.WriteLine();

        Console.Write("Agora digite o preço por hora: R$");
        var valuePerHour = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
        while (true)
        {
            try
            {
                Console.WriteLine("Digite a sua opção desejada: ");
            
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Sair");
            
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1":
                        Console.Write("Digite a placa do carro para estacionar: \n");
                        string placa = Console.ReadLine()!;

                        if (string.IsNullOrEmpty(placa))
                        {
                            throw new ArgumentException("A placa não pode estar vazia!");
                        }

                        if (placa.Length < 8 || placa.Length > 8)
                        {
                            throw new ArgumentException("A placa está invalida!");
                        }

                        if (placa.Length == 8 && placa.Contains('-'))
                        {
                            cars.Add(new  Car(placa));   
                        }
                        break;
                
                    case "2":
                        Console.Write("Digite a placa do carro para remover: ");
                        string removeCar = Console.ReadLine()!;

                        Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                        int hours = int.Parse(Console.ReadLine()!);
                    
                        bool existCar = cars.Any(x => x.Placa == removeCar);

                        if (existCar)
                        {
                            cars.RemoveAll(x => x.Placa == removeCar);
                        
                            Console.WriteLine($"Carro com a placa {removeCar} excluido com sucesso, e o preço total foi de R$: " +
                                              $"{CalculaPreco(initialPrice, valuePerHour, hours)}");
                        }
                        else
                        {
                            Console.WriteLine("Este carro não existe!");
                        }
                        break;
                
                    case "3":
                        VerificaLista(cars);

                        foreach (var car in cars)
                        {
                            Console.WriteLine($"Placa: {car}"); 
                        }

                        break;
                    
                    case "4":
                        Console.WriteLine("Ok, saindo...");

                        VerificaLista(cars);
                        
                        Console.WriteLine("Aqui está todos os carros cadastrados!");
                        foreach (var car in cars)
                        {
                            Console.WriteLine(car);
                        }
                        return;
                    
                    default:
                        Console.WriteLine("Esse numero não existe!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Write("Ops! Um erro Ocorreu: ");
                Console.Write(e.Message);
                Console.WriteLine();
            }
        }
        
    }

    static double CalculaPreco(double initialprice, double valueperhour, int horas)
    {
        return initialprice +  (valueperhour * horas);
    }

    static void VerificaLista(List<Car> cars)
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("A lista está vazia, tente novamente!");
        }
    }
}