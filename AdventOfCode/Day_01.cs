namespace AdventOfCode;

public class Day_01 : BaseDay
{
    private readonly string _input;

    public Day_01()
    {
        _input = File.ReadAllText(InputFilePath);

    }


    public override ValueTask<string> Solve_1()
    {
        List<int> nrs = _input.Split('\n').Select(x => int.Parse(x)).ToList();

        int nrOfIncreases = 0;
        int lastDepth = nrs[0];

        foreach (int n in nrs)
        {
            if (n > lastDepth )
            {
                nrOfIncreases++;
            }
            lastDepth = n;    
        }
        return ValueTask.FromResult(nrOfIncreases.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<int> nrs = _input.Split('\n').Select(x => int.Parse(x)).ToList();
        
        int nrOfIncreases = 0;

        int sumOfLast3 = nrs[0] + nrs[1] + nrs[2];

        for (int i = 3; i < nrs.Count; i++)
        {
            int sumOfCurrent3 = sumOfLast3 - nrs[i - 3] + nrs[i];
            if (sumOfLast3 < sumOfCurrent3)
            {
                nrOfIncreases++;
            }
            sumOfLast3 = sumOfCurrent3;
        }

        return ValueTask.FromResult(nrOfIncreases.ToString());
    }

}
