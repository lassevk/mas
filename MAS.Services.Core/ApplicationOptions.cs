using System;
using System.Linq;

using MAS.Services.Application;

namespace MAS.Services.Core
{
    internal class ApplicationOptions : IApplicationOptions
    {
        public ApplicationOptions()
        {
            foreach (var argument in Environment.GetCommandLineArgs().Skip(1))
            {
                if (argument.StartsWith("-"))
                {
                    switch (argument)
                    {
                        case "-v":
                        case "--verbose":
                            IsVerbose = true;
                            break;

                        case "-d":
                        case "--debug":
                            IsDebug = true;
                            break;

                        default:
                            throw new Exception($"Unknown command line option: '{argument}'");
                    }
                }
                else
                    throw new Exception($"Unknown command line argument: '{argument}'");
            }
        }

        public bool IsDebug { get; }

        public bool IsVerbose { get; }
    }
}