using Asseveration.Game.Player;
using Godot;

public class IntroPlayer : Player
{
    [Export]
    public int Speed = 1000;
    [Export]
    public int JumpSpeed = 550;

    private Vector2 _velocity = Vector2.Zero;
    public override void _Ready()
    {
        
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

        if (Input.IsActionPressed("ui_up") && IsOnFloor())
        {
            _velocity.y = -JumpSpeed;
        }

        _velocity = MoveAndSlide(_velocity, Vector2.Up);

        //if (_velocity.x != 0)
        //{
        //    sprite.Animation = "walk";
        //    sprite.FlipV = false;
        //    sprite.FlipH = _velocity.x < 0;
        //    sprite.Play("walk");
        //}
        //else if (_velocity.y < 0)
        //{
        //    sprite.Play("jump");
        //}
        if (_velocity.x == 0 && _velocity.y == 0)
        {
            sprite.Play("idle");
        }
    }
}