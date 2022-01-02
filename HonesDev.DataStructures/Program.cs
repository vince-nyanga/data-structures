using System;
using HonesDev.DataStructures.DoublyLinkedList.BasicImpl;

HDLinkedList<int> linkedList = new();
linkedList.AddFirst(1);
linkedList.AddLast(3);
linkedList.InsertSorted(2);

Console.WriteLine("List");
linkedList.ListItems();
Console.WriteLine();
Console.WriteLine("Reverse\r");
linkedList.ListItemsReverse();

Console.ReadLine();