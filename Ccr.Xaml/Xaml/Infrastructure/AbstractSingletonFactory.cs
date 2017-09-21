using System;
using System.Collections.Generic;
using Ccr.Core.Extensions;
using Ccr.Introspective.Extensions;
using Ccr.Introspective.Infrastructure;
using Ccr.Introspective.Infrastructure.Context;

namespace Ccr.Xaml.Infrastructure
{
	public abstract class AbstractSingletonFactoryBase :
		IAbstractSingletonFactoryBase
	{
		#region Singleton Service
		private static AbstractSingletonFactoryBase _instance;
		public static AbstractSingletonFactoryBase I
		{
			get => _instance ?? (_instance = new AbstractSingletonFactoryBaseImpl());
		}

		private class AbstractSingletonFactoryBaseImpl
			: AbstractSingletonFactoryBase
		{
		}
		#endregion

		#region Fields
		protected static readonly Dictionary<Type, object> _instanceCache =
			new Dictionary<Type, object>();

		#endregion

		#region Methods
		object IAbstractSingletonFactoryBase.GetInstanceBase(
			Type type,
			params object[] constructorArgs)
		{
			if (_instanceCache.ContainsKey(type))
				return _instanceCache[type];

			var instance = new IntrospectiveStaticContext(type)
				.CreateInstanceImpl(MemberDescriptor.Public, constructorArgs);

			_instanceCache.Add(type, instance);
			return instance;
		}

		#endregion
	}

	
	public abstract class AbstractSingletonFactory<TValue>
		: AbstractSingletonFactoryBase,
			IAbstractSingletonFactory<TValue>
	{
		#region Singleton Service
		private static AbstractSingletonFactory<TValue> _instance;
		public new static AbstractSingletonFactory<TValue> I
		{
			get => _instance ?? (_instance = new AbstractSingletonFactoryImpl());
		}

		private class AbstractSingletonFactoryImpl
			: AbstractSingletonFactory<TValue>
		{
			public AbstractSingletonFactoryImpl()
			{
			}
		}

		#endregion

		#region Methods
		TResult IAbstractSingletonFactory<TValue>.GetInstance<TResult>(
			params object[] constructorArgs)
		{
			var instance = this.As<IAbstractSingletonFactoryBase>()
				.GetInstanceBase(
					typeof(TResult),
					constructorArgs);

			return (TResult)instance;
		}

		#endregion
	}
}


//TResult GetInstance<TResult>(
//	params object[] constructorArgs)
//{
//	var instance = GetInstanceBase(
//		typeof(TResult),
//		constructorArgs);

//	return (TResult)instance;
//}
/*		internal static AbstractSingletonFactory<TValue> CreateServiceInstance()
	{
		return new AbstractSingletonFactoryImpl();
	}
			//public TValue GetInstanceImpl(
	//	Type type,
	//	params object[] constructorArgs)
	//{
	//	return (TValue)AbstractSingletonFactoryBase
	//		.GetInstanceImpl(type, constructorArgs);
	//}

	//public static TResult GetInstance<TResult>(
	//	params object[] constructorArgs)
	//		where TResult : TValue
	//{
	//	var instance = GetInstanceImpl(
	//		typeof(TResult),
	//		constructorArgs);

	//	return (TResult)instance;
	//}

*/
