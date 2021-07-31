using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDrumsBeep
{
    class Pam
    {
       public int size { get; set; }
       public int[] arr { get; set; }

        public Pam()
        {
            arr = new int[1];

            size = 1;
            arr[0] = 1;
        }

        public Pam(int sz , int[] arr)
        {
            size = sz;

            this.arr = new int[size];

            for (int i= 0 ; i< size;i++)
            {
                this.arr[i] = arr[i];

            }
        
        }
    }
}
