using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6
{
    public partial class Controller
    {
        //Вес наименьшего компонента подарка
        public static void LessNumbOfMass()
        {
            foreach (Goods i in Present.podarok)
            {
                if (i.weight < min)
                {
                    min = i.weight;
                }
            }
            Console.WriteLine("Наименьший вес: " + min + " грамм");
        }
    }
}
