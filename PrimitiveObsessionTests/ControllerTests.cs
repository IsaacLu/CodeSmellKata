using NUnit.Framework;
using PrimitiveObsession;

namespace PrimitiveObsessionTests
{
	public class ControllerTests
	{
		private const string targetUrl = "https://www.github.com/hwchw/CodeSmellKata";

		[Test]
		public void When_Login_Should_Return_ErrorCode_0()
		{
			var target = new Controller();
			var actual = target.Login("", targetUrl).ErrorCode;
			Assert.AreEqual(0, actual);
		}

		[Test]
		public void When_Login1_Should_Return_ErrorCode_0()
		{
			var target = new Controller();
			var actual = target.Login1("", targetUrl).ErrorCode;
			Assert.AreEqual(0, actual);
		}

		[Test]
		public void When_Login2_Should_Return_ErrorCode_0()
		{
			var target = new Controller();
			var actual = target.Login2("", targetUrl).ErrorCode;
			Assert.AreEqual(0, actual);
		}
	}
}