extends KinematicBody2D
signal enemy_damage_platwalker()
signal enemy_hit_platwalker()
var in_game = false
var movement = Vector2()
func _ready():
	in_game = false
	movement = Vector2()
	movement.x = 0
	movement.y = 0
	$animation.play("anim")
func _physics_process(_delta):
	if in_game:
		if !$animation.flip_h:
			movement.x = -37
			movement.y = 0
		else:
			movement.x = 37
			movement.y = 0
		movement = move_and_slide(movement,Vector2.UP)
func _on_rabbit_boss_rabbitBossDeath():
	in_game = true
	$switch.start()
	if name == "plat_walker1":
		position = Vector2(381,496)
	if name == "plat_walker2":
		position = Vector2(455,288)
	if name == "plat_walker3":
		position = Vector2(741,288)
	if name == "plat_walker4":
		position = Vector2(285,439)
func _on_hitbox_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemy_damage_platwalker")
	elif area in get_tree().get_nodes_in_group("weapons") || area in get_tree().get_nodes_in_group("weapons2"):
		emit_signal("enemy_hit_platwalker")
		position = Vector2(3838,2922)
		in_game = false
		$switch.stop()
func _on_switch_timeout():
	if !$animation.flip_h:
		$animation.flip_h = true
	else:
		$animation.flip_h = false
