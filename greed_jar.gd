extends AnimatedSprite
signal greedJar()
var collected = false
func _ready():
	play("anim")
	collected = false
	position = Vector2(1248,272)
func _on_area_area_entered(area):
	if area in get_tree().get_nodes_in_group("player") && !collected:
		collected = true
		emit_signal("greedJar")
		position = Vector2(4484,3933)
		$sfx.play()
func _on_restart_restart_game():
	collected = false
	position = Vector2(1248,272)
