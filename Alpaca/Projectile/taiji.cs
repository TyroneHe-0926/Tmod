public void DamageNPC(NPC npc, ref int damage, ref float knockback)
{
            foreach (NPC n in Main.npc)
                if (n.active && !n.friendly)
{
Vector2 vectorenemy = new Vector2(n.position.X + (float)n.width * 0.5f, n.position.Y + (float)n.height * 0.5f);
float num199 = this.projectile.position.X + (float)(this.projectile.width / 2) - vectorenemy.X;
float num198 = this.projectile.position.Y + (float)(this.projectile.height / 2) - vectorenemy.Y;
float num197 = (float)Math.Sqrt((double)(num199 * num199 + num198 * num198));
                                if (num197 < 150)
				{
					n.AddBuff(24, 180, false);
                    n.StrikeNPC(this.projectile.damage, this.projectile.knockBack, this.projectile.direction, false, false);
                    bool fal= false;
                    foreach(int zz in n.buffType)
                    {
                        if (zz == 39)
	                    {
		                    fal=true;
                            break;
	                    }
                    }
                    if(!fal)
                    {
                    int a= Projectile.NewProjectile(n.position.X,n.position.Y,0,0,this.projectile.name,0,0,this.projectile.owner);
                    Main.projectile[a].Kill(); 
                    }
				}
}
}
public void AI()
{
int num41 = Dust.NewDust(new Vector2(this.projectile.position.X + this.projectile.velocity.X, this.projectile.position.Y + this.projectile.velocity.Y), this.projectile.width, this.projectile.height, 75, this.projectile.velocity.X, this.projectile.velocity.Y, 100, default(Color), 3f * this.projectile.scale);
                                                    Main.dust[num41].noGravity = true;
float num7 = 1f;
float num8 = 0.1f;
float num9 = 0.1f;
Lighting.addLight((int)((this.projectile.position.X + (float)(this.projectile.width / 2)) / 16f), (int)((this.projectile.position.Y + (float)(this.projectile.height / 2)) / 16f), num7, num8, num9);                
 #region alpha related
                    if (this.projectile.alpha > 0)
                    {
                        this.projectile.alpha -= 15;
                    }
                    if (this.projectile.alpha < 0)
                    {
                        this.projectile.alpha = 0;
                    }
                #endregion
                if (this.projectile.ai[0] >= 15f)
                {
                    this.projectile.ai[0] = 15f;
                }
                this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
                if (this.projectile.velocity.Y > 16f)
                {
                    this.projectile.velocity.Y = 16f;
                    return;
                }

}

public void Kill()
{
this.projectile.active = false;
Main.PlaySound(2, (int)this.projectile.position.X, (int)this.projectile.position.Y, 10);
this.projectile.position.X = this.projectile.position.X + (float)(this.projectile.width / 2);
this.projectile.position.Y = this.projectile.position.Y + (float)(this.projectile.height / 2);
this.projectile.width = 200;
this.projectile.height = 200;
this.projectile.position.X = this.projectile.position.X - (float)(this.projectile.width / 2);
this.projectile.position.Y = this.projectile.position.Y - (float)(this.projectile.height / 2);

for (int num70 = 0; num70 < 50; num70++)
{
int num71 = Dust.NewDust(new Vector2(this.projectile.position.X, this.projectile.position.Y), this.projectile.width, this.projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
Main.dust[num71].velocity *= 1.4f;
}
for (int num72 = 0; num72 < 80; num72++)
{
    int num73 = Dust.NewDust(new Vector2(this.projectile.position.X, this.projectile.position.Y), this.projectile.width, this.projectile.height, 75, 0f, 0f, 100, default(Color), 3f);
    Main.dust[num73].noGravity = true;
    Main.dust[num73].velocity *= 5f;
    num73 = Dust.NewDust(new Vector2(this.projectile.position.X, this.projectile.position.Y), this.projectile.width, this.projectile.height, 75, 0f, 0f, 100, default(Color), 2f);
    Main.dust[num73].velocity *= 3f;
}
    this.projectile.position.X = this.projectile.position.X + (float)(this.projectile.width / 2);
    this.projectile.position.Y = this.projectile.position.Y + (float)(this.projectile.height / 2);
    this.projectile.width = 10;
    this.projectile.height = 10;
    this.projectile.position.X = this.projectile.position.X - (float)(this.projectile.width / 2);																																			
    this.projectile.position.Y = this.projectile.position.Y - (float)(this.projectile.height / 2);
    double z = Math.Sqrt((this.projectile.position.X*this.projectile.position.X)+(this.projectile.position.Y*this.projectile.position.Y));

            foreach (NPC n in Main.npc)
                if (n.active && !n.friendly)
{
Vector2 vectorenemy = new Vector2(n.position.X + (float)n.width * 0.5f, n.position.Y + (float)n.height * 0.5f);
float num199 = this.projectile.position.X + (float)(this.projectile.width / 2) - vectorenemy.X;
float num198 = this.projectile.position.Y + (float)(this.projectile.height / 2) - vectorenemy.Y;
float num197 = (float)Math.Sqrt((double)(num199 * num199 + num198 * num198));
                                if (num197 < 150)
				{
					n.AddBuff(39, 180, false);
                    n.StrikeNPC(this.projectile.damage, this.projectile.knockBack, this.projectile.direction, false, false);
                    bool fal= false;
                    foreach(int zz in n.buffType)
                    {
                        if (zz == 39)
	                    {
		                    fal=true;
                            break;
	                    }
                    }
                    if(!fal)
                    {
                    int a= Projectile.NewProjectile(n.position.X,n.position.Y,0,0,this.projectile.name,0,0,this.projectile.owner);
                    Main.projectile[a].Kill(); 
                    }
				}
}
}