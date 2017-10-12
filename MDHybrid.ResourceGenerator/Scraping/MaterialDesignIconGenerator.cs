using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ccr.Core.Extensions;
using Newtonsoft.Json.Linq;

namespace MDHybrid.ResourceGenerator.Scraping
{
	public class MaterialDesignIconGenerator
	{
		private const string _apiPath = 
			"https://materialdesignicons.com/api/package/38EF63D0-4744-11E4-B3CF-842B2B6CFE1B";

		public void Run()
		{
			var iconData = GetSourceData();
			var nameDataPairs = GetNameDataPairs(iconData);

		}

		private static string GetSourceData()
		{
			var webRequest = WebRequest.CreateDefault(
				new Uri(_apiPath));

			webRequest.Credentials = CredentialCache.DefaultCredentials;

			if (webRequest.Proxy != null)
				webRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;

			using (var responseStream = webRequest.GetResponse().GetResponseStream())
			{
				if(responseStream == null)
					throw new NullReferenceException();

				using (var streamReader = new StreamReader(responseStream))
				{
					return streamReader.ReadToEnd();
				}
			}
			
		}

		private static IEnumerable<(string name, string data)> GetNameDataPairs(string sourceData)
		{
			var jObject = JObject.Parse(sourceData);
			var dataPairs = jObject["icons"]
				.Select(
					t => (
						name: t["name"]
							.ToString()
							.Underscore()
							.ToPascalCase(),
						data: t["data"]
							.ToString()));

			return dataPairs;
		}

		//private string UpdateDataFactory(
		//	string sourceFile,
		//	IEnumerable<(string name, string data)> nameDataPairs)
		//{
		//	var sourceText = SourceText
		//}
	}
}
