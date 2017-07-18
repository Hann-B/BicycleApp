namespace Bicycle.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new Bicycle.App());
        }
    }
}