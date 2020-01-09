public void AI()
{
	projectile.AI(true);
}
public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
	if (Main.rand.Next(4) == 0)
	{
		npc.AddBuff("Inferno", 540);
	}
}

public void DamagePVP(ref int damage, Player enemyPlayer)
{
	if (Main.rand.Next(4) == 0)
	{
		enemyPlayer.AddBuff(24, 540, false);
	}
}
public void PostKill()
{
	Main.PlaySound(2, -1, -1, 14);
	Rectangle aoe = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
	//Rectangle aoe = new Rectangle((int)projectile.position.X - 50, (int)projectile.position.Y - 50, (int)projectile.position.X + 50, (int)projectile.position.Y + 50);
	if (projectile.friendly && projectile.owner == Main.myPlayer)
	{
		if (projectile.type == Config.projDefs.byName["Magma Arrow"].type)
		{
			int myPlayer = Main.myPlayer;
			if (Main.player[myPlayer].active && !Main.player[myPlayer].dead && !Main.player[myPlayer].immune && (!projectile.ownerHitCheck || Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
			{
				Rectangle value = new Rectangle((int)Main.player[myPlayer].position.X, (int)Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
				if (aoe.Intersects(value))
				{
					if (Main.player[myPlayer].position.X + (float)(Main.player[myPlayer].width / 2) < projectile.position.X + (float)(projectile.width / 2))
					{
						projectile.direction = -1;
					}
					else
					{
						projectile.direction = 1;
					}
					int num2 = Main.DamageVar((float)projectile.damage);
					projectile.StatusPlayer(myPlayer);
					Main.player[myPlayer].Hurt(num2, projectile.direction, true, false, Lang.deathMsg(projectile.owner, -1, projectile.whoAmI, -1), false);
					if (Main.netMode != 0)
					{
						NetMessage.SendData(26, -1, -1, Lang.deathMsg(projectile.owner, -1, projectile.whoAmI, -1), myPlayer, (float)projectile.direction, (float)num2, 1f, 0);
					}
				}
			}
		}
	}
	if (projectile.owner == Main.myPlayer)
	{
		if (projectile.damage > 0)
		{
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && (((!Main.npc[k].friendly || (Main.npc[k].type == 22 && projectile.owner < 255 && Main.player[projectile.owner].killGuide)) && projectile.friendly) || (Main.npc[k].friendly && projectile.hostile)) && (projectile.owner < 0 || Main.npc[k].immune[projectile.owner] == 0))
				{
					bool flag = false;
					if (!flag && (Main.npc[k].noTileCollide || !projectile.ownerHitCheck || Collision.CanHit(Main.player[projectile.owner].position, Main.player[projectile.owner].width, Main.player[projectile.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
					{
						Rectangle value2 = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
						if (aoe.Intersects(value2))
						{
							if (projectile.aiStyle == 3)
							{
								if (projectile.ai[0] == 0f)
								{
									projectile.velocity.X = -projectile.velocity.X;
									projectile.velocity.Y = -projectile.velocity.Y;
									projectile.netUpdate = true;
								}
								projectile.ai[0] = 1f;
							}
							if (projectile.type == Config.projDefs.byName["Magma Arrow"].type && projectile.timeLeft > 1)
							{
								projectile.timeLeft = 1;
							}
							bool flag2 = false;
							if (projectile.ranged && Main.rand.Next(1, 101) <= Main.player[projectile.owner].rangedCrit)
							{
								flag2 = true;
							}
							int num7 = Main.DamageVar((float)projectile.damage);
							projectile.StatusNPC(k);
							Main.npc[k].StrikeNPC(num7, projectile.knockBack, projectile.direction, flag2, false);
							if (Main.netMode != 0)
							{
								if (flag2)
								{
									NetMessage.SendData(28, -1, -1, "", k, (float)num7, projectile.knockBack, (float)projectile.direction, 1);
								}
								else
								{
									NetMessage.SendData(28, -1, -1, "", k, (float)num7, projectile.knockBack, (float)projectile.direction, 0);
								}
							}
							if (projectile.penetrate != 1)
							{
								Main.npc[k].immune[projectile.owner] = 10;
							}
							if (projectile.penetrate > 0)
							{
								projectile.penetrate--;
								if (projectile.penetrate == 0)
								{
									break;
								}
							}
						}
					}
				}
			}
		}
	}
	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 36, 0f, 0f, 100, default(Color), 1.5f);
	Main.dust[dust].noGravity = true;
	if (projectile.type == Config.projDefs.byName["Magma Arrow"].type && projectile.owner == Main.myPlayer)
	{
		for (int num13 = 0; num13 < 5; num13++)
		{
			float num14 = -projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
			float num15 = -projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
			Projectile.NewProjectile(projectile.position.X + num14, projectile.position.Y + num15, num14, num15, Config.projDefs.byName["Magma"].type, (int)((double)projectile.damage * 0.6), 0f, projectile.owner);
		}
		projectile.active = false;
	}
	projectile.active = false;
}