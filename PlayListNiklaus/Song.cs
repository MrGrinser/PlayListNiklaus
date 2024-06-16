public class Song : BindableObject
{
    private bool _isSelected;

    public string Title { get; set; }
    public string Duration { get; set; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            OnPropertyChanged();
        }
    }
}
