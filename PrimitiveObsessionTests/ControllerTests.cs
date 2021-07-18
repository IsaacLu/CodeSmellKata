using NUnit.Framework;
using PrimitiveObsession;

namespace PrimitiveObsessionTests
{
	public class ControllerTests
	{
		[Test]
		public void Login_When_Enter_Wrong_Currency_Length_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWDA",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Username_Length_Lower_Than_6_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "code1",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Username_Length_Greater_Than_20_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry123123666",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Referral_Length_Lower_Than_6_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmell",
				Password = "codesmellTry123123666",
				Referral = "nices",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Referral_Length_Greater_Than_20_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmell",
				Password = "codesmellTry123123666",
				Referral = "codesmellTry123123666",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Email_Dont_Have_At_Symbol_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmellsmell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Email_Have_More_Than_One_At_Symbol_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell@.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Empty_FirstName_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_Empty_LastName_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "smellBad",
				LastName = "",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Enter_FirstName_Equals_LastName_Should_Return_Error()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "smellBad",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(1, actual);
		}

		[Test]
		public void Login_When_Ip_Was_LocalHost_And_CountryCode_Should_Be_TW()
		{
			var target = new MemberService();
			var request = new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			};
			target.UserRegister(request);
			Assert.AreEqual("TW", request.CountryCode);
		}

		[Test]
		public void Login_When_Ip_Was_Not_LocalHost_And_CountryCode_Should_Be_MY()
		{
			var target = new MemberService();
			var request = new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "129.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			};
			target.UserRegister(request);
			Assert.AreEqual("MY", request.CountryCode);
		}

		[Test]
		public void Login_When_EveryThing_Correct_Then_Response_ErrorCode_Equals_0()
		{
			var target = new MemberService();
			var actual = target.UserRegister(new UserRegisterRequest()
			{
				Currency = "TWD",
				Email = "codesmell@smell.com",
				Ip = "127.0.0.1",
				LoginUrl = "www.codesmellhello.io",
				Username = "codesmellTry",
				Password = "codesmellTry123123666",
				Referral = "nicesmellTry",
				FirstName = "codesmell",
				LastName = "smellBad",
				WebId = 18763
			}).ErrorCode;
			Assert.AreEqual(0, actual);
		}
	}
}