using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ccr.Introspective.Extensions;
using Ccr.Introspective.Infrastructure.Context;

// ReSharper disable ArrangeAccessorOwnerBody
namespace Ccr.Introspective.Infrastructure.ExternalIntrospection
{
	/// <summary>
	/// Provides access to types that are defined in external assemblies.
	/// The assemblies can be loaded at runtime dynamically, access, and
	/// instantiation of any of the types declared therin (Public and NonPublic)
	/// </summary>
	public class ForeignNonPublicTypeProxy
	{
		private static Dictionary<string, Assembly> _assemblyCache;
		protected static Dictionary<string, Assembly> assemblyCache
		{
			get { return _assemblyCache ?? (_assemblyCache = _fetchLoadedAssemblies()); }
		}

		private static Dictionary<string, Assembly> _fetchLoadedAssemblies()
		{
			var _loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

			AppDomain.CurrentDomain.AssemblyLoad += onCurrentAppDomainAssemblyResolved;

			return _loadedAssemblies.ToDictionary(t => t.FullName);
		}

		private static void onCurrentAppDomainAssemblyResolved(
			object sender,
			AssemblyLoadEventArgs args)
		{
			var assembly = args.LoadedAssembly;

			if (!assemblyCache.ContainsKey(assembly.FullName))
				assemblyCache.Add(assembly.FullName, assembly);
		}
		

		public Assembly Assembly { get; }

		public Type Type { get; }


		private ForeignNonPublicTypeProxy(
			Assembly _assembly,
			Type _type)
		{
			Assembly = _assembly;
			Type = _type;
		}


		public static ForeignNonPublicTypeProxy CreateProxy(
			string qualifiedAssemblyName,
			string qualifiedTypeName)
		{
			var assemblyReference = _getAssembly(qualifiedAssemblyName);

			var typeReference = assemblyReference.GetType(qualifiedTypeName, false);
			if (typeReference == null)
				throw new TypeLoadException(
					$"The qualifiedTypeName parameter \'{qualifiedTypeName}\' does not map to a valid type" +
					$"declaration in the assembly with the qualifiedAssemblyName \'{qualifiedAssemblyName}\'.");

			return new ForeignNonPublicTypeProxy(
				assemblyReference,
				typeReference);
		}

		private static Assembly _getAssembly(
			string qualifiedAssemblyName)
		{
			Assembly _resolvedAssembly;
			if (!assemblyCache.TryGetValue(qualifiedAssemblyName, out _resolvedAssembly))
			{
				_resolvedAssembly = Assembly.Load(qualifiedAssemblyName);
				assemblyCache.Add(qualifiedAssemblyName, _resolvedAssembly);
			}
			return _resolvedAssembly;
		}

		public object CreateInstance()
		{
			var memberDescriptor = Type.IsVisible ? 
				MemberDescriptor.NonPublic : MemberDescriptor.Public;

			var typeInstance = new IntrospectiveStaticContext(Type)
				.CreateInstanceImpl(memberDescriptor);

			return typeInstance;
		}
	}
}
/*	
 *	
 *	//AppDomain.CurrentDomain.AssemblyResolve += onCurrentDomainOnAssemblyResolved;
 *	
			AppDomain.CurrentDomain.TypeResolve += onCurrentAppDomainTypeResolved;
 *	
 *	private static Assembly onCurrentDomainOnAssemblyResolve(
			object sender, 
			ResolveEventArgs args)
		{

		}

		private static void onCurrentAppDomainAssemblyLoaded(
			object sender, 
			ResolveEventArgs args)
		{

		}
				private static Assembly onCurrentAppDomainTypeResolved(
			object sender,
			ResolveEventArgs args)
		{

		}
*/
