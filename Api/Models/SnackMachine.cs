namespace Api.Models;

public partial class SnackMachine : Entity
{
    public string address { get; set; }
    
    public Money? MoneyInTransaction { get; private set; }

    public IList<Product> products { get; set; }

    public SnackMachine()
    {
        MoneyInside = new Money();
    }

    public void BuySnack()
    {
        if (MoneyInTransaction != null)
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = null;
        } else
        {
            throw new ArgumentNullException("You can't buy a snack!! you don't have enough money. put the money first!!!");
        }
    }

    public void InsertMoney(Money money)
    {
        if (MoneyInTransaction != null)
        {
            MoneyInTransaction += money;
        }
    }

    public void ReturnMoney()
    {
        MoneyInTransaction = null;
    }
}