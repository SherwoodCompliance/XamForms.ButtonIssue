
namespace XamForms.ButtonIssue.Views
{
    using System.IO;
    using System.Reflection;
    using System.Threading;
    
    using Autofac;

    using Xamarin.Forms;
    using Xamarin.Forms.Labs.Mvvm;
    using Xamarin.Forms.Labs.Services;
    using Xamarin.Forms.Labs.Services.Autofac;

    using XamForms.ButtonIssue.Views.ViewModels;
    using XamForms.ButtonIssue.Views.Views;

    /// <summary>
    /// The app.
    /// </summary>
    public class App
    {
        #region Static Fields
        
        /// <summary>
        /// Gets or sets the root nav page.
        /// </summary>
        private static NavigationPage RootNavPage { get; set; }
        
        /// <summary>
        /// The reflection assembly.
        /// </summary>
        private static Assembly reflectionAssembly;
        
        #endregion
        
        #region Methods and Operators

        /// <summary>
        /// The initialisation of the app.
        /// </summary>
        /// <param name="assembly">
        /// The assembly.
        /// </param>
        /// <param name="containerBuilder">
        /// The container Builder.
        /// </param>
        public static void Init(Assembly assembly, ContainerBuilder containerBuilder)
        {
            Interlocked.CompareExchange(ref reflectionAssembly, assembly, null);

            RegisterServices(containerBuilder);
            RegisterViewModels(containerBuilder);

            var autofacResolver = new AutofacResolver(containerBuilder.Build());
            containerBuilder.RegisterInstance(autofacResolver).As<IDependencyContainer>();
            Resolver.SetResolver(autofacResolver);

            RegisterViews();
            InitialiseServices();
        }
        
        /// <summary>
        /// The load resource.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Stream"/>.
        /// </returns>
        public static Stream LoadResource(string name)
        {
            return reflectionAssembly.GetManifestResourceStream(name);
        }
        
        /// <summary>
        /// The get root view page.
        /// </summary>
        /// <returns>
        /// The <see cref="Page"/>.
        /// </returns>
        public static Page GetRootNavPage()
        {
            if (RootNavPage == null)
            {
                InitialiseServices();
            }

            return RootNavPage;
        }

        /// <summary>
        /// Initialise app services
        /// </summary>
        private static void InitialiseServices()
        {
            var page = ViewFactory.CreatePage<Page1VM>();
            RootNavPage = new NavigationPage(page);

            var view = Resolver.Resolve<ViewManager>();
            view.Initialise(RootNavPage);
        }

        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ViewManager>().InstancePerLifetimeScope();
        }
        
        #endregion

        #region Private Methods

        /// <summary>
        /// The register view models.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<Page1VM>();
            builder.RegisterType<Page2VM>();
        }

        /// <summary>
        /// Register views with view factory.
        /// </summary>
        private static void RegisterViews()
        {
            ViewFactory.EnableCache = false;
            ViewFactory.Register<Page1, Page1VM>();
            ViewFactory.Register<Page2, Page2VM>();
        }

        #endregion
    }
}