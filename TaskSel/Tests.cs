using NUnit.Framework;


namespace TaskSel
{
	public class Tests : Helpers
	{
		const string LandingUrl = "https://if.lv";

		[Test]
		public void AssertVacancyName()
		{
			string ExpectedHeading = "Quality Assurance/Test Automation Specialist";
			var _nav = new PageObjectNavigation();
			NavigateTo(LandingUrl);
			
			NavigateElementClick(_nav.AboutSection);
			NavigateElementClick(_nav.WorkForSection);
			NavigateElementClick(_nav.Vacancies);
			NavigateElementClick(_nav.DesiredVacancyInOverview);

			Assert.AreEqual(ExpectedHeading, _nav.VacHeading.Text);
		}
	}
}
