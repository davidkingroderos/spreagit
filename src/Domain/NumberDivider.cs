namespace dk.roderos.SpreaGit.Domain;

public static class NumberDivider
{
    public static List<int> GetRandomNumberParts(int originalNumber, int numberOfDivisions)
    {
        var resultList = new List<int>();
        var quotient = originalNumber / numberOfDivisions;

        for (int i = 0, sumOfQuotients = 0; i < numberOfDivisions; i++)
        {
            sumOfQuotients += quotient;
            resultList.Add(sumOfQuotients);
        }

        return resultList;
    }
}