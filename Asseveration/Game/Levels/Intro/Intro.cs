using Godot;

public class Intro : Node2D
{

    [Signal]
    public delegate void PlaySelectedTrack(string fileName);
    [Signal]
    public delegate void HandleCutSceneEntrance();

    public Timer ExplosionTimer;
    public Timer Dialoguetimer;

    private AnimatedSprite _shipSprite;
    private TextureRect _dialogueOverlay;
    private bool _isShipFlying = true;
    private bool _isDialogueDisplaying = false;

    public override void _Ready()
    {
        ExplosionTimer = GetNode<Timer>("ExplosionTimer");
        Dialoguetimer = GetNode<Timer>("DialogueTimer");
        _shipSprite = GetNode<AnimatedSprite>("MainLayer/Background/Starship");
        _dialogueOverlay = GetNode<TextureRect>("MainLayer/Background/DialogueOverlay");
        ExplosionTimer.WaitTime = 11;
        Dialoguetimer.WaitTime = 14;
        _dialogueOverlay.Hide();
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

        if (Dialoguetimer.IsStopped() && !_isDialogueDisplaying)
        {
            DisplayDialogue();
        }
    }

    private void StartShip()
    {
        _shipSprite.Play("idle");
    }
    private void PlayIntroMusic()
    {
        EmitSignal("PlaySelectedTrack", "The End is the Beginning is the End.wav");
    }

    private void ExplodeShip()
    {
        _isShipFlying = false;
        _shipSprite.Play("explosion");
        EmitSignal("HandleCutSceneEntrance");
    }

    private void DisplayDialogue()
    {
        _isDialogueDisplaying = true;
        _dialogueOverlay.Show();
    }
}
