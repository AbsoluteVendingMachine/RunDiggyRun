using Godot;
using System;

public class titlescreen_background : Node2D
{
    [Signal] public delegate void background1();
    [Signal] public delegate void background2();
    [Signal] public delegate void background3();
    [Signal] public delegate void background4();
    [Signal] public delegate void background5();
    [Signal] public delegate void background6();
    double backgroundType;
    public override void _Ready(){
        var rng = new RandomNumberGenerator();
        backgroundType = Math.Floor(rng.RandfRange(1,3));
        EmitSignal("background"+backgroundType);
        Show();       
        GD.Print(backgroundType);
    }
    public void _on_controls_sprite_game_start(){
        QueueFree();
    }
}
