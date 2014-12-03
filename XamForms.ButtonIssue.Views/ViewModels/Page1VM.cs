
namespace XamForms.ButtonIssue.Views.ViewModels
{
    using Xamarin.Forms;
    using Xamarin.Forms.Labs.Mvvm;

    /// <summary>
    /// The home view model.
    /// </summary>
    public class Page1VM : ViewModel
    {
        private string btnClicked;

        /// <summary>
        /// Initialises a new instance of the <see cref="Page1VM"/> class.
        /// </summary>
        public Page1VM(ViewManager viewManager)
        {
            this.ViewManager = viewManager;
            this.BtnClicked = "No button clicked yet";
        }

        public ViewManager ViewManager { get; set; }

        public Command NavigateToPage2Command
        {
            get
            {
                return new Command(() => this.ViewManager.NavigateTo<Page2VM>());
            }
        }

        public Command ClickButtonCmd
        {
            get
            {
                return new Command(
                    (btn) =>
                    {
                        this.BtnClicked = (string)btn;
                    });
            }
        }

        public string BtnClicked
        {
            get
            {
                return this.btnClicked;
            }
            set
            {
                this.SetProperty(ref this.btnClicked, "You clicked button: " + value);
            }
        }
    }
}
