using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal static class Globales
    {
        //private static string lclDbConString = "Server=localhost\\SQLEXPRESS;Database=Blackjack;Integrated Security=True;";
        //private static string remDbConString = "Data Source=tcp:201.213.192.68;Initial Catalog=Blackjack;User ID=leshe;Password=PijaPeluda";

        public static string DBCon() => "Data Source=tcp:201.213.192.68\\SQLEXPRESS,1433;Initial Catalog=Blackjack;User ID=player;Password=playerpass";
    }
}