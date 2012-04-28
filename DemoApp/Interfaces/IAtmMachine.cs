namespace DemoApp
{
    public interface IAtmMachine
    {
        decimal CheckBalance();
        void InsertCard(IAtmCard card);
        void EnterPin(string pinCode);
        bool CardInserted { get; }
        bool Authenticated { get;}
        void EjectCard();
    }
}