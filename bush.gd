extends KinematicBody2D
signal bushDeath()
signal enemyDamage6()
var ingame = false
var inrange = false
var cooldown = false
var canmove = false
var movement = Vector2()
func checkInstance():
	if name == "bush1":
		position = Vector2(913,571)
	if name == "bush2":
		position = Vector2(400,315)
	if name == "bush3":
		position = Vector2(537,427)
	if name == "bush4":
		position = Vector2(900,315)
	if name == "bush5":
		position = Vector2(153,571)
	if name == "bush6":
		position = Vector2(496,555)
	show()
func _ready():
	$projectile/animation.play("anim")
	$projectile.position = Vector2(34834,34943)
	ingame = false
	inrange = false
	cooldown = false
	canmove = false
	show()
func _physics_process(_delta):
	if ingame == true:
		if inrange == true && cooldown == false:
			$cooldown_timer.start()
			cooldown = true
		if canmove == true:
			movement.x = -100
			movement.y = 0
			movement = $projectile.move_and_slide(movement,Vector2.UP)
			if $projectile.position.x < -75:
				cooldown = false
				canmove = false
				$projectile.position = Vector2(39293,39333)
func _on_parameter_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		inrange = true
		if $animation.animation == ("idle"):
			$animation.play("awake")
	else:
		$animation.play("idle")
		inrange = false
func _on_cooldown_timer_timeout():
	if inrange == true:
		$projectile.position = Vector2(0,0)
		canmove = true
	else:
		canmove = false
func _on_collision_area_entered(area):
	if area in get_tree().get_nodes_in_group("weapons") || area in get_tree().get_nodes_in_group("weapons2"):
		emit_signal("bushDeath")
		position = Vector2(30235,39484)
	elif area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemyDamage6")
func _on_collision2_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemyDamage6")
func _on_world_singleton_level5():
	ingame = true
	checkInstance()
func _on_restart_restart_game():
	ingame = false
	position = Vector2(48455,4394)
	$projectile.position = Vector2(34834,34943)
