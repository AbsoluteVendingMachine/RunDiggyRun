using Godot;
using System;

public class level : Label
{
    int world;
    int lvl;
    public override void _Ready()
    {
        lvl = 1;
        world = 1;
        Text = world+"-"+lvl;
    }
    public void updateText(){
        Text = world+"-"+lvl;
    }
    public void _on_world_singleton_level1(){
        lvl = 1;
        world = 1;
        updateText();
    }
    public void _on_world_singleton_level2(){
        lvl = 2;
        world = 1;
        updateText();
    }
    public void _on_world_singleton_level3(){
        lvl = 3;
        world = 1;
        updateText();
    }
    public void _on_world_singleton_level4(){
        lvl = 4;
        Text = "1-B";
    }
    public void _on_world_singleton_level5(){
        lvl = 1;
        world = 2;
        updateText();
    }
    public void _on_world_singleton_level6(){
        lvl = 2;
        world = 2;
        updateText();
    }
    public void _on_world_singleton_level7(){
        lvl = 3;
        world = 2;
        updateText();
    }
    public void _on_world_singleton_level8(){
        lvl = 4;
        Text = "2-B";
    }
    public void _on_rabbit_boss_rabbitBossDeath(){
        lvl = 1;
        world = 3;
        updateText();
    }
    public void _on_world_singleton2_level10(){
        lvl = 2;
        world = 3;
        updateText();
    }
    public void _on_world_singleton2_finalboss(){
        lvl = 4;
        Text = "3-B";
    }
    public void _on_restart_restart_game(){
        lvl = 1;
        world = 1;
        Text = world+"-"+lvl;
    }
    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
