namespace AdventOfCode;

public class Day_05 : BaseDay
{
    private readonly string _input;

    public Day_05()
    {
        _input = File.ReadAllText(InputFilePath);

    }

    public class Line
    {
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }
    }

    public override ValueTask<string> Solve_1()
    {
        List<string> inputLines = _input.Split("\r\n").ToList();

        List<Line> linesToConsider = new List<Line>();

        inputLines.ForEach(line =>
        {
            string[] firstCordinates = line.Substring(0, line.IndexOf(' ')).Split(',');
            string[] secondCordinates = line.Substring(line.IndexOf("->") + 3, line.Length - (line.IndexOf("->") + 3)).Split(',');

            Line l = new Line();

            l.x1 = int.Parse(firstCordinates[0]);
            l.y1 = int.Parse(firstCordinates[1]);
            l.x2 = int.Parse(secondCordinates[0]);
            l.y2 = int.Parse(secondCordinates[1]);

            if (l.x1 == l.x2 | l.y1 == l.y2)
            {
                linesToConsider.Add(l);
            }
        });

        int[,] coordinateMap = new int[1000, 1000];
        List<string> coordinatesWith2PlusOverlaps = new List<string>();

        linesToConsider.ForEach(line =>
        {
            if (line.x1 == line.x2)
            {
                int start = 0;
                int end = 0;
                if (line.y1 > line.y2) { start = line.y2; end = line.y1; } else { start = line.y1; end = line.y2; }

                for (int yPos = start; yPos <= end; yPos++)
                {
                    coordinateMap[line.x1, yPos]++;
                    if (coordinateMap[line.x1, yPos] >= 2)
                    {
                        if (!coordinatesWith2PlusOverlaps.Contains(line.x1 + "," + yPos)) coordinatesWith2PlusOverlaps.Add(line.x1 + "," + yPos);
                    }
                }

            }
            else
            {
                int start = 0;
                int end = 0;
                if (line.x1 > line.x2) { start = line.x2; end = line.x1; } else { start = line.x1; end = line.x2; }

                for (int xPos = start; xPos <= end; xPos++)
                {
                    coordinateMap[xPos, line.y1]++;

                    if (coordinateMap[xPos, line.y1] >= 2)
                    {
                        if (!coordinatesWith2PlusOverlaps.Contains(xPos + "," + line.y1)) coordinatesWith2PlusOverlaps.Add(xPos + "," + line.y1);
                    }
                }
            }
        });

        return ValueTask.FromResult(coordinatesWith2PlusOverlaps.Count.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<string> inputLines = _input.Split("\r\n").ToList();

        List<Line> lines = new List<Line>();

        inputLines.ForEach(line =>
        {
            string[] firstCordinates = line.Substring(0, line.IndexOf(' ')).Split(',');
            string[] secondCordinates = line.Substring(line.IndexOf("->") + 3, line.Length - (line.IndexOf("->") + 3)).Split(',');

            Line l = new Line();

            l.x1 = int.Parse(firstCordinates[0]);
            l.y1 = int.Parse(firstCordinates[1]);
            l.x2 = int.Parse(secondCordinates[0]);
            l.y2 = int.Parse(secondCordinates[1]);

            lines.Add(l);
        });

        int[,] coordinateMap = new int[1000, 1000];
        List<string> coordinatesWith2PlusOverlaps = new List<string>();

        lines.ForEach(line =>
        {
            if (line.x1 == line.x2)
            {
                int start = 0;
                int end = 0;
                if (line.y1 > line.y2) { start = line.y2; end = line.y1; } else { start = line.y1; end = line.y2; }

                for (int yPos = start; yPos <= end; yPos++)
                {
                    coordinateMap[line.x1, yPos]++;
                    if (coordinateMap[line.x1, yPos] >= 2)
                    {
                        if (!coordinatesWith2PlusOverlaps.Contains(line.x1 + "," + yPos)) coordinatesWith2PlusOverlaps.Add(line.x1 + "," + yPos);
                    }
                }

            }
            else if(line.y1 == line.y2)
            {
                int start = 0;
                int end = 0;
                if (line.x1 > line.x2) { start = line.x2; end = line.x1; } else { start = line.x1; end = line.x2; }

                for (int xPos = start; xPos <= end; xPos++)
                {
                    coordinateMap[xPos, line.y1]++;

                    if (coordinateMap[xPos, line.y1] >= 2)
                    {
                        if (!coordinatesWith2PlusOverlaps.Contains(xPos + "," + line.y1)) coordinatesWith2PlusOverlaps.Add(xPos + "," + line.y1);
                    }
                }
            }
            else
            {
                int start = 0;
                int end = 0;
                char yOperator = '+';
                int yPos = 0;



                if (line.x1 > line.x2)
                {
                    start = line.x2;
                    end = line.x1;
                    yPos = line.y2;

                    if (line.y2 > line.y1)
                    {
                        yOperator = '-';
                    }
                }
                else
                {
                    start = line.x1;
                    end = line.x2;
                    yPos = line.y1;

                    if (line.y1 > line.y2)
                    {
                        yOperator = '-';
                    }
                }


                Console.WriteLine(start);
                Console.WriteLine(end);
                Console.WriteLine(yPos);
                Console.WriteLine(yOperator);
                for (int xPos = start; xPos <= end; xPos++)
                {
                    coordinateMap[xPos, yPos]++;

                    if (coordinateMap[xPos, yPos] >= 2)
                    {
                        if (!coordinatesWith2PlusOverlaps.Contains(xPos + "," + yPos)) coordinatesWith2PlusOverlaps.Add(xPos + "," + yPos);
                    }
                    if (yOperator == '-')
                    {
                        yPos--;
                    }
                    else
                    {
                        yPos++;
                    }
                }
            }



        });

        return ValueTask.FromResult(coordinatesWith2PlusOverlaps.Count.ToString());
    }

}
