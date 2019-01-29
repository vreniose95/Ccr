namespace Ccr.Dnc.Data.EntityFramework.Infrastucture
{
  public abstract class EntityDeclaration
  {
    public int? EntityID { get; set; }

    public int LineNumber { get; }

    public abstract object EntityBase { get; }


    protected EntityDeclaration(
      int lineNumber)
    {
      LineNumber = lineNumber;
    }
  }

  public class EntityDeclaration<TValue>
    : EntityDeclaration
  {
    public override object EntityBase => Entity;

    public TValue Entity { get; }


    public EntityDeclaration(
      int lineNumber,
      TValue entity)
      : base(
        lineNumber)
    {
      Entity = entity;
    }
  }
}