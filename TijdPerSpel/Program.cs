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
                return output - 1;
            }
        }

        static private string CalculateTime(ulong sec)
        {
            ulong myHour = sec / 3600;
            ulong myMin = sec % 3600 / 60;
            ulong mySec = (sec % 3600) % 60;
            string myTime = string.Format("{0:D2}:{1:D2}:{2:D2}", myHour, myMin, mySec);

            return myTime;
        }
    }
}
