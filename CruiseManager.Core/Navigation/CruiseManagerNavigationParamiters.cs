namespace CruiseManager.Navigation
{
    public class CruiseManagerNavigationParamiters : NavigationParamiters_Base
    {
        public string Species
        {
            get => GetValueInternal<string>();
            set => SetValueInternal(value);
        }

        public string LiveDead
        {
            get => GetValueInternal<string>();
            set => SetValueInternal(value);
        }

        public string PrimaryProduct
        {
            get => GetValueInternal<string>();
            set => SetValueInternal(value);
        }

        public string[] ProductCodeOptions
        {
            get => GetValueInternal<string[]>();
            set => SetValueInternal(value);
        }
    }
}
