using Godot;
using System;

public class titlescreen : CanvasLayer
{

[Signal] public delegate void do_intro();
public void _on_titlekeys_enter_intro()

{

Hide();
EmitSignal(nameof(do_intro));
QueueFree();

}
    public override void _Ready()
    {
        Show();
    }
  
  public override void _Process(float delta)
  { 
    
  }
}


