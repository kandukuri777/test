using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.ComponentHelper;

namespace SeleniumWebdriver.BaseClasses
{
    public class PageBase
    {
        private IWebDriver driver;

        [FindsBy(How = How.LinkText,Using = "Home")]
        private IWebElement HomeLink;
        //private IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));

        public PageBase(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver,this);
            this.driver = _driver;
        }

        protected void NaviGateToHomePage()
        {
            HomeLink.Click();
        }

        public string Title
        {
            get { return driver.Title; }
        }
    }
}
