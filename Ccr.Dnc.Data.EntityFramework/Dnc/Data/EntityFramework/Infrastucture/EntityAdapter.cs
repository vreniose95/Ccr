using System;

namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
  public abstract class EntityAdapterBase
  {
    public int EntityID { get; }

    protected abstract object EntityBase { get; }

    public abstract Type EntityType { get; }


    protected EntityAdapterBase(
      int entityID)
    {
      EntityID = entityID;
    }
  }

  public class EntityAdapter<TValue>
    : EntityAdapterBase
  {
    protected override object EntityBase => Entity;

    public TValue Entity { get; }

    public override Type EntityType => typeof(TValue);


    public EntityAdapter(
      int entityID,
      TValue entity)
        : base(
            entityID)
    {
      Entity = entity;
    }
  }
}
