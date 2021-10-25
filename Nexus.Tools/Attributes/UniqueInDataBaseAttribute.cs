using Microsoft.EntityFrameworkCore;
using Nexus.Tools.Validations.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
    /// <summary>
    /// Validate whether the object field is unique in the database.
    /// </summary>
    public sealed class UniqueInDataBaseAttribute : ValidationAttribute
    {

        private UniqueInDataBaseAttribute() : base()
        {
            ErrorMessage = null;
            ErrorMessageResourceType = typeof(Errors);
            ErrorMessageResourceName = "UniqueInDatabaseValidation";
        }
        /// <summary>
        /// Constructor for DbSet type, DbContext type and Validation Field name.
        /// </summary>
        /// <param name="dbType">Type of DbContext</param>
        /// <param name="dbSetClassType">Type of DbSet class</param>
        /// <param name="fieldName">Class property name of validation</param>
        public UniqueInDataBaseAttribute(Type dbType, Type dbSetClassType, string fieldName) :
            this(dbType,
                dbSetClassType,
            dbType.GetProperties().FirstOrDefault(fs => fs.PropertyType.FullName == typeof(DbSet<>).MakeGenericType(dbSetClassType).FullName).Name,
            fieldName)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Type of DbContext</param>
        /// <param name="property">DbContext dbset Property Name</param>
        /// <param name="classProperty">Property name of class unique</param>
        /// <param name="classType">Type of DbSet class</param>
        public UniqueInDataBaseAttribute(Type type, Type classType, string property, string classProperty) : this()
        {
            if (!type.IsSubclassOf(typeof(DbContext)))
                throw new ArgumentException("The type class must be inherited from DbContext.");

            PropertyInfo propertyInfo = type.GetProperty(property);

            if (propertyInfo == null)
                throw new ArgumentException($"The type '{type.FullName}' does not contains '{property}' property.");

            if (propertyInfo.PropertyType != typeof(DbSet<>).MakeGenericType(classType))
                throw new ArgumentException($"The type of Property It should be one DbSet type for '{classType.FullName}'.");

            DbContext = (DbContext)Activator.CreateInstance(type);
            ContextType = type;
            ClassType = classType;
            ContextPropertyName = property;
            ClassPropertyName = classProperty;
        }
        /// <summary>
        /// Database Entity Framework Context
        /// </summary>
        public DbContext DbContext { get; set; }
        /// <summary>
        /// Type of Database Context
        /// </summary>
        public Type ContextType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Type ClassType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContextPropertyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClassPropertyName { get; set; }
        public override bool IsValid(object value)
        {
            Type enumarableType = typeof(EntityFrameworkQueryableExtensions);
            MethodInfo firstMethod = enumarableType.GetMethods().Where(fs => fs.Name == "FirstOrDefaultAsync").ToArray()[1];
            PropertyInfo propertyInfo = ContextType.GetProperty(ContextPropertyName);
            PropertyInfo classProperty = ClassType.GetProperty(ClassPropertyName);

            object dbSet = propertyInfo.GetValue(DbContext);
            Expression lambda = CreateLambda(value);

            firstMethod = firstMethod.MakeGenericMethod(ClassType);
            var queryableType = typeof(IQueryable<>).MakeGenericType(propertyInfo.PropertyType);
            var invokeResult = firstMethod.Invoke(null, new[] { dbSet, lambda, null });

            Type taskType = typeof(Task<>).MakeGenericType(ClassType);
            MethodInfo waitTaskMethod = taskType.GetMethods().FirstOrDefault(fs => fs.GetParameters().Length < 1);
            PropertyInfo taskResultProperty = taskType.GetProperty("Result");
            waitTaskMethod.Invoke(invokeResult, null);

            object taskResult = taskResultProperty.GetValue(invokeResult);
            if (taskResult == null)
                return true;

            return false;
        }
        private Expression CreateLambda(object value)
        {
            var param = Expression.Parameter(ClassType, "p");
            var len = Expression.PropertyOrField(param, ClassPropertyName);
            var body = Expression.Equal(
                len, Expression.Constant(value));

            Type funcType = typeof(Func<,>).MakeGenericType(ClassType, typeof(bool));

            MethodInfo methodInfo = typeof(Expression).GetMethods().FirstOrDefault(fs => fs.IsGenericMethod == true && fs.Name == "Lambda");
            methodInfo = methodInfo.MakeGenericMethod(funcType);
            var lmb = methodInfo.Invoke(null, new object[] { body, new ParameterExpression[] { param } });

            return (Expression)lmb;
        }
    }
}