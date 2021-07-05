using System;

namespace FeatureEnvyAnswer1
{
	class FeatureEnvyPractice
	{
		static void MainAnswer()
		{
			var user = new Member()
			{
				Username = "eric",
				Password = "xxxyyyzzzz",
				Email = "email@email.com",
				Ip = "127.0.0.1"
			};
			Console.WriteLine($"Is Member Login Succeed : {user.Login()}");
		}
	}
	public class ValidationHelper
	{
	
	}
	public class Member
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Ip { get; set; }

		public bool Login()
		{
			return IsValidMemberInformation();
		}

		public bool IsValidUsername(string username)
		{
			return true;
		}

		public bool IsValidPassword(string password)
		{
			return true;
		}

		public bool IsValidEmail(string email)
		{
			return true;
		}
		public bool IsValidLocation(string ip)
		{
			return true;
		}
		public bool IsCorrectPassword(string password)
		{
			return true;
		}

		public bool IsValidMemberInformation()
		{
			return IsValidUsername(Username) && IsValidPassword(Password) && IsValidEmail(Email) && IsValidLocation(Ip) && IsCorrectPassword(Password);
		}

	}
}
