namespace DemoApp.Interfaces
{
    public interface IAccount
    {
        decimal Balance { get; }

        void Debit(decimal amount);
        void Credit(decimal amount);
    }
}