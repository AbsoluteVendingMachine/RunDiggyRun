extends Node

signal reset_position()

func _ready():
	pass

func _on_pickaxe_area2_body_entered(body):
	if body in get_tree().get_nodes_in_group("collidables") || body in get_tree().get_nodes_in_group("enemy"):
		emit_signal("reset_position")
