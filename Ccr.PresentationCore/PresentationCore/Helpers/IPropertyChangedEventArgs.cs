namespace Ccr.PresentationCore.Helpers
{
  public interface IPropertyChangedEventArgs
  {
    string PropertyName { get; }

    object OldValueBase { get; }

    object NewValueBase { get; }

  }
}