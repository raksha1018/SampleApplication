using System;
using UrlHelper;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DataAccessLayer.Routing.UrlHelperStartup), "Start")]
namespace DataAccessLayer.Routing
{
	public static class UrlHelperStartup
	{
		public static void Start()
		{
			UrlManager<AppUrls>.Initialize();
		}
	}
}