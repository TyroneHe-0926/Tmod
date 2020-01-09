public bool UseAmmo(Player P)
{
	if (P.ammoCost80 && Main.rand.Next(5) == 0) return false;
	if (P.ammoCost75 && Main.rand.Next(4) == 0) return false;
	if(Main.rand.Next(10) < 4) return false;
	return true;
}
public bool PreShoot(Player P, Vector2 pos, Vector2 vel, int type, int dmg, ref float kb, int owner)
{
	if (Main.rand.Next(50) == 0)
	{
		Main.projectile[Projectile.NewProjectile(pos.X, pos.Y, vel.X, vel.Y, type, dmg, kb, owner)].penetrate = 0;
		return false;
	}
	return true;
}