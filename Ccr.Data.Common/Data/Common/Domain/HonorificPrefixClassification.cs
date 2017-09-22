using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable VirtualMemberCallInConstructor
namespace Ccr.Data.Common.Domain
{
  public partial class HonorificPrefixClassification
  {
	  public int HonorificPrefixClassificationID { get; set; }

    public string PrefixClassificationName { get; set; }

    public virtual ICollection<HonorificPrefix> HonorificPrefixes { get; set; }



	  protected HonorificPrefixClassification()
	  {
		  HonorificPrefixes = new HashSet<HonorificPrefix>();
	  }

    public HonorificPrefixClassification(
      string memberName) : this()
    {
      PrefixClassificationName = memberName.Replace('_', ' ');
    }
    protected HonorificPrefixClassification(
      int honorificPrefixClassificationID,
      [CallerMemberName] string memberName = "") : this(
        memberName)
    {
      HonorificPrefixClassificationID = honorificPrefixClassificationID;
    }
  }
	
}