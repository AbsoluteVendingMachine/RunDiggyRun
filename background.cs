using Godot;
using System;

public class background : AnimatedSprite
{
    
    public override void _Ready()
    {
        Offset = new Vector2(0,0);
    }

    public override void _PhysicsProcess(float delta)
    {
        var player_ = GetNode<KinematicBody2D>("/root/game/game_scene/player");
        Offset = new Vector2(-((player_.Position.x-640)/100),0);
    }
}
