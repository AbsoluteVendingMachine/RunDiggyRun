extends KinematicBody2D
signal enemyDamage5()
signal flowerDeath()
func _ready():
	hide()
func checkInstance():
	$animation.play("anim")
	show()
	if name == "flower1":
		position = Vector2(344,603)
	if name == "flower2":
		position = Vector2(440,571)
	if name == "flower3":
		position = Vector2(248,571)
	if name == "flower4":
		position = Vector2(806,171)
	if name == "flower5":
		position = Vector2(457,235)
	if name == "flower6":
		position = Vector2(1017,539)
func _on_restart_restart_game():
	hide()
func _on_world_singleton_level5():
	checkInstance()
func _on_area_area_entered(area):
	if area in get_tree().get_nodes_in_group("weapons") || area in get_tree().get_nodes_in_group("weapons2"):
		emit_signal("flowerDeath")
		hide()
		$sfx.stream = load("res://assets/audio/sfx/enemy.wav")
		$sfx.play()
		position = Vector2(30203,39484)
	elif area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemyDamage5")
