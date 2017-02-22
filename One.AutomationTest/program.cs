using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using OpenQA.Selenium.Interactions;
using One.AutomationTest.automations;

namespace One.AutomationTest
{
    public class program
    {
        static IWebDriver driver;
        static string baseURL = "http://localhost:49036/ui/index";
        static void Main(string[] args)
        {
            Console.WriteLine("Automation test start");
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
            var s = new StudentAutomation(driver);

            Console.ReadLine();
        }
    }
}
