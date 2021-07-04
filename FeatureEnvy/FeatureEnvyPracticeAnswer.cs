using System;

namespace FeatureEnvyAnswer
{
	class FeatureEnvyPractice
	{
		static void MainAnswer()
		{
			var user = new Member(new ValidationHelper());
			Console.WriteLine($"Is Member Login Succeed : {user.Login("eric","xxxyyyzzzz", "email@email.com", "127.0.0.1")}");
		}
	}
	public class ValidationHelper
	{
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

		public bool IsValidMemberInformation(string username, string password, string email, string ip)
		{
			var isValidUsername = IsValidUsername(username);
			var isValidPassword = IsValidPassword(password);
			var isValidEmail = IsValidEmail(email);
			var isValidLocation = IsValidLocation(ip);
			var isCorrectPassword = IsCorrectPassword(password);
			return isValidUsername && isValidPassword && isValidEmail && isValidLocation && isCorrectPassword;
		}
	}
	public class Member
	{
		private readonly ValidationHelper _validationHelper;

		public Member(ValidationHelper validationHelper)
		{
			_validationHelper = validationHelper;
		}
		public bool Login(string username, string password, string email, string ip)
		{
			return _validationHelper.IsValidMemberInformation(username, password, email, ip);
		}

	}
}
