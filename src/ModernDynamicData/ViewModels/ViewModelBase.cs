namespace ModernDynamicData.ViewModels
{
    public abstract class ViewModelBase
    {
        public virtual string Title { get; set; } = "Modern Dynamic Data";
        public string Version { get; set; }
    }
}