namespace BankLibrary.BankAccountLibrary;

public class BankAccountFactory
{
    private readonly Dictionary<int, IBankAccount> accounts = new Dictionary<int, IBankAccount>();

    public int CreateAccount()
    {
        IBankAccount account = new BankAccount();
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }

    public int CreateAccount(decimal balance)
    {
        IBankAccount account = new BankAccount(balance);
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }

    public int CreateAccount(AccountType accountType)
    {
        IBankAccount account = new BankAccount(accountType);
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }

    public int CreateAccount(decimal balance, AccountType accountType, string holder)
    {
        IBankAccount account = new BankAccount(balance, accountType, holder);
        accounts[account.AccountNumber] = account;
        return account.AccountNumber;
    }

    public void CloseAccount(int accountNumber)
    {
        if (accounts.ContainsKey(accountNumber))
        {
            accounts.Remove(accountNumber);
            Console.WriteLine($"Счёт с номером {accountNumber} был закрыт.");
        }
        else
        {
            Console.WriteLine($"Счёт с номером {accountNumber} не найден.");
        }
    }

    public IBankAccount GetAccount(int accountNumber)
    {
        if (accounts.TryGetValue(accountNumber, out var account))
        {
            return account;
        }

        Console.WriteLine($"Счёт с номером {accountNumber} не найден.");
        return null;
    }
}