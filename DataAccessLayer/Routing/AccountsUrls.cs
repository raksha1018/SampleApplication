using System;
using UrlHelper;

namespace DataAccessLayer.Routing
{
	public class AccountsUrls : UrlsBase
	{
		public Uri Login()
		{
			var rvd = Action("Login");
			/* example of adding a parameter -> rvd["id"] = "123"; */
			return ToUri(rvd);
		}
	}
}