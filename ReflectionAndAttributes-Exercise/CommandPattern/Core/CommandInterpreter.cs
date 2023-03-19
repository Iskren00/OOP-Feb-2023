using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core;

public class CommandInterpreter : ICommandInterpreter
{
    public string Read(string args)
    {
        string[] arg = args
            .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

        string commandName = arg[0];

        string[] commandArg = arg
            .Skip(1)
            .ToArray();

        Type commandType = Assembly
            .GetEntryAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == $"{commandName}Command");

        if (commandType == null)
        {
            throw new ArgumentException("Command not found");
        }

        ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;

        string result = commandInstance.Execute(commandArg);

        return result;
    }
}
