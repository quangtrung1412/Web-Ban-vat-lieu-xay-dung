namespace App.Shared.Core.Handle;

public  class GenerateCode
{
    public static string GenerateCodeFollowNumber(int number)
    {
        var numberCode = "";
        if (number < 10)
        {
            numberCode = $"0000000{number}";
        }
        if (10 <= number && number < 100)
        {
            numberCode = $"000000{number}";
        }
        if (100 <= number && number < 1000)
        {
            numberCode = $"00000{number}";
        }
        if (1000 <= number && number < 10000)
        {
            numberCode = $"0000{number}";
        }
        if (10000 <= number && number < 100000)
        {
            numberCode = $"000{number}";
        }
        if (100000 <= number && number < 1000000)
        {
            numberCode = $"00{number}";
        }
        if (1000000 <= number && number < 10000000)
        {
            numberCode = $"0{number}";
        }
        if (10000000 <= number && number < 100000000)
        {
            numberCode = $"{number}";
        }
        return numberCode;
    }
}