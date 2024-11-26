namespace DILifeTime.Models
{
    public interface ITransient
    {
        Guid Guid { get; }
    }

    public interface IScoped
    {
        Guid Guid { get; }
    }

    public interface ISingleton
    {
        Guid Guid { get; }
    }

    public class Transient: ITransient
    {
        public Transient()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class Scoped : IScoped
    {
        public Scoped()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }

    public class Singleton : ISingleton
    {
        public Guid Guid { get; }
        public Singleton()
        {
            Guid = Guid.NewGuid();

        }
    }

    public class PoCService
    {
        public PoCService(ISingleton singleton, IScoped scoped, ITransient transient)
        {
            Singleton = singleton;
            Scoped = scoped;
            Transient = transient;
        }

        public ISingleton Singleton { get; }
        public IScoped Scoped { get; }
        public ITransient Transient { get; }
    }
}

