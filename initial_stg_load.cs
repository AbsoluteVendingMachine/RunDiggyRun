using Godot;
using System;

public class initial_stg_load : Node

{

    [Export]
    public bool debugmode2;
    
    private ConfigFile cf = new ConfigFile();

    string cfg_f_one = "settings.cfg";

    public void def_conf1()

    {

    var fill = new File();

    if (debugmode2 == true) 
    
    {

    if (fill.FileExists("res://settings.cfg") == false)
    
    {

    cf.SetValue("settings","res_value",1);
    cf.SetValue("settings","f_screen",0);
    cf.SetValue("settings","frames_ps",1);
    cf.SetValue("settings","vsync",0);
    cf.Save("res://"+cfg_f_one);
    cf.Clear();

    }

    }

    else if (debugmode2 == false) 
    
    {

    if (fill.FileExists("user://settings.cfg") == false)

    {

    cf.SetValue("settings","res_value",1);
    cf.SetValue("settings","f_screen",0);
    cf.SetValue("settings","frames_ps",1);
    cf.SetValue("settings","vsync",0);
    cf.Save("user://"+cfg_f_one);
    cf.Clear();

    }

    }

    }

    public void load_conf()

    {

    if (debugmode2 == true) 
    
    {

    var fill = new File();

    {

    cf.Load("res://settings.cfg");
    int res_ig = (int) cf.GetValue("settings","res_value");
    int fscn_ig = (int) cf.GetValue("settings","f_screen");
    int fps_ig = (int) cf.GetValue("settings","frames_ps");
    int vsync_ig = (int) cf.GetValue("settings","vsync");

    if (fscn_ig == 0)

    {
    
    OS.WindowFullscreen = false;
    OS.WindowBorderless = false;

    if (res_ig == 1)

    {

    Vector2 res_rn = new Vector2 (1280,720);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 2)

    {

    Vector2 res_rn = new Vector2 (854,480);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 3)

    {

    Vector2 res_rn = new Vector2 (640,360);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 4)

    {

    Vector2 res_rn = new Vector2 (1600,900);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 5)

    {

    Vector2 res_rn = new Vector2 (1920,1080);
    OS.WindowSize = res_rn;

    }

    }

    else if (fscn_ig == 1)

    {

    OS.WindowFullscreen = true;
    OS.WindowBorderless = true;

    if (res_ig == 1)

    {

    Vector2 res_rn = new Vector2 (1280,720);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 2)

    {

    Vector2 res_rn = new Vector2 (854,480);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 3)

    {

    Vector2 res_rn = new Vector2 (640,360);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 4)

    {

    Vector2 res_rn = new Vector2 (1600,900);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 5)

    {

    Vector2 res_rn = new Vector2 (1920,1080);
    OS.WindowSize = res_rn;

    }

    }

    if (fps_ig == 0)

    {

    Engine.TargetFps = 30;

    }

    else if (fps_ig == 1)

    {

    Engine.TargetFps = 60;

    }

    else if (fps_ig == 2)

    {

    Engine.TargetFps = 120;

    }

    else if (fps_ig == 3)

    {

    Engine.TargetFps = 144;

    }

    else if (fps_ig == 4)

    {

    Engine.TargetFps = 165;

    }

    else if (fps_ig == 5)

    {

    Engine.TargetFps = 240;
        
    }

    if (vsync_ig == 0)

    {

    OS.VsyncEnabled = true;

    }

    else if (vsync_ig == 1)

    {

    OS.VsyncEnabled = false;

    }

    }

    cf.Clear();

    }

    if (debugmode2 == false) 
    
    {

    var fill = new File();

    {

    cf.Load("user://settings.cfg");
    int res_ig = (int) cf.GetValue("settings","res_value");
    int fscn_ig = (int) cf.GetValue("settings","f_screen");
    int fps_ig = (int) cf.GetValue("settings","frames_ps");
    int vsync_ig = (int) cf.GetValue("settings","vsync");

    if (fscn_ig == 0)

    {
    
    OS.WindowFullscreen = false;
    OS.WindowBorderless = false;

    if (res_ig == 1)

    {

    Vector2 res_rn = new Vector2 (1280,720);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 2)

    {

    Vector2 res_rn = new Vector2 (854,480);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 3)

    {

    Vector2 res_rn = new Vector2 (640,360);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 4)

    {

    Vector2 res_rn = new Vector2 (1600,900);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 5)

    {

    Vector2 res_rn = new Vector2 (1920,1080);
    OS.WindowSize = res_rn;

    }

    }

    else if (fscn_ig == 1)

    {

    OS.WindowFullscreen = true;
    OS.WindowBorderless = true;

    if (res_ig == 1)

    {

    Vector2 res_rn = new Vector2 (1280,720);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 2)

    {

    Vector2 res_rn = new Vector2 (854,480);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 3)

    {

    Vector2 res_rn = new Vector2 (640,360);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 4)

    {

    Vector2 res_rn = new Vector2 (1600,900);
    OS.WindowSize = res_rn;

    }

    else if (res_ig == 5)

    {

    Vector2 res_rn = new Vector2 (1920,1080);
    OS.WindowSize = res_rn;

    }

    }

    if (fps_ig == 0)

    {

    Engine.TargetFps = 30;

    }

    else if (fps_ig == 1)

    {

    Engine.TargetFps = 60;

    }

    else if (fps_ig == 2)

    {

    Engine.TargetFps = 120;

    }

    else if (fps_ig == 3)

    {

    Engine.TargetFps = 144;

    }

    else if (fps_ig == 4)

    {

    Engine.TargetFps = 165;

    }

    else if (fps_ig == 5)

    {

    Engine.TargetFps = 240;
        
    }

    if (vsync_ig == 0)

    {

    OS.VsyncEnabled = true;

    }

    else if (vsync_ig == 1)

    {

    OS.VsyncEnabled = false;

    }

    }

    cf.Clear();

    }

    }
    
    public override void _Ready()

    {

    def_conf1();
    load_conf();
    QueueFree();

    }

}
