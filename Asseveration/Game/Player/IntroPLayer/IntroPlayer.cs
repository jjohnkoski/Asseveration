using Asseveration.Game.Player;
using Godot;

public class IntroPlayer : Player
{
    
    public override void _Ready()
    {
        Speed = 1300;
    }

    public override void _Process(float delta)
    {
        AnimatedSprite sprite = GetNode<AnimatedSprite>("IntroPlayerSprite");
        _velocity.x = 0;
        _velocity.y = 0;

        if (Input.IsActionPressed("ui_right"))
        {
            _velocity.x += Speed;
        }
        if (Input.IsActionPressed("ui_left"))
        {
            _velocity.x -= Speed;
        }
        if (Input.IsActionPressed("ui_up"))
        {
            _velocity.y -= Speed;
        }
        if (Input.IsActionPressed("ui_down"))
        {
            _velocity.y += Speed;
        }

        _velocity = MoveAndSlide(_velocity, Vector2.Up);

        if (_velocity.x != 0)
        {
            sprite.Animation = "forward";
            sprite.FlipV = false;
            sprite.FlipH = _velocity.x < 0;
            sprite.Play("forward");
        }
        else
        {
            sprite.Play("idle");
        }
    }
}
