using System.Data;
using inputSpace;

// AoC 1.2

int total = 0;
int[] numberArray = Enumerable.Range(1, 9).ToArray();
string[] stringifiedNumbers = numberArray.Select(n => n.ToString()).ToArray();

string[] combined = stringifiedNumbers.Concat(InputClass.inputWordNumbers).ToArray();


string[] splitInput = InputClass.inputString.Split("\n");
// string[] splitInput = ["fasfj545"];


foreach (var line in splitInput)
{
    int firstNumber = getFirstNumber(combined, line);
    int lastNumber = getLastNumber(combined, line);



    _ = int.TryParse(firstNumber.ToString() + lastNumber.ToString(), out int lastInt);
    total += lastInt;
    Console.WriteLine(total);
}
    Console.WriteLine(total);

static int getFirstNumber(string[] combined, string line)
{
    var firstIndex = int.MaxValue;
    var firstNumber = "";
    foreach (var number in combined)
    {
        var index = 0;
        index = line.IndexOf(number) > -1 ? line.IndexOf(number) : int.MaxValue;

        var isFirst = index < firstIndex;
        firstIndex = isFirst ? index : firstIndex;
        firstNumber = isFirst ? number : firstNumber;
    }

    _ = int.TryParse(firstNumber.ToString(), out int firstInt);
    return firstInt == 0 ? Array.IndexOf(InputClass.inputWordNumbers, firstNumber) + 1 : firstInt;
}

static int getLastNumber(string[] combined, string line)
{
    var lastIndex = int.MinValue;
    var lastNumber = "";
    foreach (var number in combined)
    {
        var index = 0;
        index = line.LastIndexOf(number) > -1 ? line.LastIndexOf(number) : int.MinValue;

        var isLast = index > lastIndex;
        lastIndex = isLast ? index : lastIndex;
        lastNumber = isLast ? number : lastNumber;
    }

    _ = int.TryParse(lastNumber.ToString(), out int lastInt);
    return lastInt == 0 ? Array.IndexOf(InputClass.inputWordNumbers, lastNumber) + 1 : lastInt;
}


// AoC 1.1 (broken)
// foreach (var line in splitInput)
// {
//     var firstInt = 0;
//     foreach (var ch in line.ToCharArray())
//     {
//         var foundFirst = int.TryParse(ch.ToString(), out firstInt);
//         if (foundFirst)
//             break;

//     }
//     var lastInt = 0;
//     foreach (var ch in line.Reverse())
//     {
//         var foundLast = int.TryParse(ch.ToString(), out lastInt);
//         if (foundLast)
//             break;
//     }
//     Console.Write($"{total} + {firstInt}{lastInt} = ");
//     total += int.Parse($"{firstInt}{lastInt}");
// }

