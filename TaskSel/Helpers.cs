using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TaskSel
{
	public class Helpers
	{
		public static IWebDriver Driver { get; private set; }
		private static WebDriverWait wait;

		private static readonly string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		private static readonly string ScreenshotsDir = $"{BaseDirectory}/Screenshots/";

		[SetUp]
		public void SetUpWebDriver()
		{
			Driver = CreateChromeDriver();			
		}

		[TearDown]
		public void Cleanup()
		{
			if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
			{
				TakeScreenShot();
			}
				Driver.Quit();
		}

		private IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-popup-blocking");
            options.AddUserProfilePreference("disable-popup-blocking", "true");

            Driver = new ChromeDriver(options);
			wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));

			return Driver;
        }

		public void TakeScreenShot()
		{
			string filename = TestContext.CurrentContext.Test.Name;
			Directory.CreateDirectory(ScreenshotsDir);

			ITakesScreenshot screenShotDriver = (ITakesScreenshot)Driver;
			Screenshot screenShot = screenShotDriver.GetScreenshot();
			
			screenShot.SaveAsFile($"{ScreenshotsDir}{filename}.png", ScreenshotImageFormat.Png);
		}

		public void NavigateElementClick(IWebElement element)
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(element)).Click();
		}

		public void NavigateTo(string url)
		{
			Driver.Navigate().GoToUrl(url);
			TryConsentConfirmation();
		}

		public void TryConsentConfirmation()
		{
			var _nav = new PageObjectNavigation();
			try
			{
				wait.Until(ExpectedConditions.ElementToBeClickable(_nav.AcceptCookiesBtn)).Click();
				wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@role='alertdialog' and @style='top: 0px; display: none;']")));
			}
			catch (WebDriverTimeoutException)
			{ 
			}
		}
	}
}
