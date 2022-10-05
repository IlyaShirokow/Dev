using System;
using System.IO;

namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] output_string = new string[0];
            string[] stack = new string[0];//стек
            List<string> nums = new List<string>();
            string input_string;
            Console.WriteLine("Введите значения:");
            input_string = Console.ReadLine();
            int k = 0;
            for (int i = 0; i < input_string.Length; i++)
            {
                string temp = "";//переменная для хранения числа
                //проверка на отрицательное число
                if (input_string[i] == '-' && ((i > 0 && !Char.IsDigit(input_string[i - 1])) || i == 0))
                {
                    i++;
                    temp += "-";
                }
                if (Char.IsDigit(input_string[i]))
                {
                    while (i < input_string.Length && Char.IsDigit(input_string[i]))
                        temp += input_string[i++].ToString();
                    i--;
                    Array.Resize(ref output_string, output_string.Length + 1);
                    output_string[output_string.Length - 1] = temp;
                }
                if (input_string[i] == '+' || input_string[i] == '-')
                {
                m:
                    if (stack.Length != 0)
                    {
                        Array.Resize(ref output_string, output_string.Length + 1);
                        output_string[output_string.Length - 1] = stack[stack.Length - 1];
                        Array.Resize(ref stack, stack.Length - 1);
                        goto m;

                        stack[stack.Length - 1] = input_string[i].ToString();
                    }
                    else
                    {
                        Array.Resize(ref stack, stack.Length + 1);
                        stack[stack.Length - 1] = input_string[i].ToString();
                    }
                }
                if (input_string[i] == '*' || input_string[i] == '/')
                {

                    if (stack.Length != 0)
                    {

                        if (stack[stack.Length - 1] != "*" && stack[stack.Length - 1] != "/")
                        {
                            Array.Resize(ref stack, stack.Length + 1);
                            stack[stack.Length - 1] = input_string[i].ToString();
                        }
                        else
                        {
                            Array.Resize(ref output_string, output_string.Length + 1);
                            output_string[output_string.Length - 1] = stack[stack.Length - 1];
                            stack[stack.Length - 1] = input_string[i].ToString();

                        }

                    }
                    else
                    {
                        Array.Resize(ref stack, stack.Length + 1);
                        stack[stack.Length - 1] = input_string[i].ToString();
                    }
                }
                if (input_string[i] == '(' || input_string[i] == ')')
                {
                    Console.WriteLine("Введите выражение без скобок");
                    System.Environment.Exit(0); // Приложение завершается и возвращает ОС указанное параметром значение
                }
            }
            Array.Resize(ref output_string, output_string.Length + stack.Length);
            Array.Reverse(stack);
            for (int i = output_string.Length - stack.Length; i < output_string.Length; i++)
                output_string[i] = stack[k++];
            string t = "";
            for (int i = 0; i < output_string.Length; i++)
                if (i != output_string.Length - 1)
                    t += output_string[i] + " ";
                else
                    t += output_string[i];
            Console.WriteLine(t);//ввывод записанных значений
            string[] mas = t.Split(' ');
            string temp_string;

            for (int i = 0; i < mas.Length; i++)
                switch (mas[i])
                {
                    case "+":
                        temp_string = (double.Parse(mas[i - 2]) + double.Parse(mas[i - 1])).ToString();
                        nums.Append(mas[i - 2] + "+" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);
                        i -= 2;
                        break;
                    case "-":
                        temp_string = (double.Parse(mas[i - 2]) - double.Parse(mas[i - 1])).ToString();
                        nums.Append(mas[i - 2] + "-" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);
                        i -= 2;
                        break;
                    case "*":
                        temp_string = (double.Parse(mas[i - 2]) * double.Parse(mas[i - 1])).ToString();
                        nums.Append(mas[i - 2] + "*" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);

                        i -= 2;
                        break;
                    case "/":
                        temp_string = (double.Parse(mas[i - 2]) / double.Parse(mas[i - 1])).ToString();
                        nums.Append(mas[i - 2] + "/" + mas[i - 1] + "=" + temp_string + "\n");
                        mas[i - 2] = temp_string;
                        for (int j = i - 1; j < mas.Length - 2; j++)
                            mas[j] = mas[j + 2];
                        Array.Resize(ref mas, mas.Length - 2);
                        i -= 2;
                        break;
                }
            double result = double.Parse(mas[0]);
            Console.WriteLine("Ответ:" + result);
        }
    }
}