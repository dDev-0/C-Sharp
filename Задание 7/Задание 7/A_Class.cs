using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_7
{
    class A_Class
    {
        int[] aM;

        public A_Class(int n)
        {
            if (n > 0)
                aM = new int[n];
            else
                throw new Exception("Значение размерности должно быть больше 0");
        }

        public int this[int k]
        {
            get
            {
                if (k >= 0 && k < aM.Length)
                    return aM[k];
                else
                    throw new Exception("Индекс выходит за границы диапазона");
            }
            set
            {
                if (k >= 0 && k < aM.Length)
                    aM[k] = value;
                else
                    throw new Exception("Индекс выходит за границы диапазона");
            }
        }
    }
}
