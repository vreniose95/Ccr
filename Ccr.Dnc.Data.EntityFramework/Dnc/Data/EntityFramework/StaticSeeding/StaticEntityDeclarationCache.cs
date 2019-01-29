using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ccr.Dnc.Data.EntityFramework.Infrastucture;

namespace Ccr.Dnc.Data.EntityFramework
{
  public abstract class StaticEntityDeclarationCache
  {
    protected readonly IList<EntityDeclaration> _entityDeclarations
      = new List<EntityDeclaration>();

    //protected static readonly IDictionary<Type, bool> _entityTypeConstructorStates
    //  = new Dictionary<Type, bool>();


    public abstract Type EntityType { get; }
    

   // public void VerifyEntityTypeIsInitialized()
   // {
   //   if (!_entityTypeConstructorStates.TryGetValue(EntityType, out var _entityTypeConstuctorState))
   //   {
   //    RuntimeHelpers.RunClassConstructor(EntityType.TypeHandle);
 
   //   _entityTypeConstructorStates.Add(EntityType, true);
   //  }
   //}

    protected abstract void RegisterEntityBase(
      int lineNumber,
      object entityBase);
  }


  public class StaticEntityDeclarationCache<TValue>
    : StaticEntityDeclarationCache,
      IEnumerable<TValue>
  {
    public override Type EntityType => typeof(TValue);


    protected override void RegisterEntityBase(
      int lineNumber,
      object entityBase)
    {
      RegisterEntity(
        lineNumber,
        (TValue)entityBase);
    }

    public void RegisterEntity(
      int lineNumber,
      TValue entity)
    {
      managedInsert(
        lineNumber,
        entity);
    }

    private void managedInsert(
      int lineNumber,
      TValue entity)
    {
      int insertionIndex = 0;

      for (var index = 1; index <= _entityDeclarations.Count; index++)
      {
        var currentDeclaration = _entityDeclarations[index - 1];
        if (lineNumber > currentDeclaration.LineNumber)
        {
          var declaration = new EntityDeclaration<TValue>(
            lineNumber,
            entity);

          declaration.EntityID = index;

          _entityDeclarations.Insert(
            index,
            declaration);

          insertionIndex = index;
          break;
        }
      }
      if (insertionIndex > 0)
      {
        for (var index = insertionIndex; index < _entityDeclarations.Count; index++)
        {
          var currentDeclaration = _entityDeclarations[index];
          currentDeclaration.EntityID = index + 1;
        }
      }
      else
      {
        var declaration = new EntityDeclaration<TValue>(
          lineNumber,
          entity);

        declaration.EntityID = _entityDeclarations.Count + 1;

        _entityDeclarations.Add(declaration);
      }}


    public IEnumerator<TValue> GetEnumerator()
    {
      return _entityDeclarations
        .Select(t => (TValue) t.EntityBase)
        .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
  
}