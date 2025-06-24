namespace EventTriggerLibrary.Interfaces
{
    /// <summary>
    /// Provides the classification for a user (Standard, Gold, etc.).
    /// </summary>
    public interface IUserType
    {
        string Name { get; }
    }
}
