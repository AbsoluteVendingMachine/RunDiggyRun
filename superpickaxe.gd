extends KinematicBody2D

signal particle_hit()

var selected
var exists
var cooldown
var ingame
var movemode
var movement = Vector2()

func _ready():
	exists = false
	ingame = false
	cooldown = false
	selected = true
	movemode = 1
	hide()

func _on_controls_sprite_game_start():
	exists = false
	ingame = true
	cooldown = false
	selected = true
	movemode = 1
	hide()

func _on_cooldown_timer2_timeout():
	cooldown = false
	$pickaxe_area2/pickaxe_col3.disabled = true
	hide()
	$pickaxe_anim2.stop()

func _on_final_boss_killAll():
	queue_free()

func _on_spickaxe_singleton_reset_position():
	if (ingame == true):
		var sfx_ = get_node("/root/game/game_scene/player/sfx")
		sfx_.stream = load("res://assets/audio/sfx/hit2.wav")
		sfx_.play()
		emit_signal("particle_hit")
		$teleport_timer2.start()
		hide()
		
	

func _on_teleport_timer2_timeout():
	movemode = 0
	position = Vector2(-2000,1500)
	$pickaxe_area2/pickaxe_col3.disabled = true
	
	
func _on_player_get_super():
	exists = true
	

func _physics_process(_delta):
	if (selected == true && cooldown == false && ingame == true && Input.is_action_just_pressed("action") && exists == true):
		var player_ = get_node("/root/game/game_scene/player")
		var player_anim_ = get_node("/root/game/game_scene/player/player_anim")
		$pickaxe_anim2.play("anim")
		$cooldown_timer2.start()
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
			$pickaxe_area2/pickaxe_col3.disabled = false
		if (movemode == 1):
			movement.x = 250
			movement.y = 0
			movement = move_and_slide(movement,Vector2.UP)
		if (movemode == 2):
			movement.x = -250
			movement.y = 0
			movement = move_and_slide(movement,Vector2.UP)
		if (movemode == 3):
			movement.x = 0
			movement.y = -250
			movement = move_and_slide(movement,Vector2.UP)
		if (movemode == 4):
			movement.x = 0
			movement.y = 250
			movement = move_and_slide(movement,Vector2.UP)
		
	
func _on_debug_timer_timeout():
	pass
func _on_restart_restart_game():
	position = Vector2(-2000,1500)
	selected = true
	exists = false


func _on_player_death():
	exists = false

func _on_toggle_singleton_item1():
	selected = true

func _on_toggle_singleton_item2():
	selected = false
