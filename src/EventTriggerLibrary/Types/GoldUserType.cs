using EventTriggerLibrary.Interfaces;

namespace EventTriggerLibrary.Types
{
    /// <summary>
    /// Premium gold user classification.
    /// </summary>
    public class GoldUserType : IUserType
    {
        public string Name => "Gold";
    }
}
