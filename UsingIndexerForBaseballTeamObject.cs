using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel;

namespace SandBox
{
    class Program
    {
        public class BaseballTeam
        {
            private string[] players = new string[9];
            private readonly List<string> positionAbbreviations = new List<string>
            {
                "P", "C", "1B", "2B", "3B", "SS", "LF", "CF", "RF"
            };

            public int Length
            {
                get { return positionAbbreviations.Count; }
            }

            public string this[int position]
            {
                get { return players[position - 1]; }
                set { players[position - 1] = value; }
            }

            public string this[string position]
            {
                get { return players[positionAbbreviations.IndexOf(position)]; }
                set { players[positionAbbreviations.IndexOf(position)] = value; }
            }

            public string GetPositionAbbreviation(int indexer)
            {
                return positionAbbreviations.ElementAt(indexer-1);

            }
        }

        static void Main()
        {
            var team = new BaseballTeam
            {
                [1] = "Hosea Calibre",
                ["C"] = "John Green",
                ["1B"] = "Bailey Matthews",
                ["2B"] = "Mookie Wilson",
                ["3B"] = "Louis Atavia",
                ["SS"] = "Rex Gatlin",
                ["RF"] = "Harvey White",
                ["CF"] = "Lou Gherig",
                ["LF"] = "Jordan Millan"
            };

            

            for (int i = 1; i <= 9 ; i++)
            {
                string position = team.GetPositionAbbreviation(i);

                Console.WriteLine(team[i] + " " + position);
            }
            
            Console.ReadKey();
        }
    }
}
