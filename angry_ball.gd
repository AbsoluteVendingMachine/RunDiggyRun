extends KinematicBody2D
signal canceltimerStart()
var in_game = false
var movement = Vector2()
func _ready():
	movement.x = -300
	movement.y = 0
	position = Vector2(1920,1080)
func _physics_process(_delta):
	if in_game:
		movement = move_and_slide(movement,Vector2.UP)
	else:
		position = Vector2(1920,1080)
func _on_ball_timer_timeout():
	in_game = true
	$sfx.play()
	var rng = RandomNumberGenerator.new()
	rng.randomize()
	position = Vector2(960,rng.randi_range(252,282))
	emit_signal("canceltimerStart")
func _on_cancel_timeout():
	in_game = false

