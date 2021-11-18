using Godot;

namespace Asseveration.Game.Weapons.Weapon_Accessories
{
    // Position2D is not playing nice with the MechPlayer.
    // This file allows for manually adding a position variant for phaser
    // bursts so the burst origin looks correct on the sprite. This may
    // require some better math if we need to rescale sprites.
    public class MechPhaserMuzzle
    {
        public Vector2 IdleXPositivePosition { get; set; } 
        public Vector2 IdleXNegativePosition { get; set; }
        public Vector2 MovingXPositivePosition { get; set; }
        public Vector2 MovingXNegativePosition { get; set; }
    }
}
