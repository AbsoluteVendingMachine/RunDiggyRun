using Godot;
using System;

public class health : AnimatedSprite
{
    int local_health;

    public void _on_restart_restart_game(){
        Play("3");
    }
    public void _on_player_healthIncrease(){
        if (Animation == "1"){
            Play("2");
        }
        else if (Animation == "2"){
            Play("3");
        }
        else if (Animation == "3"){
            Play("4");
        }
        else if (Animation == "4"){
            Play("5");
        }
        else if (Animation == "5"){
            Play("6");
        }
    }
    public void _on_rabbit_boss_rabbitBossDeath(){
        if (Animation == "1"){
            Play("3");
        }
        else if (Animation == "2"){
            Play("4");
        }
        else if (Animation == "3"){
            Play("5");
        }
        else if (Animation == "4"){
            Play("6");
        }
    }
    public void _on_heart_jar_fullHeal(){
        Play("6");
    }
    public void _on_greed_jar_greedJar(){
        Play("1");
    }
    public override void _Ready()
    {
        Play("3");
    }

    public void _on_hurt_timer_hurt()
    {
        if (Animation == "6")
        {
            Play("5");
        }
        else if (Animation == "5")
        {
            Play("4");
        }
        else if (Animation == "4")
        {
            Play("3");
        }
        else if (Animation == "3")
        {
            Play("2");
        }
        else if (Animation == "2")
        {
            Play("1");
        }
        else if (Animation == "1")
        {
            Play("1");
        }
    }   
}
