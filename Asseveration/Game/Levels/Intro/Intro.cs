using Godot;

public class Intro : Node2D
{

    [Signal]
    public delegate void PlaySelectedTrack(string fileName);
    
    public override void _Ready()
    {
        PlayIntroMusic();
    }

    public void PlayIntroMusic()
    {
        EmitSignal("PlaySelectedTrack", "The End is the Beginning is the End.wav");
    }
}
