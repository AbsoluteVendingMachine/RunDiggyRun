extends KinematicBody2D
signal damage4()
var ingame
var movement = Vector2()
var canMove
func _ready():
	canMove = false
	hide()
	position = Vector2(-3000,30404)
func _on_bat_boss_batWave():
	show()
	$first_bat.play("anim")
	$second_bat.play("anim")
	$third_bat.play("anim")
	$sfx.stream = load("res://assets/audio/sfx/batwave.wav")
	$sfx.play()
	var rng = RandomNumberGenerator.new()
	rng.randomize()
	position = Vector2(430,rng.randi_range(600,650))
	canMove = true
func _physics_process(_delta):
	if canMove == true:
		movement.x = -300
		movement.y = 0
		movement = move_and_slide(movement,Vector2.UP)
	if position.x < -72 && canMove == true:
		canMove = false
func _on_area_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		emit_signal("damage4")
func _on_extra_hud_audio1():
	$sfx.volume_db = 0
func _on_extra_hud_audio3():
	$sfx.volume_db = -100
