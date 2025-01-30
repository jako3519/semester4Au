namespace Kata;

public class Class1
{
    
    public double Balance { get; set; }

    public Class1(double balance_)
    {

        Balance = balance_;
    }

    public double Withdrawl(double amount)
    {
        return Balance -= amount;
    }

    public double Deposit(double amount)
    {
        return Balance += amount;
    }
}
