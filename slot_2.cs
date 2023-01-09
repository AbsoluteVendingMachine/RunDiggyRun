using Godot;
using System;
public class slot_2 : AnimatedSprite{
    bool hasShotgun;
    public override void _Ready(){
        hasShotgun = false;
        Play("slot1_0");
    }
    public void _on_shotgun_shotgunExists(){
        hasShotgun = true;
    }
    public void _on_restart_restart_game(){
        hasShotgun = false;
        Play("slot1_0");
    }
    public void _on_toggle_singleton_item1(){
        if (hasShotgun == false){
            Play("slot1_0");
        }
        else{
            Play("slot2_0");
        }
    }
    public void _on_toggle_singleton_item2(){
        if (hasShotgun == false){
            Play("slot1_1");
        }
        else{
            Play("slot2_1");
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
