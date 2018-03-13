namespace Ccr.Introspective.Tests.Mock
{
  public class GenericFixture<TValue>
  {
    private TValue _backingValue;

    public TValue GetValueProperty
    {
      get => _backingValue;
    }


    public GenericFixture(
      TValue backingValue)
    {
      _backingValue = backingValue;
    }
    
    public TValue GetValueMethod()
    {
      return _backingValue;
    }
  }
}
