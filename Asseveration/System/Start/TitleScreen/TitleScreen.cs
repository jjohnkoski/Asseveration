using Godot;

public class TitleScreen : MarginContainer
{
    [Signal]
    public delegate void StartNewGame();

    public override void _Ready()
    {
        
    }

    public void _on_NewGameButton_pressed()
    {
        EmitSignal("StartNewGame");
    }
}
