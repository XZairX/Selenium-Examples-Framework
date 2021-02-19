﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumExamples.Pages
{
    public class WebsitePOM
    {
        public WebsitePOM(int elementWaitTime = 0, int pageWaitTime = 0)
        {
            Driver = new DriverConfig(elementWaitTime, pageWaitTime).Driver;
            IndexPage = new IndexPage(Driver);
            AddRemovePage = new AddRemovePage(Driver);
            FormAuthenticationPage = new FormAuthenticationPage(Driver);
        }
        
        public FirefoxDriver Driver { get; private set; }

        public IndexPage IndexPage { get; private set; }

        public AddRemovePage AddRemovePage { get; private set; }

        public FormAuthenticationPage FormAuthenticationPage { get; private set; }

        public void NavigateToPage(string url) => Driver.Navigate().GoToUrl(url);

        public void NavigateToIndexPage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
        }

        public void NavigateToAddRemovePage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.AddRemoveElements);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
        }

        public void NavigateToFormAuthenticationPage()
        {
            //Driver.Navigate().GoToUrl(ConfigReader.Index + ConfigReader.FormAuthetication);
            Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
        }

        public void CloseDriver() => Driver.Quit();
    }
}