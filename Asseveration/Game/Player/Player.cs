﻿using Godot;
namespace Asseveration.Game.Player 
{
    public class Player : KinematicBody2D
    {
        [Export]
        public int Speed = 100;
        [Export]
        public int JumpSpeed = 550;

        public Vector2 _velocity = Vector2.Zero;

        public override void _Ready()
        {

        }
    }
}
