using System;
using System.Collections.Generic;
using Autofac;

namespace CommandPattern
{
    public class CommandFactory
    {
        private readonly IComponentContext _componentContext;

        public CommandFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        public LinkedList<Command> GetCommands()
        {
            var commandTypes = new List<Type>
            {
                typeof(PreProcessCommand),
                typeof(ProcessOrderCommand),
                typeof(CapturePaymentCommand),
                typeof(ActivateProductCommand)
            };
            var commandInstances = new List<Command>();
            foreach (var type in commandTypes)
            {
                var instance = _componentContext.Resolve(type);
                commandInstances.Add((Command)instance);
            }

            return new LinkedList<Command>(commandInstances);
        }
    }
}