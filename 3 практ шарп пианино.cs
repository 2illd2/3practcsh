using System;

class Piano
{
    private int[][] octaves;
    private int currentOctaveIndex;

    public Piano()
    {
        // Инициализация октав с частотами
        octaves = new int[][]
        {
            new int[] { 261, 293, 329, 349, 392, 440, 493, 523 },
            new int[] { 523, 587, 659, 698, 784, 880, 987, 1046 }, // Частоты для второй октавы
            new int[] { 1046, 1174, 1318, 1396, 1568, 1760, 1975, 2093 } // Частоты для третьей октавы
        };

        currentOctaveIndex = 0;
    }

    public void Play()
    {
        Console.WriteLine("используйте клавиши на клавиатуре для воспроизведения нот");
        Console.WriteLine("для переключения октав используйте клавиши F1, F2, F3");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                    break;

                if (key.Key == ConsoleKey.F1 || key.Key == ConsoleKey.F2 || key.Key == ConsoleKey.F3)
                {
                    currentOctaveIndex = (int)(key.Key - ConsoleKey.F1);
                    ChangeOctave();
                }
                else
                {
                    int noteIndex = GetNoteIndex(key.Key);
                    if (noteIndex != -1)
                    {
                        PlaySound(octaves[currentOctaveIndex][noteIndex]);
                    }
                }
            }
        }
    }

    private int GetNoteIndex(ConsoleKey key)
    {
        ConsoleKey[] noteKeys = { ConsoleKey.A, ConsoleKey.S, ConsoleKey.D, ConsoleKey.F, ConsoleKey.G, ConsoleKey.H, ConsoleKey.J, ConsoleKey.K };

        for (int i = 0; i < noteKeys.Length; i++)
        {
            if (key == noteKeys[i])
            {
                return i;
            }
        }

        return -1;
    }

    private void ChangeOctave()
    {
        Console.WriteLine($"Переключена на октаву {currentOctaveIndex + 1}");
    }

    private void PlaySound(int frequency)
    {
        Console.Beep(frequency, 500); // Изменение второго параметра может регулировать длительность звука
    }
}

class Program
{
    static void Main()
    {
        Piano piano = new Piano();
        piano.Play();
    }
}