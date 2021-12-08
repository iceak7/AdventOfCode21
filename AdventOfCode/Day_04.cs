namespace AdventOfCode;

public class Day_04 : BaseDay
{
    private readonly string _input;

    public Day_04()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        List<string> inputs = _input.Split("\r\n\r\n").ToList();

        List<int> bingoNumbers = inputs[0].Split(',').Select(x => int.Parse(x)).ToList();

        List<int[,]> boards = new List<int[,]>();
        List<int[,]> correctNrs = new List<int[,]>();
        int[] sumOfUnMarkedNumbers = new int[100];

        for (int i = 1; i < inputs.Count; i++)
        {
            List<string> rows = inputs[i].Split("\r\n").ToList();

            int[,] board = new int[5, 5];
            
            for (int x = 0; x < 5; x++)
            {
                List<int> numbers = rows[x].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToList();

                board[0, x] = numbers[0];
                board[1, x] = numbers[1];
                board[2, x] = numbers[2];
                board[3, x] = numbers[3];
                board[4, x] = numbers[4];

                sumOfUnMarkedNumbers[i-1] += numbers[0]+ numbers[1]+ numbers[2]+ numbers[3]+ numbers[4];

            }
            boards.Add(board);

            int[,] correctNrBoard = new int[5, 2]
            {
                    {0,0 },
                    {0,0 },
                    {0,0 },
                    {0,0 },
                    {0,0 }
            };
            correctNrs.Add(correctNrBoard);
        }

        foreach (var bingoNumber in bingoNumbers)
        {
            int boardIndex = 0;
            foreach (var board in boards)
            {
                for (int row = 0; row < 5; row++)
                {
                   
                    for (int column = 0; column < 5; column++)
                    {
                        if(board[row, column] == bingoNumber)
                        {
                            sumOfUnMarkedNumbers[boardIndex] -= bingoNumber;

                            correctNrs[boardIndex][row, 0]++;
                            correctNrs[boardIndex][column, 1]++;

                            if (correctNrs[boardIndex][row, 0] == 5 | correctNrs[boardIndex][column, 1] == 5)
                            {
                                return ValueTask.FromResult((sumOfUnMarkedNumbers[boardIndex] * bingoNumber).ToString());
                            }
                        }
                    }
                }
                boardIndex++;
            }
        }   
      
        return ValueTask.FromResult("");
    }

    public override ValueTask<string> Solve_2()
    {
        List<string> inputs = _input.Split("\r\n\r\n").ToList();

        List<int> bingoNumbers = inputs[0].Split(',').Select(x => int.Parse(x)).ToList();

        List<int[,]> boards = new List<int[,]>();
        List<int[,]> correctNrs = new List<int[,]>();
        int[] sumOfUnMarkedNumbers = new int[100];

        for (int i = 1; i < inputs.Count; i++)
        {
            List<string> rows = inputs[i].Split("\r\n").ToList();


            int[,] board = new int[5, 5];


            for (int x = 0; x < 5; x++)
            {
                List<int> numbers = rows[x].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToList();

                board[0, x] = numbers[0];
                board[1, x] = numbers[1];
                board[2, x] = numbers[2];
                board[3, x] = numbers[3];
                board[4, x] = numbers[4];

                sumOfUnMarkedNumbers[i - 1] += numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4];

            }
            boards.Add(board);

            int[,] correctNrBoard = new int[5, 2]
            {
                    {0,0 },
                    {0,0 },
                    {0,0 },
                    {0,0 },
                    {0,0 }
            };
            correctNrs.Add(correctNrBoard);
        }

        List<KeyValuePair<int, int>> scoresFromWinningBoards = new List<KeyValuePair<int, int>>();

        foreach (var bingoNumber in bingoNumbers)
        {
            int boardIndex = 0;
            foreach (var board in boards)
            {
                for (int row = 0; row < 5; row++)
                {

                    for (int column = 0; column < 5; column++)
                    {
                        if (board[row, column] == bingoNumber)
                        {
                            sumOfUnMarkedNumbers[boardIndex] -= bingoNumber;

                            correctNrs[boardIndex][row, 0]++;
                            correctNrs[boardIndex][column, 1]++;

                            if (correctNrs[boardIndex][row, 0] == 5 | correctNrs[boardIndex][column, 1] == 5)
                            {
                                if (!scoresFromWinningBoards.Exists(x=>x.Key==boardIndex))
                                {
                                    scoresFromWinningBoards.Add(new KeyValuePair<int, int>(boardIndex, sumOfUnMarkedNumbers[boardIndex] * bingoNumber));
                                }
                                
                            }

                        }
                    }
                }
                boardIndex++;
            }
        }

        Console.WriteLine(scoresFromWinningBoards.Count);
        return ValueTask.FromResult(scoresFromWinningBoards.Last().Value.ToString());
    }
}