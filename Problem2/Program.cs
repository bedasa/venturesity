using System;
using System.Collections.Generic;

namespace Problem2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nodelist = new List<StNode>
                           {
                               new StNode("Karnataka"),
                               new StNode("TamilNadu"),
                               new StNode("AndhraPradesh"),
                               new StNode("Orissa"),
                               new StNode("Delhi"),
                               
                              
                           };

            var nodelist2 =
                new List<StNode>
                           {

                               new StNode("District1"),
                               new StNode("District2"),
                               new StNode("District3"),
                               new StNode("District4"),
                               new StNode("District6"),
                               new StNode("District5")
                           };



            StNode stNode = new StNode("India");
            stNode.Insert(nodelist, 1);
            nodelist[1].Add(nodelist2);

            Console.Read();
        }
    }
}