namespace LogLibrary
{
    public interface ILogDestination
    {
        void AddLog(LogMessage message);
    }
}
