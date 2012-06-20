namespace DemoApp
{
    public interface ICustomer
    {
        string MySecretPin { get; }
        decimal CashInPocket { get; }

        void DrawCash(decimal amount);
    }
}