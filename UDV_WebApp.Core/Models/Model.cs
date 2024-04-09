namespace UDV_WebApp.Core.Models
{
    public abstract class Model
    {
        public Model(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
