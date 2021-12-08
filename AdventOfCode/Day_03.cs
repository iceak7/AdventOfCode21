namespace AdventOfCode;

public class Day_03 : BaseDay
{
    private readonly string _input;

    public Day_03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        List<string> report = _input.Split("\r\n").ToList();

        int[] mostCommon = new int[12] {0,0,0,0,0,0,0,0,0,0,0,0};

        foreach (var r in report)
        {
            char[] chars = r.ToCharArray();

            for (int i = 0; i < chars.Length ; i++)
            {
                if (chars[i] == '1')
                {
                    mostCommon[i]++;
                }
                else
                {
                    mostCommon[i]--;
                }
            }
        }


        string gamma = "";
        string epsilon = "";


        for(int i = 0;i < mostCommon.Length; i++)
        {
            if(mostCommon[i] > 0)
            {
                gamma+= 1 ;
                epsilon+= 0 ;
            }
            else
            {
                gamma+= 0 ;
                epsilon+= 1 ;
            }
        };

        int gammaInt = Convert.ToInt32(gamma, 2);
        int epsilonInt= Convert.ToInt32(epsilon, 2);
         
        return ValueTask.FromResult((gammaInt*epsilonInt).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<string> report = _input.Split("\r\n").ToList();

        List<string> findOxygenRating = new List<string>(report);
        List<string> findCo2Rating = new List<string>(report); ;

        int positionToCheck = 0;

        while(findOxygenRating.Count > 1)
        {
            char mostCommon = '1';
            int counter = 0;

            foreach (var item in findOxygenRating)
            {
                if (item[positionToCheck]=='1'){counter++;}
                else { counter--; }
            }
            if (counter < 0)mostCommon = '0';
            
            findOxygenRating.RemoveAll(x => x[positionToCheck] != mostCommon);
            positionToCheck++;
            Console.WriteLine(findOxygenRating.Count);
            
        }

        Console.WriteLine("Count: " + report.Count);
        positionToCheck = 0;

        while (findCo2Rating.Count > 1)
        {
            char leastCommon = '0';
            int counter = 0;

            foreach (var item in findCo2Rating)
            {
                if (item[positionToCheck] == '1') { counter++; }
                else { counter--; }
            }
            if (counter < 0) leastCommon = '1';

            findCo2Rating.RemoveAll(x => x[positionToCheck] != leastCommon);
            positionToCheck++;
            Console.WriteLine(findCo2Rating.Count);
        }

        int oxygenRating = Convert.ToInt32(findOxygenRating[0], 2);
        int co2Rating = Convert.ToInt32(findCo2Rating[0], 2);


        return ValueTask.FromResult((oxygenRating*co2Rating).ToString());
    }
}