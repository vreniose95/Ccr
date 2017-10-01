using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Ccr.PresentationCore.Media.Metadata
{
	//[TestFixture]
	//public class AudioFileMetadataTests
	//{
	//	[Test]
	//	public void CanReadDuration()
	//	{
			//var sampleAudio2 = new Uri("../", UriKind.Relative);
			//var sampleAudio = new Uri("../../../SampleMedia/SampleAudio/", UriKind.Relative);
			//var absolutePath = sampleAudio.AbsolutePath;

			//var directoryInfo = new DirectoryInfo(
			//	@"C:\Repositories\Ccr\Ccr.PresentationCore.Tests\SampleMedia\SampleAudio\");

			//if(!directoryInfo.Exists)
			//	throw new DirectoryNotFoundException();

			//var library = directoryInfo
			//	.EnumerateFiles("*.mp3")
			//	.Select(t => new AudioShellObject(t))
			//	.ToArray();


			//foreach (var audioShellObject in library)
			//{
			//	Debug.WriteLine($"Duration: {audioShellObject.Duration}");
			//	Debug.WriteLine($"AudioChannelCount: {audioShellObject.AudioChannelCount}");
			//	Debug.WriteLine($"AudioEncodingBitrate: {audioShellObject.AudioEncodingBitrate}");
			//	Debug.WriteLine($"EncodingSettings: {audioShellObject.EncodingSettings}");
			//	Debug.WriteLine($"AudioSampleRate: {audioShellObject.AudioSampleRate}");
			//	Debug.WriteLine($"DateEncoded: {audioShellObject.DateEncoded}");
			//	Debug.WriteLine($"ContributingArtists: {string.Join(", ", audioShellObject.ContributingArtists)}");

			//}
	//	}

	//}
}
