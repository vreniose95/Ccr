using System;
using System.Collections.Generic;
using System.Linq;

namespace Ccr.Dnc.Data.EntityFramework.Dnc.Data.EntityFramework
{
  public abstract class EntityBuilder
  {
    private static readonly IList<EntityBuilder> _registeredBuilders
      = new List<EntityBuilder>();

    internal static IReadOnlyDictionary<Type, EntityBuilder> RegisteredBuildersMap
    {
      get => _registeredBuilders
        .ToDictionary(
          t => t.EntityType,
          t => t);
    }

    //protected abstract Func<string, EntityBuilder> _builderFuncBase { get; }

    protected abstract EntityBase BuildBase(
      string text);

    static EntityBuilder()
    {
      RegisterBuilder(
        memberName => new Gender(
          memberName.Substring(0, 1),
          memberName));

      RegisterBuilder(
        memberName => new GuestAppearanceType(
          memberName));

      RegisterBuilder(memberName =>
      {
        return PersonFactory.CreatePerson<Host>(
          memberName);
      });
      RegisterBuilder(memberName =>
      {
        return new EmbeddedContentSource(
          memberName);
      });
    }


    internal abstract Type EntityType { get; }


    
    public static void RegisterBuilder<TEntity>(
      Func<string, TEntity> _builderFunc)
        where TEntity
          : EntityBase
    {
      _registeredBuilders.Add(
        new EntityBuilder<TEntity>(
          _builderFunc));
    }

    public static EntityBuilder<TEntity> GetBuilder<TEntity>()
      where TEntity
      : EntityBase
    {
      if(!RegisteredBuildersMap.TryGetValue(
        typeof(TEntity), 
        out var _baseEntityBuilder))
        throw new NotSupportedException(
          $"There is no EntityBuilder defined in the registration map for the " +
          $"entity type \'{typeof(TEntity).Name}\'");

      return (EntityBuilder<TEntity>) _baseEntityBuilder;
    }
  }


  public class EntityBuilder<TEntity>
    : EntityBuilder
    where TEntity
    : EntityBase
  {
    
    protected readonly Func<string, TEntity> _builderFunc;

    internal override Type EntityType => typeof(TEntity);
    


    internal EntityBuilder(
      Func<string, TEntity> builderFunc)
    {
      _builderFunc = builderFunc;
    }


    internal TEntity Build(
      string text)
    {
      return _builderFunc(text);
    }

    protected override EntityBase BuildBase(
      string text)
    {
      return Build(text);
    }
  }
}
/*protected override Func<string, EntityBuilder> _builderFuncBase
    {
      get => text => _builderFunc(text);
    }
*/


//    public static EntityBuilder<TEntity> GetBuilder<TEntity>()
//      where TEntity
//        : EntityBase
//    {
//      var _builderBase = GetBuilderBase(
//        typeof(TEntity));

//      return (EntityBuilder<TEntity>)_builderBase;
//    }

//    protected static EntityBuilder GetBuilderBase(
//      Type entityType)
//    {
//      if (!_builderMap.TryGetValue(entityType, out var entityBuilder))
//      {
//        throw new InvalidOperationException(
//          "Builder type not found.");
//      }
//      return entityBuilder;
//    }

//  }
//  {
//    public static TEntity Create<TEntity>(
//      [CallerLineNumber] int callerLineNumber = 0,
//      [CallerMemberName] string callerMemberName = "")
//    {
//      return CreateImpl<TEntity>(
//        callerLineNumber,
//        callerMemberName);
//    }

//    internal static TEntity CreateImpl<TEntity>(
//      int callerLineNumber = 0,
//      string callerMemberName = "")
//    {
//      var builder = EntityBuilder
//        .GetBuilder<TEntity>();

//      var builtEntity = builder
//        .Build(callerMemberName);

//      var storageCache = StaticEntityStorageCache
//        .I.GetDeclarationCache<TEntity>();

//      storageCache.RegisterEntity(
//        callerLineNumber,
//        builtEntity);

//      return builtEntity;
//    }
//  }
//    {
//      _registeredBuilders.Add(
//        new EntityBuilder<TEntity>(
//          _builderFunc));
//    }

//    public static EntityBuilder<TEntity> GetBuilder<TEntity>()
//      where TEntity
//      : EntityType
//    {
//      var _builderBase = GetBuilderBase(
//        typeof(TEntity));

//      return (EntityBuilder<TEntity>)_builderBase;
//    }

//    protected static EntityBuilder GetBuilderBase(
//      Type entityType)
//    {
//      if (!_builderMap.TryGetValue(entityType, out var entityBuilder))
//      {
//        throw new InvalidOperationException(
//          "Builder type not found.");
//      }
//      return entityBuilder;
//    }

//  }
//  internal class EntityBuilder<TEntity>
//    : EntityBuilder
//  {
//    protected override Type EntityType => typeof(TEntity);


//    public EntityBuilder(
//      Func<string, TEntity> _builderFunc)
//    {

//    }
//  }
//}
