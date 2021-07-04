namespace PrimitiveObsession.Model
{
	public class UserLoginResponse
	{
		public UserLoginResponse(int errorCode)
		{
			ErrorCode = errorCode;
		}
		public int ErrorCode { get;}
	}
}