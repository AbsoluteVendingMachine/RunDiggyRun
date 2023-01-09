extends KinematicBody2D
var lootType
var item
signal lootbag2_1()
signal lootbag2_2()
signal lootbag2_3()
signal item1Get()
signal item2Get()
signal item3Get()
func _ready():
	hide()
	$collider/shape.disabled = false
	position = Vector2(10200,-10000)
	lootType = 1
func _on_world_singleton_level1():
	hide()
	lootType = 1
	$animation.play("loot1")
func _on_world_singleton_level2():
	show()
	$animation.play("loot1")
	position = Vector2(361,505)
func _on_world_singleton_level3():
	position = Vector2(10200,-10000)
	hide()
func _on_collider_area_entered(area):
	if area in get_tree().get_nodes_in_group("player"):
		if lootType == 1:
			emit_signal("lootbag2_1")
		elif lootType == 2:
			emit_signal("lootbag2_2")
		elif lootType == 3:
			emit_signal("lootbag2_3")
func _on_player_lootbag2Bought():
	position = Vector2(10200,-10000)
	hide()
	var rng = RandomNumberGenerator.new()
	rng.randomize()
	item = rng.randi_range(1,3)
	if item == 1:
		emit_signal("item1Get")
	if item == 2:
		emit_signal("item2Get")
	if item == 3:
		emit_signal("item3Get")
func _on_world_singleton_level6():
	position = Vector2(648,425)
	show()
	$animation.play("loot2")
	lootType = 2
func _on_world_singleton_level7():
	position = Vector2(10200,-10000)
	hide()
