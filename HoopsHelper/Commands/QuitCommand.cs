using Spectre.Console.Cli;

namespace HoopsHelper.Commands
{
    public class QuitCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            return 1;
        }
    }
}
