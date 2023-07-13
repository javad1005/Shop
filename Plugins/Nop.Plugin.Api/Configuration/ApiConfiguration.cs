using Nop.Core.Configuration;
using System;

namespace Nop.Plugin.Api.Configuration
{
    public class ApiConfiguration : IConfig, IDisposable
    {
        public int AllowedClockSkewInMinutes { get; set; } = 5;

        public string SecurityKey { get; set; } = "NowIsTheTimeForAllGoodMenToComeToTheAideOfTheirCountry";

        public void Dispose()
        {
        }
    }
}
