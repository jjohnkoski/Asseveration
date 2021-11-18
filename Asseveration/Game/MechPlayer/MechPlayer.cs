using Asseveration.Repositories;
using Godot;

namespace Asseveration.Game.MechPlayer 
{
    public class MechPlayer : KinematicBody2D
    {
        [Export]
        public int Speed;
        [Export]
        public float BurstDelay;

        public Vector2 _velocity = Vector2.Zero;
        public CollisionPolygon2D IdleHitbox;
        public CollisionPolygon2D ForwardHitbox;
        public Timer PhaserCooldown;

        public override void _Ready()
        {

        }

        public void HandleMovement(AnimatedSprite sprite)
        {
            _velocity.x = 0;
            _velocity.y = 0;

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

            SetMechPlayerHitboxes();
        }

        public void FirePhaser(Area2D phaserBurst, AnimatedSprite sprite)
        {
            PhaserCooldown.Start(BurstDelay);
            SetPhaserBurstHorizontalDirection(phaserBurst, sprite);
        }

        private void SetMechPlayerHitboxes()
        {
            IdleHitbox.Disabled = !ForwardHitbox.Disabled;
            ForwardHitbox.Disabled = !IdleHitbox.Disabled;
        }

        private void SetPhaserBurstHorizontalDirection(Area2D phaserBurst, AnimatedSprite playerSprite)
        {
            AnimatedSprite phaserBurstSprite = phaserBurst.GetNode<AnimatedSprite>("PhaserBurstSprite");
            phaserBurstSprite.FlipH = playerSprite.FlipH;
        }
    }
}
