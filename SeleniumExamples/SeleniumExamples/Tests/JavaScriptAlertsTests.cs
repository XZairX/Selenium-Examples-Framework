﻿using NUnit.Framework;
using SeleniumExamples.Pages;

namespace SeleniumExamples
{
    [TestFixture]
    public class JavaScriptAlertsTests
    {
        private WebsitePOM _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new WebsitePOM();

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void JSAlertButton_OKButton_UpdatesResultMessage()
        {
            _sut.NavigateToJavaScriptAlertsPage();

            _sut.JavaScriptAlertsPage.ClickJSAlertButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test]
        public void JSConfirmButton_CancelButton_UpdatesResultMessage()
        {
            _sut.NavigateToJavaScriptAlertsPage();

            _sut.JavaScriptAlertsPage.ClickJSConfirmButton();
            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You clicked: Cancel"));
        }

        [Test]
        public void JSConfirmButton_OKButton_UpdatesResultMessage()
        {
            _sut.NavigateToJavaScriptAlertsPage();

            _sut.JavaScriptAlertsPage.ClickJSConfirmButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You clicked: Ok"));
        }

        [Test]
        public void JSPromptButton_CancelButton_UpdatesResultMessage()
        {
            _sut.NavigateToJavaScriptAlertsPage();

            _sut.JavaScriptAlertsPage.ClickJSPromptButton();
            _sut.SharedIAlert.ClickCancelButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You entered: null"));
        }

        [Test]
        public void JSPromptButton_OKButton_UpdatesResultMessage()
        {
            _sut.NavigateToJavaScriptAlertsPage();

            _sut.JavaScriptAlertsPage.ClickJSPromptButton();
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You entered:"));
        }

        [Test]
        public void JSPromptButton_InputIsNotPurelyWhitespacesAndOKButton_UpdatesResultMessageWithSingleWhitespaceReplacingInputWhitespaces()
        {
            _sut.NavigateToJavaScriptAlertsPage();

            _sut.JavaScriptAlertsPage.ClickJSPromptButton();
            _sut.SharedIAlert.EnterInformation(" i  np  u  t  1 ");
            _sut.SharedIAlert.ClickOKButton();
            var result = _sut.JavaScriptAlertsPage.ReadResultText();

            Assert.That(result, Is.EqualTo("You entered: i np u t 1"));
        }
    }
}
