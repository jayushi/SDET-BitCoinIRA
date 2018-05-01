using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace Test
{
	class Program
	{
		static void Main(string [] args)
		{ 
			//Initializing the browser
			IWebDriver driver = new ChromeDriver();

			//Navigate to URL – Assuming it is http://demo.com/options.html
			driver.Navigate().GoToUrl(“http://demo.com/options.html”);

			//Get the elements
			var minDurationField = driver.FindElement(By.Id(“MinDuration”));
			var messageField = driver.FindElement(By.Id(“Message”));
			var demoButton = driver.FindElement(By.xpath(“//input[@value=’Demo’]”));
			var list = driver.FindElement(By.Id(“urlList”));
			var listItem = new SelectElement(list);
			var BusyIndicator = driver.FindElement(By.Name(“BusyIndicator”));
			var DancingWizard = driver.FindElement(By.Name(“Dancingwizard”));
			
				
      //For Acceptance Criteria 5
			listItem.SelectByValue(“Standard”);
      demoButton.Click();

      //Assuming Delay is 10 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(10));
      Assert.IsTrue(BusyIndicator.Displayed);

      //Assuming Min Duration is also 10 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(10));

      listItem.SelectByValue(“custom-template.html”);
      demoButton.Click();
      Assert.IsTrue(DancingWizard.Displayed);


      //For Acceptance Criteria 7.1
      messageField.SendKeys(“Please Wait…”);
      demoButton.Click();

      //Assuming Delay is 10 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(10));
      Assert.IsTrue(BusyIndicator.Text(“Please Wait…”).Displayed);

      //Assuming Min Duration is also 10 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(10));

	
      //For Acceptance Criteria 7.2
      messageField.SendKeys(“Waiting”);
      demoButton.Click();

      //Assuming Delay is 10 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(10));
      Assert.IsTrue(BusyIndicator.Text(“Waiting”).Displayed);

      //Assuming Min Duration is also 10 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(10));


      //For Acceptance Criteria 7.3
      minDurationField.SendKeys(“1000”);
      demoButton.Click();

      //Assuming Delay is 10 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(10));
      Assert.IsTrue(BusyIndicator.Text(“Waiting”).Displayed);

      //Min Duration is set to 1000 ms
      driver.Manage().Timeouts().ImplicitlyWait(Timespan.FromMilliseconds(1000));

      /*Verifying existence of grid elements on webpage. Assumption: Table id is “dataTable”
      */

      //Test for Larry the Bird
      var larry = driver.FindElement(By.xpath(“.//*[@id=’dataTable’]/tbody/tr[5]/td[2]”));
      if (larry.getText() == “Larry the Bird”)
      Console.WriteLine(“Larry the Bird : present”);

      //Test for @TwBootstrap
      var twb = driver.FindElement(By.xpath(“.//*[@id=’dataTable’]/tbody/tr[3]/td[4]”));
      if (twb.getText() == “@TwBootstrap”)
      Console.WriteLine(“@TwBootstrap : present”);


      driver.quit();
		}
	}
}
