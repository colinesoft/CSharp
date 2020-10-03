using System;

namespace cedulas
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaration of variables
            int[] cedulas = {50, 20, 10, 5, 2, 1}; //Types of existing banknotes
            int[] qtCedulas = {0, 0, 0, 0, 0, 0}; //Array to store the number of bills 
            int inputValue=0, result=0, rest=0, allItems=0; //Aux

            //Presentation
            Console.WriteLine("***** CALCULO DE MINIMO DE CEDULAS PARA UM DADO VALOR *****");
            Console.WriteLine("-----------------------------------------------------------");

            //Data input
            Console.Write("Entre com o valor que deseja para separacao de cedulas: ");
            inputValue = Convert.ToInt32(Console.ReadLine());

            //Processing
            //Initial value with rest is necessary
            rest = inputValue;
            for (int i=0; i<cedulas.Length; i++)
            {
                result = rest / cedulas[i];     
                if(rest==0) break;           
                rest = rest % cedulas[i]; 
                qtCedulas[i] = result;
            }

            //OUTPUT
            Console.WriteLine("A separacao da menor quantidade possivel de decedulas para o valor {0:C}: \n", inputValue);
            Console.WriteLine(String.Format("{0,10} | {1,6} | {2,10}", "CEDULAS", "QTDE", "VALOR POR CEDULA"));
            for (int i=0; i<cedulas.Length; i++)
            {
                //Values ​​only> 0
                if(qtCedulas[i]>0)
                {
                    allItems += qtCedulas[i];
                    Console.WriteLine(String.Format("{0,10:C} | {1,6} | {2,10:C}", cedulas[i], qtCedulas[i], qtCedulas[i]*cedulas[i]));
                }                   
            }
            //Display amount
            Console.WriteLine("\nTotal minimo de cedulas: {0:D}", allItems);
        }
    }
}
