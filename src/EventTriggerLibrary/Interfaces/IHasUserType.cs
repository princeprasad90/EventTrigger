namespace EventTriggerLibrary.Interfaces
{
    /// <summary>
    /// Indicates that an event includes user type information.
    /// </summary>
    public interface IHasUserType
    {
        IUserType UserType { get; }
    }
}
