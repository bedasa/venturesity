using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;

namespace Problem2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestBulkInsert();
            TestNestedObjects();
            Console.Read();
        }


        private static void TestBulkInsert()
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

            Console.WriteLine(nodelist[1].Children[1].Nodeid == 21? "success TestBulkInsert" : "fail TestBulkInsert") ;
        }

        private static void TestNestedObjects()
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

            nodelist[4].Add(nodelist2);

            StNode District5 = nodelist2[5];
            StNode stNode = new StNode("India");

            stNode.Insert(nodelist, 2);

            Console.WriteLine(District5.Nodeid == 21 ? "success TestNestedObjects" : "fail TestNestedObjects");
        }

    }
}