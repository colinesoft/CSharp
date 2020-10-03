using System;

namespace qtdechar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables declaration
            String letrasUsadas="";
            String msg="";
            Char letra=' ';
            int qtdeMax=0, aux=0;

            //DATA INPUT
            Console.WriteLine("REGRAS: <ESPACO> tambem conta como letra. No caso de letras repetidas");
            Console.WriteLine("como sendo as que mais se repetem, o algoritmo apresentara a ultima.");
            Console.WriteLine("\nDigite uma mensagem para calculo de maior repeticao de caractere....:");
            msg = Console.ReadLine();

            //PROCESSING
            for(int i=0; i<msg.Length; i++)
            {
                //Tests if the current character is not used
                if(!letrasUsadas.Contains(msg[i]))
                {
                    //Stores the character as used
                    letrasUsadas += msg[i];
                    aux = 0;
                    //starts counting in msg
                    for(int j=i; j<msg.Length;j++)
                    {
                        //COUNT HOW MANY TIMES THE LETTER REPEATS
                        if(msg[j] == msg[i])
                            aux++; 
                    }
                    //Stores the MAX quantity and the corresponding letter
                    if(aux>qtdeMax)
                    {
                        letra = msg[i];
                        qtdeMax = aux; 
                    }
                }
            }
            //OUTPUT
            Console.WriteLine("\nA letra [" + letra +"] repetiu " + qtdeMax + " vezes.");
        }
    }
}
