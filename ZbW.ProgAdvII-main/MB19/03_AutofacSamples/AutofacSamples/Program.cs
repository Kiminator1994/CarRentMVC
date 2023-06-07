using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace AutofacSamples {
    public interface ILog {
        void Write(string message);
    }

    public interface IConsole {

    }

    public class RabbitHoleLog : ILog {
        public void Write(string message) {
        }
    }

    public class ConsoleLog : ILog, IConsole {
        public ConsoleLog() {
            // für Breakpoint
        }
        public void Write(string message) {
            Console.WriteLine(message);
        }
    }

    public class EmailLog : ILog {
        private const string adminEmail = "admin@foo.com";

        public void Write(string message) {
            Console.WriteLine($"Email sent to {adminEmail} : {message}");
        }
    }

    public class SmsLog : ILog {
        public void Write(string message) {
            Console.WriteLine($"SMS sent to 075 409 00 00 : {message}");
        }
    }

    public class Engine {
        private ILog log;
        private int id;

        public Engine(ILog log) {
            this.log = log;
            id = new Random().Next();
        }

        public Engine(ILog log, int id) {
            this.log = log;
            this.id = id;
        }

        public void Ahead(int power) {
            log.Write($"Engine [{id}] ahead {power}");
        }
    }

    public class Car {
        private Engine engine;
        private ILog log;

        //public Car(Engine engine) {
        //    this.engine = engine;
        //    this.log = new EmailLog();
        //}

        //public Car(Engine engine, ILog log) {
        //    this.engine = engine;
        //    this.log = log;
        //}

            public Car(ILog log) {
            this.log = log;
        }
        public void Go() {
            engine?.Ahead(100);
            log.Write("Car going forward...");
        }
    }

    internal class Program {
        public static void Main(string[] args) {
            DemoMultipleComponents();
            DemoNoSingleton();
            DemoSingleton();
            DemoInstanceScope();
            PropertyAndMethodInjectionDemo();
            DemoScanningTypes();

            var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleLog>().As<ILog>();
            builder.RegisterType<RabbitHoleLog>().As<ILog>();

            //builder.RegisterType<Engine>();
            builder.RegisterType<Car>();

            // Register with delegate
            builder.Register((IComponentContext c) => new Engine(c.Resolve<ILog>(), 123));

            IContainer container = builder.Build();

            var car = container.Resolve<Car>();
            car.Go();
        }

        public static void DemoMultipleComponents() {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmailLog>().As<ILog>();
            builder.RegisterType<ConsoleLog>().As<ILog>();

            IContainer container = builder.Build();

            var log = container.Resolve<IEnumerable<ILog>>();

            // *** the last one registered
            var l = container.Resolve<ILog>();
        }

        public static void DemoInstanceScope() {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>().InstancePerMatchingLifetimeScope("foo");

            var container = builder.Build();

            using (var scope1 = container.BeginLifetimeScope("foo")) {
                for (int i = 0; i < 3; i++) {
                    scope1.Resolve<ConsoleLog>();
                }

                using (var scope2 = scope1.BeginLifetimeScope()) {
                    for (int i = 0; i < 3; i++) {
                        scope2.Resolve<ConsoleLog>();
                    }
                }
            }


            using (var scope3 = container.BeginLifetimeScope()) {
                scope3.Resolve<ConsoleLog>();
            }
        }

        public static void DemoNoSingleton() {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>();

            var container = builder.Build();

            for (int i = 0; i < 3; i++) {
                container.Resolve<ConsoleLog>();
            }

        }
        public static void DemoSingleton() {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>().SingleInstance();

            var container = builder.Build();

            for (int i = 0; i < 3; i++) {
                container.Resolve<ConsoleLog>();
            }
        }

        public static void PropertyAndMethodInjectionDemo() {
            // anstatt Constructor-Injection
            var builder = new ContainerBuilder();
            builder.RegisterType<Parent>();

            // ****** Version 1
            //builder.RegisterType<Child>();
            //var container = builder.Build();
            //var parent = container.Resolve<Child>().Parent;
            //Console.WriteLine(parent);    // parent ist null


            // ****** Version 2
            // Autofac probiert jedes Property aufzulösen
            //builder.RegisterType<Child>().PropertiesAutowired();
            //var container = builder.Build();
            //var parent = container.Resolve<Child>().Parent;
            //Console.WriteLine(parent);


            // ****** Version 3
            // nur spezifisches Property
            //builder.RegisterType<Child>().WithProperty("Parent", new Parent());
            //var container = builder.Build();
            //var parent = container.Resolve<Child>().Parent;
            //Console.WriteLine(parent);

            // ****** Version 4
            // MethodInjection mit Registration-Lambda
            builder.Register(c => {
                var child = new Child();
                child.SetParent(c.Resolve<Parent>());
                return child;
            });
            var container = builder.Build();
            var parent = container.Resolve<Child>().Parent;
            Console.WriteLine(parent);


            // ****** Version 5
            // MethodInjection mit OnActivated-Event
            //builder.RegisterType<Child>()
            //    .OnActivated((IActivatedEventArgs<Child> e) => {
            //        var p = e.Context.Resolve<Parent>();
            //        e.Instance.SetParent(p);
            //    });
            //var container = builder.Build();
            //var parent = container.Resolve<Child>().Parent;
            //Console.WriteLine(parent);
        }

        public class Parent {
            public override string ToString() {
                return "I am your father";
            }
        }

        public class Child {
            public string Name { get; set; }
            public Parent Parent { get; set; }

            public void SetParent(Parent parent) {
                Parent = parent;
            }
        }

        public static void DemoScanningTypes() {
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly)
                //.Where(t => t.Name.EndsWith("Log"))
                .Except<SmsLog>()
                .Except<ConsoleLog>(c => c.As<ILog>().SingleInstance());

            IContainer container = builder.Build();

            var car = container.Resolve<Car>();
            car.Go();

            //var log = container.Resolve<ConsoleLog>(); // Fehler, nicht so registriert
            var log = container.Resolve<ILog>();
        }
    }
}