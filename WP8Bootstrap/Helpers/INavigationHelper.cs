namespace WP8Bootstrap.Helpers
{
    /// <summary> 
    /// An interface to provide navigation between pages within a ViewModel or elsewhere.
    /// </summary> 
    /// http://code.msdn.microsoft.com/wpapps/Sharing-CodeAdding-a4c4beb8
    public interface INavigationHelper
    {
        bool CanGoBack { get; }

        void GoBack();

        void Navigate<TDestinationPage>(string query = "");
    }
}
