using Asseveration.Game.MechPlayer;
using Asseveration.Game.Weapons.Weapon_Accessories;
using Asseveration.Repositories;
using Godot;

public class IntroMechPlayer : MechPlayer
{
    [Export]
    public PackedScene PhaserBurst;

    private AnimatedSprite _sprite;
    private Area2D _burst;
    private MechPhaserMuzzle _phaserMuzzle;

    public override void _Ready()
    {
        Speed = 1300;
        BurstDelay = (float) 0.1;
        IdleHitbox = GetNode<CollisionPolygon2D>("IdleHitbox");
        ForwardHitbox = GetNode<CollisionPolygon2D>("ForwardHitbox");
        PhaserCooldown = GetNode<Timer>("PhaserCooldown");
        PhaserBurst = GD.Load<PackedScene>("res://Game/Weapons/MechProjectiles/IntroMech/IntroMechPhaserBurst.tscn");
        _sprite = GetNode<AnimatedSprite>("IntroPlayerSprite");
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
        HandleMovement(_sprite);

        if (Input.IsActionPressed("ui_select") && PhaserCooldown.IsStopped())
        {
            FireIntroMechPhaser();
        }
    }

    private void FireIntroMechPhaser()
    {
        _burst = (Area2D)PhaserBurst.Instance();        
        AddChild(_burst);
        _burst.Position += PhaserRepository.SetPhaserMuzzlePosition(_sprite, _phaserMuzzle);
        FirePhaser(_burst, _sprite);
    }
}
