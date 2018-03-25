using System.Runtime.CompilerServices;

namespace Ccr.Dnc.Data.EntityFramework.Dnc.Data.EntityFramework
{
  public class EntityFactory
  {
    public static TEntity Create<TEntity>(
      [CallerLineNumber] int callerLineNumber = 0,
      [CallerMemberName] string callerMemberName = "")
        where TEntity
          : EntityBase
    {
      return CreateImpl<TEntity>(
        callerLineNumber,
        callerMemberName);
    }

    internal static TEntity CreateImpl<TEntity>(
      int callerLineNumber = 0,
      string callerMemberName = "")
        where TEntity
          : EntityBase
    {
      var builder = EntityBuilder
        .GetBuilder<TEntity>();

      var builtEntity = builder
        .Build(callerMemberName);

      var storageCache = StaticEntityStorageCache
        .I.GetDeclarationCache<TEntity>();[]

      storageCache.RegisterEntity(
        callerLineNumber,
        builtEntity);

      return builtEntity;
    }
  }
}
