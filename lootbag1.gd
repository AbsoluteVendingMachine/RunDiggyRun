extends KinematicBody2D
var lootType
var item
signal lootbag1_1()
signal lootbag1_2()
signal lootbag1_3()
signal item1Get()
signal item2Get()
signal item3Get()
func _ready():
	hide()
	$collider/shape.disabled = false
	position = Vector2(10000,-10000)
	lootType = 1
func _on_world_singleton_level2():
	show()
	$animation.play("loot1")
	position = Vector2(393,505)
func _on_world_singleton_level1():
	hide()
	lootType = 1
	$animation.play("loot1")
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		if lootType == 1:
			emit_signal("lootbag1_1")
		elif lootType == 2:
			emit_signal("lootbag1_2")
		elif lootType == 3:
			emit_signal("lootbag1_3")
func _on_player_lootbag1Bought():
	position = Vector2(10000,-10000)
	hide()
	var rng = RandomNumberGenerator.new()
	rng.randomize()
	item = 1
	if item == 1:
		emit_signal("item1Get")
	if item == 2:
		emit_signal("item2Get")
	if item == 3:
		emit_signal("item3Get")
func _on_world_singleton_level3():
	position = Vector2(10000,-10000)
	hide()
func _on_world_singleton_level6():
	position = Vector2(680,425)
	show()
	$animation.play("loot2")
	lootType = 2
func _on_world_singleton_level7():
	position = Vector2(10000,-10000)
	hide()
