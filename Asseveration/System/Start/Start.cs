using Godot;

public class Start : Node2D
{    
    public override void _Ready()
    {
        
    }

    public void StartNewGame()
    {
        GetTree().ChangeScene("res://Game/Intro/Intro.tscn");
    }

    public void LoadGame()
    {
        
    }

    public void OpenOptions()
    {

    }

    public void OpenCredits()
    {

    }

    public void ExitGame()
    {
        GetTree().Quit();
    }
}
