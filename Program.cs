using System;
using System.Collections.Generic;

namespace TaskManagementSystem
{
    public class Task
    {
        public int Index { get; set; }
        public string Description { get; set; }

        public Task(int index, string description)
        {
            Index = index;
            Description = description;
        }
    }

    class TaskManagement
    {
        private LinkedList<Task> tasks = new LinkedList<Task>();
        private int nextIndex = 1;

        public void AddTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            tasks.AddLast(new Task(nextIndex, description));
            Console.WriteLine($"Task {nextIndex} added.\n");
            nextIndex++;
        }

        public void RemoveTask()
        {
            Console.Write("Enter task index to remove: ");
            int index = Convert.ToInt32(Console.ReadLine());

            // Find the node with the matching index
            LinkedListNode<Task> current = tasks.First;
            while (current != null)
            {
                if (current.Value.Index == index)
                {
                    tasks.Remove(current);
                    Console.WriteLine($"Task {index} removed.\n");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine($"Task {index} not found.\n");
        }

        public void EditTask()
        {
            Console.Write("Enter task index to edit: ");
            int index = Convert.ToInt32(Console.ReadLine());

            // Traverse to find the task
            LinkedListNode<Task> current = tasks.First;
            while (current != null)
            {
                if (current.Value.Index == index)
                {
                    Console.Write("Enter new description: ");
                    current.Value.Description = Console.ReadLine();
                    Console.WriteLine("Task updated.\n");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine($"Task {index} not found.\n");
        }

        public void DisplayTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.\n");
                return;
            }

            foreach (Task task in tasks)
                Console.WriteLine($"Index: {task.Index} \n Description: {task.Description}");

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            TaskManagement tm = new TaskManagement();

            while (choice != 5)
            {
                Console.WriteLine("Welcome to Task Management System");
                Console.WriteLine("1. Add Task\n" +
								"2. Remove Task\n" +
								"3. Edit Task\n" +
								"4. Display Tasks\n" +
								"5. Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: tm.AddTask();     break;
                    case 2: tm.RemoveTask();  break;
                    case 3: tm.EditTask();    break;
                    case 4: tm.DisplayTask(); break;
                    case 5: Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice.\n"); break;
                }
            }
        }
    }
}