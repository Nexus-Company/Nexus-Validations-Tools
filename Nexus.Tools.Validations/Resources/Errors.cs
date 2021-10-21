// Decompiled with JetBrains decompiler
// Type: Nexus.Tools.Validations.Resources.Errors
// Assembly: Nexus.Tools.Validations, Version=1.0.3.0, Culture=neutral, PublicKeyToken=ee7faefdb387cffb
// MVID: 673DBDAF-EC06-4C60-8C3A-88354CD59F73
// Assembly location: D:\Repositories\SexyCity\SexyCity.Web\bin\Debug\net5.0\Nexus.Tools.Validations.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Nexus.Tools.Validations.Resources
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  public class Errors
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Errors()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static ResourceManager ResourceManager
    {
      get
      {
        if (Errors.resourceMan == null)
          Errors.resourceMan = new ResourceManager("Nexus.Tools.Validations.Resources.Errors", typeof (Errors).Assembly);
        return Errors.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
      get => Errors.resourceCulture;
      set => Errors.resourceCulture = value;
    }

    public static string CnpjValidation => Errors.ResourceManager.GetString(nameof (CnpjValidation), Errors.resourceCulture);

    public static string CompareValidation => Errors.ResourceManager.GetString(nameof (CompareValidation), Errors.resourceCulture);

    public static string ContainsValidation => Errors.ResourceManager.GetString(nameof (ContainsValidation), Errors.resourceCulture);

    public static string CpfOrCnpjValidation => Errors.ResourceManager.GetString(nameof (CpfOrCnpjValidation), Errors.resourceCulture);

    public static string CpfValidation => Errors.ResourceManager.GetString(nameof (CpfValidation), Errors.resourceCulture);

    public static string EmailValidation => Errors.ResourceManager.GetString(nameof (EmailValidation), Errors.resourceCulture);

    public static string MinYearsLestedsValidation => Errors.ResourceManager.GetString(nameof (MinYearsLestedsValidation), Errors.resourceCulture);

    public static string Name => Errors.ResourceManager.GetString(nameof (Name), Errors.resourceCulture);

    public static string NameValidation => Errors.ResourceManager.GetString(nameof (NameValidation), Errors.resourceCulture);

    public static string PasswordValidation => Errors.ResourceManager.GetString(nameof (PasswordValidation), Errors.resourceCulture);

    public static string PhoneValidation => Errors.ResourceManager.GetString(nameof (PhoneValidation), Errors.resourceCulture);

    public static string RequiredValidation => Errors.ResourceManager.GetString(nameof (RequiredValidation), Errors.resourceCulture);

    public static string SmallStringLengthValidation => Errors.ResourceManager.GetString(nameof (SmallStringLengthValidation), Errors.resourceCulture);

    public static string StringLengthValidation => Errors.ResourceManager.GetString(nameof (StringLengthValidation), Errors.resourceCulture);

    public static string TimeSpanValidation => Errors.ResourceManager.GetString(nameof (TimeSpanValidation), Errors.resourceCulture);

    public static string UniqueInDatabaseValidation => Errors.ResourceManager.GetString(nameof (UniqueInDatabaseValidation), Errors.resourceCulture);

    public static string ZipCodeValidation => Errors.ResourceManager.GetString(nameof (ZipCodeValidation), Errors.resourceCulture);
  }
}
