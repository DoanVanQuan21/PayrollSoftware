using Prism.Events;

namespace InnoSoft.Core.Events
{
    public class ChangeThemeEvent : PubSubEvent
    { }

    public class ConnectionDatabaseSuccess : PubSubEvent
    { }

    public class ExitApplicationEvent : PubSubEvent
    { }

    public class LoginSuccessEvent : PubSubEvent<bool>
    {
    }

    public class LogoutSuccessEvent : PubSubEvent
    {
    }
    public class OpenSidebarEvent : PubSubEvent
    {
    }

    public class RequiredConnectionDatabase : PubSubEvent
    { }
}