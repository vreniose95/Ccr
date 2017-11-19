using System;
using System.Collections.Generic;
using System.Numerics;
using Ccr.Algorithms.Collections;
using Ccr.Algorithms.Extensions;
using Ccr.Core.Extensions.NumericExtensions;


namespace Ccr.Algorithms
{
  //https://en.wikipedia.org/wiki/Centripetal_Catmull–Rom_spline
  public class SplineInterpolationAlgorithms
  {
    public static IEnumerable<Vector2> CentripetalCatmullRomSplineInterpolator(
      Vector2[] source,
      float alpha = 0.5f,
      int splineResolution = 15)
    {
      var result = new List<Vector2>();

      var initial = source.SliceTriple(0);
      var segment = GetFirstSegment(
        initial,
        alpha,
        splineResolution);

      result.AddRange(segment);

      for (var i = 0; i < source.Length - 3; i++)
      {
        var innerSpline = source.SliceQuad(i);
        var innerSplineSegment = GetSegment(
          innerSpline,
          alpha,
          splineResolution);

        result.AddRange(innerSplineSegment);
      }

      var final = source.SliceTriple(source.Length - 3);
      var finalSplineSegment = GetLastSegment(
        final,
        alpha,
        splineResolution);

      result.AddRange(finalSplineSegment);

      return result;
    }

    private static IEnumerable<Vector2> GetFirstSegment(
      SequentialTriple<Vector2> points,
      float alpha,
      int splineResolution)
    {
      var initial = points[0] * 2 - points[1];
      var quad = points.PrependValue(initial);

      return GetSegment(
        quad,
        alpha,
        splineResolution);
    }

    private static IEnumerable<Vector2> GetLastSegment(
      SequentialTriple<Vector2> points,
      float alpha,
      int splineResolution)
    {
      var final = points[2] * 2 - points[1];
      var quad = points.AppendValue(final);

      return GetSegment(
        quad,
        alpha,
        splineResolution);
    }

    private static IEnumerable<Vector2> GetSegment(
      SequentialQuad<Vector2> points,
      float alpha,
      int splineResolution)
    {
      var result = new List<Vector2>();

      var t0 = 0.0f;
      var t1 = GetT(t0, points[0], points[1], alpha);
      var t2 = GetT(t1, points[1], points[2], alpha);
      var t3 = GetT(t2, points[2], points[3], alpha);

      for (var t = t1; t < t2; t += ((t2 - t1) / splineResolution))
      {
        Vector2 A1 = (t1 - t) / (t1 - t0) * points[0] + (t - t0) / (t1 - t0) * points[1];
        Vector2 A2 = (t2 - t) / (t2 - t1) * points[1] + (t - t1) / (t2 - t1) * points[2];
        Vector2 A3 = (t3 - t) / (t3 - t2) * points[2] + (t - t2) / (t3 - t2) * points[3];

        Vector2 B1 = (t2 - t) / (t2 - t0) * A1 + (t - t0) / (t2 - t0) * A2;
        Vector2 B2 = (t3 - t) / (t3 - t1) * A2 + (t - t1) / (t3 - t1) * A3;

        Vector2 C = (t2 - t) / (t2 - t1) * B1 + (t - t1) / (t2 - t1) * B2;

        result.Add(C);
      }

      return result;
    }

    private static float GetT(
      float t,
      Vector2 p0,
      Vector2 p1,
      float alpha)
    {

      return (
        (p1.X - p0.X).Power(2f) +
        (p1.Y - p0.Y).Power(2f))
          .Power(.5f)
          .Power(alpha) + t;
    }
  }

}
/*

      var a = (float)(Math.Pow(p1.X - p0.X, 2.0f) + Math.Pow(p1.Y - p0.Y, 2.0f));
      var b = (float)Math.Pow(a, 0.5f);

      return (float)Math.Pow(b, alpha) + t;*/
/*  class Algorithm
  {
    // newPoints = new List<Vector2>();
    /// <summary>
    /// It's actually maybe this value - 1 cuz raisins, whatever just look at your curve and see what looks good
    /// </summary>
    public int PointsBetweenDataPoints { get; set; } = 15;

    /// <summary>
    /// Set from 0-1, whatever it is, I have no idea
    /// </summary>
    public float Alpha { get; set; } = 0.5f;

    public List<Vector2> Smoothen(params Vector2[] points)
    {
      List<Vector2> result = new List<Vector2>();
      result.AddRange(GetFirstSegment(points[0], points[1], points[2]));
      for (int i = 0; i < points.Length - 3; i++)
      {
        result.AddRange(GetSegment(points[i + 0], points[i + 1], points[i + 2], points[i + 3]));
      }
      result.AddRange(GetLastSegment(points[points.Length - 3], points[points.Length - 2], points[points.Length - 1]));

      return result;
    }

    private List<Vector2> GetFirstSegment(params Vector2[] firstThreePoints)
      => GetSegment(2 * firstThreePoints[0] - firstThreePoints[1],
                    firstThreePoints[0], firstThreePoints[1], firstThreePoints[2]);

    private List<Vector2> GetLastSegment(params Vector2[] lastThreePoints)
      => GetSegment(lastThreePoints[0], lastThreePoints[1], lastThreePoints[2],
                    2 * lastThreePoints[2] - lastThreePoints[1]);

    private List<Vector2> GetSegment(params Vector2[] fourPoints)
    {
      List<Vector2> result = new List<Vector2>();

      float t0 = 0.0f;
      float t1 = GetT(t0, fourPoints[0], fourPoints[1]);
      float t2 = GetT(t1, fourPoints[1], fourPoints[2]);
      float t3 = GetT(t2, fourPoints[2], fourPoints[3]);

      for (float t = t1; t < t2; t += ((t2 - t1) / PointsBetweenDataPoints))
      {
        Vector2 A1 = (t1 - t) / (t1 - t0) * fourPoints[0] + (t - t0) / (t1 - t0) * fourPoints[1];
        Vector2 A2 = (t2 - t) / (t2 - t1) * fourPoints[1] + (t - t1) / (t2 - t1) * fourPoints[2];
        Vector2 A3 = (t3 - t) / (t3 - t2) * fourPoints[2] + (t - t2) / (t3 - t2) * fourPoints[3];

        Vector2 B1 = (t2 - t) / (t2 - t0) * A1 + (t - t0) / (t2 - t0) * A2;
        Vector2 B2 = (t3 - t) / (t3 - t1) * A2 + (t - t1) / (t3 - t1) * A3;

        Vector2 C = (t2 - t) / (t2 - t1) * B1 + (t - t1) / (t2 - t1) * B2;

        result.Add(C);
      }

      return result;
    }

    private float GetT(float t, Vector2 p0, Vector2 p1)
    {
      float a = (float)(Math.Pow((p1.X - p0.X), 2.0f) + Math.Pow((p1.Y - p0.Y), 2.0f));
      float b = (float)Math.Pow(a, 0.5f);
      float c = (float)Math.Pow(b, Alpha);

      return (c + t);
    }
  }*/
