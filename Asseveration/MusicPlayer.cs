using Godot;

public class MusicPlayer : AudioStreamPlayer2D
{
    public override void _Ready()
    {
    }

    public void PlaySelectedTrack(string fileName)
    {
        Stream = ResourceLoader.Load<AudioStream>($"res://Assets/Music/{fileName}");
        Play();
    }
}
