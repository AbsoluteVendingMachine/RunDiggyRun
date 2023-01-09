using Godot;
using System;

public class level_timer : Label
{
    [Signal] public delegate void timeLimitPassed();
    decimal time;
    bool countingAllowed;
    bool overTimeLimit;
    bool timeLimitPassable;
    public override void _Ready(){
        countingAllowed = true;
        time = 0;
        overTimeLimit = false;
        Show();
    }
    public void _on_ig_timer_counter_timeout(){
        time = time+1;
        if (countingAllowed == true){
            if (time < 599){
                if ((time-((Math.Floor(time/60))*60)) < 10){
                Text = Math.Floor(time/60)+":0"+(time-((Math.Floor(time/60))*60));
                }
                else if ((time-((Math.Floor(time/60))*60)) >= 10){
                Text = Math.Floor(time/60)+":"+(time-((Math.Floor(time/60))*60));
                }
            }
            else{
                Text = "9:59";
            }
            if (time > 119){
                if (overTimeLimit == false && timeLimitPassable == true){
                    GD.Print("It comes.");
                    EmitSignal("timeLimitPassed");
                    overTimeLimit = true;
                }
            }
        }
    }
    public void _on_world_singleton_level2(){
        overTimeLimit = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton_level3(){
        overTimeLimit = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton_level4(){
        overTimeLimit = false;
        timeLimitPassable = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton_level5(){
        overTimeLimit = false;
        timeLimitPassable = true;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton_level6(){
        overTimeLimit = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton_level7(){
        overTimeLimit = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton_level8(){
        overTimeLimit = false;
        timeLimitPassable = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_rabbit_boss_rabbitBossDeath(){
        overTimeLimit = false;
        timeLimitPassable = true;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton2_level10(){
        overTimeLimit = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_world_singleton2_finalboss(){
        overTimeLimit = false;
        timeLimitPassable = false;
        time = 0;
        Text = "0:00";
    }
    public void _on_player_death(){
        overTimeLimit = false;
        countingAllowed = false;
    }
    public void _on_restart_restart_game(){
        overTimeLimit = false;
        timeLimitPassable = true;
        countingAllowed = true;
        time = 0;
        if (countingAllowed == true){
            if (time < 599){
                if ((time-((Math.Floor(time/60))*60)) < 10){
                Text = Math.Floor(time/60)+":0"+(time-((Math.Floor(time/60))*60));
                }
                else if ((time-((Math.Floor(time/60))*60)) >= 10){
                Text = Math.Floor(time/60)+":"+(time-((Math.Floor(time/60))*60));
                }
            }
            else{
                Text = "9:59";
            }
        }
    }
}
