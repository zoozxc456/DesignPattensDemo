namespace DesignPattens.Behavioral.Strategy;

public interface ITicketPriceStrategy
{
    public double Calculate(double distance);
}

public class TrainTicketPriceStrategy : ITicketPriceStrategy
{
    private const double PricePerKiloMeter = 1.3;

    public double Calculate(double distance)
    {
        return distance * PricePerKiloMeter;
    }
}

public class BusTicketPriceStrategy : ITicketPriceStrategy
{
    private const double PricePerKiloMeter = 1.1;

    public double Calculate(double distance)
    {
        return distance * PricePerKiloMeter;
    }
}

public class PlaneTicketPriceStrategy : ITicketPriceStrategy
{
    private const double PricePerKiloMeter = 2.7;

    public double Calculate(double distance)
    {
        return distance * PricePerKiloMeter;
    }
}

public abstract class Vehicle
{
    public abstract void BuyTicket(double distance);
}

public class Train(ITicketPriceStrategy ticketPriceStrategy) : Vehicle
{
    public override void BuyTicket(double distance)
    {
        var ticketPrice = ticketPriceStrategy.Calculate(distance);
        Console.WriteLine($"You should spend {ticketPrice} buying the ticket by train.");
    }
}

public class Bus(ITicketPriceStrategy ticketPriceStrategy) : Vehicle
{
    public override void BuyTicket(double distance)
    {
        var ticketPrice = ticketPriceStrategy.Calculate(distance);
        Console.WriteLine($"You should spend {ticketPrice} buying the ticket by bus.");
    }
}

public class Plane(ITicketPriceStrategy ticketPriceStrategy) : Vehicle
{
    public override void BuyTicket(double distance)
    {
        var ticketPrice = ticketPriceStrategy.Calculate(distance);
        Console.WriteLine($"You should spend {ticketPrice} buying the ticket by plane.");
    }
}

public static class StrategyDemo
{
    public static void Main()
    {
        var train = new Train(new TrainTicketPriceStrategy());
        var bus = new Bus(new BusTicketPriceStrategy());
        var plane = new Plane(new PlaneTicketPriceStrategy());

        train.BuyTicket(312.4);
        bus.BuyTicket(312.4);
        plane.BuyTicket(312.4);
    }
}