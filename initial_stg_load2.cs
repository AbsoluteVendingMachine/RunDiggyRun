using Godot;
using System;

public class initial_stg_load2 : Node

{
    [Export]
    public bool debugmode;
    public string cfgname = "stats.cfg";

    private ConfigFile cf = new ConfigFile();
    
    public override void _Ready()

    {
        
    var fl = new File();

    if (debugmode == true)

    {

    if (fl.FileExists("res://stats.cfg") == false)

    {

    cf.SetValue("stats","deaths",0);
    cf.Save("res://"+cfgname);
    cf.Clear();

    }

    }

    else if (debugmode == false)

    {

    if (fl.FileExists("user://stats.cfg") == false)

    {

    cf.SetValue("stats","deaths",0);
    cf.Save("user://"+cfgname);
    cf.Clear();

    }

    }

    }

}
