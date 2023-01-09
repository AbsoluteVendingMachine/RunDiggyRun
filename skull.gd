extends KinematicBody2D
signal enemyDamage10()
signal pitchReset()
signal pitchChange()
var movement = Vector2()
var ingame = false
func _on_final_boss_killAll():
	queue_free()
func _ready():
	emit_signal("pitchReset")
	$particles.emitting = false
	$animation.play("anim")
	movement.x = 0
	movement.y = 0
	ingame = false
	hide()
	position = Vector2(0,0)
func _physics_process(_delta):
	var plr = get_node("/root/game/game_scene/player")
	if ingame == true:
		if plr.position.x > position.x:
			$animation.flip_h = false
			movement.x = 30
		if plr.position.x < position.x:
			$animation.flip_h = true
			movement.x = -30
		if plr.position.y > position.y:
			movement.y = 30
		if plr.position.y < position.y:
			movement.y = -30
		movement = move_and_slide(movement,Vector2.UP)
func _on_animation_animation_finished():
	if ingame == true:
		$sfx.stream = load("res://assets/audio/sfx/bite2.wav")
		$sfx.play()
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemyDamage10")
func _on_restart_restart_game():
	emit_signal("pitchReset")
	$particles.emitting = false
	movement.x = 0
	movement.y = 0
	ingame = false
	hide()
	position = Vector2(-200,0)
func _on_level_timer_timeLimitPassed():
	$particles.emitting = true
	emit_signal("pitchChange")
	ingame = true
	show()
	position = Vector2(0,0)
func _on_progress_point_newLevelPosition():
	emit_signal("pitchReset")
	$particles.emitting = false
	ingame = false
	hide()
	movement.x = 0
	movement.y = 0
	position = Vector2(-200,0)
func _on_extra_hud_audio1():
	$sfx.volume_db = 0
func _on_extra_hud_audio3():
	$sfx.volume_db = -100
