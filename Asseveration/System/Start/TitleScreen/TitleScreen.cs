using Godot;

public class TitleScreen : MarginContainer
{
    [Signal]
    public delegate void StartNewGame();
    [Signal]
    public delegate void LoadGame();
    [Signal]
    public delegate void OpenOptions();
    [Signal]
    public delegate void OpenCredits();
    [Signal]
    public delegate void ExitGame();
    [Signal]
    public delegate void PlaySelectedTrack(string fileName);

    public override void _Ready()
    {
        PlayTitleMusic();
    }

    public void PlayTitleMusic()
    {
        EmitSignal("PlaySelectedTrack", "Asseveration.wav");
    }

    public void _on_NewGameButton_pressed()
    {
        EmitSignal("StartNewGame");
    }

    public void _on_LoadGameButton_pressed()
    {
        EmitSignal("LoadGame");
    }

    public void _on_OptionsButton_pressed()
    {
        EmitSignal("OpenOptions");
    }

    public void _on_CreditsButton_pressed()
    {
        EmitSignal("OpenCredits");
    }

    public void _on_ExitGameButton_pressed()
    {
        EmitSignal("ExitGame");
    }
}
