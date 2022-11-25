﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_2018118
{
    class Program
    {
        class Node
        {
            /*creates nodes for the cicular nexted list*/
            public int rollNumber;
            public string name;
            public Node next;
        }
        class CircularList
        {
            Node LAST;

            public CircularList()
            {
                LAST = null;
            }

            public bool Search(int rollNo, ref Node previous, ref Node current)
            /*Searches for the specified node*/
            {
                for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
                {
                    if (rollNo == current.rollNumber)
                        return (true);/*return true if the node is found*/
                }
                if (rollNo == LAST.rollNumber)/*if the node is present at the end*/
                    return (true);
                else
                    return (false);/*return false if the node is not found*/
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
