using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TaskSel
{
	public class PageObjectNavigation : Helpers
	{
		private readonly IWebDriver driver;

		[FindsBy(How = How.CssSelector, Using = "button[class='optanon-allow-all accept-cookies-button']")]
		public IWebElement AcceptCookiesBtn { get; private set; }

		[FindsBy(How = How.CssSelector, Using = "[href='/par-if']")]
		public IWebElement AboutSection { get; private set; }

		[FindsBy(How = How.CssSelector, Using = "#main-navigation > li > a[href='/par-if/darbs-if']")]
		public IWebElement WorkForSection { get; private set; }

		[FindsBy(How = How.CssSelector, Using = "[href='/par-if/darbs-if/vakances']")]
		public IWebElement Vacancies { get; private set; }

		[FindsBy(How = How.CssSelector, Using = "[href='/par-if/darbs-if/vakances/QA-test-automation-specialist']")]
		public IWebElement DesiredVacancyInOverview { get; private set; }

		[FindsBy(How = How.CssSelector, Using = "h1[class='if heading large']")]
		public IWebElement VacHeading { get; private set; }

		public PageObjectNavigation()
		{
			this.driver = Driver;
			PageFactory.InitElements(driver, this);
		}
	}
}
