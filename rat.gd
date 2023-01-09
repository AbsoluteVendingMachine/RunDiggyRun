extends KinematicBody2D
signal rat_death()
signal enemy_damage2()
var inGame
var state
var velocity = Vector2()
func _ready():
	show()
	inGame = false
	velocity = Vector2(0,0)
func _physics_process(_delta):
	if (inGame == true):
		if (position.x < 5555 && position.y > -5555 && !is_on_floor()):
			velocity.y = velocity.y+5
		else:
			velocity.y = 0 
		if (state == 1):
			$animation.flip_h = false
			$animation.play("idle")
			velocity.x = 0
		if (state == 2):
			if ($animation.animation == "idle"):
				$animation.play("walk")
			velocity.x = -100
			velocity = move_and_slide(velocity,Vector2.UP)
		if (state == 3):
			$animation.flip_h = true
			$animation.play("idle")
			velocity.x = 0
		if (state == 4):
			if ($animation.animation == "idle"):
				$animation.play("walk")
			velocity.x = 100
		velocity = move_and_slide(velocity,Vector2.UP)
func _on_controls_sprite_game_start():
	inGame = true
	state = 1
	$rat_timer.start()
	velocity = Vector2(0,0)
func _on_rat_timer_timeout():
	#print(inGame)
	#print(state)
	if (state < 4):
		state = state+1
	else:
		state = 1
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("weapons") || area in get_tree().get_nodes_in_group("weapons2"):
		$animation.play("death")
		emit_signal("rat_death")
		$sfx.stream = load("res://assets/audio/sfx/enemy.wav")
		$sfx.play()
		show()
		$rat_timer.stop()
		position = Vector2(5555,-5555)
	elif area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemy_damage2")

func _on_restart_restart_game():
	$animation.play("idle")
	if name == "rat1":
		position = Vector2(450,424)
	if name == "rat2":
		position = Vector2(1001,664)
	if name == "rat3":
		position = Vector2(616,504)
	if name == "rat4":
		position = Vector2(615,312)
	if name == "rat5":
		position = Vector2(272,552)
	if name == "rat6":
		position = Vector2(880,696)
	if name == "rat7":
		position = Vector2(456,327)
	state = 1
	$rat_timer.start()
