namespace AdventOfCode;

public class Day_07 : BaseDay
{
    private readonly string _input;

    public Day_07()
    {
        _input = File.ReadAllText(InputFilePath);

    }


    public override ValueTask<string> Solve_1()
    {
        int[] inputVals = _input.Split(",").Select(x => int.Parse(x)).ToArray();

        int maxVal = inputVals.Max();
        int[] costPerPos = new int[maxVal+1];

        for(int i=0; i <= maxVal; i++)
        {
            int cost = 0;

            foreach(int val in inputVals)
            {
                cost += Math.Abs(val - i);
            }
            costPerPos[i] = cost;
        }


        return ValueTask.FromResult(costPerPos.Min().ToString());
    }

    public override ValueTask<string> Solve_2()
    {


        int[] inputVals = _input.Split(",").Select(x => int.Parse(x)).ToArray();

        int maxVal = inputVals.Max();
        int[] costPerPos = new int[maxVal + 1];

        for (int i = 0; i <= maxVal; i++)
        {
            int cost = 0;

            foreach (int val in inputVals)
            {
                int positionDiff = Math.Abs(val - i);
                
                cost +=positionDiff*(positionDiff+1)/2;
            }
            costPerPos[i] = cost;
        }


        return ValueTask.FromResult(costPerPos.Min().ToString());
    }

}
