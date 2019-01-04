using System.Collections.Generic;

namespace CommandPattern
{
    public class CommandExecutor
    {
        public void DoIt(Context context, LinkedList<Command> commands)
        {
            var command = commands.First;
            while (command != null)
            {
                if (command.Value.ShouldExecute(context))
                {
                    command.Value.Execute(context);
                }

                command = command.Next;
            }
        }
    }
}