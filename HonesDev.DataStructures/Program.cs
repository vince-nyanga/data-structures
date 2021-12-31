using System;
using HonesDev.DataStructures.DoublyLinkedList.BasicImpl;

HDLinkedList<int> linkedList = new();
for (var i = 1; i < 11; i++)
{
    linkedList.AddLast(i);
}

Console.WriteLine("List");
linkedList.ListItems();
Console.WriteLine();
Console.WriteLine("Reverse\r");
linkedList.ListItemsReverse();

Console.ReadLine();