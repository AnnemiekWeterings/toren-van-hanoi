using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TijdPerSpel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0, -25} {1, -25} {2, -25}", "Schijven", "Zetten", "Tijd");
            for (int i = 1; i <= 64; i++)
            {

                string myTime = CalculateTime(CalculateTurn(2, i, 0));

                Console.WriteLine("{0, -25} {1, -25} {2, -25}", i, CalculateTurn(2, i, 0), myTime);
            }


            Console.WriteLine("press enter to exit. . . ");
            Console.ReadLine();
        }

        static private ulong CalculateTurn(ulong output, int schijven, int herhalingen)
        {
             if (herhalingen < schijven - 1)
            {
                output *= 2;
                herhalingen += 1;
                return CalculateTurn(output, schijven, herhalingen);
            }

            else
            {
                // PRBLM: Dit kan mogelijk mis g 
                return output - 1;
            }
        }

        static private string CalculateTime(ulong sec)
        {
            /*  ulong myDay = sec / 86400;
                ulong myHour = sec % 86400 / 3600;
                ulong myMin = sec % 3600 / 60;
                ulong mySec = (sec % 3600) % 60;
                string myTime = string.Format("{0:D2} dagen {1:D2}:{2:D2}:{3:D2}", myDay, myHour, myMin, mySec);

                return myTime;
            */

            ulong day = 86400;
            ulong year = day * 365;
            ulong decenia = year * 10;
            ulong century = decenia * 10;
            ulong millenium = century * 10;

            ulong myMillenium = sec / millenium;
            ulong myCentury = sec % millenium / century;
            ulong myDecenia = sec % millenium % century / decenia;
            ulong myYear = sec % millenium % century % decenia / year;
            ulong myDay = sec % millenium % century % decenia % year / day;
            ulong myHour = sec % millenium % century % decenia % year % day / 3600;
            ulong myMin = sec % millenium % century % decenia % year % day % 3600 / 60;
            ulong mySec = sec % millenium % century % decenia % year % day % 3600 % 60 % 60;


            // string myTime = string.Format("{0:D2} eeuwen {1:D2}:{2:D2}:{3:D2}", myDay, myHour, myMin, mySec);

            return Convert.ToString(myMillenium + " millenia " + myCentury + " centuries " + myDecenia + " decenia " + myYear + " years " + myDay +" days "+ myHour +":"+ myMin + ":" + mySec);
            
            //return Convert.ToString(myMillenium +" millenia "+ myCentury + " eeuwen " + myDecenia + " decenia " + myYear + " jaren " + myDay + "dagen");
        }
    }
}
