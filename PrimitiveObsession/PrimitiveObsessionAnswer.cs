using System.Linq;

namespace PrimitiveObsessionFake
{
	internal class PrimitiveObsessionAnswer
	{
		internal static void MainAnswer(string[] args)
		{
		}
	}

	public class MemberService
	{
		public UserRegisterResponse UserRegister(UserRegisterRequest req)
		{
			if (!(req.Username.Length >= 6 && req.Username.Length <= 20))
			{
				return new UserRegisterResponse(1);
			}

			if (!(req.Password.Length >= 20 && req.Password.Length <= 25))
			{
				return new UserRegisterResponse(1);
			}

			if (!(req.Currency.Length == 3))
			{
				return new UserRegisterResponse(1);
			}

			if (!(req.Referral.Length >= 6 && req.Referral.Length <= 20))
			{
				return new UserRegisterResponse(1);
			}

			if (!(req.Email.Count(w => w == '@')==1))
			{
				return new UserRegisterResponse(1);
			}

			if (!(!string.IsNullOrEmpty(req.FirstName) && !string.IsNullOrEmpty(req.LastName)&& req.FirstName != req.LastName))
			{
				return new UserRegisterResponse(1);
			}

			req.CountryCode = GetCountryCodeByIp(req.Ip);

			if (!((req.Currency == "TWD" && req.CountryCode == "TW") || (req.Currency == "MYR" && req.CountryCode == "MY")))
			{
				return new UserRegisterResponse(1);
			}

			return new UserRegisterResponse(0);
		}

		private string GetCountryCodeByIp(string ip)
		{
			return (ip=="127.0.0.1")?"TW":"MY";
		}

		public UserLoginResponse UserLogin(UserLoginRequest req)
		{
			const string currencyFromDb = "TWD";

			if (!(req.Username.Length >= 6 && req.Username.Length <= 20))
			{
				return new UserLoginResponse(1);
			}

			if (!(req.Username.Length >= 20 && req.Username.Length <= 25))
			{
				return new UserLoginResponse(1);
			}
			req.CountryCode = GetCountryCodeByIp(req.Ip);

			if (!(currencyFromDb == "TWD" && req.CountryCode == "TW" || currencyFromDb == "MYR" && req.CountryCode == "MY"))
			{
				return new UserLoginResponse(1);
			}

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
		public string CountryCode { get; set; }
		public string Ip { get; set; }
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


	//問題 : 這不就是差在方法寫在哪邊的差異而已嗎?

	//對，可以想像一下，在實際開發的情境當中，因為基礎型別的關係，每個人可以自由選擇用甚麼方法得到答案
	//當然你也可以透過團隊規範來規範這個，但有可能規範不完，URL 用 extension method, 那 email 呢?
	//而當有人選擇第一種方法，判斷寫在該使用的地方，不能重複使用的情況下，會不會在別的類別或方法當中也要相同的判斷呢?
	//最終，很容易演變成 code smell : Duplicate Code, Alternative Classes with Different Interfaces
	//當你用 string 接 URL 的那瞬間，你已經失去了對他的部件存取的權力了，當然你也可以把它放回預設物件 Uri 啦!

	//URL 你可能還需要對她進行操作，但是為了方便，就用 string 先接了，對我來說 Primitive Obsession 就是在過高的層級使用過基礎的型別了

	//這次的練習，如果要避免 primitive obsession. 可以單純的使用預設類別 Uri
	//幾個問題可以想想看
	//萬一你要寫的東西沒有前人呢? 你會怎麼寫
	//當然，前面的練習有提到了一些方法
	//我覺得有一個關鍵點是在於，你是不是比要使用的地方之前還要早就把目標物裝進去非基礎型別
	//如果是 API 街口，或許在最一開始接到參數的時候就已經成為具有"自我檢查機制"的物件裡面了
	//https://hwchw.medium.com/codesmell-primitive-obsession-f0aab6f0aabb
}