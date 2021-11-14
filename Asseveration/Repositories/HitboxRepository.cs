using Godot;
using System.Collections.Generic;

namespace Asseveration.Repositories
{
    public class HitboxRepository
    {
        public static void DisableAllHitboxes(KinematicBody2D sprite)
        {
            var children = sprite.GetChildren();
            List<CollisionPolygon2D> hitboxes = new List<CollisionPolygon2D>();
            foreach(var child in children)
            {
                if (child is CollisionPolygon2D)
                {
                    hitboxes.Add((CollisionPolygon2D)child);
                }
            }
            foreach(CollisionPolygon2D hitbox in hitboxes)
            {
                hitbox.Disabled = true;
            }
        }

        public static void EnableHitbox(CollisionPolygon2D hitbox)
        {
            hitbox.Disabled = false;
        }
    }
}
