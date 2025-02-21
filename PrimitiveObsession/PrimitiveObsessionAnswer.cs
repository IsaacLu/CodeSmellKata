﻿using System;
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
			if (!req.User.IsValidateSuccess())
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
			if (!req.User.IsValidateSuccess())
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


		public ChangeUserPasswordRequestResponse ChangeUserPassword(ChangeUserPasswordRequest req)
		{
			if (!req.IsValidateSuccess())
			{
				return new ChangeUserPasswordRequestResponse(1);
			}

			return new ChangeUserPasswordRequestResponse(0);
		}
	}

	public class Member
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public bool IsValidateSuccess()
		{
			return IsValidUsername() && IsValidPassword();
		}

		private bool IsValidUsername()
		{
			return Username.Length >= 6 && Username.Length <= 20;
		}
		private bool IsValidPassword()
		{
			return Password.Length >= 20 && Password.Length <= 25;
		}
	}

	public class ChangeUserPasswordRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string NewPassword { get; set; }

		public bool IsValidateSuccess()
		{
			if (!(Username.Length >= 6 && Username.Length <= 20))
			{
				return false;
			}

			if (!(Password.Length >= 20 && Password.Length <= 25))
			{
				return false;
			}

			if (!(NewPassword.Length >= 20 && NewPassword.Length <= 25))
			{
				return false;
			}
			return true;
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

	public class ChangeUserPasswordRequestResponse
	{
		public int ErrorCode { get; }
		public ChangeUserPasswordRequestResponse(int errorCode)
		{
			ErrorCode = errorCode;
		}
	}

	public class UserLoginRequest
	{
		public int WebId { get; set; }
		public Member User { get; set; }
		public string CountryCode { get; set; }
		public string Ip { get; set; }
	}

	public class UserRegisterRequest
	{
		public int WebId { get; set; }
		public Member User { get; set; }
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


	//https://hwchw.medium.com/codesmell-primitive-obsession-f0aab6f0aabb
}