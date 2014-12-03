
namespace XamForms.ButtonIssue.Views.Views
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    /// The home page.
    /// </summary>
    public partial class Page1 : ContentPage
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Page1"/> class.
        /// </summary>
        public Page1()
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

        #endregion
    }
}