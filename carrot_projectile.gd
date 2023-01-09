extends KinematicBody2D
signal carrotDamage()
var active = false
var state = 1
var movement = Vector2()
func _ready():
	position = Vector2(49393,29330)
	state = 1
	movement = Vector2()
	movement.y = 0
	movement.x = 0
	active = false
func _physics_process(_delta):
	if active:
		$animation.play("normal")
		movement = move_and_slide(movement,Vector2.UP)
		if state == 1:
			$animation.flip_h = false
			movement.x = -225
		if state == 2:
			$animation.flip_h = true
			movement.x = 225
	elif !active:
		movement.x = 0
func _on_rabbit_boss_carrotThrow1():
	$sfx.stream = load("res://assets/audio/sfx/carrot.wav")
	$sfx.play()
	var rabbitBoss = get_node("/root/game/game_scene/world2_4/rabbit_boss")
	position = Vector2(rabbitBoss.position.x+20,rabbitBoss.position.y)
	state = 1
	active = true
func _on_rabbit_boss_carrotThrow2():
	$sfx.stream = load("res://assets/audio/sfx/carrot.wav")
	$sfx.play()
	var rabbitBoss = get_node("/root/game/game_scene/world2_4/rabbit_boss")
	position = Vector2(rabbitBoss.position.x-20,rabbitBoss.position.y)
	state = 2
	active = true
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player") || area in get_tree().get_nodes_in_group("collidables"):
		active = false
		$teleport.start()
		$animation.play("break")
		$sfx.stream = load("res://assets/audio/sfx/carrotwall.wav")
		$sfx.play()
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("carrotDamage")
		$sfx.stream = load("res://assets/audio/sfx/carrotwall.wav")
		$sfx.play()
func _on_teleport_timeout():
	position = Vector2(49393,29330)
