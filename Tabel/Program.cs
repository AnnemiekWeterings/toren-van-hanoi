using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0,-25} {1,-25}", "Schijven", "Zetten");

            for (int i = 1; i <= 64; i++)
            {
                Console.WriteLine("{0, -25} {1, -25}",i, CalculateTurn(2, i, 0));
            }

            Console.WriteLine("Press enter to exit. . . ");
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
    }
}
