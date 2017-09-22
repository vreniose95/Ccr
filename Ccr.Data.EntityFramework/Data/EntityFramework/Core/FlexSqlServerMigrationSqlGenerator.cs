using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Data.Entity.SqlServer;
using Ccr.Data.EntityFramework.SqlServer;

namespace Ccr.Data.EntityFramework.Core
{
	public class FlexSqlServerMigrationSqlGenerator
		: SqlServerMigrationSqlGenerator
	{
		protected override void Generate(AddColumnOperation addColumnOperation)
		{
			SetCreatedUtcColumn(addColumnOperation.Column);

			base.Generate(addColumnOperation);
		}

		protected override void Generate(CreateTableOperation createTableOperation)
		{
			SetCreatedUtcColumn(createTableOperation.Columns);

			base.Generate(createTableOperation);
		}

		protected override string Quote(string identifier)
		{
			return FlexSqlServer2014Service.FormatIdentifier(identifier);
		}

		protected override void GenerateCreateSchema(string schema)
		{
			base.GenerateCreateSchema(schema);
		}

		protected override void WriteCreateTable(CreateTableOperation createTableOperation)
		{
			base.WriteCreateTable(createTableOperation);
		}

		protected override void Generate(CreateIndexOperation createIndexOperation)
		{
			base.Generate(createIndexOperation);
		}

		protected override string Name(string name)
		{
			return base.Name(name);
		}

		protected override void WriteCreateTable(CreateTableOperation createTableOperation, IndentedTextWriter writer)
		{
			base.WriteCreateTable(createTableOperation, writer);
		}


		private static void SetCreatedUtcColumn(IEnumerable<ColumnModel> columns)
		{
			foreach (var columnModel in columns)
			{
				SetCreatedUtcColumn(columnModel);
			}
		}

		private static void SetCreatedUtcColumn(PropertyModel column)
		{
			if (column.Name == "CreationDateUTC")
			{
				column.DefaultValueSql = "GETUTCDATE()";
			}
		}
	}
}
