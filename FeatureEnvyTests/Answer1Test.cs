using FeatureEnvyAnswer1;
using NUnit.Framework;

namespace FeatureEnvyTestsAnswer1
{
	public class PracticeTest
	{
		[Test]
		public void LoginTest()
		{
			var user = new Member()
			{
				Username = "eric",
				Password = "xxxyyyzzzz",
				Email = "email@email.com",
				Ip = "127.0.0.1"
			};
			var actual = user.Login();
			Assert.AreEqual(true, actual);
		}
	}
}