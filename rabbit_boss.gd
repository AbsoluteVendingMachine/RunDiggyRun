extends KinematicBody2D
signal enemyDamage11()
signal rabbitBossDeath()
signal rabbitBossHit()
signal carrotThrow1()
signal carrotThrow2()
var inGame = false
var movement = Vector2()
var state = 1
var isHurt = false
var health = 35
func _on_final_boss_killAll():
	queue_free()
func hurtProcess():
	$hurt_cooldown.start()
	isHurt = true
	$animations.stop()
	$animations.play("hurt")
	$sfx.stop()
	$sfx.stream = load("res://assets/audio/sfx/bosshurt2.wav")
	$sfx.play()
	emit_signal("rabbitBossHit")
	if health < 1:
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/teleport2.wav")
		$sfx.play()
		$main_cooldown.stop()
		inGame = false
		isHurt = false
		movement.x = 0
		movement.y = 0
		emit_signal("rabbitBossDeath")
		position = Vector2(48484,20202)
func resetVelocity():
	movement = Vector2()
	movement.x = 0
	movement.y = 0
func resetState():
	show()
	movement = Vector2()
	movement.x = 0
	movement.y = 0
	state = 1
	isHurt = false
	health = 35
	position = Vector2(163,677)
	$animations.play("idle")
func _ready():
	inGame = false
	resetState()
func _physics_process(_delta):
	if inGame == true:
		$health.text = str(health)+"/35"
		if isHurt == true:
			if !$animations.animation == "hurt":
				$animations.play("hurt")
		if is_on_ceiling():
			movement.y = 20
		movement = move_and_slide(movement,Vector2.UP)
		if !is_on_floor():
			movement.y += 5
		var _player = get_node("/root/game/game_scene/player")
		if _player.position.x > position.x:
			$animations.flip_h = true
		else:
			$animations.flip_h = false
		if state == 1 || state == 4 || state == 5 || state == 8 || state == 9 || state == 10:
			if !$animations.animation == "idle" && isHurt == false:
				$animations.play("idle")
		if state == 2 || state == 6:
			if !$animations.animation == "jump" && isHurt == false:
				$animations.play("jump")
			if $animations.flip_h == false:
				movement.x = -75
			if $animations.flip_h == true:
				movement.x = 75
		if state == 3 || state == 7:
			if !$animations.animation == "phase" && isHurt == false:
				$animations.play("phase")
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemyDamage11")
	elif area in get_tree().get_nodes_in_group("weapons") && isHurt == false:
		health -= 1
		hurtProcess()
	elif area in get_tree().get_nodes_in_group("weapons2") && isHurt == false:
		health -= 2
		hurtProcess()
func getLog():
	var _log = get_node("/root/game/game_scene/world2_4/log")
	var _logTimer = get_node("/root/game/game_scene/world2_4/log/log_cooldown")
	_log.position = position
	_log.show()
	_logTimer.start()
func _on_main_cooldown_timeout():
	if state < 10:
		state += 1
	elif state == 10:
		state = 1
		resetVelocity()
		getLog()
		position = Vector2(26,677)
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/teleport.wav")
		$sfx.play()
		emit_signal("carrotThrow2")
	if state == 2:
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/bossjump.wav")
		$sfx.play()
		movement.y = -175
	if state == 6:
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/bossjump.wav")
		$sfx.play()
		movement.y = -175
	if state == 3:
		resetVelocity()
		getLog()
		position = Vector2(26,677)
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/teleport.wav")
		$sfx.play()
	if state == 4:
		resetVelocity()
		getLog()
		position = Vector2(290,677)
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/teleport.wav")
		$sfx.play()
		emit_signal("carrotThrow1")
	if state == 7:
		resetVelocity()
		getLog()
		position = Vector2(290,677)
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/teleport.wav")
		$sfx.play()
	if state == 8:
		resetVelocity()
		getLog()
		position = Vector2(26,677)
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/teleport.wav")
		$sfx.play()
		emit_signal("carrotThrow2")
	if state == 9:
		resetVelocity()
		getLog()
		position = Vector2(290,677)
		$sfx.stop()
		$sfx.stream = load("res://assets/audio/sfx/teleport.wav")
		$sfx.play()
		emit_signal("carrotThrow1")
func _on_world_singleton_level8():
	$main_cooldown.start()
	inGame = true
	resetState()
func _on_log_cooldown_timeout():
	var _log = get_node("/root/game/game_scene/world2_4/log")
	_log.hide()
func _on_world_singleton_level1():
	inGame = false
	resetState()
func _on_hurt_cooldown_timeout():
	isHurt = false
	$animations.stop()
func _on_world_singleton2_gotolevel9():
	emit_signal("rabbitBossDeath")
