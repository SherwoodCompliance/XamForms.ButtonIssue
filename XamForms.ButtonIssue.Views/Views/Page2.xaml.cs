
namespace XamForms.ButtonIssue.Views.Views
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// The home page.
    /// </summary>
    public partial class Page2 : ContentPage
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Page2"/> class.
        /// </summary>
        public Page2()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                var st = e.Message;
            }
        }

    }
}