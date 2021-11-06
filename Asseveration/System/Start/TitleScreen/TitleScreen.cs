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

    public override void _Ready()
    {
        
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
}
