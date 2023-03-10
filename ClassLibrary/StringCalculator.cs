using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StringCalculator
    {
        public int Add(string number)
        {
            if (number == "")
            {
                return 0;
            }

            try
            {
                var numbers = number.Split(',', '\n');
                int sum = 0;
                for (int i = 0; i < numbers.Length; ++i)
                {
                    int num = Convert.ToInt32(numbers[i]);
                    if (num < 0) throw new ArgumentOutOfRangeException();
                    if (num > 1000) continue;
                    sum += num;
                }
                return sum;
            }
            catch
            {
                throw new ArgumentException();
            }

            throw new ArgumentException();
        }
    }
}
