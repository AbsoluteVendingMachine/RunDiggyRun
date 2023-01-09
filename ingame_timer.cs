using Godot;
using System;

public class ingame_timer : Label
{
    decimal time;
    string time_display;
    bool countingAllowed;

    public void _on_ig_timer_counter_timeout()
    {
        if (countingAllowed == true){
        time = time+1;
        if ((time-((Math.Floor(time/60))*60)) < 10)
        {
            time_display = Math.Floor(time/60)+":0"+(time-((Math.Floor(time/60))*60));
        }
        else if ((time-((Math.Floor(time/60))*60)) >= 10)
        {
            time_display = Math.Floor(time/60)+":"+(time-((Math.Floor(time/60))*60));
        }
        Text = time_display;
        }
        //GD.Print(time_display);
    }

    public void _on_player_death(){
        countingAllowed = false;
    }
    
    public void _on_restart_restart_game(){
        countingAllowed = true;
        time = 0;
        if (countingAllowed == true){
        if ((time-((Math.Floor(time/60))*60)) < 10)
        {
            time_display = Math.Floor(time/60)+":0"+(time-((Math.Floor(time/60))*60));
        }
        else if ((time-((Math.Floor(time/60))*60)) >= 10)
        {
            time_display = Math.Floor(time/60)+":"+(time-((Math.Floor(time/60))*60));
        }
        Text = time_display;
        }
    }

    public override void _Ready()
        
    {
        countingAllowed = true;
        time = 0; 
        Show();
    }
}
