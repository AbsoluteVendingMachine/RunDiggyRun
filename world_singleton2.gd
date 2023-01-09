extends Node
signal level10()
signal gotolevel9()
signal finalboss()
var signalable = false
var levelorder = 0
func _ready():
	signalable = false
	levelorder = 0
func _on_world_singleton_level1():
	signalable = false
	levelorder = 0
func _on_progress_point_newLevelPosition():
	print(signalable)
	if signalable:
		if levelorder < 1:
			emit_signal("level10")
			print("level10")
			levelorder = 1
		elif levelorder == 1:
			levelorder = 2
			emit_signal("finalboss")
			print("finalboss")
func _on_rabbit_boss_rabbitBossDeath():
	signalable = true
func _physics_process(_delta):
	if Input.is_action_just_pressed("world3"):
		emit_signal("gotolevel9")
