﻿using NUnit.Framework;
using SeleniumHerokuapp.Pages;

namespace SeleniumHerokuapp.Tests
{
    using static DropdownPage;

    [TestFixture]
    public class DropdownTests
    {
        private PageFactory _sut;

        [OneTimeSetUp]
        public void OneTimeSetUp() => _sut = new PageFactory(StaticDriver.Type);

        [OneTimeTearDown]
        public void OneTimeTearDown() => _sut.CloseDriver();

        [Test]
        public void DefaultSelection_DoesNotSelectAnyOptionsFromTheDropdownList()
        {
            _sut.DropdownPage.NavigateToPage();

            var result = _sut.DropdownPage.ReadDropdownText();

            Assert.That(result, Is.EqualTo("Please select an option"));
        }

        [TestCase(DropdownID.Option1)]
        [TestCase(DropdownID.Option2)]
        public void ClickDropdownOption_OptionId_SelectsOptionIdFromTheDropdownList(
            DropdownID dropdownID)
        {
            _sut.DropdownPage.NavigateToPage();

            _sut.DropdownPage.ClickDropdownOption(dropdownID);
            var result = _sut.DropdownPage.ReadDropdownText();

            Assert.That(result, Is.EqualTo("Option " + (int)dropdownID));
        }
    }
}
