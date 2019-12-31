namespace Ccr.Std.Core.FluentBuilder
{
	public interface IFluentBuilder<out TBuilds>
	{
		TBuilds Build();
	}
}
