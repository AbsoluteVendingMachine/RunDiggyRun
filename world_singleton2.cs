using Godot;
using System;
public class world_singleton2 : Node{
    [Signal] public delegate void level1();
    [Signal] public delegate void level2();
    [Signal] public delegate void level3();
    [Signal] public delegate void level4();
    [Signal] public delegate void level5();
    [Signal] public delegate void level6();
    [Signal] public delegate void level7();
    [Signal] public delegate void level8();
    [Signal] public delegate void level9();
    int level;
    int world;
    public override void _Ready(){
        level = 1;
        world = 1;
    }
    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionJustPressed("world2")){
            EmitSignal("level5");
            level = 1;
            world = 2;
        }
    }
    public void _on_controls_sprite_game_start(){
        level = 1;
        world = 1;
        EmitSignal("level1");
    }
    public void _on_restart_restart_game(){
        level = 1;
        world = 1;
        EmitSignal("level1");
    }
    public void _on_world_singleton2_gotolevel9(){
        level = 1;
        world = 3;
    }

    public void _on_progress_point_newLevelPosition(){
        GD.Print("world: "+world+" | level: "+level);
        if (world == 2 && level == 4){
            EmitSignal("level9");
            GD.Print("test world 3_1");
            level = 1;
            world = 3;
        }
        if (world == 2 && level == 3){
            EmitSignal("level8");
            level = 4;
        }
        if (world == 2 && level == 2){
            EmitSignal("level7");
            level = 3;
            world = 2;
        }
        if (world == 2 && level == 1){
            EmitSignal("level6");
            level = 2;
            world = 2;
        }
        if (world == 1 && level == 4){
            EmitSignal("level5");
            level = 1;
            world = 2;
        }
        if (world == 1 && level == 3){
            EmitSignal("level4");
            level = 4;
        }
        if (world == 1 && level == 2){
            EmitSignal("level3");
            level = 3;
        }
        if (world == 1 && level == 1){
            EmitSignal("level2");
            level = 2;
        }
    }
}
