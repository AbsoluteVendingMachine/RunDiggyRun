extends KinematicBody2D
signal enemy_damage_swordwalker()
signal enemy_hit_swordwalker()
var in_game = false
var movement = Vector2()
func _ready():
	$animation.play("anim")
	in_game = false
	movement = Vector2()
	movement.x = 0
	movement.y = 0
func _physics_process(_delta):
	if in_game:
		movement = move_and_slide(movement,Vector2.UP)
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemy_damage_swordwalker")
	if area in get_tree().get_nodes_in_group("weapons") || area in get_tree().get_nodes_in_group("weapons2"):
		emit_signal("enemy_hit_swordwalker")
		in_game = false
		position = Vector2(4848,3933)
		$switch.stop()
func _on_switch_timeout():
	if !$animation.flip_h:
		movement.x = 20
		$animation.flip_h = true
	else:
		movement.x = -20
		$animation.flip_h = false
func _on_rabbit_boss_rabbitBossDeath():
	in_game = true
	$animation.flip_h = false
	$switch.start()
	if name == "sword_walker1":
		position = Vector2(657,624)
	if name == "sword_walker2":
		position = Vector2(598,288)
	if name == "sword_walker3":
		position = Vector2(1109,272)
