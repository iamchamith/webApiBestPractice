using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace One.AutomationTest.automations
{
    public class StudentAutomation: IAutomationTest
    {
        IWebDriver driver;
        IJavaScriptExecutor jsEx;
        public StudentAutomation(IWebDriver _driver) {
            this.driver = _driver;
            jsEx = (IJavaScriptExecutor)driver;
            Thread.Sleep(2000);
            Create();
            Read();
            Delete();
            Update();
        }
        public void Create()
        { 
            driver.FindElement(By.Id("btnCreateStudentModelOpen")).Click();
            Thread.Sleep(1000);
            SetValuesWithoutValidation();
            driver.FindElement(By.Id("btnSave")).Click();
            driver.FindElement(By.XPath(@"/html/body/div[6]/div[7]/div/button")).Click();//confirmation box button
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(@"/html/body/div[4]/div[7]/div/button")).Click();//error box button
            Thread.Sleep(2000);
            SetValues();
            driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath(@"/html/body/div[6]/div[7]/div/button")).Click();//confimation box button
        }
         

        public void Delete()
        {
           // throw new NotImplementedException();
        }
         
        public void Read()
        {
           // throw new NotImplementedException();
        }

        public void SetValues()
        {
            driver.FindElement(By.Id("txtName")).SendKeys("Nuwan");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtEmail")).SendKeys("nuwan@gmail.com");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtAddress")).SendKeys("kandana");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtPhone")).SendKeys("0718920205");
            Thread.Sleep(1000);
          
        }
        public void SetValuesWithoutValidation() {
            driver.FindElement(By.Id("txtEmail")).SendKeys("errorGmail");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txtPhone")).SendKeys("123123123123123");
            Thread.Sleep(1000);
        }

        public void Update()
        {
            //driver.FindElement(By.Id("btnCreateStudentModelOpen")).Click();
            //Setvalues();
            //driver.FindElement(By.Id("btnSave")).Click();
        }
    }
}
