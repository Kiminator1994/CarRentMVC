using System;
using PluginInterface;

namespace WorkflowPlugin {
    public class Plugin : IPlugin {
        public string Name { get; } = "WorkflowPlugin";

        public bool Execute() {
            Console.WriteLine($"Execute {this.Name}.");
            return true;
        }
    }
}
