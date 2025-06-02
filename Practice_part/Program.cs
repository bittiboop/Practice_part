namespace Practice_part;

class CreditCard
{
    public string CardNumber { get; private set; }
    public string OwnerName { get; private set; }
    public string CVC { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    
    private decimal balance;
    public decimal Balance
    {
        get => balance;
        private set => balance = value;
    }

    public CreditCard(string cardNumber, string ownerName, string cvc, DateTime expirationDate, decimal initialBalance = 0)
    {
        if (string.IsNullOrWhiteSpace(cardNumber) || cardNumber.Length != 16)
            throw new ArgumentException("Invalid card number.");
        if (string.IsNullOrWhiteSpace(ownerName))
            throw new ArgumentException("Owner name cannot be empty.");
        if (string.IsNullOrWhiteSpace(cvc) || cvc.Length != 3)
            throw new ArgumentException("Invalid CVC.");
        if (expirationDate <= DateTime.Now)
            throw new ArgumentException("Expiration date must be in the future.");
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");

        CardNumber = cardNumber;
        OwnerName = ownerName;
        CVC = cvc;
        ExpirationDate = expirationDate;
        Balance = initialBalance;
    }

    public static CreditCard operator +(CreditCard card, decimal amount)
    {
        card.Balance += amount;
        return card;
    }

    public static CreditCard operator -(CreditCard card, decimal amount)
    {
        if (card.Balance < amount)
            throw new InvalidOperationException("Insufficient funds.");
        card.Balance -= amount;
        return card;
    }

    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        if (ReferenceEquals(card1, null) || ReferenceEquals(card2, null))
            return ReferenceEquals(card1, card2);
        return card1.CVC == card2.CVC;
    }

    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return !(card1 == card2);
    }

    public static bool operator <(CreditCard card1, CreditCard card2)
    {
        if (ReferenceEquals(card1, null) || ReferenceEquals(card2, null))
            throw new ArgumentNullException("Cannot compare null credit cards.");
        return card1.Balance < card2.Balance;
    }

    public static bool operator >(CreditCard card1, CreditCard card2)
    {
        if (ReferenceEquals(card1, null) || ReferenceEquals(card2, null))
            throw new ArgumentNullException("Cannot compare null credit cards.");
        return card1.Balance > card2.Balance;
    }

    public override bool Equals(object obj)
    {
        if (obj is CreditCard otherCard)
        {
            return this.CVC == otherCard.CVC;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return CVC.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            CreditCard card1 = new CreditCard("1234567812345678", "Alice", "123", DateTime.Now.AddYears(1), 1000);
            CreditCard card2 = new CreditCard("8765432187654321", "Bob", "456", DateTime.Now.AddYears(1), 500);

            Console.WriteLine($"Card 1 Balance: {card1.Balance}");
            Console.WriteLine($"Card 2 Balance: {card2.Balance}");

            card1 += 200;
            Console.WriteLine($"Card 1 Balance after deposit: {card1.Balance}");

            card2 -= 100;
            Console.WriteLine($"Card 2 Balance after withdrawal: {card2.Balance}");

            Console.WriteLine($"Are cards equal? {card1 == card2}");
            Console.WriteLine($"Is Card 1 balance greater than Card 2? {card1 > card2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured in creating credit card: {ex.Message}");
        }
    }
}