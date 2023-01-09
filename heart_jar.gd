extends Sprite
signal fullHeal()
var collected = false
func _ready():
	collected = false
	position = Vector2(955,280)
func _on_area_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		if !collected:
			$sfx.play()
			position = Vector2(4383,3022)
			emit_signal("fullHeal")
			collected = true
func _on_restart_restart_game():
	position = Vector2(955,280)
	collected = false
