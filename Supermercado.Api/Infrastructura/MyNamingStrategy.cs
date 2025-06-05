using NHibernate.Cfg;

namespace Supermercado.Api.Infrastructura
{
    public class MyNamingStrategy : INamingStrategy
    {
        public string ClassToTableName(string className) => className;
        public string PropertyToColumnName(string propertyName) => propertyName;
        public string TableName(string tableName) => tableName;
        public string ColumnName(string columnName) => columnName;
        public string PropertyToTableName(string className, string propertyName) => propertyName;
        public string LogicalColumnName(string columnName, string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
