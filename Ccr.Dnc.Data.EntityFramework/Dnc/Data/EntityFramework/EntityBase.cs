using System.ComponentModel.DataAnnotations.Schema;

namespace Ccr.Dnc.Data.EntityFramework.Dnc.Data.EntityFramework
{
  public abstract class EntityBase
  {
    [NotMapped]
    private int? _entityID;

    [NotMapped]
    public int? EntityID
    {
      get => _entityID;
      internal set
      {
        _entityID = value;
      }
    }
  }
}
