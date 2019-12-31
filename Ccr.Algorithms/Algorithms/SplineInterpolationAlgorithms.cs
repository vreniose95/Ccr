using System.Collections.Generic;
using System.Numerics;
using Ccr.Algorithms.Collections;
using Ccr.Algorithms.Extensions;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Algorithms
{
  //https://en.wikipedia.org/wiki/Centripetal_Catmull–Rom_spline
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
//for (
//  var t = center.Value1; 
//  t < center.Value2;
//  t += center.Difference / splineResolution)
//{

/*
         var a1 = 
            (T[1] - t) / (T[1] - T[0]) * points[0] 
          + (t - T[0]) / (T[1] - T[0]) * points[1];

        var a2 = 
            (T[2] - t) / (T[2] - T[1]) * points[1] 
          + (t - T[1]) / (T[2] - T[1]) * points[2];

        var a3 = 
            (T[3] - t) / (T[3] - T[2]) * points[2] 
          + (t - T[2]) / (T[3] - T[2]) * points[3];


        var b1 = 
            (T[2] - t) / (T[2] - T[0]) * a1 
          + (t - T[0]) / (T[2] - T[0]) * a2;

        var b2 = 
            (T[3] - t) / (T[3] - T[1]) * a2 
          + (t - T[1]) / (T[3] - T[1]) * a3;


        yield return 
            (T[2] - t) / (T[2] - T[1]) * b1 
          + (t - T[1]) / (T[2] - T[1]) * b2;*/
//var t0 = 0.0f;
//var t1 = GetT(t0, segments[0], alpha);
//var t2 = GetT(t1, segments[1], alpha);
//var t3 = GetT(t2, segments[2], alpha);

//for (var t = t1; t < t2; t += (t2 - t1) / splineResolution)
//{
//  var A1 = (t1 - t) / (t1 - t0) * points[0] + (t - t0) / (t1 - t0) * points[1];
//  var A2 = (t2 - t) / (t2 - t1) * points[1] + (t - t1) / (t2 - t1) * points[2];
//  var A3 = (t3 - t) / (t3 - t2) * points[2] + (t - t2) / (t3 - t2) * points[3];

//  var B1 = (t2 - t) / (t2 - t0) * A1 + (t - t0) / (t2 - t0) * A2;
//  var B2 = (t3 - t) / (t3 - t1) * A2 + (t - t1) / (t3 - t1) * A3;

//  var C = (t2 - t) / (t2 - t1) * B1 + (t - t1) / (t2 - t1) * B2;

//  result.Add(C);
//}

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
