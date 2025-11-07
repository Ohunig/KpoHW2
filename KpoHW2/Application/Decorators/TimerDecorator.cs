using System.Diagnostics;
using System.Text;

public class TimerDecorator(ICommand wrappee) : BaseDecorator(wrappee)
{
    public override string Execute()
    {
        StringBuilder message = new StringBuilder();
        var sw = Stopwatch.StartNew();
        message.AppendLine(base.Execute());
        sw.Stop();
        message.AppendLine($"Time elapsed: {sw.ElapsedMilliseconds}ms");
        return message.ToString();
    }
}