using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringDemo {
    public class Numbers {

        //  keine aussagekräftige Namen
        //  unnötige Codeteile
        //  zuviele Verantwortlichkeiten
        //  Kommentare erklären zuwenig
        //  Verschachtelungen


        // calculate numbers
        public static int[] Func(int z, bool p) {
            // treat special case smaller than 2
            if ((z < 2)) {
                return new int[0];
            }

            int l = (((int)(Math.Sqrt(z))) + 2);
            // create Array with boolean
            bool[] array = new bool[(z + 1)];
            // initialise Array with true
            for (int i = 0; (i< (z + 1)); i++) {
                array[i] = true;
            }

            // initialise special cases 0 und 1
            array[0] = false;
            array[1] = false;
            // actual algorithm
            for (int a = 2; (a < l); a++) {
                if (array[a]) {
                    //  if true
                    for (int n = 2; (n <= (z / a)); n++) {
                        int b = (n * a);
                        if ((b <= z)) {
                            array[b] = false;
                        }

                        // set false
                    }

                }

            }

            //  count in array
            int c = 0;
            foreach (bool b in array) {
                if (b) {
                    c++;
                }

            }

            //  evaluate array
            int[] buffer = new int[c];
            int j = 0;
            for (int i = 0; (i < array.Length); i++) {
                if (array[i]) {
                    buffer[j++] = i;
                }

            }

            //  write to console
            if (p) {
                foreach (int x in buffer) {
                    Console.WriteLine(x);
                }

            }

            return buffer;
        }
    }
}
