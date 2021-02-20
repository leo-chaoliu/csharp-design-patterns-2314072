using System;
using System.Collections.Generic;

// yield 
/**
** @doc https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield
**/
class YieldReturn
{
    public static IEnumerable<int> Power(int number, int exponent)
    {
        int result = 1;

        for (int i = 0; i < exponent; i++)
        {
            result = result * number;

            // if (i == 1)
            // {
            //     yield break;
            // }

            yield return result;
        }
    }

    public static IEnumerable<int> InfiniteYield(){
        while(true){
            var ramdom = new Random();
            // state machine in IL
            // https://www.linkedin.com/learning/clr-bytecode-for-developers/yield-return-example
            // consume stream
            // reactive programming
            yield return ramdom.Next();
        }
    }

    public static void Test()
    {
        // The call to MyIteratorMethod doesn't execute the body of the method. 
        // Instead the call returns an IEnumerable<string>
        // var collection = InfiniteYield();
        var collection = Power(2, 8);

        foreach (int i in collection)
        {
            Console.Write("{0} ", i);
        }

        // var enumerator = collection.GetEnumerator();

        // MoveNext executes the function until the next yield return statement is reached

        // while (enumerator.MoveNext())
        // {
        //     var days = enumerator.Current;
        //     Console.WriteLine($"Days in {days.Date} - {days.Days}");
        // }
    }
}