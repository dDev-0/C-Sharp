using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_7
{
    class B_Class
    {
        int[] bM;
        int min;

        public B_Class(int m)
        {
            if (m > 0)
                bM = new int[m];
            else
                throw new Exception("Значение размерности должна быть больше 0");
        }

        public int this[int k]
        {
            get
            {
                if (k >= 0 && k < bM.Length)
                    return bM[k];
                else
                    throw new Exception("Индекс выходит за границы диапазона");
            }

            set
            {
                if (k >= 0 && k < bM.Length)
                     bM[k] = value;
                else
                    throw new Exception("Индекс выходит за границы диапазона");
            }
        }

        public int minimim
        {
            get
            {
              min = bM[0];
              for (int i = 1; i < bM.Length; i++)
              {
                if (bM[i] < min)
                min = bM[i];
              }
                return min;
            }
        }
    }
}
