using System.Globalization;
using Estacionamento.Entities;

namespace Estacionamento;

public class Program
{
    static void Main(string[] args)
    {
        var cars = new List<Car>();
        
        Console.WriteLine("==============Bem vino ao sistema de Estacionamento!===========\n");

        Console.Write("Digite o preço inicial: ");
        var initialPrice = double.Parse(Console.ReadLine()!);

        Console.WriteLine();

        Console.Write("Agora digite o preço por hora: ");
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
                        Console.WriteLine("Digite a placa do carro para estacionar: ");
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
                    
                        bool existCar = cars.Any(x => x.Placa == removeCar);

                        if (existCar)
                        {
                            cars.RemoveAll(x => x.Placa == removeCar);
                        
                            Console.WriteLine($"Carro com a placa {removeCar} excluido com sucesso!");
                        }
                        break;
                
                    case "3":
                        if (cars.Count == 0)
                        {
                            Console.WriteLine("Parece que a lista está vazia, tente novamente!");
                        }

                        foreach (var car in cars)
                        {
                            Console.WriteLine(car);
                        }

                        break;
                    
                    case "4":
                        
                }
            }
            catch (Exception e)
            {
                Console.Write("Ops! Um erro Ocorreu: ");
                Console.Write(e);
            }
        }
        
    }

    static double CalculaPreco(double initialprice, double valueperhour, int horas)
    {
        return (initialprice + valueperhour) / horas;
    }
}