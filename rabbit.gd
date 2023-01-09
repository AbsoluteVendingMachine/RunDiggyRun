extends KinematicBody2D
signal enemyDamage8()
signal rabbitDeath()
var ingame = false
var state = 1
var velocity = Vector2()
func resetState():
	state = 1
func checkInstance():
	if name == "rabbit1":
		position = Vector2(462,491)
	if name == "rabbit2":
		position = Vector2(149,395)
	if name == "rabbit3":
		position = Vector2(223,411)
	if name == "rabbit4":
		position = Vector2(306,395)
	if name == "rabbit5":
		position = Vector2(574,411)
	state = 1
func _ready():
	ingame = false
	state = 1
func _on_world_singleton_level5():
	$state_timer.start()
	ingame = true
	checkInstance()
	resetState()

func _physics_process(_delta):
	if ingame == true:
		velocity = move_and_slide(velocity,Vector2.UP)
		if is_on_floor():
			velocity.y = 0
			$animation.play("idle")
		if !is_on_floor():
			$animation.play("jump")
			velocity.y = velocity.y+11
		if is_on_ceiling():
			velocity.y = velocity.y+20
		if velocity.x > 0:
			velocity.x = velocity.x-2
		elif velocity.x < 0:
			velocity.x = velocity.x+2
func _on_state_timer_timeout():
	if state == 1:
		state = 2
		$animation.flip_h = false
		velocity.x = -125
		velocity.y = -180
	elif state == 2:
		state = 1
		$animation.flip_h = true
		velocity.x = 125
		velocity.y = -180
func _on_area_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemyDamage8")
	elif area in get_tree().get_nodes_in_group("weapons") || area in get_tree().get_nodes_in_group("weapons2"):
		emit_signal("rabbitDeath")
		ingame = false
		position = Vector2(57575,49494)
func _on_world_singleton_level1():
	position = Vector2(4484,5858)
	ingame = false
func _on_world_singleton_level6():
	if name == "rabbit2" || name == "rabbit3":
		ingame = true
func _on_restart_restart_game():
	pass 
