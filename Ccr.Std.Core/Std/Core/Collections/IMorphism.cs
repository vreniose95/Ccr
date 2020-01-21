﻿namespace Ccr.Std.Core.Collections
{
	public interface IMorphism<in TA, out TB>
	{
		TB Evaluate(TA a);
	}
}