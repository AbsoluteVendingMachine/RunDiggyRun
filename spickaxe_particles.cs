using Godot;
using System;

public class spickaxe_particles : CPUParticles2D
{

    public override void _Ready()
    {
        Emitting = false;
        Hide();
    }

    public void _on_spickaxe_singleton_reset_position()
    {
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/spickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/superpickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_particle_timer_timeout()
    {
        Hide();
        Emitting = false;
    }
}
