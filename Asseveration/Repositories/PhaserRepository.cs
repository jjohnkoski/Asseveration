using Asseveration.Game.Weapons.Weapon_Accessories;
using Godot;

namespace Asseveration.Repositories
{
    public class PhaserRepository
    {
        public static void ProcessHorizontalPhaserBurstPhysics(Area2D phaserBurst,
            AnimatedSprite sprite, float parentPlayerVelocityX, float movement, float delta)
        {
            // Burst facing positive x axis
            if (!sprite.FlipH)
            {
                // Compensating for player x axis movement
                if (parentPlayerVelocityX != 0)
                {
                    movement = movement - parentPlayerVelocityX;
                }
                phaserBurst.Position += phaserBurst.Transform.x * movement * delta;
            }
            // Burst facing negative x axis
            else
            {
                // Compensating for player x axis movement
                if (parentPlayerVelocityX != 0)
                {
                    movement = movement + parentPlayerVelocityX;
                }
                phaserBurst.Position -= phaserBurst.Transform.x * movement * delta;
            }
            if (phaserBurst.Position.x > 2000)
            {
                phaserBurst.QueueFree();
            }
        }

        public static Vector2 SetPhaserMuzzlePosition(AnimatedSprite sprite, MechPhaserMuzzle muzzle)
        {
            // Sprite facing positive x axis
            if (!sprite.FlipH)
            {
                if (sprite.Animation.ToLower() == "idle")
                {
                    return muzzle.IdleXPositivePosition;
                }
                else
                {
                    return muzzle.MovingXPositivePosition;
                }
            }
            // Sprite facing negative x axis
            else
            {
                if (sprite.Animation.ToLower() == "idle")
                {
                    return muzzle.IdleXNegativePosition;
                }
                else
                {
                    return muzzle.MovingXNegativePosition;
                }
            }
        }
    }
}
