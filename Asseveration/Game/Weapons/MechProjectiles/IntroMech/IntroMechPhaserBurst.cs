using Asseveration.Repositories;
using Godot;

public class IntroMechPhaserBurst : Area2D
{
    private float _speed = 1800;
    
    public override void _Ready()
    {

    }

    public override void _Process(float delta)
    {
        AnimatedSprite sprite = GetNode<AnimatedSprite>("PhaserBurstSprite");
        float parentPlayerVelocityX = GetParent<IntroMechPlayer>()._velocity.x;
        float movement = _speed;
        PhaserRepository.ProcessHorizontalPhaserBurstPhysics(this, sprite, parentPlayerVelocityX, movement, delta);
        sprite.Play("fire");
    }

    public void _on_PhaserBurst_body_entered(PhysicsBody2D body)
    {
        QueueFree();
        // TODO: Add signal emission and enemy HP handling here once we have enemies.
    }
}
