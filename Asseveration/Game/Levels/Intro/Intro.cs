using Godot;

public class Intro : Node2D
{

    [Signal]
    public delegate void PlaySelectedTrack(string fileName);
    [Signal]
    public delegate void HandleCutSceneEntrance();

    public Timer ExplosionTimer;

    private AnimatedSprite _shipSprite;
    private bool _isShipFlying = true;

    public override void _Ready()
    {
        ExplosionTimer = GetNode<Timer>("ExplosionTimer");
        _shipSprite = GetNode<AnimatedSprite>("MainLayer/Background/Starship");
        ExplosionTimer.WaitTime = 11;

        StartShip();
        PlayIntroMusic();
    }

    public override void _Process(float delta)
    {
        base._Process(delta);

        if (ExplosionTimer.IsStopped() && _isShipFlying)
        {
            ExplodeShip();
        }
    }

    private void StartShip()
    {
        _shipSprite.Play("idle");
    }

    private void ExplodeShip()
    {
        _isShipFlying = false;
        _shipSprite.Play("explosion");
        EmitSignal("HandleCutSceneEntrance");
    }

    private void PlayIntroMusic()
    {
        EmitSignal("PlaySelectedTrack", "The End is the Beginning is the End.wav");
    }
}
