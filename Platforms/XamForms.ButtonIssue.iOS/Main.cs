
namespace XamForms.ButtonIssue.iOS
{
    using System;

    using MonoTouch.UIKit;

    /// <summary>
    /// The application.
    /// </summary>
    public class Application
    {
        // This is the main entry point of the application.
        #region Methods

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            try
            {
                // if you want to use a different Application Delegate class from "AppDelegate"
                // you can specify it here.
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception e)
            {
                var error = e.Message;
            }
        }

        #endregion
    }
}