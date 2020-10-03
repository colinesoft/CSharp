using System;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Instance of Cards. The Cards contructor will Fill them 
            Cards ct = new Cards();
            //Method ToString is Override
            Console.WriteLine(ct.ToString());
        }
    }





    /// <summary>
    /// Cards class - Create the cards and fill the numbers
    /// </summary>
    class Cards
    {
        const int MAX_NUMBERS=60;
        const int QT_CARDS=20;
        const int QT_NUM_CARDS=6;
        private int[] numbers = new int[MAX_NUMBERS];        
        private int[,] cards = new int[QT_CARDS, QT_NUM_CARDS];
        
        //Call fillRandom in constructor method
        public Cards()
        {
            FillRandom();                  
        }

        /// <summary>
        /// Generate the cards using the const MAX_NUMBERS, QT_CARDS, QT_NUM_CARDS
        /// </summary>
        private void GenerateCards()
        {
            int p = 0;
            for(int i=0; i<QT_NUM_CARDS;i++)
            {
                for(int j=0; j<QT_CARDS;j++)
                {
                    this.cards[j, i] = this.numbers[p]; 
                    p++;
                }
                if(p==MAX_NUMBERS)
                {
                    //One more time using the numbers with 3 adress deslocation
                    RotateArray(3);
                    p = 0;                        
                }                 
            }
        }

        /// <summary>
        /// Rotate the array for generate news numbers
        /// </summary>
        private void RotateArray(int n)
        {
            //Save a temp array n firts elements
            int[] swap = new int[n];            
            for(int i=0;i<n;i++)
            {
                swap[i] = this.numbers[i];
            }

            //Rotate Left Array n elements
            for(int i=0; i<this.numbers.Length-n; i++)
            {
                this.numbers[i] = this.numbers[i+n]; 
            }

            //Rescue swap to numbers
            for(int i=0;i<n;i++)
            {
                this.numbers[this.numbers.Length-n+i] =swap[i];
            }
        }

        /// <summary>
        /// Fill the class with  the random numbers 
        /// </summary>
        public void FillRandom()
        {
            for(int p=0; p<MAX_NUMBERS; p++)
            {
                this.numbers[p] = GetNewNumber();
            }
            //Affeter raffle the numbers, The cards is generated 
            GenerateCards();
        }

        /// <summary>
        /// Override the ToString() method, displaying the raffled numbers
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            String r = "RANDOM CARDS: \n";
            for(int i=0; i<20; i++)
            {
                r += "\n" + DisplayCard(i);
            }
            return r;
        }        

        /// <summary>
        /// Display the Card
        /// </summary>
        /// <param name="index">int - index of cards</param>
        /// <returns></returns>
        public string DisplayCard(int index)
        {
            String r="Card "+((index+1).ToString()).PadLeft(2,'0')+": [ ";
            String m="";
            int[] tmp = new int[QT_NUM_CARDS];

            for(int i=0;i<QT_NUM_CARDS;i++)
                tmp[i] = this.cards[index,i];

            Array.Sort(tmp);

            for(int i=0;i<QT_NUM_CARDS;i++)
            {
                r += m + (tmp[i].ToString()).PadLeft(2,'0');
                m = ", ";
            }
            r += " ]";

            return r;            
        }

        /// <summary>
        /// Display array - All Raffled numebrs
        /// </summary>
        /// <returns>String</returns>
        public string DisplayNumbers()
        {
            String r="[";
            String m="";
            foreach (var item in this.numbers)
            {
                r += m + item;
                m = ",";
            }
            r += "]";
            return r;
        } 
        /// <summary>
        /// Checks if number is raffled
        /// </summary>
        /// <param name="number">int - Number for verification</param>
        /// <returns>boolean
        ///         If the number has already been drawn, returns true
        /// </returns>
        private bool IsRaffled(int number)
        {
            bool r=false;
            foreach (var item in this.numbers)
                if(r = item == number) break;
            return r;
        } 

        /// <summary>
        /// Random a new number between 1 and 60
        /// </summary>
        /// <returns>int</returns>
        private int GetNewNumber()
        {
            Random rnd = new Random();
            int r;
            do{
                r = rnd.Next(60);
                r++; //if r==0, then r=1... the number 60 do note will raffled MAX 59
            } while(IsRaffled(r));
            return r;
        }
    }
}
