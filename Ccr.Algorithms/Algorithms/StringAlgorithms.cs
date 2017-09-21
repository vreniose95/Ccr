using System;
using Ccr.Core.Extensions;

namespace Ccr.Algorithms
{
  public static class StringAlgorithms
  {
    public static int LevenshteinDistance(
      string a, string b)
    {
      if (a.IsNullOrEmpty())
        return !b.IsNullOrEmpty() ? a.Length : 0;

      if (b.IsNullOrEmpty())
        return !a.IsNullOrEmpty() ? b.Length : 0;

      var d = new int[a.Length - 1, b.Length - 1];

      for (var i = 0; i <= d.GetUpperBound(0); i++)
      {
        d[i, 0] = i;
      }

      for (var i = 0; i <= d.GetUpperBound(1); i++)
      {
        d[0, i] = i;
      }

      for (var i = 1; i <= d.GetUpperBound(0); i++)
      {
        for (var j = 1; j <= d.GetUpperBound(1); j += 1)
        {
          var cost = Convert.ToInt32(a[i - 1] != b[j - 1]);

          var min1 = d[i - 1, j] + 1;
          var min2 = d[i, j - 1] + 1;
          var min3 = d[i - 1, j - 1] + cost;
          d[i, j] = Math.Min(Math.Min(min1, min2), min3);
        }
      }

      return d[d.GetUpperBound(0), d.GetUpperBound(1)];
    }


	  public static int LevenshteinDistanceVersion2(
			string source,
			string target)
	  {
		  var bounds = new
		  {
			  Height = source.Length + 1,
				Width = target.Length + 1
		  };

		  var matrix = new int[bounds.Height, bounds.Width];

		  for (var height = 0; height < bounds.Height; height++)
		  {
			  matrix[height, 0] = height;
		  }
		  for (var width = 0; width < bounds.Width; width++)
		  {
			  matrix[0, width] = width;
		  }

		  for (var height = 1; height < bounds.Height; height++)
		  {
			  for (var width = 1; width < bounds.Width; width++)
			  {
				  var cost = source[height - 1] == target[width - 1] ? 0 : 1;
				  var insertion = matrix[height, width - 1] + 1;
				  var deletion = matrix[height - 1, width] + 1;
				  var substitution = matrix[height - 1, width - 1] + cost;

				  var distance = Math.Min(insertion, Math.Min(deletion, substitution));

				  matrix[height, width] = distance;
			  }
		  }

		  return matrix[bounds.Height - 1, bounds.Width - 1];
	  }

	  public static int DamerauLevenshteinDistance(
			string source,
			string target)
	  {
		  var bounds = new
		  {
			  Height = source.Length + 1,
				Width = target.Length + 1
		  };

		  var matrix = new int[bounds.Height, bounds.Width];

		  for (var height = 0; height < bounds.Height; height++)
		  {
			  matrix[height, 0] = height;
		  }
		  for (var width = 0; width < bounds.Width; width++)
		  {
			  matrix[0, width] = width;
		  }

		  for (var height = 1; height < bounds.Height; height++)
		  {
			  for (var width = 1; width < bounds.Width; width++)
			  {
				  var cost = source[height - 1] == target[width - 1] ? 0 : 1;
				  var insertion = matrix[height, width - 1] + 1;
				  var deletion = matrix[height - 1, width] + 1;
				  var substitution = matrix[height - 1, width - 1] + cost;

				  var distance = Math.Min(insertion, Math.Min(deletion, substitution));

				  if (height > 1 
						&& width > 1 
						&& source[height - 1]
						== target[width - 2] 
						&& source[height - 2] 
						== target[width - 1])
				  {
					  distance = Math.Min(
							distance, 
							matrix[height - 2, width - 2] + cost);
				  }

				  matrix[height, width] = distance;
			  }
		  }

		  return matrix[bounds.Height - 1, bounds.Width - 1];
	  }
	}
}
