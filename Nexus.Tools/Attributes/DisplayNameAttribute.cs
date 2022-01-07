 using System;


#nullable enable
namespace Nexus.Tools.Validations.Attributes
{
    public class DisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        private string? _displayName;

        public DisplayNameAttribute(string displayName) => _displayName = displayName;

        public DisplayNameAttribute(Type resourceType, string resourceName)
        {
            ResourceType = resourceType;
            ResourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                if (_displayName != null)
                    return _displayName;

                if (ResourceName == null || !(ResourceType != null))
                    return string.Empty;

                object obj = ResourceType.GetProperty(ResourceName).GetValue(null, null);
                return obj is string str ? str : obj.ToString();
            }
        }

        public

    Type? ResourceType
        { get; set; }

        public string? ResourceName { get; set; }
    }
}
#nullable disable