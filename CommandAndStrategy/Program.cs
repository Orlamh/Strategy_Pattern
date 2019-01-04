using System;
using System.Reflection;
using Autofac;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            var context = new Context { PurchasedProduct = ProductType.Subscription, PurchaseAction = PurchaseAction.Renewal};
            var commands = container.Resolve<CommandFactory>().GetCommands();
            new CommandExecutor().DoIt(context, commands);
            Console.ReadLine();
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            builder.RegisterType<CommandFactory>();
            builder.RegisterType<PreProcessCommand>();
            builder.RegisterType<ProcessOrderCommand>();
            builder.RegisterType<CapturePaymentCommand>();
            builder.RegisterType<ActivateProductCommand>();

            return builder.Build();
        }
    }
}
