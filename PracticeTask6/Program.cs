using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask6
{
    class Program
    {
        // Ввод необходимых параметров
        static void InputParams(out ushort CountTotal, out ushort CountComparer, out double Comparer)
        {
            // Флаг правильности ввода
            bool CorrectInput;

            // Ввод количества элементов
            do
            {
                Console.WriteLine("Введите количество всех элементов последовательности, которые нужно вычислить:");
                CorrectInput = UInt16.TryParse(Console.ReadLine(), out CountTotal);
                if (!CorrectInput)
                    Console.WriteLine("Требуется ввести целое неотрицательное число.");
            } while (!CorrectInput);

            // Ввод числа для сравнения
            do
            {
                Console.WriteLine("Введите число, с которым будут сравниваться элементы последовательности:");
                CorrectInput = Double.TryParse(Console.ReadLine(), out Comparer);
                if (!CorrectInput)
                    Console.WriteLine("Требуется ввести вещественное число.");
            } while (!CorrectInput);

            // Ввод количества элементов больших заданного числа
            do
            {
                Console.WriteLine("Введите количество элементов последовательности, больших введенного числа, которые нужно вычислить:");
                CorrectInput = UInt16.TryParse(Console.ReadLine(), out CountComparer);
                if (!CorrectInput)
                    Console.WriteLine("Требуется ввести целое неотрицательное число.");
            } while (!CorrectInput);
        }

        // Ввод первых <= 3 элементов последовательности
        static void InputFirstElements(ref double[] Elements, ushort CountTotal, ushort CountComparer, 
            ref ushort CurrentTotal, ref ushort CurrentComparer, double Comparer)
        {
            for (CurrentTotal = 0; CurrentTotal < 3  && CurrentTotal < CountTotal && CurrentComparer < CountComparer; CurrentTotal++)
            {
                // Флаг правильности ввода
                bool ok;
                do
                {
                    Console.Write("Введите {0}-й член последовательности: ", CurrentTotal + 1);
                    ok = Double.TryParse(Console.ReadLine(), out Elements[CurrentTotal]);
                    if (!ok)
                        Console.WriteLine("Требуется ввести вещественное число.");
                    else
                        if (Elements[CurrentTotal] > Comparer)
                        CurrentComparer++;
                } while (!ok);
            }

            if (CurrentTotal == CountTotal)
                Console.WriteLine("Вычислено требуемое количество элементов.");
            else if (CurrentComparer == CountComparer)
                Console.WriteLine("Вычислено требуемое количество элементов, больших {0}.", Comparer);
        }

        // Вычисление последовательности
        static void Calculate(ref double[] Array, ushort CountTotal, ushort CountComparer, ushort CurrentTotal, 
            ushort CurrentComparer, double Comparer)
        {
            if (CurrentTotal == CountTotal)
                Console.WriteLine("Вычислено требуемое количество элементов.");
            else if (CurrentComparer == CountComparer)
                Console.WriteLine("Вычислено требуемое количество элементов, больших {0}.", Comparer);
            else
            {
                Array[CurrentTotal] = (7.0 / 3 * Array[CurrentTotal - 1] + Array[CurrentTotal - 2]) / 2.0 * Array[CurrentTotal - 3];
                Console.WriteLine("A{0} = {1}", CurrentTotal + 1, Array[CurrentTotal]);
                if (Array[CurrentTotal] > Comparer)
                    CurrentComparer++;
                CurrentTotal++;
                Calculate(ref Array, CountTotal, CountComparer, CurrentTotal, CurrentComparer, Comparer);
            }
        }

        static void Main(string[] args)
        {
            // Параметры последовательности

            // Общее количество элементов
            ushort CountTotal, CountComparer;
            // Текущее количество элементов
            ushort CurrentTotal = 0, CurrentComparer = 0;
            // Число для сравнения
            double Comparer;

            // Ввод параметров
            InputParams(out CountTotal, out CountComparer, out Comparer);
            
            // Массив элементов
            double[] Elements = new double[CountTotal];

            if (CountTotal == 0)
                Console.WriteLine("Последовательность пуста.");
            else
            {
                InputFirstElements(ref Elements, CountTotal, CountComparer, ref CurrentTotal, ref CurrentComparer, Comparer);
                if (CurrentTotal < CountTotal && CurrentComparer < CountComparer)
                    Calculate(ref Elements, CountTotal, CountComparer, CurrentTotal, CurrentComparer, Comparer);
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}