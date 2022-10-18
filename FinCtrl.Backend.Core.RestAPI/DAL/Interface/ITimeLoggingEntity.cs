namespace FinCtrl.Backend.Core.RestAPI.DAL.Interface
{
    public interface ITimeLoggingEntity
    {
        public DateTime CreatedAt { get; }
        public DateTime LastUpdatedAt { get; }
    }
}
