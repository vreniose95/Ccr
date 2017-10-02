using System;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Ccr.PresentationCore.Media.Metadata
{
	public class VideoShellObject
	{
		protected FileInfo FileInfo { get; }

		private readonly ShellObject shellObject;

		/// <summary>
		/// Gets the height / vertical resolution of the video in pixels
		/// </summary>
		public uint FrameHeight
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Video.FrameHeight));
				return uint.Parse(_rawValue);
			}
		}

		/// <summary>
		/// Gets the width / horizontal resolution of the video in pixels
		/// </summary>
		public uint FrameWidth
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Video.FrameWidth));
				return uint.Parse(_rawValue);
			}
		}

		/// <summary>
		/// Gets the encoding data rate of the video in kbps
		/// </summary>
		public double VideoDataRate
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Video.EncodingBitrate));
				return uint.Parse(_rawValue) / 1000d;
			}
		}

		/// <summary>
		/// Gets the total bitrate of the video in kbps
		/// </summary>
		public double TotalVideoBitrate
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Video.TotalBitrate));
				return uint.Parse(_rawValue) / 1000d;
			}
		}

		/// <summary>
		/// Gets the frame rate of the video in frames per second
		/// </summary>
		public double VideoFrameRate
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Video.FrameRate));
				return double.Parse(_rawValue) / 1000d;
			}
		}

		/// <summary>
		/// Gets the compression of the video
		/// </summary>
		//public MEDIATYPE VideoCompression
		//{
		//	get
		//	{
		//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
		//			SystemProperties.System.Video.Compression));
		//		return MediaEncoding.GetMediaTypeFromGUID(_rawValue);
		//	}
		//}

		/// <summary>
		/// Gets the duration of the video as a TimeSpan object
		/// </summary>
		public TimeSpan Duration
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Media.Duration));
				var _100nsUnits = long.Parse(_rawValue);
				var _seconds = _100nsUnits / 10000000d;
				return TimeSpan.FromSeconds(_seconds);
			}
		}

		/// <summary>
		/// Gets the encoding settings of the video
		/// </summary>
		public string EncodingSettings
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Media.EncodingSettings));
				return _rawValue;
			}
		}

		/// <summary>
		/// Gets the number of audio channels in the video
		/// </summary>
		public uint AudioChannels
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Audio.ChannelCount));
				return uint.Parse(_rawValue);
			}
		}

		/// <summary>
		/// Gets the encoding bitrate of the video's audio in kbps
		/// </summary>
		public double AudioEncodingBitrate
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Audio.EncodingBitrate));
				return uint.Parse(_rawValue) / 1000d;
			}
		}

		/// <summary>
		/// Gets the sample rate of the video's audio in kHz
		/// </summary>
		public double AudioSampleRate
		{
			get
			{
				var _rawValue = GetValue(shellObject.Properties.GetProperty(
					SystemProperties.System.Audio.SampleRate));
				return uint.Parse(_rawValue) / 1000d;
			}
		}

		/// <summary>
		/// Gets the compression of the video's audio
		/// </summary>
		//public MEDIATYPE AudioCompression
		//{
		//	get
		//	{
		//		var _rawValue = GetValue(shellObject.Properties.GetProperty(
		//			SystemProperties.System.Audio.Compression));
		//		return MediaEncoding.GetMediaTypeFromGUID(_rawValue);
		//	}
		//}


		public bool TrySetMeta_ContributingArtistNames(string[] contributingArtists)
		{
			try
			{
				using (var shellPropertyWriter = shellObject.Properties.GetPropertyWriter())
				{
					shellPropertyWriter.WriteProperty(SystemProperties.System.Music.Artist, contributingArtists);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

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
			catch (Exception)
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
			catch (Exception)
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
			catch (Exception)
			{
				return false;
			}
		}

		public VideoShellObject(FileInfo fileInfo)
		{
			FileInfo = fileInfo;
			shellObject = ShellObject.FromParsingName(fileInfo.FullName);
			if (shellObject == null)
				throw new NotSupportedException();
		}

		private static string GetValue(IShellProperty value)
		{
			if (value == null || value.ValueAsObject == null)
			{
				return string.Empty;
			}
			return value.ValueAsObject.ToString();
		}
	}
}
