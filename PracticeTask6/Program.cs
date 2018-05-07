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
        static void InputParams(out ushort Count, out double Accuracy)
        {
            // Флаг правильности ввода
            bool CorrectInput;

            // Ввод количества элементов
            do
            {
                Console.WriteLine("Введите количество элементов последовательности, которые нужно вычислить:");
                CorrectInput = UInt16.TryParse(Console.ReadLine(), out Count);
                if (!CorrectInput)
                    Console.WriteLine("Требуется ввести целое неотрицательное число.");
            } while (!CorrectInput);

            // Ввод требуемой точности
            do
            {
                Console.WriteLine("Введите требуемую точность вычислений:");
                CorrectInput = Double.TryParse(Console.ReadLine(), out Accuracy) && Accuracy > 0;
                if (!CorrectInput)
                    Console.WriteLine("Требуется ввести положительное вещественное число.");
            } while (!CorrectInput);
        }

        // Ввод первых <= 3 элементов последовательности
        static void InputFirstElements(ref double[] Elements, ushort ElementsCount)
        {
            switch (ElementsCount)
            {
                case 1:
                    Console.Write("A1 = ");
                    Elements[0] = Double.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("A1 = ");
                    Elements[0] = Double.Parse(Console.ReadLine());
                    Console.Write("A2 = ");
                    Elements[1] = Double.Parse(Console.ReadLine());
                    break;
                default:
                    Console.Write("A1 = ");
                    Elements[0] = Double.Parse(Console.ReadLine());
                    Console.Write("A2 = ");
                    Elements[1] = Double.Parse(Console.ReadLine());
                    Console.Write("A3 = ");
                    Elements[2] = Double.Parse(Console.ReadLine());
                    break;
            }
        }

        // Вычисление последовательности
        static void Calculate(ref double[] Array, ushort CountTotal, ushort CountCurrent, double Accuracy)
        {
            Array[CountCurrent-1] = (7.0 / 3 * Array[CountCurrent - 2] + Array[CountCurrent-3]) / 2.0 * Array[CountCurrent-4];
            Console.WriteLine("A{0} = {1}", CountCurrent + 1, Array[CountCurrent]);
            if (CountCurrent < CountTotal && Math.Abs(Array[CountCurrent]) > Accuracy)
                Calculate(ref Array, CountTotal, (ushort)(CountCurrent + 1), Accuracy);
            else
                if (CountCurrent == CountTotal)
                    Console.WriteLine("Вычислено указанное количество элементов последовательности.");
                else
                    Console.WriteLine("Достигнута требуемая точность вычислений.");
        }

        static void Main(string[] args)
        {
            // Параметры последовательности
            // Количество элементов
            ushort Count;
            // Точность вычислений
            double Accuracy;

            // Ввод параметров
            InputParams(out Count, out Accuracy);
            
            // Массив элементов
            double[] Elements = new double[Count];

            if (Count == 0)
                Console.WriteLine("Последовательность пуста.");
            else
            {
                InputFirstElements(ref Elements, Count);
                if (Count <= 3)
                {
                    for (int i = 0; i < Count; i++)
                        Console.WriteLine("A{0} = {1}", i + 1, Elements[i]);
                    Console.WriteLine("");
                }
                else
                    Calculate(ref Elements, Count, 3, Accuracy);
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}