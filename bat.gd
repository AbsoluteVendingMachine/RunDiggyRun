extends KinematicBody2D
signal bat_death()
signal enemy_damage1()
var sinTick
var inGame
func _reset_properties():
	sinTick = 0
func _ready():
	inGame = false
	_reset_properties()
#$object/animation.play("anim")
func _physics_process(_delta):
	if (inGame == true):
		sinTick = sinTick + 0.05
		$object.position = Vector2(0,sin(sinTick)*17.5)
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("weapons") || area in get_tree().get_nodes_in_group("weapons2"):
		$object/animation.play("death")
		emit_signal("bat_death")
		$sfx.stream = load("res://assets/audio/sfx/enemy.wav")
		$sfx.play()
		hide()
		position = Vector2(5555,-5555)
	elif area in get_tree().get_nodes_in_group("player"):
		emit_signal("enemy_damage1")
func _on_controls_sprite_game_start():
	$object/animation.play("anim")
	inGame = true
	_reset_properties()
func _on_restart_restart_game():
	$object/animation.play("anim")
	show()
	if name == "bat1":
		position = Vector2(612,573)
	if name == "bat2":
		position = Vector2(611,371)
	if name == "bat3":
		position = Vector2(857,576)
	if name == "bat4":
		position = Vector2(945,582)
	if name == "bat5":
		position = Vector2(791,292)
