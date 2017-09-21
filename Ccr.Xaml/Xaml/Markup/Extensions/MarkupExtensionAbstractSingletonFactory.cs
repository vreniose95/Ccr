using System;
using System.Windows.Markup;
using Ccr.Core.Extensions;
using Ccr.Xaml.Infrastructure;

namespace Ccr.Xaml.Markup.Extensions
{
	public class MarkupExtensionAbstractSingletonFactory
		: MarkupExtension
	{
		private AbstractSingletonFactory<MarkupExtension> _factoryService;
		internal AbstractSingletonFactory<MarkupExtension> FactoryService
		{
			get => _factoryService ?? (
				_factoryService = AbstractSingletonFactory<MarkupExtension>.I);
		}

		public override object ProvideValue(
			IServiceProvider serviceProvider)
		{
			var instanceBase = FactoryService
				.As<IAbstractSingletonFactory<MarkupExtension>>()
				.GetInstanceBase(
					GetType());
			
			var instance = instanceBase.As<MarkupExtension>();
			return instance;
		}
	}
}
