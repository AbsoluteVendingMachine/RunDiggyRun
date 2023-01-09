extends KinematicBody2D
signal newLevelPosition()

var level

func resetPosition():
	position = Vector2(974,280)

func _ready():
	hide()
	$animation.play("anim")

func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		resetPosition()
		emit_signal("newLevelPosition")
		$sfx.stream = load("res://assets/audio/sfx/teleport.wav")
		$sfx.play()

func _on_controls_sprite_game_start():
	show()
	resetPosition()

func _on_restart_restart_game():
	show()
	resetPosition()

func _on_bat_boss_boss1Dead():
	show()
	position = Vector2(365,680)

func _on_rabbit_boss_rabbitBossDeath():
	show()

func _on_world_singleton2_finalboss():
	hide()
	position = Vector2(3838,33903)
