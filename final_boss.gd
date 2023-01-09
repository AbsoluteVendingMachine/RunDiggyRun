extends KinematicBody2D
signal finalBossHit()
signal finalBossDamage()
signal killAll()
var in_game = false
var is_hurt = false
var sine_tick = 0
var health = 0
var state = 1
var movement = Vector2()
func _reset_all():
	in_game = false
	sine_tick = 0
	health = 50
	is_hurt = false
	movement.x = 20
	movement.y = 0
	state = 1
	$power_beam.position = Vector2(1920,1080)
	$power_beam.stop()
	$sfx.stop()
	$warning.hide()
	$ball_timer.stop()
	$warning_timer.stop()
	$ball_timer/cancel.stop()
	$actual.stop()
func _ready():
	_reset_all()
func _physics_process(_delta):
	if in_game:
		$health.text = str(health)+"/50"
		sine_tick = sine_tick+0.05
		if state == 1:
			position = Vector2(655+cos(sine_tick)*75,215+sin(sine_tick)*15)
			if position.x > 655:
				$animation.flip_h = false
			elif position.x < 655:
				$animation.flip_h = true
		elif state == 2:
			movement = move_and_slide(movement,Vector2.UP)
		if !$animation.animation == "idle" && !is_hurt && state == 1:
			$animation.play("idle")
		elif !$animation.animation == "blast" && !is_hurt && state == 2:
			$animation.play("blast")
		elif !$animation.animation == "hurt" && is_hurt:
			$animation.play("hurt")
func _on_hitbox_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("finalBossDamage")
	elif area in get_tree().get_nodes_in_group("weapons"):
		emit_signal("finalBossHit")
		$animation.play("hurt")
		health -= 1
		if health < 1:
			emit_signal("killAll")
			print("signal is supposed to go through")
		is_hurt = true
	elif area in get_tree().get_nodes_in_group("weapons2"):
		$animation.play("hurt")
		health -= 2
		if health < 1:
			emit_signal("killAll")
		is_hurt = true
func _on_animation_animation_finished():
	if is_hurt:
		$animation.play("idle")
		is_hurt = false
func _on_warning_timer_timeout():
	$actual.start()
	$warning.show()
	$warning.play("anim")
	$sfx.stream = load("res://assets/audio/sfx/warning.wav")
	$sfx.play()
func _on_actual_timeout():
	if state == 1:
		state = 2
		position = Vector2(590,178)
	else:
		state = 1
	$warning_timer.start()
	if state == 2:
		$power_beam.position = Vector2(0,62)
		$power_beam.play("anim")
		$sfx.stream = load("res://assets/audio/sfx/lightningwall.wav")
		$sfx.play()
	else:
		$power_beam.position = Vector2(1920,1080)
func _on_warning_animation_finished():
	$warning.hide()
func _on_world_singleton_level1():
	position = Vector2(1920,1080)
	_reset_all()
func _on_world_singleton2_finalboss():
	_reset_all()
	$warning_timer.start()
	$ball_timer.start()
	in_game = true
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("finalBossDamage")
func _on_player_killfinal():
	emit_signal("killAll")
	queue_free()
