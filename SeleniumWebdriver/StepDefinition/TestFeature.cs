using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebdriver.StepDefinition
{
    [Binding]
    public sealed class TestFeature
    {
       private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  public string waitForWindow(int timeout) {
    try {
      Thread.Sleep(timeout);
    } catch(Exception e) {
      Console.WriteLine("{0} Exception caught.", e);
    }
    var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
    var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
    if (whNow.Count > whThen.Count) {
      return whNow.Except(whThen).First().ToString();
    } else {
      return whNow.First().ToString();
    }
  }
 [Given(@"User is at Home Page")]
   public void test() {
    driver.Navigate().GoToUrl("https://www.labcorp.com/");
    driver.Manage().Window.Size = new System.Drawing.Size(1382, 744);
    vars["WindowHandles"] = driver.WindowHandles;
    driver.FindElement(By.LinkText("Careers(link is external)")).Click();
    vars["win7511"] = waitForWindow(2000);
    driver.SwitchTo().Window(vars["win7511"].ToString());
    driver.FindElement(By.Id("search-keyword-da6d38e636")).Click();
    driver.FindElement(By.Id("search-keyword-da6d38e636")).SendKeys("QA");
    driver.FindElement(By.Id("search-submit-da6d38e636")).Click();
    js.ExecuteScript("window.scrollTo(0,470)");
    
    driver.FindElement(By.CssSelector("li:nth-child(1) h2")).Click();
    Assert.AreEqual(driver.FindElement(By.tagName("h1")).getText(), "Senior Software QA Analyst");
    Assert.AreEqual(driver.FindElement(By.xpath("//span[@class='job-location job-info']")).getText(), "Location:Burlington, North Carolina");
    Assert.AreEqual(driver.FindElement(By.xpath("//span[@class='job-id job-info']")).getText(), "Job ID:21-85987");
    driver.FindElement(By.CssSelector(".top")).Click();
    {
      var element = driver.FindElement(By.CssSelector(".top"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element).Perform();
      
    }
    {
      var element = driver.FindElement(By.tagName("body"));
      Actions builder = new Actions(driver);
      builder.MoveToElement(element, 0, 0).Perform();
    }
    driver.FindElement(By.CssSelector(".si-overlay")).Click();
    driver.FindElement(By.CssSelector(".btn-secondary > span")).Click();
  }
}
 
    }
