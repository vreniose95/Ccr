using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Ccr.Data.EntityFramework.Core
{
	internal class EntityPrimaryKeyResolver<TEntity, TKey, TContext>
		where TEntity : class
		where TKey : IComparable
		where TContext : DbContext
	{
		public Type EntityType => typeof(TEntity);
		

		private readonly string _primaryKeyPropertyName;

		private Expression<Func<TEntity, TKey>> _primaryKeyGetterExpression;
		public Expression<Func<TEntity, TKey>> PrimaryKeyGetterExpression
		{
			get => _primaryKeyGetterExpression ??
			       (_primaryKeyGetterExpression = buildPrimaryKeyGetterExpression(_primaryKeyPropertyName));
		}

		private Expression<Action<TEntity, TKey>> _primaryKeySetterExpression;
		public Expression<Action<TEntity, TKey>> PrimaryKeySetterExpression
		{
			get => _primaryKeySetterExpression ??
			       (_primaryKeySetterExpression = buildPrimaryKeySetterExpression(_primaryKeyPropertyName));
		}



		protected static Expression<Func<TEntity, TKey>> buildPrimaryKeyGetterExpression(
			string propertyName)
		{
			var lambdaArgument = Expression.Parameter(
				typeof(TEntity), "t");

			var memberExpression = Expression.Property(
				lambdaArgument,
				propertyName);

			var lambdaExpression = Expression
				.Lambda<Func<TEntity, TKey>>(
					memberExpression,
					lambdaArgument);

			return lambdaExpression;
		}

		protected static Expression<Action<TEntity, TKey>> buildPrimaryKeySetterExpression(
			string propertyName)
		{
			var targetLambdaArgument = Expression.Parameter(
				typeof(TEntity), "t");

			var valueLambdaArgument = Expression.Parameter(
				typeof(TKey), "v");

			var memberExpression = Expression.Property(
				targetLambdaArgument,
				propertyName);

			var assignExpression = Expression.Assign(
				memberExpression,
				valueLambdaArgument);

			var lambdaExpression = Expression
				.Lambda<Action<TEntity, TKey>>(
					assignExpression,
					targetLambdaArgument,
					valueLambdaArgument);

			return lambdaExpression;
		}



		private Func<TEntity, TKey> _primaryKeyGetterCompiledDelegate;
		public Func<TEntity, TKey> PrimaryKeyGetterCompiledDelegate
		{
			get => _primaryKeyGetterCompiledDelegate ??
			       (_primaryKeyGetterCompiledDelegate = PrimaryKeyGetterExpression.Compile());
		}

		private Action<TEntity, TKey> _primaryKeySetterCompiledDelegate;
		public Action<TEntity, TKey> PrimaryKeySetterCompiledDelegate
		{
			get => _primaryKeySetterCompiledDelegate ??
			       (_primaryKeySetterCompiledDelegate = PrimaryKeySetterExpression.Compile());
		}

		
		public void SetPrimaryKeyValue(
			TEntity entity,
			TKey value)
		{
			PrimaryKeySetterCompiledDelegate(entity, value);
		}
		public TKey GetPrimaryKeyValue(
			TEntity entity)
		{
			return PrimaryKeyGetterCompiledDelegate(entity);
		}


		
		public Expression<Func<TEntity, IComparable>> PrimaryKeyExpressionBase { get; }

		public Expression<Func<TEntity, bool>> CreatePrimaryKeyExpressionPredicate(TKey keyValue)
		{
			var lambdaArgument = Expression.Parameter(typeof(TEntity), typeof(TEntity).Name);
			var binaryExpr = Expression.Equal(
				Expression.Property(lambdaArgument, _primaryKeyPropertyName),
				Expression.Constant(keyValue));

			var lambdaExpr = Expression.Lambda<Func<TEntity, bool>>(binaryExpr, lambdaArgument);
			return lambdaExpr;
		}


		public EntityPrimaryKeyResolver(TContext context)
		{
			var objectContext = ((IObjectContextAdapter)context)
				.ObjectContext;

			var set = objectContext.CreateObjectSet<TEntity>();

			var keyNames = set.EntitySet.ElementType
																	.KeyMembers
																	.Select(k => k.Name)
																	.ToArray();
			if (keyNames.Length != 1)
				throw new NotSupportedException();

			_primaryKeyPropertyName = keyNames[0];
		}
	}
}
//public void SetPrimaryKeyValue(
//	TEntity entity,
//	TKey keyValue)
//{
//	PropertyInfo.SetValue(entity, keyValue);
//var lambdaArgument = Expression.Parameter(typeof(TEntity), typeof(TEntity).Name);
//Express

//var assignExpression = Expression.Assign(
//	Expression.Property(lambdaArgument, PropertyInfo.Name),
//	Expression.Constant(keyValue));

//var lambdaExpr = Expression.Lambda<Action<TEntity, TKey>>(assignExpression, lambdaArgument);
//lambdaExpr.Compile()

//}
