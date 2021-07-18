namespace PrimitiveObsession
{
	internal class PrimitiveObsessionPractice
	{
		internal static void Main(string[] args)
		{
		}
	}

	public class MemberService
	{
		public UserRegisterResponse UserRegister(UserRegisterRequest req)
		{
			//請嘗試驗證:使用者名稱(Username)長度需要於 6-20 碼之間
			//代碼寫這

			//請嘗試驗證:使用者密碼(Password)長度需要於 20-25 碼之間
			//代碼寫這

			//請嘗試驗證:貨幣(Currency)必須要是三個字元(e.g. TWD), 而且只能支援 TWD, MYR
			//代碼寫這

			//請嘗試驗證:介紹人(Referral) 名稱長度需要於 6-14 碼之間
			//代碼寫這

			//請嘗試驗證:電子信箱(Email) 必須且只能有 1 個 @ 符號
			//代碼寫這

			//請嘗試驗證:FirstName 不能等於 LastName 且兩者都不能為空字串
			//代碼寫這

			//請嘗試將 ip 換成地區，並且將地區指定到 UserRegisterRequest.CountryCode
			//因為不是主要目的，所以簡單一些，ip = 127.0.0.1 = "TW" 其他就設定為"MY" 

			//請嘗試驗證:地區必須要符合貨幣 MYR 只能在 MY 使用, TWD 只能在 TW 使用
			//代碼寫這

			//以上如果有驗證沒通過都回傳  new UserRegisterResponse(1);

			return new UserRegisterResponse(0);
		}

		public UserLoginResponse UserLogin(UserLoginRequest req)
		{
			//Step1 請嘗試驗證:使用者名稱(Username)長度需要於 6-20 碼之間
			//代碼寫這

			//Step2 請嘗試驗證:使用者密碼(Password)長度需要於 20-25 碼之間
			//代碼寫這

			//請嘗試將 ip 換成地區，並且將地區指定到 UserLoginRequest.CountryCode

			//請嘗試驗證:地區必須要符合貨幣 MYR 只能在 MY 使用, TWD 只能在 TW 使用
			//代碼寫這

			return new UserLoginResponse(0);
		}
	}

	public class UserLoginResponse
	{
		public int ErrorCode { get; }
		public UserLoginResponse(int errorCode)
		{
			ErrorCode = errorCode;
		}
	}

	public class UserLoginRequest
	{
		public int WebId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}

	public class UserRegisterRequest
	{
		public int WebId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Currency { get; set; }
		public string Referral { get; set; }
		public string Ip { get; set; }
		public string LoginUrl { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CountryCode { get; set; }
	}

	public class UserRegisterResponse
	{
		public int ErrorCode { get; }
		public UserRegisterResponse(int errorCode)
		{
			ErrorCode = errorCode;
		}
		public string Username { get; set; }
		public string LoginName { get; set; }
		public int CustomerId { get; set; }
		public int ParentId { get; set; }
		public string Currency { get; set; }
		public decimal Points { get; set; }
		public long OnlineId { get; set; }
		public int AccountType { get; set; }
	}

}