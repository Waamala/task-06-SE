CellularAutomata ca = new CellularAutomata(20, 20);
ca.StartLife();

class CellularAutomata
{
    private bool[,] field;
    private int x; // ширина
    private int y; // высота

    private void InitRandomField()
    {
        Random random = new Random();
        // разброс для определения начального состояния
        double lifeFrequency = random.NextDouble() * 0.2 + 0.1; // 0.1 до 0.3

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                field[i, j] = random.NextDouble() < lifeFrequency;
            }
        }
    }

    private int CountLivingNeighbours(int xpos, int ypos)
    {
        int res = 0;

        // хардкод восьми соседей по модулю для замкнутого поля
        res += field[(xpos + 1) % x, (ypos + 1) % y] ? 1 : 0;
        res += field[(xpos - 1 + x) % x, (ypos + 1) % y] ? 1 : 0;
        res += field[(xpos + 1) % x, (ypos - 1 + y) % y] ? 1 : 0;
        res += field[(xpos - 1 + x) % x, (ypos - 1 + y) % y] ? 1 : 0;
        res += field[xpos, (ypos + 1) % y] ? 1 : 0;
        res += field[xpos, (ypos - 1 + y) % y] ? 1 : 0;
        res += field[(xpos + 1) % x, ypos] ? 1 : 0;
        res += field[(xpos - 1 + x) % x, ypos] ? 1 : 0;

        return res;
    }

    private void LifeGoesOn()
    {
        bool[,] nextField = new bool[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                int livingNeighbours = CountLivingNeighbours(i, j);

                if (field[i, j])
                {
                    if (livingNeighbours == 2 || livingNeighbours == 3)
                        nextField[i, j] = true;
                    else
                        nextField[i, j] = false;
                }
                else
                {
                    if (livingNeighbours == 3)
                        nextField[i, j] = true;
                    else
                        nextField[i, j] = false;
                }
            }
        }

        field = nextField;
    }

    public CellularAutomata(int x, int y)
    {
        this.x = x;
        this.y = y;

        field = new bool[x, y];
        InitRandomField();
    }

    public void RenderField()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (field[i, j])
                    Console.Write("@ ");
                else
                    Console.Write(". ");
            }
            Console.WriteLine();
        }
    }

    public void StartLife()
    {
        while (true)
        {
            RenderField();
            Thread.Sleep(400);
            LifeGoesOn();
            Console.Clear();
        }
    }
}
