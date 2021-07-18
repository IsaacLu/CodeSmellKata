using NUnit.Framework;
using PrimitiveObsession;

namespace PrimitiveObsessionTests
{
	public class ControllerTests
	{
		[Test]
		public void When_Login_Should_Return_ErrorCode_0()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry123123123",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry123123",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(0, actual);
		}
	}
}