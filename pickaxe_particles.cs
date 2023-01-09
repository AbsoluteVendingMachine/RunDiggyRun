using Godot;
using System;

public class pickaxe_particles : CPUParticles2D
{

    public override void _Ready()
    {
        Emitting = false;
        Hide();
    }

    public void _on_bat_bat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bat2_bat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rat1_rat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rat2_rat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bat3_bat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bat4_bat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rat3_rat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rat4_rat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rat5_rat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rat6_rat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rat7_rat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bush2_bushDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rabbit1_rabbitDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rabbit2_rabbitDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rabbit3_rabbitDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rabbit4_rabbitDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rabbit5_rabbitDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bush5_bushDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bush6_bushDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_flower5_flowerDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_flower6_flowerDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }
    
    public void _on_bat5_bat_death(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bat_boss_boss1Hit(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_flower3_flowerDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bush3_bushDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bush4_bushDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_flower4_flowerDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_pickaxe_singleton_reset_position()
    {
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_flower1_flowerDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_flower2_flowerDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_bush1_bushDeath(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_rabbit_boss_rabbitBossHit(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_plat_walker1_enemy_hit_platwalker(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_plat_walker2_enemy_hit_platwalker(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_plat_walker3_enemy_hit_platwalker(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_plat_walker4_enemy_hit_platwalker(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_sword_walker1_enemy_hit_swordwalker(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_sword_walker2_enemy_hit_swordwalker(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_sword_walker3_enemy_hit_swordwalker(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }

    public void _on_final_boss_finalBossHit(){
        if (Emitting == false)
        {
            GetNode<Timer>("/root/game/game_scene/pickaxe_particles/particle_timer").Start();
            Show();
            Position = GetNode<KinematicBody2D>("/root/game/game_scene/pickaxe").Position;
            Emitting = true;
        }
    }
    
    public void _on_particle_timer_timeout()
    {
        Hide();
        Emitting = false;
    }
}
    
    
