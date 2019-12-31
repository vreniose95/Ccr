using System;

namespace Ccr.Html.Attributes.Extensions
{
	public static class EnumExtensions
	{
		public static string LiteralValue(
			this Enum enumValue)
		{
			return enumValue.ToString("f")
				.ToLowerInvariant();
		}

		public static string LiteralValue(
			this Charset charset)
		{
			switch (charset)
			{
				case Charset.UNKNOWN:
					return "UNKNOWN";
				case Charset.ASCII:
					return "ASCII";
				case Charset.ANSI:
					return "ANSI";
				case Charset.UTF_8:
					return "UTF-8";
				case Charset.ISO_8859_1:
					return "ISO-8859-1";
				case Charset.ISO_8859_8:
					return "ISO-8859-1";
				default:
					throw new ArgumentException();
			}
		}

		public static string LiteralValue(
			this Crossorigin crossorigin)
		{
			switch (crossorigin)
			{
				case Crossorigin.Anonymous:
					return "anonymous";
				case Crossorigin.UseCredentials:
					return "use-credentials";
				default:
					throw new ArgumentException();
			}
		}

		public static string LiteralValue(
			this EncType enctype)
		{
			switch (enctype)
			{
				case EncType.Application_X_WWW:
					return "application/x-www-form-urlencoded";
				case EncType.Multipart_Form_Data:
					return "multipart/form-data";
				case EncType.Plaintext:
					return "text/plain";
				default:
					throw new ArgumentException();
			}
		}

		public static string LiteralValue(
			this HttpEquiv httpEquiv)
		{
			switch (httpEquiv)
			{
				case HttpEquiv.ContentType:
					return "content-type";
				case HttpEquiv.DefaultStyle:
					return "default-style";
				case HttpEquiv.Refresh:
					return "refresh";
				default:
					throw new ArgumentException();
			}
		}

		public static string LiteralValue(
			this Name name)
		{
			switch (name)
			{
				case Name.ApplicationName:
					return "application-name";
				case Name.Author:
					return "author";
				case Name.Description:
					return "description";
				case Name.Generator:
					return "generator";
				case Name.Keywords:
					return "keywords";
				case Name.Viewport:
					return "viewport";
				default:
					throw new ArgumentException();
			}
		}

		public static string LiteralValue(
			this Sandbox sandbox)
		{
			switch (sandbox)
			{
				case Sandbox.AllowForms:
					return "allow-forms";
				case Sandbox.AllowPointerLock:
					return "allow-pointer-lock";
				case Sandbox.AllowPopups:
					return "allow-popups";
				case Sandbox.AllowSameOrigin:
					return "allow-same-origin";
				case Sandbox.AllowScripts:
					return "allow-scripts";
				case Sandbox.AllowTopNavigation:
					return "allow-top-navigation";
				default:
					throw new ArgumentException();
			}
		}
	}
}
