using Atlas.Components.Security;
using System.Diagnostics.CodeAnalysis;

namespace Atlas.Tests.Unit.Components.Security
{
    [AllowUnauthorized]
    [ExcludeFromCodeCoverage]
    public class AllowUnauthorizedController : AuthorizedController
    {
    }
}
