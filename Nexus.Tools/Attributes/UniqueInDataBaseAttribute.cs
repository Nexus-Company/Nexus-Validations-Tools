// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Attributes.UniqueInDataBaseAttribute
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using Microsoft.EntityFrameworkCore;
using Nexus.Tools.Validations.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Nexus.Tools.Validations.Attributes
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
  public sealed class UniqueInDataBaseAttribute : ValidationAttribute
  {
    private UniqueInDataBaseAttribute()
    {
      ErrorMessage = (string) null;
      ErrorMessageResourceType = typeof (Errors);
      ErrorMessageResourceName = "UniqueInDatabaseValidation";
    }

    public UniqueInDataBaseAttribute(Type dbType, Type dbSetClassType, string fieldName)
      : this(dbType, dbSetClassType, ((IEnumerable<PropertyInfo>) dbType.GetProperties()).FirstOrDefault<PropertyInfo>((Func<PropertyInfo, bool>) (fs => fs.PropertyType.FullName == typeof (DbSet<>).MakeGenericType(dbSetClassType).FullName)).Name, fieldName)
    {
    }

    public UniqueInDataBaseAttribute(
      Type type,
      Type classType,
      string property,
      string classProperty)
      : this()
    {
      PropertyInfo propertyInfo = type.IsSubclassOf(typeof (DbContext)) ? type.GetProperty(property) : throw new ArgumentException("The type class must be inherited from DbContext.");
      if (propertyInfo == (PropertyInfo) null)
        throw new ArgumentException("The type '" + type.FullName + "' does not contains '" + property + "' property.");
      if (propertyInfo.PropertyType != typeof (DbSet<>).MakeGenericType(classType))
        throw new ArgumentException("The type of Property It should be one DbSet type for '" + classType.FullName + "'.");
      DbContext = (DbContext) Activator.CreateInstance(type);
      ContextType = type;
      ClassType = classType;
      ContextPropertyName = property;
      ClassPropertyName = classProperty;
    }

    public DbContext DbContext { get; set; }

    public Type ContextType { get; set; }

    public Type ClassType { get; set; }

    public string ContextPropertyName { get; set; }

    public string ClassPropertyName { get; set; }

    public override bool IsValid(object value)
    {
      MethodInfo methodInfo1 = ((IEnumerable<MethodInfo>) typeof (EntityFrameworkQueryableExtensions).GetMethods()).Where<MethodInfo>((Func<MethodInfo, bool>) (fs => fs.Name == "FirstOrDefaultAsync")).ToArray<MethodInfo>()[1];
      PropertyInfo property1 = ContextType.GetProperty(ContextPropertyName);
      ClassType.GetProperty(ClassPropertyName);
      DbContext dbContext = DbContext;
      object obj1 = property1.GetValue((object) dbContext);
      Expression lambda = CreateLambda(value);
      Type[] typeArray = new Type[1]{ ClassType };
      object obj2 = methodInfo1.MakeGenericMethod(typeArray).Invoke((object) null, new object[3]
      {
        obj1,
        (object) lambda,
        null
      });
      Type type = typeof (Task<>).MakeGenericType(ClassType);
      MethodInfo methodInfo2 = ((IEnumerable<MethodInfo>) type.GetMethods()).FirstOrDefault<MethodInfo>((Func<MethodInfo, bool>) (fs => fs.GetParameters().Length < 1));
      PropertyInfo property2 = type.GetProperty("Result");
      object obj3 = obj2;
      methodInfo2.Invoke(obj3, (object[]) null);
      return property2.GetValue(obj2) == null;
    }

    private Expression CreateLambda(object value)
    {
      ParameterExpression parameterExpression = Expression.Parameter(ClassType, "p");
      BinaryExpression binaryExpression = Expression.Equal((Expression) Expression.PropertyOrField((Expression) parameterExpression, ClassPropertyName), (Expression) Expression.Constant(value));
      Type type = typeof (Func<,>).MakeGenericType(ClassType, typeof (bool));
      return (Expression) ((IEnumerable<MethodInfo>) typeof (Expression).GetMethods()).FirstOrDefault<MethodInfo>((Func<MethodInfo, bool>) (fs => fs.IsGenericMethod && fs.Name == "Lambda")).MakeGenericMethod(type).Invoke((object) null, new object[2]
      {
        (object) binaryExpression,
        (object) new ParameterExpression[1]
        {
          parameterExpression
        }
      });
    }
  }
}
