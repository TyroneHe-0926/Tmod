public bool PreShoot(Player P,Vector2 ShootPos,Vector2 ShootVelocity,int projType,int Damage,float knockback,int owner)
{
	Main.projectile[Projectile.NewProjectile(ShootPos.X, ShootPos.Y, ShootVelocity.X, ShootVelocity.Y, projType, Damage, knockback, owner)].penetrate = 1;
	return false;
}