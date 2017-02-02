using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace One.AutomationTest
{
    public class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Automation test start");
            
            Console.ReadLine();
        }
    }

    public class Student {

        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
