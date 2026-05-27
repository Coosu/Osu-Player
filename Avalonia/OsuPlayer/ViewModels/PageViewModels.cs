namespace Milki.OsuPlayer.ViewModels;

public sealed class HomePageViewModel
{
    public string PrimaryTitle => "Osu Player";

    public string SecondaryTitle => "Music Library";
}

public sealed class PlaceholderPageViewModel
{
    public PlaceholderPageViewModel(string title)
    {
        Title = title;
    }

    public string Title { get; }
}
