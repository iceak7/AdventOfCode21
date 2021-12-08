namespace AdventOfCode;

public class Day_06 : BaseDay
{
    private readonly string _input;

    public Day_06()
    {
        _input = File.ReadAllText(InputFilePath);

    }


    public override ValueTask<string> Solve_1()
    {
        int[] inputVals = _input.Split(",").Select(x=>int.Parse(x)).ToArray();
        int[] fish = new int[9];

        foreach (var f in inputVals)
        {
            fish[f]++;
        }


        for (int day=1; day<=80; day++)
        {
            int nrOfFishToCreate = fish[0];
            Console.WriteLine(nrOfFishToCreate);
            for (int i = 0; i < fish.Length; i++)
            {
                if (i == 8)
                {
                    fish[i - 1] = fish[i];
                    fish[8] = nrOfFishToCreate;                 

                }
                else if (i == 7)
                {
                    fish[6] = fish[7] + nrOfFishToCreate;

                }
                else if(i!=0)
                {
                    fish[i - 1] = fish[i];
                }
            }
        }
        int sum = fish.Sum();

        return ValueTask.FromResult(sum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {


        int[] inputVals = _input.Split(",").Select(x => int.Parse(x)).ToArray();
        long[] fish = new long[9];

        foreach (var f in inputVals)
        {
            fish[f]++;
        }


        for (int day = 1; day <= 256; day++)
        {
            long nrOfFishToCreate = fish[0];
            for (int i = 0; i < fish.Length; i++)
            {
                if (i == 8)
                {
                    fish[i - 1] = fish[i];
                    fish[8] = nrOfFishToCreate;

                }
                else if (i == 7)
                {
                    fish[6] = fish[7] + nrOfFishToCreate;

                }
                else if (i != 0)
                {
                    fish[i - 1] = fish[i];
                }
            }
        }

        long sumOfFish = 0;
        foreach (var f in fish)
        {
            sumOfFish += f;
        }

        return ValueTask.FromResult(sumOfFish.ToString());
    }

}
