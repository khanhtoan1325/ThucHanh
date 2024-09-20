using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_01
{
    internal class Program

    {

        static void Main(string[] args)

        {

            Console.WriteLine("===Chuong trinh doan so===");



            Random random = new Random();

            int targetNumber = random.Next(100, 199);

            string targetString = targetNumber.ToString();



            int attempt = 1, MAX_GUESS = 7;

            string guess, feedback = "";

            while (feedback != "+++" && attempt <= MAX_GUESS)

            {

                Console.Write("Lan doan thu {0}: ", attempt);

                guess = Console.ReadLine();

                feedback = GetFeedback(targetString, guess);

                Console.WriteLine("Phan hoi tu may tinh: {0}", feedback);

                attempt++;

            }

            Console.WriteLine("Nguoi choi da doan {0} lan. Tro choi ket thuc!", attempt - 1);

            if (attempt > MAX_GUESS)

                Console.WriteLine("Nguoi choi thua cuoc. So lan doan la: {0}", targetNumber);

            Console.ReadLine();

        }



        private static string GetFeedback(string targetString, string guess)

        {

            string feedback = "";

            for (int i = 0; i < targetString.Length; i++)

            {

                if (targetString[i] == guess[i])

                    feedback += "+";

                else if (targetString.Contains(guess[i].ToString()))

                    feedback += "?";

            }

            return feedback;

        }

    }
}
