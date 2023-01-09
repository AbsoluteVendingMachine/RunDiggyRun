using Godot;
using System;

public class settings_updater : Node
{
[Export] bool debug_on;
private ConfigFile cf = new ConfigFile();
bool update_flag;

    public override void _Ready()
    {
        update_flag = false;
    }

public void _on_settings_node_returntitle()

{

update_flag = true;

}

  public override void _Process(float delta)
 {

     if (update_flag == true)

     {
     
     update_flag = false;
     if (debug_on == true)

     {

     cf.Load("res://settings.cfg");

     }

     else

     {

     cf.Load("user://settings.cfg");

     }

     int var1 = (int) cf.GetValue("settings","f_screen");

     if (var1 == 0)

     {

     
     OS.WindowFullscreen = false;
     OS.WindowBorderless = false;

     }

     else

     {

     OS.WindowFullscreen = true;
     OS.WindowBorderless = false;

     }
     GD.Print("fullscreen"+OS.WindowFullscreen);
     int var2 = (int) cf.GetValue("settings","frames_ps");

     if (var2 == 0)

     {

     Engine.TargetFps = 30;

     }

     else if (var2 == 1)

     {

     Engine.TargetFps = 60;

     }

     else if (var2 == 2)

     {

     Engine.TargetFps = 120;

     }

     else if (var2 == 3)

     {

     Engine.TargetFps = 144;

     }
     
     else if (var2 == 4)

     {

     Engine.TargetFps = 165;

     }

     else if (var2 == 5)

     {

     Engine.TargetFps = 240;

     }
     GD.Print("fps:"+Engine.TargetFps);
     int var3 = (int) cf.GetValue("settings","res_value");
     Vector2 windowsize;

     if (var3 == 1)

     {

     windowsize = new Vector2 (1280,720);
     OS.WindowSize = windowsize;

     }

     if (var3 == 2)

     {

     windowsize = new Vector2 (854,480);
     OS.WindowSize = windowsize;

     }

     if (var3 == 3)

     {

     windowsize = new Vector2 (640,360);
     OS.WindowSize = windowsize;
         
     }

     if (var3 == 4)

     {
        
     windowsize = new Vector2 (1600,900);
     OS.WindowSize = windowsize;

     }
     
     if (var3 == 5)

     {

     windowsize = new Vector2 (1920,1080);
     OS.WindowSize = windowsize;

     }
     GD.Print("windowsize: "+OS.WindowSize);
     int var4 = (int) cf.GetValue("settings","vsync");

     if (var4 == 0)

     {

     OS.VsyncEnabled = true;

     }

     else

     {

     OS.VsyncEnabled = false;

     }
     GD.Print("vsync: "+OS.VsyncEnabled);

     }

     }

 }
