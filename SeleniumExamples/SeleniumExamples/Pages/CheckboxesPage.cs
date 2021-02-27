﻿using OpenQA.Selenium;

namespace SeleniumExamples.Pages
{
    public sealed class CheckboxesPage : WebPage, IPageNavigation
    {
        public CheckboxesPage(IWebDriver driver) : base(driver) { }

        public void NavigateToPage()
        {
            NavigateToURL(ConfigReader.Index + ConfigReader.Checkboxes);
        }
        
        private IWebElement Checkbox1 =>
            Driver.FindElement(By.CssSelector("input:nth-child(1)"));

        private IWebElement Checkbox2 =>
            Driver.FindElement(By.CssSelector("input:nth-child(3)"));

        public bool IsCheckBoxTicked(int id)
        {
            return (id == 1) ? Checkbox1.Selected : Checkbox2.Selected;
        }

        public void ClickCheckBox(int id)
        {
            if (id == 1)
            {
                Checkbox1.Click();
            }
            else
            {
                Checkbox2.Click();
            }
        }
    }
}
