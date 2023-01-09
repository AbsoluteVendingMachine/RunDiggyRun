extends AnimatedSprite
var accepting = true
func _ready():
	accepting = true
	hide()
func _on_player_ending1():
	play("normal")
func _on_player_ending2():
	play("greed")
func _on_player_ending3():
	play("perfect")
func _on_player_ending4():
	play("rich")
func _on_player_ending5():
	play("secret")
func _on_kill_timer_timeout():
	show()
