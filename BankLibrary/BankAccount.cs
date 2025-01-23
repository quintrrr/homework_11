using System.Diagnostics;

namespace BankLibrary.BankAccountLibrary;
[DeveloperInfo("Arina Gomza", "GomzaBank")]
public class BankAccount : IBankAccount
{
    private static int nextAccountNumber = 1;
    private int accountNumber;
    private decimal balance;
    private AccountType accountType;
    private Queue<BankTransaction> transactions = new Queue<BankTransaction>();
    private string holderName;
    private string holderLastName;

    public int AccountNumber
    {
        get
        {
            return accountNumber;
        }
    }
    public decimal Balance => balance;

    public AccountType AccountType
    {
        get
        {
            return accountType;
        }
    }

    public string Holder
    {
        get
        {
            return $"{holderName} {holderLastName}";
        }
        set
        {
            holderName = value.Split(" ").First();
            holderLastName = value.Split(" ").Last();
        }
    }

    internal BankAccount()
    {
        SetUniqueAccountNumber();
        balance = 0;
        accountType = AccountType.Current;
    }

    internal BankAccount(decimal balance)
    {
        SetUniqueAccountNumber();
        this.balance = balance;
        accountType = AccountType.Current;
    }

    internal BankAccount(AccountType accountType)
    {
        SetUniqueAccountNumber();
        balance = 0;
        this.accountType = accountType;
    }

    internal BankAccount(decimal balance, AccountType accountType, string holder)
    {
        SetUniqueAccountNumber();
        this.balance = balance;
        this.accountType = accountType;
        Holder = holder;
    }

    public BankTransaction this[int index]
    {
        get
        {
            return transactions.ElementAt(index);
        }
    }
    
    public static bool operator ==(BankAccount first, BankAccount second)
    {
        return first.Equals(second);
    }
        
    public static bool operator !=(BankAccount first, BankAccount second)
    {
        return !first.Equals(second);
    }

    protected bool Equals(BankAccount other)
    {
        return balance == other.balance && accountNumber == other.accountNumber && accountType == other.accountType && Equals(transactions, other.transactions);
    }
    
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((BankAccount)obj);
    }
    
    private void SetUniqueAccountNumber()
    {
        accountNumber = nextAccountNumber++;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Сумма снятия должна быть больше нуля");
            return false;
        }

        if (amount > Balance)
        {
            Console.WriteLine("На счете недостаточно средств");
            return false;
        }

        BankTransaction transaction = new BankTransaction(amount);
        transactions.Enqueue(transaction);
        Dispose(transaction);
        balance -= amount;
        return true;
    }

    public void Deposit(decimal amount)
    {
        BankTransaction transaction = new BankTransaction(amount);
        transactions.Enqueue(transaction);
        balance += amount;
    }

    public void TransferFrom(IBankAccount fromAccount, decimal amount)
    {
        if (fromAccount == null)
        {
            Console.WriteLine("Не указан целевой счёт");
            return;
        }

        if (fromAccount.Withdraw(amount))
        {
            Deposit(amount);
            Console.WriteLine(
                $"Совершен перевод {amount} со счета {fromAccount.AccountNumber} на счет {AccountNumber}");
        }
    }

    public override string ToString()
    {
        return $"Номер счета: {AccountNumber}, Баланс: {Balance}, Тип счета: {AccountType}";
    }

    private void Dispose(BankTransaction transaction)
    {
        string str = $"\nНомер счёта: {AccountNumber}\n Переведено: {transaction.Amount}";
        File.AppendAllText($"{Directory.GetCurrentDirectory()}/../../../output.txt", str);

        GC.SuppressFinalize(this);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(AccountNumber, Balance, AccountType);
    }
    
    [Conditional("DEBUG_ACCOUNT")]
    public void DumpToScreen()
    {
        Console.WriteLine("Детали банковского счета");
        Console.WriteLine($"Номер аккаунта: {AccountNumber}");
        Console.WriteLine($"Держатель банковского счета: {Holder}");
        Console.WriteLine($"Баланс: {Balance}");
    }
}