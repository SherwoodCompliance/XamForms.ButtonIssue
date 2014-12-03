
namespace XamForms.ButtonIssue.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Labs.Mvvm;
    
    /// <summary>
    /// The view manager.
    /// </summary>
    public class ViewManager
    {
        /// <summary>
        /// Gets or sets a value indicating whether current page name.
        /// </summary>
        private string CurrentPageName { get; set; }

        /// <summary>
        /// Gets or sets the root navigation page.
        /// </summary>
        private NavigationPage RootNavigation { get; set; }
        
        /// <summary>
        /// The initialise navigation service.
        /// </summary>
        /// <param name="navigationPage">
        /// The navigation page.
        /// </param>
        public void Initialise(NavigationPage navigationPage)
        {
            this.RootNavigation = navigationPage;
            this.CurrentPageName = navigationPage.GetType().Name;
        }

        /// <summary>
        /// The navigate to.
        /// </summary>
        /// <typeparam name="T">
        /// View Model
        /// </typeparam>
        public void NavigateTo<T>() where T : ViewModel
        {
            this.NavigateTo<T>(null);
        }

        /// <summary>
        /// The navigate to.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <typeparam name="T">
        /// View Model
        /// </typeparam>
        public void NavigateTo<T>(object parameters) where T : ViewModel
        {
            var viewPage = ViewFactory.CreatePage<T>();
            this.RootNavigation.PushAsync(viewPage);
            this.CurrentPageName = typeof(T).Name;
        }

        /// <summary>
        /// Go back a page. If a modal is open, close it.
        /// </summary>
        public void GoBack()
        {
            this.RootNavigation.PopAsync();
        }
    }
}
