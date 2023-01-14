extends KinematicBody2D

signal particle_hit()

var selected
var exists
var cooldown
var ingame
var movemode
var movement = Vector2()

func _ready():
	exists = true
	ingame = false
	cooldown = false
	selected = true
	movemode = 1
	hide()

func _on_controls_sprite_game_start():
	exists = true
	ingame = true
	cooldown = false
	selected = true
	movemode = 1
	hide()

func _on_cooldown_timer_timeout():
	cooldown = false
	hide()
	$pickaxe_anim.stop()

func _on_final_boss_killAll():
	queue_free()

func _on_pickaxe_singleton_reset_position():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_teleport_timer_timeout():
	movemode = 0
	position = Vector2(-1657,739)
	$pickaxearea/pickaxe_col2.disabled = true
	
func _on_player_get_super():
	exists = false
	
func _physics_process(_delta):
	if (selected == true && cooldown == false && ingame == true && Input.is_action_just_pressed("action") && exists == true):
		var player_ = get_node("/root/game/game_scene/player")
		var player_anim_ = get_node("/root/game/game_scene/player/player_anim")
		$pickaxe_anim.play("anim")
		$cooldown_timer.start()
		position = player_.position
		show()
		if (!Input.is_action_pressed("up") || !Input.is_action_pressed("down")):
			if (player_anim_.flip_h == true):
				movemode = 2
			elif (player_anim_.flip_h == false):
				movemode = 1
		if (Input.is_action_pressed("up")):
			movemode = 3
		if (Input.is_action_pressed("down")):
			movemode = 4
		cooldown = true
	if (cooldown == true):
		if movemode != 0:
			$pickaxearea/pickaxe_col2.disabled = false
		if (movemode == 1):
			movement.x = 150
			movement.y = 0
			movement = move_and_slide(movement,Vector2.UP)
		if (movemode == 2):
			movement.x = -150
			movement.y = 0
			movement = move_and_slide(movement,Vector2.UP)
		if (movemode == 3):
			movement.x = 0
			movement.y = -150
			movement = move_and_slide(movement,Vector2.UP)
		if (movemode == 4):
			movement.x = 0
			movement.y = 150
			movement = move_and_slide(movement,Vector2.UP)
		
	
func _on_restart_restart_game():
	position = Vector2(-1657,739)
	selected = true
	exists = true

func _on_player_death():
	exists = false

func _on_bat_bat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bat2_bat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_toggle_singleton_item1():
	selected = true

func _on_toggle_singleton_item2():
	selected = false
	
func _on_rat1_rat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rat2_rat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bat3_bat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bat4_bat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rat3_rat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rat4_rat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rat5_rat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rat6_rat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rat7_rat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bat5_bat_death():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bat_boss_boss1Hit():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_flower2_flowerDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_flower1_flowerDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bush1_bushDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bush2_bushDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rabbit1_rabbitDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rabbit2_rabbitDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rabbit3_rabbitDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bush3_bushDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bush4_bushDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_flower3_flowerDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_flower4_flowerDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rabbit4_rabbitDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rabbit5_rabbitDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bush5_bushDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_bush6_bushDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_flower5_flowerDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_flower6_flowerDeath():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_rabbit_boss_rabbitBossHit():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_plat_walker1_enemy_hit_platwalker():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_plat_walker2_enemy_hit_platwalker():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_plat_walker3_enemy_hit_platwalker():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_plat_walker4_enemy_hit_platwalker():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_sword_walker1_enemy_hit_swordwalker():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_sword_walker2_enemy_hit_swordwalker():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_sword_walker3_enemy_hit_swordwalker():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_final_boss_finalBossHit():
	var sfx_ = get_node("/root/game/game_scene/player/sfx")
	sfx_.stream = load("res://assets/audio/sfx/hit.wav")
	sfx_.play()
	emit_signal("particle_hit")
	$teleport_timer.start()
	hide()

func _on_attack_released():
	if selected && !cooldown && exists && ingame:
		var player_ = get_node("/root/game/game_scene/player")
		var player_anim_ = get_node("/root/game/game_scene/player/player_anim")
		$pickaxe_anim.play("anim")
		$cooldown_timer.start()
		position = player_.position
		show()
		if (player_anim_.flip_h):
			movemode = 2
		elif (!player_anim_.flip_h):
			movemode = 1
		cooldown = true
	

func _on_attack_up_released():
	show()
	if selected && !cooldown && exists && ingame:
		movemode = 3
		cooldown = true
		var player_ = get_node("/root/game/game_scene/player")
		$pickaxe_anim.play("anim")
		$cooldown_timer.start()
		position = player_.position


func _on_attack_down_released():
	show()
	if selected && !cooldown && exists && ingame:
		movemode = 4
		cooldown = true
		var player_ = get_node("/root/game/game_scene/player")
		$pickaxe_anim.play("anim")
		$cooldown_timer.start()
		position = player_.position