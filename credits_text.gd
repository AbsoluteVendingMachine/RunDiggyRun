extends Node2D
var start_scrolling = false

# Called when the node enters the scene tree for the first time.
func _ready():
	hide()
	start_scrolling = false

func _on_cutscene_startCredits():
	show()
	start_scrolling = true
	position = Vector2(0,0)

func _physics_process(_delta):
	if (start_scrolling):
		if (position.y > -2600):
			position = Vector2(0,position.y-1)
		else:
			position = Vector2(0,-2600)
		
func _on_kill_timer_timeout():
	get_node("/root/game/credits/background").hide()
	queue_free()
