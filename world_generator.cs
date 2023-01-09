using Godot;
using System;

public class world_generator : Node2D
{
    int world;
    int level;
    int tile_set;
    public override void _Ready()
    {
        Hide();    
    }

    public void _on_controls_sprite_game_start()
    {
        generate_world();
    }

    public void generate_world()
    {
        
    }

}
