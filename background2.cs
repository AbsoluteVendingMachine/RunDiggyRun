using Godot;
using System;

public class background2 : AnimatedSprite
{
    public override void _Ready()
    {
        var rng = new RandomNumberGenerator();
        rng.Randomize();
        string animName = ""+rng.RandiRange(1,3);
        Play(animName);
    }

}
