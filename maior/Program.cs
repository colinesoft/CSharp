using System;

namespace maior
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 n, x=0;
            int[] isolate;

            try
            {
                //Get the number
                Console.Write("Input a integer number: ");
                n = Int32.Parse(Console.ReadLine());
                //make a array for explode number
                isolate = explode(n);
                Console.WriteLine("Value...: [ {0} ]", string.Join("", isolate));
                while(true)
                {
                    if(!NextInt(isolate))
                    {
                        Console.WriteLine("\n*** it's working! ***");
                        break;
                    }
                    //Display ; Reorder and Display Sorted
                    Console.WriteLine("Next Int: {0} - [ {1} ]",++x , string.Join("", isolate));
                }
            }
            catch (System.Exception)
            {   
                //Exception
                throw new Exception("Invalid Parameter, try a integer number.");
            }
        }

        /// <summary>
        /// This function rearranges the numbers to the next 
        /// possible integer with the same numbers entered
        /// </summary>
        /// <param name="array">Number array</param>
        /// <returns>
        ///     bool
        ///         if not is possible generate next integer, return false
        ///         else return true
        /// </returns>
        private static bool NextInt(int[] array )
        {
            int aux;
            bool r=false;
            for(int i=array.Length-1; i>0; i--)
            {
                if(array[i]>array[i-1])
                {
                    //swap number
                    aux = array[i];
                    array[i] = array[i-1];
                    array[i-1] = aux;
                    r=true;
                    break;
                }                
            }
            return r;
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
    }
}
