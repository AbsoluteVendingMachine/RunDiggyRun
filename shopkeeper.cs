using Godot;
using System;
public class shopkeeper : AnimatedSprite{
    public override void _Ready(){
        Hide();
        Play("anim");
    }
    public void _on_world_singleton_level1(){
        Hide();
    }
    public void _on_world_singleton_level2(){
        Position = new Vector2(296,501);
        Show();
    }
    public void _on_world_singleton_level3(){
        Hide();
    }
    public void _on_world_singleton_level6(){
        Position = new Vector2(584,421);
        Show();
    }
    public void _on_world_singleton_level7(){
        Hide();
    }
}
