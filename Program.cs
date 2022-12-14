using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_2018118
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

        static Node addToEmpty(Node last, int data)
        {
            // This function is only for empty list
            if (last != null)
                return last;

            // Creating a node dynamically.
            Node temp = new Node();

            // Assigning the data.
            temp.rollNumber = data;
            last = temp;

            // Creating the link.
            last.next = last;

            return last;
        }

        static Node deleteNode(Node head, int key)
        {
            if (head == null)
                return null;

            // Find the required node
            Node curr = head, prev = new Node();
            while (curr.data != key)
            {
                if (curr.next == head)
                {
                    Console.Write("\nGiven node is not found"
                                  + " in the list!!!");
                    break;
                }

                prev = curr;
                curr = curr.next;
            }

            // Check if node is only node
            if (curr.next == head && curr == head)
            {
                head = null;
                return head;
            }

            // If more than one node, check if
            // it is first node
            if (curr == head)
            {
                prev = head;
                while (prev.next != head)
                    prev = prev.next;
                head = curr.next;
                prev.next = head;
            }

            // check if node is last node
            else if (curr.next == head)
            {
                prev.next = head;
            }
            else
            {
                prev.next = curr.next;
            }
            return head;
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

            public bool listEmpty()
            {
                if (LAST == null)
                    return true;
                else
                    return false;
            }

            public void traverse()/*traverses all the nodes of the list*/
            {
                if (listEmpty())
                    Console.WriteLine("\nList is empty");
                else
                {
                    Console.WriteLine("\nRecords in the list are:\n");
                    Node currentNode;
                    currentNode = LAST.next;
                    while (currentNode != LAST)
                    {
                        Console.Write(currentNode.rollNumber + "     " +
                            currentNode.name + "\n");
                        currentNode = currentNode.next;
                    }
                    Console.Write(LAST.rollNumber + "      " + LAST.name + "\n");
                }
            }
            public void firstNode()
            {
                if (listEmpty())
                    Console.WriteLine("\nList is empty");
                else
                    Console.WriteLine("\nThe first record in the list is:\n\n" + LAST.next.rollNumber + "     " + LAST.next.name);       
            }

            
            static void Main(string[] args)
            {
            CircularList obj = new CircularList();

            while (true) 
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. view all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll Number: " + curr.rollNumber);
                                    Console.WriteLine("\nName:  " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

    }
        
        
    
}
