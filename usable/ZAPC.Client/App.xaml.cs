using System.Windows;

namespace ZAPC.Client
{
    using System;
    using ZAPC.BikWorker;
    using ZAPC.Client.Essentials;
    using ZAPC.Client.ServerObject;
    using ZAPC.Core;
    using ZAPC.Core.Configuration;
    using ZAPC.Core.Logging;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public static IBikWorker BikWorker { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Config.Configuration = new AppConfigConfiguration();
            Log.Logger = new MessageBoxLogger();
            Container.ServerObject = new ClientServerObject();

            FrameworkElement.StyleProperty.OverrideMetadata(
                typeof(Window),
                new FrameworkPropertyMetadata { DefaultValue = FindResource(typeof(Window)) });

            // TODO: remove after settings will be created
            Global.OperationDay = new DateTime(2018, 1, 17);

            BikWorker = new BikWorker(Container.ServerObject, Log.Logger);
        }
    }
}
