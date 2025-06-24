using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Types
{
    /// <summary>
    /// Highest tier diamond user classification.
    /// </summary>
    public class DiamondUserType : IUserType
    {
        public string Name => "Diamond";
    }
}
