using FeatureEnvyAnswer;
using NUnit.Framework;

namespace FeatureEnvyTestsAnswer
{
	public class PracticeTest
	{
		[Test]
		public void LoginTest()
		{
			var member = new Member(new ValidationHelper());
			var actual = member.Login("eric", "xxxyyyzzzz", "email@email.com", "127.0.0.1");
			Assert.AreEqual(true, actual);
		}
	}
}