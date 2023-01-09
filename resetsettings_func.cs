using Godot;
using System;

public class resetsettings_func : Timer
{

    [Export] bool debug;
    bool in_settings;
    bool cangoback;
    private ConfigFile cf = new ConfigFile();
    
    public void _on_settings_node_enter_inputs()
    {
        in_settings = false;
        cangoback = false;
    }
    public void _on_titlekeys_enter_settings()
    {
    in_settings = true;
    cangoback = true;
    }
    public void _on_settings_node_returntitle()
    {
    in_settings = false;
    }
    public void _on_input_singleton_settingsreset()

    {
    if (in_settings == true && cangoback == true)
    {
    if (debug == true)
    {
    cf.Load("res://settings.cfg");
    }
    else
    {
    cf.Load("user://settings.cfg");
    }
    cf.SetValue("settings","res_value",1);
    cf.SetValue("settings","f_screen",0);
    cf.SetValue("settings","frames_ps",1);
    cf.SetValue("settings","vsync",0);
    if (debug == true)
    {
    cf.Save("res://settings.cfg");
    }
    else
    {
    cf.Save("user://settings.cfg");
    }
    cf.Clear();
    if (debug == true)
    {
    cf.Load("res://controls.cfg");
    }
    else
    {
    cf.Load("user://controls.cfg");
    }
    cf.SetValue("controls","left","a");
    cf.SetValue("controls","right","d");
    cf.SetValue("controls","up","w");
    cf.SetValue("controls","down","s");
    cf.SetValue("controls","jump","spacebar");
    cf.SetValue("controls","action","k");
    cf.SetValue("controls","toggle","l");
    if (debug == true)
    {
    cf.Save("res://controls.cfg");
    }
    else
    {
    cf.Save("user://controls.cfg");
    }
    cf.Clear();
    Start();
    }

    }

    public override void _Ready()

    {
        in_settings = false;
        cangoback = true;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
