using System.Collections.Generic;
using System.Numerics;
using Ccr.Algorithms.Collections;
using Ccr.Algorithms.Extensions;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Algorithms
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// https://en.wikipedia.org/wiki/Centripetal_Catmull–Rom_spline
	/// </remarks>
	public class SplineInterpolationAlgorithms
	{
		public static IEnumerable<Vector2> CentripetalCatmullRomSplineInterpolator(
			Vector2[] source,
			float alpha = 0.5f,
			int resolution = 15)
		{
			var result = new List<Vector2>();

			var initial = source.SliceTriple(0);
			var segment = GetFirstSegment(
				initial,
				alpha,
				resolution);

			result.AddRange(segment);

			for (var i = 0; i < source.Length - 3; i++)
			{
				var innerSpline = source.SliceQuad(i);
				var innerSplineSegment = GetSegment(
					innerSpline,
					alpha,
					resolution);

				result.AddRange(innerSplineSegment);
			}

			var final = source.SliceTriple(source.Length - 3);
			var finalSplineSegment = GetLastSegment(
				final,
				alpha,
				resolution);

			result.AddRange(finalSplineSegment);

			return result;
		}

		private static IEnumerable<Vector2> GetFirstSegment(
			SequentialTriple<Vector2> points,
			float alpha,
			int resolution)
		{
			var initial = points[0] * 2 - points[1];
			var quad = points.PrependValue(initial);

			return GetSegment(
				quad,
				alpha,
				resolution);
		}

		private static IEnumerable<Vector2> GetLastSegment(
			SequentialTriple<Vector2> points,
			float alpha,
			int resolution)
		{
			var final = points[2] * 2 - points[1];
			var quad = points.AppendValue(final);

			return GetSegment(
				quad,
				alpha,
				resolution);
		}

		private static IEnumerable<Vector2> GetSegment(
			SequentialQuad<Vector2> points,
			float alpha,
			int resolution)
		{
			var segments = points.Pairwise();

			var t = new SequentialQuad<float>(0f, 0f, 0f, 0f);
			var index = 0;

			foreach (var segment in segments)
			{
				t[index + 1] = GetT(t[index], segment, alpha);
				index++;
			}

			var center = t.Center;

			foreach (var x in center.LinearSpace(resolution))
			{
				var a1 =
					(t[1] - x) / (t[1] - t[0]) * points[0]
					+ (x - t[0]) / (t[1] - t[0]) * points[1];

				var a2 =
					(t[2] - x) / (t[2] - t[1]) * points[1]
					+ (x - t[1]) / (t[2] - t[1]) * points[2];

				var a3 =
					(t[3] - x) / (t[3] - t[2]) * points[2]
					+ (x - t[2]) / (t[3] - t[2]) * points[3];
				

				var b1 =
					(t[2] - x) / (t[2] - t[0]) * a1
					+ (x - t[0]) / (t[2] - t[0]) * a2;

				var b2 =
					(t[3] - x) / (t[3] - t[1]) * a2
					+ (x - t[1]) / (t[3] - t[1]) * a3;
				

				yield return
					(t[2] - x) / (t[2] - t[1]) * b1
					+ (x - t[1]) / (t[2] - t[1]) * b2;
			}
		}

		private static float GetT(
			float tValue,
			SequentialPair<Vector2> segment,
			float alpha)
		{
			return (
					(segment.Value2.X - segment.Value1.X).Power(2f) +
					(segment.Value2.Y - segment.Value1.Y).Power(2f))
				.Power(.5f)
				.Power(alpha) + tValue;
		}
	}
}