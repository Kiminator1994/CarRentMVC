namespace PluginInterface {
    public interface IPlugin {
        string Name { get; }
        bool Execute();
    }
}
