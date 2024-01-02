namespace SimpleTutorials.DPIWpf.Wpf.StartupHelpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}