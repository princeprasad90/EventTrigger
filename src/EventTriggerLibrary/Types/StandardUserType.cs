using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Types
{
    /// <summary>
    /// Default user classification.
    /// </summary>
    public class StandardUserType : IUserType
    {
        public string Name => "Standard";
    }
}
