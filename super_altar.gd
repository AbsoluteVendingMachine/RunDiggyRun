extends AnimatedSprite
signal getSuperPickaxe()
var obtainable = true
func _ready():
	obtainable = true
	show()
	play("anim")
func _on_area_area_entered(area):
	if area in get_tree().get_nodes_in_group("player") && obtainable:
		$sfx.stream = load("res://assets/audio/sfx/obtainpickaxe.wav")
		$sfx.play()
		hide()
		obtainable = false
		emit_signal("getSuperPickaxe")
func _on_world_singleton_level6():
	show()
	obtainable = true
func _on_world_singleton_level7():
	hide()
	obtainable = false
func _on_extra_hud_audio1():
	$sfx.volume_db = 0
func _on_extra_hud_audio3():
	$sfx.volume_db = -100
