namespace Ex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EGN egn = new EGN();
            string[] input = Console.ReadLine().Split(' ');
            try
            {
                if (input[0] == "Check")
                {
                    Console.WriteLine(egn.Validate(input[1]));
                }
                else if (input.Length == 1)
                {
                    if (input[0].All(char.IsDigit))
                    {
                        bool isValid = egn.Validate(input[0]);
                        if (isValid)
                        {
                            Console.WriteLine("Valid EGN");
                        }
                        else
                        {
                            Console.WriteLine("Invalid EGN");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input");
                    }
                }
                else if (input.Length == 3)
                {
                    DateTime birthDate = DateTime.Parse(input[0]);
                    string city = input[1];
                    bool isMale;
                    if (input[2].ToLower() == "male")
                    {
                        isMale = true;
                    }
                    else
                    {
                        isMale = false;
                    }

                    string[] result = egn.Generate(birthDate, city, isMale);
                    Console.WriteLine(string.Join("; ", result));
                }
                else
                {
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
