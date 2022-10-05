namespace calc
{
    class Lab
    {
        static private bool Razd(char a)
        {
            if ((" =".IndexOf(a) != -1))
                return true;
            return false;
        }
        static private bool Operation(char a)
        {
            if (("+-/*^()".IndexOf(a) != -1))
                return true;
            return false;
        }
        static private byte Prioritet(char b)
        {
            switch (b)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 2;
                case '*': return 3;
                case '/': return 3;
                default: return 4;
            }
        }
        static public double Сalculation(string input)
        {
            string output = Postficks(input);
            double result = RezPost(output);
            return result;
        }
        static private string Postficks(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {

                if (Razd(input[i]))
                    continue;

                if (Char.IsDigit(input[i]))
                {

                    while (!(Razd(input[i]) || Operation(input[i])))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length) break;
                    }

                    output += " ";
                    i--;
                }

                if (Operation(input[i]))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char s = operStack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (Prioritet(input[i]) <= Prioritet(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";

                        operStack.Push(char.Parse(input[i].ToString()));
                    }
                }
            }


            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
        }
        static private double RezPost(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!(Razd(input[i]) && !Operation(input[i])))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (Operation(input[i]))
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите выражение: ");
                Console.WriteLine(Lab.Сalculation(Console.ReadLine()));
            }
        }
    }
}
