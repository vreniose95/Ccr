using System;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Ccr.PresentationCore.Media.Metadata
{
	public class AudioShellObject
		: ShellRefObject
	{
		public static ShellRefProperty<TimeSpan> DurationProperty =
			SRP.Register<AudioShellObject, long, TimeSpan>(
				SystemProperties.System.Media.Duration,
				r => TimeSpan.FromSeconds(r / 10000000d),
				v => (long)Math.Round(v.TotalSeconds * 10000000d));


		public static ShellRefProperty<uint> AudioChannelCountProperty =
			SRP.Register<AudioShellObject, uint>(
				SystemProperties.System.Audio.ChannelCount);


		public static ShellRefProperty<double> AudioEncodingBitrateProperty =
			SRP.Register<AudioShellObject, uint, double>(
				SystemProperties.System.Media.Duration,
				r => r / 1000d,
				v => (uint)Math.Round(v * 1000d));


		public static ShellRefProperty<string> EncodingSettingsProperty =
			SRP.Register<AudioShellObject, string>(
				SystemProperties.System.Media.EncodingSettings);


		public static ShellRefProperty<double> AudioSampleRateProperty =
			SRP.Register<AudioShellObject, uint, double>(
				SystemProperties.System.Audio.SampleRate,
				r => r / 1000d,
				v => (uint)Math.Round(v * 1000d));


		public static ShellRefProperty<DateTime> DateEncodedProperty =
			SRP.Register<AudioShellObject, DateTime>(
				SystemProperties.System.Media.DateEncoded);


		public static ShellRefProperty<string[]> ContributingArtistsProperty =
			SRP.Register<AudioShellObject, string[]>(
				SystemProperties.System.Music.Artist);


		

		public TimeSpan Duration
		{
			get => DurationProperty.GetValueBase(this);
			set => DurationProperty.SetValueBase(this, value);
		}
		public uint AudioChannelCount
		{
			get => AudioChannelCountProperty.GetValueBase(this);
			set => AudioChannelCountProperty.SetValueBase(this, value);
		}
		public double AudioEncodingBitrate
		{
			get => AudioEncodingBitrateProperty.GetValueBase(this);
			set => AudioEncodingBitrateProperty.SetValueBase(this, value);
		}
		public string EncodingSettings
		{
			get => EncodingSettingsProperty.GetValueBase(this);
			set => EncodingSettingsProperty.SetValueBase(this, value);
		}
		public double AudioSampleRate
		{
			get => AudioSampleRateProperty.GetValueBase(this);
			set => AudioSampleRateProperty.SetValueBase(this, value);
		}
		public DateTime DateEncoded
		{
			get => DateEncodedProperty.GetValueBase(this);
			set => DateEncodedProperty.SetValueBase(this, value);
		}
		public string[] ContributingArtists
		{
			get => ContributingArtistsProperty.GetValueBase(this);
			set => ContributingArtistsProperty.SetValueBase(this, value);
		}

		
		public AudioShellObject(
			FileInfo fileInfo) : base(
				fileInfo)
		{
		}

	}
}
#region old
//SystemProperties.System.Audio.EncodingBitrate

///// <summary>
///// Gets the duration of the video as a TimeSpan object
///// </summary>
//public TimeSpan Duration
//{
//	get
//	{
//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
//			SystemProperties.System.Media.Duration));
//		var _100nsUnits = long.Parse(_rawValue);
//		var _seconds = _100nsUnits / 10000000d;
//		return TimeSpan.FromSeconds(_seconds);
//	}
//}

///// <summary>
///// Gets the encoding settings of the video
///// </summary>
//public string EncodingSettings
//{
//	get
//	{
//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
//			SystemProperties.System.Media.EncodingSettings));
//		return _rawValue;
//	}
//}

///// <summary>
///// Gets the number of audio channels in the video
///// </summary>
//public uint AudioChannels
//{
//	get
//	{
//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
//			SystemProperties.System.Audio.ChannelCount));
//		return uint.Parse(_rawValue);
//	}
//}

///// <summary>
///// Gets the encoding bitrate of the video's audio in kbps
///// </summary>
//public double AudioEncodingBitrate
//{
//	get
//	{
//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
//			SystemProperties.System.Audio.EncodingBitrate));
//		return uint.Parse(_rawValue) / 1000d;
//	}
////}

///// <summary>
///// Gets the sample rate of the video's audio in kHz
///// </summary>
//public double AudioSampleRate
//{
//	get
//	{
//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
//			SystemProperties.System.Audio.SampleRate));
//		return uint.Parse(_rawValue) / 1000d;
//	}
//}

//protected Lazy<IShellProperty> ContributingArtistsProperty = new Lazy<IShellProperty>(
//	() => shellObject.Properties.GetProperty<string[]>(
//		SystemProperties.System.Music.Artist););

//public string[] ContributingArtists
//{
//	get
//	{
//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
//			SystemProperties.System.Music.Artist));
//		return _rawValue.Split(',');
//	}
//	set
//	{


//		property.Value = value;
//	}
//}


//public DateTime DateEncoded
//{
//	get
//	{
//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
//			SystemProperties.System.Media.DateEncoded));
//		return DateTime.Parse(_rawValue);
//	}
//	set
//	{
//		WriteProperty(SystemProperties.System.Media.DateEncoded, value);
//	}
//}






//private void WriteProperty(PropertyKey propertyKey, object value)
//{
//	using (var propertyWriter = shellObject.Properties.GetPropertyWriter())
//	{
//		propertyWriter.WriteProperty(
//			propertyKey,
//			value);

//	}
//}

//public bool TrySetMeta_ContributingArtistNames(string[] contributingArtists)
//{
//	try
//	{
//		using (var shellPropertyWriter = shellObject.Properties.GetPropertyWriter())
//		{
//			shellPropertyWriter.WriteProperty(SystemProperties.System.Music.Artist, contributingArtists);
//		}
//		return true;
//	}
//	catch (Exception ex)
//	{
//		return false;
//	}
//}





/*
		public bool TrySetMeta_DateEncoded(DateTime? dateTimeUTC = null)
		{
			try
			{
				if (!dateTimeUTC.HasValue)
					dateTimeUTC = DateTime.UtcNow;

				using (var shellPropertyWriter = shellObject.Properties.GetPropertyWriter())
				{
					shellPropertyWriter.WriteProperty(SystemProperties.System.Media.DateEncoded, dateTimeUTC);
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool TrySetMeta_DateReleased(DateTime? dateTimeUTC = null)
		{
			try
			{
				if (!dateTimeUTC.HasValue)
					dateTimeUTC = DateTime.UtcNow;

				using (var shellPropertyWriter = shellObject.Properties.GetPropertyWriter())
				{
					shellPropertyWriter.WriteProperty(SystemProperties.System.Media.DateReleased, dateTimeUTC);
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool TrySetMeta_EncodedBy(string encodedBy)
		{
			try
			{
				using (var shellPropertyWriter = shellObject.Properties.GetPropertyWriter())
				{
					shellPropertyWriter.WriteProperty(SystemProperties.System.Media.EncodedBy, encodedBy);
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool TrySetMeta_SubTitle(string subTitle)
		{
			try
			{
				using (var shellPropertyWriter = shellObject.Properties.GetPropertyWriter())
				{
					shellPropertyWriter.WriteProperty(SystemProperties.System.Media.Subtitle, subTitle);
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}


		private static string GetValue(
			IShellProperty value)
		{
			if (value?.ValueAsObject == null)
				return string.Empty;

			return value.ValueAsObject.ToString();
		}*/
#endregion