string filePath = "input";

string[] lines = File.ReadAllLines(filePath);

long ans = 0;

foreach(string line in lines){
    string[] parts = line.Split(':');

    long result = Convert.ToInt64(parts[0]);

    string[] numbersStrings = parts[1].Split(" ");

    numbersStrings = numbersStrings.Where(x => x != "").ToArray();

    int[] numbers = Array.ConvertAll(numbersStrings, n => int.Parse(n)); 

    if(Calculate(result, numbers, 1, numbers[0]))
        ans += result;
}
Console.WriteLine(ans);

bool Calculate(long result, int[] numbers, int i, long current) {
    if(current > result)
        return false;

    if(i == numbers.Length){
        if(current == result)
            return true;
        return false;
    }

    if(Calculate(result, numbers, i + 1, current + numbers[i]))
        return true;

    if(Calculate(result, numbers, i + 1, current * numbers[i]))
        return true;

    //part 2
    if(Calculate(result, numbers, i + 1, Convert.ToInt64(current.ToString() + numbers[i].ToString())))
        return true;

    return false;


}



