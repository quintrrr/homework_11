namespace BankLibrary.BankAccountLibrary;

public class BankTransaction
{
    private DateTime date; 
    private decimal amount;

    public DateTime Date
    {
        get
        {
            return date;
        }
    }

    public decimal Amount
    {
        get
        {
            return amount;
        }
    }
    public BankTransaction(decimal amount)
    {
        date = DateTime.Now;
        this.amount = amount;
    }
}