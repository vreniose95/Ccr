using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Ccr.MaterialDesign.Primitives.Behaviors.Services
{
  public abstract class AbstractElementProxyService<TElement>
  {
    protected readonly IList<TElement> _attachedElements
      = new List<TElement>();

    public IEnumerable<TElement> AttachedElements
    {
      get => _attachedElements;
    }


    public void AttachElement(
      [NotNull] TElement element)
    {
      if (_attachedElements.Contains(element))
        return;

      OnElementAttaching(element);
      _attachedElements.Add(element);
    }

    public void DetachElement(
      [NotNull] TElement element)
    {
      if (!_attachedElements.Contains(element))
        throw new InvalidOperationException();

      OnElementDetaching(element);
      _attachedElements.Remove(element);
    }


    protected abstract void OnElementAttaching(
      [NotNull] TElement element);

    protected abstract void OnElementDetaching(
      [NotNull] TElement element);

  }
}
