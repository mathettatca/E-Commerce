using System.Reflection;
using Infrastructure.postgres;

namespace Authentication.API.Configures
{
    public static class DIAssemblies
    {
        internal static readonly Assembly[] AssembliesToScan =
        [
            typeof(Program).Assembly,
            typeof(EntityContext).Assembly,
        ];
    }
}
