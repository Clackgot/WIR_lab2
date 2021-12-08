using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIR_lab2
{

    public static class StringDistance
    {
        /// <summary>
        /// Расстояния Хэмминга
        /// </summary>
        /// <param name="a">Первая строка</param>
        /// <param name="b">Вторая строка</param>
        /// <returns></returns>
        public static int GetHammingDistance(string a, string b)
        {
            if (a.Length != b.Length)
            {
                throw new Exception("Строки должны иметь одинаковую длину");
            }

            int distance =
                a.ToCharArray()
                .Zip(b.ToCharArray(), (c1, c2) => new { c1, c2 })
                .Count(m => m.c1 != m.c2);

            return distance;
        }

        /// <summary>
        /// Расстояние Левенштейна
        /// </summary>
        /// <param name="a">Первая строка</param>
        /// <param name="b">Вторая строка</param>
        /// <returns></returns>
        public static int GetLevenshteinDistance(string a, string b)
        {
            int n = a.Length;
            int m = b.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (b[j - 1] == a[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringDistance.GetLevenshteinDistance("Иванов Иван Иванович", "Иванов Ивн Иванович"));

            Console.ReadKey();
        }
    }
}
