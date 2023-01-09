using Godot;
using System;
public class slot_1 : AnimatedSprite{
    bool hasSuper;
    public override void _Ready(){
        hasSuper = false;
        Play("slot1_1");
    }
    public void _on_restart_restart_game(){
        hasSuper = false;
        Play("slot1_1");
    }
    public void _on_toggle_singleton_item1(){
        if (hasSuper == false){
            Play("slot1_1");
        }
        else{
            Play("slot2_1");
        }
    }
    public void _on_toggle_singleton_item2(){
        if (hasSuper == false){
            Play("slot1_0");
        }
        else{
            Play("slot2_0");
        }
    }
    public void _on_player_get_super(){
        hasSuper = true;
    }
}
