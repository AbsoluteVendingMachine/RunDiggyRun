extends Timer

signal hurt()
#signal causeOfDeath2()
signal causeOfDeath3()

var cooldown

func _ready():
	cooldown = false

func _on_player_int_hitbox_body_entered(body):
	if body in get_tree().get_nodes_in_group("enemy"):
		if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_player_int_hitbox_area_entered(_area):
#	if area in get_tree().get_nodes_in_group("enemy"):
#		if cooldown == false:
#			emit_signal("hurt")
#			emit_signal("causeOfDeath3")
#			cooldown = true
#			start()
	pass

func _on_player_damage_received():
	cooldown = false

func _on_player_causeOfDeath1():
	emit_signal("hurt")
	start()

func _on_bat_enemy_damage1():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bat2_enemy_damage1():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rat1_enemy_damage2():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rat2_enemy_damage2():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bat3_enemy_damage1():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bat4_enemy_damage1():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rat3_enemy_damage2():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rat4_enemy_damage2():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rat5_enemy_damage2():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rat6_enemy_damage2():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rat7_enemy_damage2():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bat5_enemy_damage1():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bat_boss_enemyDamage3():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bat_projectile_damage4():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_flower1_enemyDamage5():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_flower2_enemyDamage5():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bush1_enemyDamage6():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_bush2_enemyDamage6():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rabbit1_enemyDamage8():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_skull_enemyDamage10():
	if cooldown == false:
			emit_signal("hurt")
			emit_signal("hurt")
			emit_signal("hurt")
			emit_signal("hurt")
			emit_signal("hurt")
			emit_signal("causeOfDeath3")
			cooldown = true
			start()

func _on_rabbit2_enemyDamage8():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_rabbit3_enemyDamage8():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_bush3_enemyDamage6():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_bush4_enemyDamage6():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_flower3_enemyDamage5():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_flower4_enemyDamage5():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_rabbit4_enemyDamage8():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_rabbit5_enemyDamage8():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_bush5_enemyDamage6():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_bush6_enemyDamage6():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_flower5_enemyDamage5():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_flower6_enemyDamage5():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_rabbit_boss_enemyDamage11():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_carrot_projectile_carrotDamage():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_plat_walker1_enemy_damage_platwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_plat_walker2_enemy_damage_platwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_plat_walker3_enemy_damage_platwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_plat_walker4_enemy_damage_platwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_plat_walker4_enemy_hit_platwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_sword_walker1_enemy_damage_swordwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_sword_walker2_enemy_damage_swordwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_sword_walker3_enemy_damage_swordwalker():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()

func _on_final_boss_finalBossDamage():
	if cooldown == false:
		emit_signal("hurt")
		emit_signal("causeOfDeath3")
		cooldown = true
		start()
