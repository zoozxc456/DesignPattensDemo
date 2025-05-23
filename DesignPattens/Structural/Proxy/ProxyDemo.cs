namespace DesignPattens.Structural.Proxy;

public interface IAccount
{
    void Deposit(decimal money);
    void Withdraw(decimal money);
    decimal GetBalance();
}

public class Account(decimal balance) : IAccount
{
    public void Deposit(decimal money) => balance += money;
    public void Withdraw(decimal money) => balance -= money;
    public decimal GetBalance() => balance;
}

public class AccountProxy(IAccount account) : IAccount
{
    public void Deposit(decimal money)
    {
        if (money >= 1) account.Deposit(money);
    }

    public void Withdraw(decimal money)
    {
        if (money >= 1 && account.GetBalance() - money >= 0) account.Withdraw(money);
    }

    public decimal GetBalance() => account.GetBalance();
}

public static class ProxyDemo
{
    public static void Main()
    {
        var account = new Account(500);
        var proxy = new AccountProxy(account);

        proxy.Deposit(100);
        proxy.Withdraw(900);

        var proxyBalance = proxy.GetBalance();
        Console.WriteLine($"Proxy Balance: {proxyBalance}");

        var accountBalance = account.GetBalance();
        Console.WriteLine($"Account Entity Balance: {accountBalance}");
    }
}