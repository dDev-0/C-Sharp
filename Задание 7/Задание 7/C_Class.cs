using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_7
{
    class C_Class
    {
        int[] cM;
        public C_Class(int n)
        {
            if (n > 0)
                cM = new int[n];
            else
                throw new Exception("Значение размерности должна быть больше 0");
        }

        public int this[int k]
        {
            get
            {
                if (k >= 0 && k < cM.Length)
                {
                    return cM[k];
                }
                else
                    throw new Exception("Индекс выходит за рамки массива");
            }
            set
            {
                if (k >= 0 && k < cM.Length)
                {
                    cM[k] = value;
                }
                else
                    throw new Exception("Индекс выходит за рамки массива");
            }
        }

    }
}
