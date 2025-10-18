namespace CustomExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                BankAccount account = new BankAccount("123456", 1000);
                Console.WriteLine($"Voy a comprar flores por 500: {account.Withdraw(500)}");
                Console.WriteLine($"Voy a llevarle al cine por 450: {account.Withdraw(450)}");
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Gracias por usar nuestro servicio de banca.");
            }
        }
    }

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base("Saldo insuficiente para realizar la operación.") { }

        public InsufficientBalanceException(string message) : base(message) { }

        public InsufficientBalanceException(string message, Exception inner) : base(message, inner) { }


    }

    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("El monto a depositar debe ser mayor que cero.");
            }
            Balance += amount;
        }

        public string Withdraw(decimal amount)
        {
            var originalBalance = Balance;
            if (amount <= 0)
            {
                throw new ArgumentException("El monto a retirar debe ser positivo.");
            }
            if (amount > Balance)
            {
                throw new InsufficientBalanceException($"No se puede retirar {amount} de la cuenta {AccountNumber} con saldo {Balance}.");
            }
            Balance -= amount;

            return $"Retiro exitoso de {amount}. Saldo original: {originalBalance}, Saldo actual: {Balance}.";
        }
    }
}