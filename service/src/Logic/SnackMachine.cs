namespace Logic;

public class SnackMachine : Entity
{
    public Money MoneyInside { get; private set; }

    public Money MoneyInTransaction { get; private set; }

    public void BuySnack()
    {
        MoneyInside += MoneyInTransaction;

        //MoneyInTransaction = 0;
    }

    public void InsertMoney(Money money)
    {
        MoneyInTransaction += money;
    }

    public void ReturnMoney()
    {
        //MoneyInTransaction = 0;
    }
}