using System;

namespace FeatureEnvy
{
	class FeatureEnvyPractice
	{
		static void Main()
		{
			var user = new User(new ValidationHelper());
			Console.WriteLine($"Is User Login Succeed : {user.Login("eric","xxxyyyzzzz", "email@email.com", "127.0.0.1")}");
		}

		public class ValidationHelper
		{
			public bool IsValidUsername(string username)
			{
				return true;
			}

			public bool IsValidPassword(string password)
			{
				return false;
			}

			public bool IsValidEmail(string email)
			{
				return false;
			}
			public bool IsValidLocation(string ip)
			{
				return false;
			}
			public bool IsCorrectPassword(string password)
			{
				return false;
			}
		}

		public class User
		{
			private readonly ValidationHelper _validationHelper;

			public User(ValidationHelper validationHelper)
			{
				 _validationHelper = validationHelper;
			}
			public bool Login(string username, string password, string email, string ip)
			{
				var isValidUsername = _validationHelper.IsValidUsername(username);
				var isValidPassword = _validationHelper.IsValidPassword(password);
				var isValidEmail = _validationHelper.IsValidEmail(email);
				var isValidLocation = _validationHelper.IsValidLocation(ip);
				var isCorrectPassword = _validationHelper.IsCorrectPassword(password);
				//我們可以看到這個 User Class 大部分都是在呼叫另一個 Helper Class 來進行驗證
				//這個 Class 超過一半以上的行為都在存取另一個 Class 提供的 Feature 這邊也可以說是對外方法
				//當然這很有可能是結合了 CodeSmell:PrimitiveObsession 的結果
				//如果是你，你會怎麼改呢? 請先跑測試，確保綠燈後再開始更動
				//這次的練習，你可以更動測試的內容
				return isValidUsername && isValidPassword && isValidEmail && isValidLocation && isCorrectPassword;
			}

		}
	}
}
