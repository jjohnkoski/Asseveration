using Godot;

public class Intro : Node2D
{

    [Signal]
    public delegate void PlaySelectedTrack(string fileName);
    public Timer ExplosionTimer;

    private AnimatedSprite _shipSprite;
    private bool isShipExploding;
    
    public override void _Ready()
    {
        ExplosionTimer = GetNode<Timer>("ExplosionTimer");
        ExplosionTimer.WaitTime = 11;
        isShipExploding = false;
        StartShip();
        PlayIntroMusic();
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (ExplosionTimer.IsStopped())
        {
            isShipExploding = true;
        }

        if (isShipExploding)
        {
            _shipSprite.Play("explosion");
        }
    }

    private void StartShip()
    {
        _shipSprite = GetNode<AnimatedSprite>("MainLayer/Background/Starship");
        _shipSprite.Play("idle");
    }

    private void PlayIntroMusic()
    {
        EmitSignal("PlaySelectedTrack", "The End is the Beginning is the End.wav");
    }
}
