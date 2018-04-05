namespace Ccr.Dnc.Data.EntityFramework
{
  internal abstract class EntityDeclaration
  {
    private int? _entityID;

    internal int? EntityID
    {
      get => _entityID;
      set
      {
        _entityID = value;
      }
    }

    internal int LineNumber { get; }

    protected abstract EntityBase EntityBase { get; }


    protected EntityDeclaration(
      int lineNumber)
    {
      LineNumber = lineNumber;
    }
  }

  internal class EntityDeclaration<TEntity>
    : EntityDeclaration
    where TEntity
    : EntityBase
  {
    public TEntity Entity { get; }

    protected override EntityBase EntityBase => Entity;


    public EntityDeclaration(
      int _lineNumber,
      TEntity _entity)
      : base(
        _lineNumber)
    {
      Entity = _entity;
    }
  }
}
