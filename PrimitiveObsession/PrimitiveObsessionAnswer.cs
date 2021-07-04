using PrimitiveObsession.Model;

namespace PrimitiveObsession
{
	internal class PrimitiveObsessionAnswer
	{
		internal static void FakeMain(string[] args)
		{
		}
	}

	public class FakeController
	{
		public UserLoginResponse Login(string user, string loginFrom)
		{
			//方法 1: 在同一處建立方法得到答案
			return GetProtocol(loginFrom) == "https" && GetSubDomain(loginFrom) == "www"
				? new UserLoginResponse(0)
				: new UserLoginResponse(1);
		}

		public UserLoginResponse Login1(string user, string loginFrom)
		{
			//方法 2: 利用擴充方法得到答案
			return loginFrom.GetProtocolByExtensionMethod() == "https" && loginFrom.GetSubDomainByExtensionMethod() == "www"
				? new UserLoginResponse(0)
				: new UserLoginResponse(1);
		}

		public UserLoginResponse Login2(string user, string loginFrom)
		{
			//方法 3: 利用自創幫手類別，方法寫在這個當中得到答案
			return UrlHelperClass.GetProtocolByHelperClass(loginFrom) == "https" || UrlHelperClass.GetSubDomainByHelperClass(loginFrom) == "www"
				? new UserLoginResponse(0)
				: new UserLoginResponse(1);
		}

		public static string GetProtocol(string url)
		{
			return url.Split(':')[0]; ;
		}

		public string GetSubDomain(string url)
		{
			return url.Split('.')[0].Split('/')[2];
		}
	}

	internal static class UrlHelper
	{
		internal static string GetProtocolByExtensionMethod(this string url)
		{
			return url.Split(':')[0];
		}

		internal static string GetSubDomainByExtensionMethod(this string url)
		{
			return url.Split('.')[0].Split('/')[2];
		}
	}

	internal static class UrlHelperClass
	{
		internal static string GetProtocolByHelperClass(string url)
		{
			return url.Split(':')[0];
		}

		internal static string GetSubDomainByHelperClass(string url)
		{
			return url.Split('.')[0].Split('/')[2];
		}
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