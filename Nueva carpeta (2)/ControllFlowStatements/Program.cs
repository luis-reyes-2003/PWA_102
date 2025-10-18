
namespace ControllFlowStatements;

class Program
{
    static void Main(string[] args)
    {
        IfStatementExample();
        IfElseStatement();
        SwitchStatementExample();
    }

    private static void IfStatementExample()
    {
        int number = 10;

        if (number > 5)
            Console.WriteLine("Mayor a 5");
        else
            Console.WriteLine("Menor a 5");

    }

    private static void IfElseStatement()
    {
        int number = 10;

        if (number > 5)
        {
            Console.WriteLine("Mayor a 10");
        }
        else if (number == 10)
        {
            Console.WriteLine("Igual a 10");
        }
        else
        {
            Console.WriteLine("Menor a 10");
        }
    }

    private static void SwitchStatementExample()
    {
        int day = 3;
        string dayName;

        switch (day)
        {
            case 1:
                dayName = "Monday";
                break;
            case 2:
                dayName = "Tuesday";
                break;
            case 3:
                dayName = "Wednesday";
                break;
            case 4:
                dayName = "Thursday";
                break;
            case 5:
                dayName = "Friday";
                break;
            case 6:
                dayName = "Saturday";
                break;
            case 7:
                dayName = "Sunday";
                break;
            default:
                dayName = "Invalid day";
                break;
        }

        Console.WriteLine($"El día {day} es {dayName}");
    }
}