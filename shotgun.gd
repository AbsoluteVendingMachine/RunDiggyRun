extends KinematicBody2D
signal shotgunExists()
signal knockbackUp()
signal getShottyMoneyBack()
#signal knockbackDown()
#signal knockbackRight()
#signal knockbackLeft()
var inGame
var selected
var exists
var cooldown
func _ready():
	inGame = false
	selected = false
	exists = false
	cooldown = false
	rotation = rad2deg(0)
	$shotgun_weapon/collider/shape.disabled = true
	hide()
func _on_controls_sprite_game_start():
	inGame = true
	selected = false
	exists = false
	cooldown = false
	rotation = rad2deg(0)
	$shotgun_weapon/collider/shape.disabled = true
	hide()
func _physics_process(_delta):
	if Input.is_action_just_pressed("give_shotgun") && !exists == true:
		exists = true
		emit_signal("shotgunExists")
		$sfx.stream = load("res://assets/audio/sfx/get.wav")
		$sfx.play()
	if selected == true && inGame == true && exists == true && cooldown == false && Input.is_action_just_pressed("action"):
		var player_ = get_node("/root/game/game_scene/player")
		var player_anim_ = get_node("/root/game/game_scene/player/player_anim")
		$sfx.stream = load("res://assets/audio/sfx/shotgun.wav")
		$sfx.play()
		$shotgun_weapon/particles.play("anim")
		$cooldown_timer.start()
		position = player_.position
		if !Input.is_action_pressed("up") || !Input.is_action_pressed("down"):
			if player_anim_.flip_h == true:
				rotation = deg2rad(180)
				$shotgun_weapon/particles.play("anim")
				show()
				$shotgun_weapon/collider/shape.disabled = false
				cooldown = true
			else:
				rotation = deg2rad(0)
				$shotgun_weapon/particles.play("anim")
				show()
				$shotgun_weapon/collider/shape.disabled = false
				cooldown = true
		if Input.is_action_pressed("up"):
			rotation = deg2rad(270)
			$shotgun_weapon/particles.play("anim")
			show()
			$shotgun_weapon/collider/shape.disabled = false
			cooldown = true
		if Input.is_action_pressed("down"):
			emit_signal("knockbackUp")
			rotation = deg2rad(90)
			$shotgun_weapon/particles.play("anim")
			show()
			$shotgun_weapon/collider/shape.disabled = false
			cooldown = true
	#if cooldown == true:
		#velocity = move_and_slide(velocity)
func _on_player_death():
	exists = false
	cooldown = false
	selected = false
func _on_toggle_singleton_item1():
	selected = false
func _on_toggle_singleton_item2():
	selected = true
func _on_particles_animation_finished():
	hide()
	$shotgun_weapon/collider/shape.disabled = true
	$shotgun_weapon/particles.stop()
func _on_cooldown_timer_timeout():
	$sfx.stream = load("res://assets/audio/sfx/reload.wav")
	$sfx.play()
	cooldown = false
func _on_restart_restart_game():
	exists = false
	selected = false
	cooldown = false
func _on_player_getShotty():
	if !exists == true:
		exists = true
		emit_signal("shotgunExists")
		$sfx.stream = load("res://assets/audio/sfx/get.wav")
		$sfx.play()
	else:
		emit_signal("getShottyMoneyBack")
	cooldown = false
func _on_final_boss_killAll():
	queue_free()
