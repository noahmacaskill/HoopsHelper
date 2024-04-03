using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Help;
using Spectre.Console.Rendering;

namespace HoopsHelper.Utilities
{
    public class CustomHelpProvider(ICommandAppSettings settings) : HelpProvider(settings)
    {
        public override IEnumerable<IRenderable> GetUsage(ICommandModel model, ICommandInfo? command)
        {
            var usage = base.GetUsage(model, command);

            string usageText = usage.ElementAt(0).ToString()!.Replace(model.ApplicationName, string.Empty); ;

            usage = [new Markup(usageText)];

            return usage;
        }
    }
}
