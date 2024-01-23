namespace dk.roderos.SpreaGit.Domain;

public static class NumberDivider
{
    public static List<int> RandomlyDivideNumber(int originalNumber, int numberOfDivisions)
    {
        // TODO: Fix bug where divisions are inconsistent
        var random = new Random();
        var result = new List<int>();
        var remainingNumber = originalNumber;

        for (var i = 0; i < numberOfDivisions - 1; i++)
        {
            // Ensure that remainingNumber is not zero to prevent the exception
            if (remainingNumber > 0)
            {
                var randomNumber = random.Next(1, remainingNumber);
                result.Add(randomNumber);
                remainingNumber -= randomNumber;
            }
            else
            {
                result.Add(0);
            }
        }

        result.Add(remainingNumber);

        return result;
    }
}