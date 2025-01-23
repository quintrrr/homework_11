namespace BankLibrary.BankAccountLibrary;

public interface IBankAccount
{
    bool Withdraw(decimal amount);
    void Deposit(decimal amount);
    void TransferFrom(IBankAccount fromAccount, decimal amount);
    int AccountNumber { get; }
}