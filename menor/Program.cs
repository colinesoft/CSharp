using System;

namespace menor
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 n;
            int[] isolate;

            try
            {
                //Get the number
                Console.Write("Input a integer number: ");
                n = Int32.Parse(Console.ReadLine());
                //make a array for explode number
                isolate = explode(n);

                //Display ; Reorder and Display Sorted
                Console.WriteLine("Value.: [ {0} ]", string.Join("", isolate));
                Reorder(isolate);
                Console.WriteLine("Sorted: [ {0} ]", string.Join("", isolate));
            }
            catch (System.Exception)
            {   
                //Exception
                throw new Exception("Invalid Parameter, try a integer number.");
            }
        }



        /// <summary>
        /// Reorder number function.
        /// Bubble-like sorting
        /// </summary>
        /// <param name="array">Array os numbers for Sort</param>
        static void Reorder(int[] array)
        {
            int minp;
            int aux;
            for(int i=0; i<array.Length; i++)
            {
                minp = MinPosition(array, i);
                if(array[i]>array[minp])
                {
                    aux = array[i];
                    array[i] = array[minp];
                    array[minp] = aux;
                }
            }
        }

        /// <summary>
        /// Explode the individual numbers loadin an array
        /// </summary>
        /// <param name="number">Integer input</param>
        /// <returns>array[] E: [ 7, 3, 9, 2, 4, 9, 8, 5, 0, 4 ]</returns>
        private static int[] explode(Int32 number){
            int[] ret = new int[number.ToString().Length];
            string tmp = number.ToString();
            for(int i=0; i<ret.Length;i++)
                ret[i]=int.Parse(tmp[i].ToString());
            return ret;
        }

        /// <summary>
        /// Get the minor value position 
        /// </summary>
        /// <param name="array">Array of values</param>
        /// <param name="ini">From initial position</param>
        /// <returns>
        /// int
        ///     Ex: MinPosition(654132,0) // 3 
        ///         MinPosition(128714,3) // 1
        /// </returns>
        private static int MinPosition(int[] array, int ini)
        {   
            int min = array[ini];            
            int r=ini;
            for(int i=ini+1;i<array.Length;i++)
                if(array[i]<min)
                {
                    r=i;
                    min = array[i];
                }
            return r;
        }
    }
}
