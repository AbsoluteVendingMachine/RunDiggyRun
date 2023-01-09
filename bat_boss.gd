extends KinematicBody2D
signal batWave()
signal boss1Dead()
signal enemyDamage3()
signal boss1Hit()
var beingHurt = false
var state = 0
var ingame = false
var cooldown = false
var health = 20
var sineTick = 0
func _ready():
	position = Vector2(-1000,1000)
	$animation.hide()
func _on_world_singleton_level4():
	sineTick = 0
	ingame = true
	health = 20
	beingHurt = false
	cooldown = false
	position = Vector2(192,633)
	$animation.show()
	$animation.play("normal")
	$state.start()
	state = 1
func _on_area_area_entered(area):
	if area in get_tree().get_nodes_in_group("weapons"):
		if !$animation.animation == "hurt" && cooldown == false:
			$animation.play("hurt")
			$sfx.stop()
			$sfx.stream = load("res://assets/audio/sfx/bosshit.wav")
			$sfx.play()
			beingHurt = true
			health = health-1
			emit_signal("boss1Hit")
			if health < 1:
				$state.stop()
				$sfx.stop()
				$sfx.stream = load("res://assets/audio/sfx/bosskill.wav")
				$sfx.play()
				ingame = false
				emit_signal("boss1Dead")
				$animation.stop()
				$animation.show()
				$animation.play("death")
	elif area in get_tree().get_nodes_in_group("weapons2"):
		if !$animation.animation == "hurt" && cooldown == false:
			$animation.play("hurt")
			$sfx.stop()
			$sfx.stream = load("res://assets/audio/sfx/bosshit.wav")
			$sfx.play()
			beingHurt = true
			health = health-2
			emit_signal("boss1Hit")
			if health < 1:
				$state.stop()
				$sfx.stop()
				$sfx.stream = load("res://assets/audio/sfx/bosskill.wav")
				$sfx.play()
				ingame = false
				emit_signal("boss1Dead")
				$animation.hide()
				$animation.stop()
	elif area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemyDamage3")
func _on_animation_animation_finished():
	if $animation.animation == "death":
		$animation.hide()
		$animation.stop()
	if health < 1:
		position = Vector2(12999,0)
	if ingame == true && state == 1 || state == 2 && beingHurt == false:
		$sfx.stream = load("res://assets/audio/sfx/wing2.wav")
		$sfx.play()
	if beingHurt == true:
		$animation.play("normal")
		cooldown = false
		beingHurt = false
	if state == 2:
		emit_signal("batWave")
		state = 1
func _physics_process(_delta):
	if ingame == true:
		if health > 0:
			$health.text = str(health)+"/20"
		elif health < 0:
			$health.text = "0/20"
		sineTick = sineTick + 0.04
		position = Vector2(192+cos(sineTick)*110,633+sin(sineTick)*22)
func _on_state_timeout():
	if state < 2:
		state = state+1
	else:
		state = 1
func _on_bat_boss_boss1Dead():
	position = Vector2(12999,0)
func _on_restart_restart_game():
	position = Vector2(12999,0)
	beingHurt = false
	state = 0
	ingame = false
	cooldown = false
	health = 20
	sineTick = 0
	$state.stop()
	$sfx.stop()
func _on_extra_hud_audio1():
	$sfx.volume_db = 0
func _on_extra_hud_audio3():
	$sfx.volume_db = -100
