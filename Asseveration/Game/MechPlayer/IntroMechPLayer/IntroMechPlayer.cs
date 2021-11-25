using Asseveration.Game.MechPlayer;
using Asseveration.Game.Weapons.Weapon_Accessories;
using Asseveration.Repositories;
using Godot;

public class IntroMechPlayer : MechPlayer
{
    [Export]
    public PackedScene PhaserBurst;

    private AnimatedSprite _sprite;
    private Vector2 _finalSpritePosition;
    private Area2D _burst;
    private MechPhaserMuzzle _phaserMuzzle;
    private bool _isEntranceMovementTriggered = false;

    public override void _Ready()
    {
        IdleHitbox = GetNode<CollisionPolygon2D>("IdleHitbox");
        ForwardHitbox = GetNode<CollisionPolygon2D>("ForwardHitbox");
        PhaserCooldown = GetNode<Timer>("PhaserCooldown");
        PhaserBurst = GD.Load<PackedScene>("res://Game/Weapons/MechProjectiles/IntroMech/IntroMechPhaserBurst.tscn");

        Speed = 1300;
        BurstDelay = (float)0.1;
        _finalSpritePosition = new Vector2((float)697.357, (float)401.194);
        _sprite = GetNode<AnimatedSprite>("IntroPlayerSprite");
        _sprite.GlobalPosition = new Vector2((float)-500.357, (float)401.194);
        _phaserMuzzle = new MechPhaserMuzzle
        {
            IdleXPositivePosition = new Vector2(100, 0),
            IdleXNegativePosition = new Vector2(-50, 0),
            MovingXPositivePosition = new Vector2(250, -55),
            MovingXNegativePosition = new Vector2(-185, -55)
        };
    }

    public override void _Process(float delta)
    {
        if (_sprite.GlobalPosition.x > _finalSpritePosition.x - 10)
        {
            _isEntranceMovementTriggered = false;
        }

        if (_isEntranceMovementTriggered)
        {
            HandleEntranceMovement();
        }
        else
        {
            HandleMovement(_sprite);

            if (Input.IsActionPressed("ui_select") && PhaserCooldown.IsStopped())
            {
                FireIntroMechPhaser();
            }
        }
    }

    public void HandleCutSceneEntrance()
    {
        _isEntranceMovementTriggered = true;
    }

    private void HandleEntranceMovement()
    {
        _velocity.x = 0;
        _sprite.Animation = "forward";
        _sprite.Play("forward");
        _velocity.x += Speed;
        _velocity = MoveAndSlide(_velocity, Vector2.Up);
    }

    private void FireIntroMechPhaser()
    {
        _burst = (Area2D)PhaserBurst.Instance();
        AddChild(_burst);
        _burst.Position += PhaserRepository.SetPhaserMuzzlePosition(_sprite, _phaserMuzzle);
        FirePhaser(_burst, _sprite);
    }
}
