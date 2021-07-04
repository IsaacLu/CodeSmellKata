using PrimitiveObsession.Model;

namespace PrimitiveObsession
{
	internal class PrimitiveObsessionPractice
	{
		internal static void Main(string[] args)
		{
			//
			//這個練習，主要是在練習如果一開始就用基礎型別接，那後續會產生的影響
			//簡單說就是體驗 CodeSmell: PrimitiveObsession
			//
		}
	}

	public class Controller
	{
		public UserLoginResponse Login(string user, string loginFrom)
		{
			//請嘗試不使用預設物件
			//var tryNotToUseThisWay= new Uri(url);

			return GetProtocol(loginFrom) == "https" || GetSubDomain(loginFrom) == "www"
				? new UserLoginResponse(0)
				: new UserLoginResponse(1);
		}
		public UserLoginResponse Login1(string user, string loginFrom)
		{
			//請嘗試不使用預設物件
			//var tryNotToUseThisWay= new Uri(url);
			//Step 3-1: 如果不用在這個 Class 當中的方法，請寫下，或想想看還有哪些方法可以用，或是那些位置可以放
			return new UserLoginResponse(0);
		}
		public UserLoginResponse Login2(string user, string loginFrom)
		{
			//請嘗試不使用預設物件
			//var tryNotToUseThisWay= new Uri(url);

			//Step 3-2: 如果不用在這個 Class 當中的方法，請寫下，或想想看還有哪些方法可以用，或是那些位置可以放
			return new UserLoginResponse(0);
		}

		public static string GetProtocol(string url)
		{
			// Step 1: 嘗試透過解析 targetUrl 來拿到 Protocol 並且把 https 更換成你解析出的結果後跑看看結果
			return "https";
		}

		public string GetSubDomain(string url)
		{
			//Step 2: 嘗試透過解析 targetUrl 來拿到 SubDomain 並且把 www 更換成你解析出的結果後跑看看結果
			return "www";
		}

		//Step 4: 想想看，這時候如果你還想要在 Login 時，驗證 loginFrom 是不是一個有效的 URL ，你會怎麼寫呢?
	}
}