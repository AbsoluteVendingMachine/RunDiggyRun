using Godot;
using System;

public class player : KinematicBody2D
{
    [Signal] public delegate void ending1();
    [Signal] public delegate void ending2();
    [Signal] public delegate void ending3();
    [Signal] public delegate void ending4();
    [Signal] public delegate void ending5();
    [Signal] public delegate void killfinal();
    [Signal] public delegate void walk();
    [Signal] public delegate void jump();
    [Signal] public delegate void idle();
    [Signal] public delegate void action();
    [Signal] public delegate void lunge();
    [Signal] public delegate void hurt();
    [Signal] public delegate void hurt_signal();
    [Signal] public delegate void damage_received();
    [Signal] public delegate void death();
    [Signal] public delegate void get_jetpack();
    [Signal] public delegate void jetpack();
    [Signal] public delegate void jetpack_over();
    [Signal] public delegate void get_super();
    [Signal] public delegate void left();
    [Signal] public delegate void right();
    [Signal] public delegate void causeOfDeath1();
    [Signal] public delegate void lootbag1Bought();
    [Signal] public delegate void lootbag2Bought();
    [Signal] public delegate void lootbag3Bought();
    [Signal] public delegate void healthIncrease();
    [Signal] public delegate void getShotty();
    int fuel;
    public Vector2 player_direction;
    Vector2 jump_thing;
    float lunge_velocity = 80;
    float x_velocity;
    float player_gravity = 8;
    float max_fallspeed = 1000;
    float min_fallspeed = 50;
    float jump_force = 175;   
    int local_death;
    [Export] int health;
    bool has_super;
    bool has_jetpack;
    bool IsCursed;
    bool IsNoHit;
    bool IsSecret;
    bool CanChangeEnding;
    bool IsRich;
    public bool in_game_;
    public bool in_air;
    public bool in_lunge;
    public bool can_attack;
    public bool hurt_cooldown;
    bool can_jetpack;
    bool in_boss_level;
    bool SpecialTeleport;
    public Vector2 player_position;
    private ConfigFile config = new ConfigFile();
    int money;
    int lootType;
    public void _on_jump_released(){
        if (in_game_ && IsOnFloor()){
            jump_thing.y = -5;
            jump_thing = MoveAndSlide(jump_thing,Vector2.Up);
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/jump2.wav");
            _sfx.Play();
            player_direction.y =- jump_force;
        }
        else if (in_game_ && !IsOnFloor() && !in_lunge && !has_jetpack || in_game_ && !IsOnFloor() && !in_lunge && has_jetpack && in_boss_level){
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/lunge2.wav");
            _sfx.Play();
            in_lunge = true;
            player_direction.y = -50;
            var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
            if (player_sprite.FlipH == false)
            {
                lunge_velocity = 60;
            }
            else
            {
                lunge_velocity = -60;
            } 
        }
    }
    public void _on_attack_released(){
        if (can_attack){
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            if (has_super == true){
                 _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/throw2.wav");
                _sfx.Play();
            }
            else{
                _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/throw.wav");
                _sfx.Play();
            }
            if (!hurt_cooldown == true)
        {
            EmitSignal(nameof(action));
        }
        can_attack = false;
        }
    }
    public void _on_attack_up_released(){
        if (can_attack){
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            if (has_super == true){
                 _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/throw2.wav");
                _sfx.Play();
            }
            else{
                _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/throw.wav");
                _sfx.Play();
            }
            if (!hurt_cooldown == true)
        {
            EmitSignal(nameof(action));
        }
        can_attack = false;
        }
    }
    public void _on_attack_down_released(){
        if (can_attack){
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            if (has_super == true){
                 _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/throw2.wav");
                _sfx.Play();
            }
            else{
                _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/throw.wav");
                _sfx.Play();
            }
            if (!hurt_cooldown == true)
        {
            EmitSignal(nameof(action));
        }
        can_attack = false;
        }
    }
    public void updateMoney(){
        //GD.Print("going through money");
        var coins = GetNode<Label>("/root/game/game_scene/player/player_cam/hud/coins");
        coins.Text = "Coins: "+money;
    }
    public void _on_final_boss_killAll(){
        in_game_ = false;
        if (IsNoHit){
            EmitSignal("ending5");
        }
        else if (!IsRich && !IsSecret && !IsCursed && !IsNoHit){
            EmitSignal("ending1");
        }
        else if (IsCursed){
            EmitSignal("ending2");
        }
        QueueFree();
    }
    public void getMoney(){
        var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
        sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/money.wav");
        sfx.Play();
        var rng = new RandomNumberGenerator();
        rng.Randomize();
        if (lootType == 1){
            money = money+rng.RandiRange(7,12);
        }
        if (lootType == 2){
            money = money+rng.RandiRange(14,29);
        }
        if (lootType == 3){
            money = money+rng.RandiRange(29,61);
        }
    }
    public void _on_greed_jar_greedJar(){
        IsCursed = true;
        money = -99;
        health = 1;
    }
    public void _on_bat1_bat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_bat2_bat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_bat3_bat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_bat4_bat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_rat3_rat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_bush5_bushDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_bush6_bushDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_flower5_flowerDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_flower6_flowerDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_rat4_rat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_rat1_rat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_rat2_rat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_rat5_rat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_rat6_rat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_rat7_rat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_bat5_bat_death(){
        lootType = 1;
        getMoney();
    }
    public void _on_flower1_flowerDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_flower2_flowerDeath(){
        lootType = 2;
        getMoney();
    }

    public void _on_bush1_bushDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_bush2_bushDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_rabbit1_rabbitDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_rabbit2_rabbitDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_rabbit3_rabbitDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_bush3_bushDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_rabbit4_rabbitDeath(){
        lootType = 2;
    }
    public void _on_bush4_bushDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_flower3_flowerDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_flower4_flowerDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_plat_walker1_enemy_hit_platwalker(){
        lootType = 3;
        getMoney();
    }
    public void _on_plat_walker2_enemy_hit_platwalker(){
        lootType = 3;
        getMoney();
    }
    public void _on_plat_walker3_enemy_hit_platwalker(){
        lootType = 3;
        getMoney();
    }
    public void _on_plat_walker4_enemy_hit_platwalker(){
        lootType = 3;
        getMoney();
    }
    public void _on_sword_walker1_enemy_hit_swordwalker(){
        lootType = 3;
        getMoney();
    }
    public void _on_sword_walker2_enemy_hit_swordwalker(){
        lootType = 3;
        getMoney();
    }
    public void _on_sword_walker3_enemy_hit_swordwalker(){
        lootType = 3;
        getMoney();
    }
    public void _on_shotgun_getShottyMoneyBack(){
        if (lootType == 1){
                money = money+33;
            }
            else if (lootType == 2){
                money = money+58;
            }
            else if (lootType == 3){
                money = money+107;
            }
    }
    public void getJetpack(){
            var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/get.wav");
            sfx.Play();
            has_jetpack = true;
            EmitSignal("get_jetpack");
            GD.Print("has_jetpack = "+has_jetpack);
    }
    public void getSuper(){
        var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/get.wav");
            sfx.Play();
            has_super = true;
            EmitSignal("get_super");
            GD.Print("has_super = "+has_super);
    }
    public void is_focused()
    {
        if (in_game_){
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
        if (OS.IsWindowFocused() == false)
        {
            _sfx.VolumeDb = -15;
        }
        else if (OS.IsWindowFocused() == true)
        {
            _sfx.VolumeDb = -5; 
        }
        }
    }

    public void _on_bat_enemy_damage1(){
    //dont touch idk what it does but it works and its fine so dont touch :)))))
    }

    public void add_death()
    {
        var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
        _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/hurt.wav");
        _sfx.Play();
        local_death = local_death+1;
        config.Load("res://stats.cfg");
        config.SetValue("stats","deaths",local_death);
        config.Save("res://stats.cfg");
        config.Clear();
        hurt_cooldown = false;
    }
    public void _on_lootbag3_item1Get(){
        if (health < 6){
            health = health+1;
            EmitSignal("healthIncrease");
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/health.wav");
            _sfx.Play();
        }
        else{
            if (lootType == 1){
                money = money+33;
            }
            else if (lootType == 2){
                money = money+58;
            }
            else if (lootType == 3){
                money = money+107;
            }
        }
    }
    public void _on_lootbag3_item2Get(){
        EmitSignal("getShotty");
    }
    public void _on_lootbag1_item2Get(){
        EmitSignal("getShotty");
    }
    public void _on_lootbag2_item1Get(){
        if (health < 6){
            health = health+1;
            EmitSignal("healthIncrease");
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/health.wav");
            _sfx.Play();
        }
        else{
            if (lootType == 1){
                money = money+33;
            }
            else if (lootType == 2){
                money = money+58;
            }
            else if (lootType == 3){
                money = money+107;
            }
        }
    }
    public void _on_lootbag2_item2Get(){
        EmitSignal("getShotty");
    }
    public void _on_lootbag1_item1Get(){
        if (health < 6){
            health = health+1;
            EmitSignal("healthIncrease");
            var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
            _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/health.wav");
            _sfx.Play();
        }
        else{
            if (lootType == 1){
                money = money+33;
            }
            else if (lootType == 2){
                money = money+58;
            }
            else if (lootType == 3){
                money = money+107;
            }
        }
    }
    public void _on_lootbag3_item3Get(){
        if (has_jetpack == false){
            getJetpack();
        }
        else{
            if (lootType == 1){
                money = money+33;
            }
            else if (lootType == 2){
                money = money+58;
            }
            else if (lootType == 3){
                money = money+107;
                if (health < 6){
                health = health+1;
                EmitSignal("healthIncrease");
                var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
                _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/health.wav");
                _sfx.Play();
                }
            }
        }
    }
    public void _on_lootbag2_item3Get(){
        if (has_jetpack == false){
            getJetpack();
        }
        else{
            if (lootType == 1){
                money = money+33;
            }
            else if (lootType == 2){
                money = money+58;
            }
            else if (lootType == 3){
                money = money+107;
                if (health < 6){
                health = health+1;
                EmitSignal("healthIncrease");
                var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
                _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/health.wav");
                _sfx.Play();
                }
            }
        }
    }
    public void _on_lootbag1_item3Get(){
        if (has_jetpack == false){
            getJetpack();
        }
        else{
            if (lootType == 1){
                money = money+33;
            }
            else if (lootType == 2){
                money = money+58;
            }
            else if (lootType == 3){
                money = money+107;
                if (health < 6){
                health = health+1;
                EmitSignal("healthIncrease");
                var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
                _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/health.wav");
                _sfx.Play();
                }
            }
        }
    }
    public override void _Ready()
    {
        var player_cam = GetNode<Camera2D>("/root/game/game_scene/player/player_cam");
        var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
        player_sprite.FlipH = false;
        player_cam.Current = false;
        in_game_ = false;
        in_air = false;
        can_attack = true;
        has_super = false;
        has_jetpack = false;
        hurt_cooldown = false;
        Hide();
        can_jetpack = false;
    }

    public void _on_debug_timer_timeout()
    {
        //GD.Print("in_air: "+in_air);
        //GD.Print(can_attack);
    }

    public void get_death()
    {
        config.Load("res://stats.cfg");
        local_death = (int) config.GetValue("stats","deaths");
        config.Clear();
    }

    public void _on_hurt_timer_timeout()
    {
        EmitSignal("damage_received");
        GD.Print("reached");
        hurt_cooldown = false;
    }

    public void take_damage()
    {
        var _sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
        _sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/hurt.wav");
        _sfx.Play();
        hurt_cooldown = true;
        health = health-1;
        IsNoHit = false;
        if (health < 1)
        {
            in_game_ = false;
            add_death();
            EmitSignal("death");
            Hide();
        }
        EmitSignal("hurt_signal");

    }

    public void _on_hurt_timer_hurt()
    {
        take_damage();
        GD.Print("health:"+health+"& hurt_cooldown:"+hurt_cooldown);
    }

    public void _on_restart_restart_game(){
        reset_state();
    }

    public void _on_world_singleton_level4(){
        in_boss_level = true;
    }

    public void _on_world_singleton_level5(){
        in_boss_level = false;
    }

    public void _on_world_singleton_level8(){
        in_boss_level = true;
    }

    public void _on_world_singleton2_finalboss(){
        in_boss_level = true;
        SpecialTeleport = true;
        Position = new Vector2 (650, 260);
    }
    
    public void reset_state()
    {
        IsCursed = false;
        IsNoHit = true;
        IsSecret = false;
        IsRich = false;
        CanChangeEnding = true;
        SpecialTeleport = false;
        money = 0;
        health = 3;
        Position = new Vector2(26,670);
        in_boss_level = false;
        can_jetpack = false;
        fuel = 105;
        var player_cam = GetNode<Camera2D>("/root/game/game_scene/player/player_cam");
        var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
        player_sprite.FlipH = false;
        x_velocity = 0;
        player_direction.x = 0;
        player_cam.Current = true;
        hurt_cooldown = false;
        in_game_ = true;
        in_air = false;
        in_lunge = false;
        can_attack = true;
        has_jetpack = false;
        has_super = false;
        Show();
    }
    public void _on_lootbag1_lootbag1_1(){
        lootType = 1;
        if (money > 24){
            EmitSignal("lootbag1Bought");
            money = money-25;
        }
    }
    public void _on_bat_boss_boss1Dead(){
        money += 33;
    }
    public void _on_rabbit_boss_rabbitBossDeath(){
        if (health < 5){
            health += 2;
        }
        in_boss_level = false;
        money += 65;
        in_game_ = false;
        Position = new Vector2(26,670);
        fuel = 90;
        var player_cam = GetNode<Camera2D>("/root/game/game_scene/player/player_cam");
        var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
        player_sprite.FlipH = false;
        x_velocity = 0;
        player_direction.x = 0;
        hurt_cooldown = false;
        in_air = false;
        in_lunge = false;
        can_attack = true;
        in_game_ = true;
    }
    public void _on_rabbit5_rabbitDeath(){
        lootType = 2;
        getMoney();
    }
    public void _on_lootbag3_lootbag3_1(){
        lootType = 1;
        if (money > 24){
            EmitSignal("lootbag3Bought");
            money = money-25;
        }
    }
    public void _on_lootbag3_lootbag3_2(){
        lootType = 2;
        if (money > 49){
            EmitSignal("lootbag3Bought");
            money = money-50;
        }
    }
    public void _on_lootbag3_lootbag3_3(){
        lootType = 3;
        if (money > 99){
            EmitSignal("lootbag3Bought");
            money = money-100;
        }
    }
    public void _on_lootbag1_lootbag1_2(){
        lootType = 2;
        if (money > 49){
            EmitSignal("lootbag1Bought");
            money = money-50;
        }
    }
    public void _on_lootbag1_lootbag1_3(){
        lootType = 3;
        if (money > 99){
            EmitSignal("lootbag1Bought");
            money = money-100;
        }
    }
    public void _on_lootbag2_lootbag2_1(){
        lootType = 1;
        if (money > 24){
            EmitSignal("lootbag2Bought");
            money = money-25;
        }
    }
    public void _on_lootbag2_lootbag2_2(){
        lootType = 2;
        if (money > 49){
            EmitSignal("lootbag2Bought");
            money = money-50;
        }
    }
    public void _on_lootbag2_lootbag2_3(){
        lootType = 3;
        if (money > 99){
            EmitSignal("lootbag2Bought");
            money = money-100;
        }
    }
    public void _on_shotgun_knockbackDown(){
        player_direction.y = 30;
    }
    public void _on_shotgun_knockbackLeft(){
        x_velocity = -120;
    }
    public void _on_shotgun_knockBackRight(){
        x_velocity = 120;
    }
    public void _on_shotgun_knockbackUp(){
        player_direction.y = -128;
    }

    public void _on_progress_point_newLevelPosition(){
        if (SpecialTeleport == false){
            Position = new Vector2(26,670);
        }
        else{
            Position = new Vector2 (650, 260);
        }
        fuel = 90;
        var player_cam = GetNode<Camera2D>("/root/game/game_scene/player/player_cam");
        var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
        player_sprite.FlipH = false;
        x_velocity = 0;
        player_direction.x = 0;
        hurt_cooldown = false;
        in_air = false;
        in_lunge = false;
        can_attack = true;
    }

    public void _on_controls_sprite_game_start()
    {
        get_death();
        var player_cam = GetNode<Camera2D>("/root/game/game_scene/player/player_cam");
        var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
        player_sprite.FlipH = false;
        player_direction.x = 0;
        player_cam.Current = true;
        hurt_cooldown = false;
        health = 3;
        in_game_ = true;
        in_air = false;
        in_lunge = false;
        x_velocity = 0;
        can_attack = true;
        Show();
    }

    public void _on_super_altar_getSuperPickaxe(){
        getSuper();
        Position = new Vector2(863,328);
    }

    public void _on_pickaxeanim_timer_timeout()
    {
        can_attack = true;
    }

    public void _on_heart_jar_fullHeal(){
        health = 6;
    }

    public override void _PhysicsProcess(float delta)
    {   //GD.Print(CanChangeEnding);
        if (in_game_){
            //GD.Print(player_direction.y);
            if (has_jetpack && has_super && !IsSecret){
                IsSecret = true;
                EmitSignal("ending5");
            }
            if (money > 660 && !IsRich){
                IsRich = true;
                EmitSignal("ending4");
            }
        }
        if (in_game_){
            if (Input.IsActionJustPressed("killfinalboss")){
                EmitSignal("killfinal");
            }
        }
        if (in_game_){
            updateMoney();
        }
        if (in_game_ == true && has_jetpack == true && !in_boss_level && !IsOnFloor() && GetNode<TouchScreenButton>("/root/game/mobile_controls/jump").IsPressed() && can_jetpack == true)
        {
            if (fuel > 0){
                var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
                player_direction.y = -120;
                fuel = fuel-3;
                sfx.Stream = GD.Load<AudioStream>("res://assets/audio/sfx/jetpack2.wav");
                var rng = new RandomNumberGenerator();
                rng.Randomize();
                if (rng.RandiRange(1,2) == 1){
                    EmitSignal("jetpack");
                    sfx.Play();
                }
                else{
                    EmitSignal("jetpack_over");
                }
            }
            else if (fuel <= 0){
                EmitSignal("jetpack_over");
            }
        }
        if (!IsOnFloor() && GetNode<TouchScreenButton>("/root/game/mobile_controls/jump").IsPressed()){
            can_jetpack = true;
        }
        if (IsOnFloor() && in_game_ == true && Input.IsActionJustPressed("fix_anim_bug")){
            GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx").Stream = GD.Load<AudioStream>("res://assets/audio/sfx/fixanimbug.wav");
            GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx").Play();
            fuel = 90;
            var player_cam = GetNode<Camera2D>("/root/game/game_scene/player/player_cam");
            var player_sprite_ = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
            player_sprite_.FlipH = false;
            x_velocity = 0;
            player_direction.x = 0;
            hurt_cooldown = false;
            in_air = false;
            in_lunge = false;
            can_attack = true;

        }
        if (in_game_ == true && has_jetpack == false && Input.IsActionPressed("give_jetpack"))
        {
            getJetpack();
        }
        if (in_game_ == true && has_super == false && Input.IsActionPressed("give_super"))
        {
            getSuper();
        }
        if (hurt_cooldown == true)
        {
            EmitSignal("hurt");
        }
        is_focused();
        if (Position.y > 720)
        {
            //GD.Print(health);
            EmitSignal("causeOfDeath1");
            if (SpecialTeleport == false){
                Position = new Vector2 (26, 670);
            }
            else{
                Position = new Vector2 (650, 260);
            }
        }
        player_position = new Vector2 (Position);
        player_direction.x = x_velocity+lunge_velocity;
        if (in_game_ == true)
        {
        if (in_lunge == true){
            var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
            if (player_sprite.FlipH == false)
            {
                lunge_velocity = 60;
            }
            else
            {
                lunge_velocity = -60;
            }
        }
        if (!IsOnFloor()){
            player_direction.y += player_gravity;
        }
        if (player_direction.y > max_fallspeed)
        {
            player_direction.y = max_fallspeed;
        }
        if (IsOnFloor())
        {
            can_jetpack = false;
            fuel = 90;
            lunge_velocity = 0;
            in_lunge = false;
            in_air = false;
            if (!hurt_cooldown == true && !GetNode<TouchScreenButton>("/root/game/mobile_controls/left").IsPressed() && !GetNode<TouchScreenButton>("/root/game/mobile_controls/right").IsPressed() && can_attack == true)
            {
                EmitSignal(nameof(idle));
            }
            if (!GetNode<TouchScreenButton>("/root/game/mobile_controls/attack").IsPressed())
            {
                 if (!hurt_cooldown == true && GetNode<TouchScreenButton>("/root/game/mobile_controls/left").IsPressed() || GetNode<TouchScreenButton>("/root/game/mobile_controls/right").IsPressed() && can_attack == true)
            {
                EmitSignal(nameof(walk));
            }
            }
            player_direction.y = min_fallspeed;
        }
        if (!IsOnFloor())
        {
            in_air = true;
        }
        if (!hurt_cooldown == true && in_air == true && can_attack == true && in_lunge == false)
        {
            EmitSignal(nameof(jump));
        }
        else if (!hurt_cooldown == true && in_air == true && can_attack == true && in_lunge == true)
        {
            EmitSignal("lunge");
        }
        if (x_velocity > 0)
        {
            EmitSignal("right");
            var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
            player_sprite.FlipH = false;
        }
        else if (x_velocity < 0)
        {
            EmitSignal("left");
            var player_sprite = GetNode<Sprite>("/root/game/game_scene/player/player_anim");
            player_sprite.FlipH = true;
        }
        if (IsOnCeiling())
        {
            player_direction.y = 20;
        }
        if (GetNode<TouchScreenButton>("/root/game/mobile_controls/right").IsPressed())
        {
            x_velocity = x_velocity+40;
            if (x_velocity > 80)
            {
                x_velocity = 80;
            }
        }
        else if (GetNode<TouchScreenButton>("/root/game/mobile_controls/left").IsPressed())
        {
            x_velocity = x_velocity-40;
            if (x_velocity < -80)
            {
                x_velocity = -80;
            }
        }
        else if (!GetNode<TouchScreenButton>("/root/game/mobile_controls/right").IsPressed() || !GetNode<TouchScreenButton>("/root/game/mobile_controls/left").IsPressed())
        {
            if (x_velocity > 19.9)
            {
                x_velocity = x_velocity-20;
            }
            else if (x_velocity < -19.9)
            {
                x_velocity = x_velocity+20;
            }
        }
        if (IsOnFloor() && GetNode<TouchScreenButton>("/root/game/mobile_controls/right").IsPressed() && GetNode<TouchScreenButton>("/root/game/mobile_controls/left").IsPressed())
        {
            x_velocity = 0;
        }
        if (has_jetpack == true)
        {
            player_direction = MoveAndSlide(player_direction,Vector2.Up); 
        }
        else if (has_jetpack == false)
        {
            player_direction = MoveAndSlide(player_direction,Vector2.Up); 
        }
        }
    }

    public void _on_extra_hud_audio1(){
        var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
        sfx.VolumeDb = -5;
    }
    public void _on_extra_hud_audio3(){
        var sfx = GetNode<AudioStreamPlayer>("/root/game/game_scene/player/sfx");
        sfx.VolumeDb = -100;
    }
}
