namespace AdventOfCode;

public class Day_02 : BaseDay
{
    private readonly string _input;

    public Day_02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        List<string> commands = _input.Split("\r\n").ToList();

        int horizontalPosition = 0;
        int depth = 0;

        foreach (var command in commands)
        {
            int value = int.Parse(command.Substring(command.Length - 1, 1));
            string direction = command.Substring(0, command.Length - 2);

           if(direction == "forward")
            {
                horizontalPosition+=value;
            }
           if(direction == "down")
            {
                depth += value;
            }
            if (direction == "up")
            {
                depth -= value;
            }
        }
        return ValueTask.FromResult((depth*horizontalPosition).ToString());
    }

    public override ValueTask<string> Solve_2() 
    {
        List<string> commands = _input.Split("\r\n").ToList();

        int horizontalPosition = 0;
        int depth = 0;
        int aim = 0;

        foreach (var command in commands)
        {
            int value = int.Parse(command.Substring(command.Length - 1, 1));
            string direction = command.Substring(0, command.Length - 2);

            if (direction == "forward")
            {
                horizontalPosition += value;
                depth += aim * value;
            }
            if (direction == "down")
            {
                aim += value;
            }
            if (direction == "up")
            {
                aim -= value;
            }
        }
        return ValueTask.FromResult((depth * horizontalPosition).ToString());
    }
}
