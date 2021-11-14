using Asseveration.Game.Player;
using Asseveration.Repositories;
using Godot;
using System;

public class IntroPlayer : Player
{
    public override void _Ready()
    {
        Speed = 1300;
        IdleHitbox = GetNode<CollisionPolygon2D>("IdleHitbox");
        ForwardHitbox = GetNode<CollisionPolygon2D>("ForwardHitbox");
    }

    public override void _Process(float delta)
    {        
        AnimatedSprite sprite = GetNode<AnimatedSprite>("IntroPlayerSprite");
        _velocity.x = 0;
        _velocity.y = 0;

        // When the player is instantiated, all hitboxes are disabled by default.
        // Changes animations takes on the responsibility of activating hitboxes dynamically.
        HitboxRepository.DisableAllHitboxes(this);

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

        if (_velocity.x != 0 || _velocity.y != 0)
        {
            sprite.Animation = "forward";
            sprite.FlipV = false;
            sprite.FlipH = _velocity.x < 0;
            sprite.Play("forward");
            HitboxRepository.EnableHitbox(ForwardHitbox);
        }
        else
        {
            sprite.Play("idle");
            HitboxRepository.EnableHitbox(IdleHitbox);
        }

        HandlePlayerHitboxes();
    }
}
