using Godot;
using System;

public class deaths : Label
{
    [Export] private bool debug;
    private ConfigFile cf = new ConfigFile();
    private bool in_title;
    private bool in_stats;
    private int deaths_cnt;
    public override void _Ready()
    {
        in_title = true;
        in_stats = false;
        Hide();
    }

    public void _on_input_singleton_titleback()
    {
        if (in_title == false && in_stats == true)
        {
            in_title = true;
            in_stats = false;
            Hide();
        }
    }

    public void _on_titlekeys_enter_stats()
    {
        if (debug == true)
        {
            cf.Load("res://stats.cfg");
        }
        else
        {
            cf.Load("user://stats.cfg");
        }
        deaths_cnt = (int) cf.GetValue("stats","deaths",0);
        cf.Clear();
        if (deaths_cnt < 99999)
        {
            Text = ("Deaths: "+deaths_cnt);
        }
        else
        {
            Text = ("Deaths: Too Many!");
        }
        in_title = false;
        in_stats = true;
        Show();
    }
}
