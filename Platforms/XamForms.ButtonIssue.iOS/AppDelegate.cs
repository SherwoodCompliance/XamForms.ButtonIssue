
namespace XamForms.ButtonIssue.iOS
{
    using System;

    using Autofac;

    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    using Xamarin.Forms;
    using Xamarin.Forms.Labs.iOS;
    using Xamarin.Forms.Labs.Mvvm;
    using Xamarin.Forms.Platform.iOS;

    using XamForms.ButtonIssue.Views;

    /// <summary>
    /// The app delegate.
    /// </summary>
    [Register("AppDelegate")]
    public class AppDelegate : XFormsApplicationDelegate
    {
        #region Fields

        /// <summary>
        /// Gets or sets the ui window.
        /// </summary>
        private UIWindow UiWindow { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The finished launching.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.InitialiseApp();

            this.UiWindow = new UIWindow(UIScreen.MainScreen.Bounds);
            UINavigationBar.Appearance.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
            UINavigationBar.Appearance.TintColor = Color.Blue.ToUIColor();
            UINavigationBar.Appearance.BarTintColor = UIColor.White;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });

            this.BuildRootView();

            return true;
        }
        
        #endregion

        #region Methods

        /// <summary>
        /// The initialise app.
        /// </summary>
        private void InitialiseApp()
        {
            AppDomain.CurrentDomain.UnhandledException += this.HandleUnhandledException;

            var builder = new ContainerBuilder();
            this.ConfigurePlatformSpecificServices(builder);
            App.Init(typeof(App).Assembly, builder);
            Forms.Init();
        }

        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private void ConfigurePlatformSpecificServices(ContainerBuilder builder)
        {
            var app = new XFormsAppiOS();
            app.Init(this);
            builder.RegisterInstance(app).As<IXFormsApp>();
        }

        /// <summary>
        /// The build view.
        /// </summary>
        private void BuildRootView()
        {
            this.UiWindow.RootViewController = App.GetRootNavPage().CreateViewController();
            this.UiWindow.MakeKeyAndVisible();
        }

        /// <summary>
        /// When app-wide unhandled exceptions are hit, this will handle them. Be aware however, that typically
        /// android will be destroying the process, so there's not a lot you can do on the android side of things,
        /// but your xamarin code should still be able to work. so if you have a custom err logging manager or 
        /// something, you can call that here. You _won't_ be able to call Android.Util.Log, because Dalvik
        /// will destroy the java side of the process.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        protected void HandleUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            // log won't be available, because dalvik is destroying the process
            //Log.Debug (logTag, "MyHandler caught : " + e.Message);
            // instead, your err handling code shoudl be run:
            Console.WriteLine("========= MyHandler caught : " + e.Message);
        }

        #endregion
    }
}