namespace DesignPattens.Structural.Decorator;

public interface IPlayer
{
    double GetBonus();
    void Settle(int money);
}

public class BasicPlayer : IPlayer
{
    public double GetBonus() => 0;

    public void Settle(int money)
    {
        Console.WriteLine(
            $"Basic Player settle ${money} and with {GetBonus()}% bonus, amount:{money * (1 + GetBonus())}");
    }
}

public abstract class Decorator(IPlayer player) : IPlayer
{
    public virtual double GetBonus() => player.GetBonus();
    public virtual void Settle(int money) => player.Settle(money);
}

public class SilverPlayer(IPlayer player) : Decorator(player)
{
    public override double GetBonus() => .2;

    public override void Settle(int money)
    {
        Console.WriteLine(
            $"Silver Player settle ${money} and with {GetBonus() * 100}% bonus, amount:{money * (1 + GetBonus())}");
    }
}

public class GoldenPlayer(IPlayer player) : Decorator(player)
{
    public override double GetBonus() => .5;

    public override void Settle(int money)
    {
        Console.WriteLine(
            $"Golden Player settle ${money} and with {GetBonus() * 100}% bonus, amount:{money * (1 + GetBonus())}");
    }
}

public class PremiumPlayer(IPlayer player) : Decorator(player)
{
    public override double GetBonus() => 1.2;

    public override void Settle(int money)
    {
        Console.WriteLine(
            $"Premium Player settle ${money} and with {GetBonus() * 100}% bonus, amount:{money * (1 + GetBonus())}");
    }
}

public static class DecoratorDemo
{
    public static void Main()
    {
        var silverPlayer = new SilverPlayer(new BasicPlayer());
        var goldenPlayer = new GoldenPlayer(new BasicPlayer());
        var premiumPlayer = new PremiumPlayer(new BasicPlayer());

        silverPlayer.Settle(100);
        goldenPlayer.Settle(100);
        premiumPlayer.Settle(100);
    }
}