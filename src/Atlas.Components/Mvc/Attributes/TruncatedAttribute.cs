using System;

namespace Atlas.Components.Mvc
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class TruncatedAttribute : Attribute
    {
    }
}
