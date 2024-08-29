namespace SuperAutoMachines.Gui.Location
{
    public interface IServiceLocator<T>
    {
        void Register(string key, Func<T> serviceFactory);
        T GetService(string key);
        void RegisterServicesFromConfig();
    }
}