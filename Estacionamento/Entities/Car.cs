namespace Estacionamento.Entities;

public class Car
{
    public string? Placa { get; set; }

    public Car(string? placa)
    {
        Placa = placa;
    }
    
}