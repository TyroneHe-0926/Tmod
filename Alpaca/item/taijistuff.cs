
public bool CanUse(Player player, int pID) {
	bool use=true;
	//This code is used by boomerangs to limit the amount of boomerang projectiles that can be thrown.
	for (int m = 0; m < 1000; m++)
	{
		if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == this.item.shoot)
		{
            
			use = false;
			break;
		}
	}
	return use;
}