public void AI(){
this.projectile.scale = 0.1f;


if(this.projectile.timeLeft < 330){
this.projectile.tileCollide = true;
}
				if (this.projectile.ai[1] == 0f)
				{
					Main.PlaySound(2, (int)this.projectile.position.X, (int)this.projectile.position.Y, 5);
					this.projectile.ai[1] = 1f;
				}
				
					this.projectile.ai[0] += 1f;


					if (this.projectile.ai[0] >= 20f)
					{
						this.projectile.ai[0] = 20f;
						this.projectile.velocity.Y = this.projectile.velocity.Y + 0.07f;
					}

				
				this.projectile.rotation = (float)Math.Atan2((double)this.projectile.velocity.Y, (double)this.projectile.velocity.X) + 1.57f;
				if (this.projectile.velocity.Y > 16f)
				{
					this.projectile.velocity.Y = 16f;
					return;
				}
				
							Vector2 arg_1B0_0 = this.projectile.position;
							int arg_1B0_1 = this.projectile.width;
							int arg_1B0_2 = this.projectile.height;
							int arg_1B0_3 = 13;
if(Main.rand.Next(3)==0){
arg_1B0_3 = 33;
}

if(Main.rand.Next(3)==0){
arg_1B0_3 = 63;
}

							float arg_1B0_4 = 0f;
							float arg_1B0_5 = 0f;
							int arg_1B0_6 = 0;
							Color newColor = default(Color);
if (Main.rand.Next(5) != 0)
							{
								
							int num2 = Dust.NewDust(arg_1B0_0, arg_1B0_1, arg_1B0_2, arg_1B0_3, arg_1B0_4, arg_1B0_5, arg_1B0_6, newColor, 1f);
							if (Main.rand.Next(2) == 0)
							{
								Main.dust[num2].noGravity = true;
					
}
}


}

public void Kill(){
this.projectile.active = false;
}