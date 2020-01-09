

public void UseItemEffect(Player player, Rectangle rectangle) {
	Color color = new Color();
	int dust = Dust.NewDust(new Vector2((float) rectangle.X, (float) rectangle.Y), rectangle.Width, rectangle.Height, 6, (player.velocity.X * 0.2f) + (player.direction * 3), player.velocity.Y * 0.2f, 100, color, 1.9f);
	Main.dust[dust].noGravity = true;

int dir = Main.player[Main.myPlayer].direction;
int speed = dir * 20;
int dmg = Main.rand.Next(3) + 1;


float playerposX = (float) Main.player[Main.myPlayer].position.X - (dir*900) + Main.rand.Next(200);
float playerposY = (float) Main.player[Main.myPlayer].position.Y + Main.rand.Next(-230,230);

for(int i=0; i < 3; i++){
Projectile.NewProjectile( playerposX  , playerposY, speed, 0, Config.projDefs.byName["Icy Wind Arrow"].type, dmg, 0, Main.myPlayer)   ; 
Projectile.NewProjectile( playerposX  , playerposY, speed, 0, Config.projDefs.byName["Icy Wind Particles"].type, dmg, 0, Main.myPlayer)   ; 
Projectile.NewProjectile( playerposX  , playerposY, speed, 0, Config.projDefs.byName["Icy Wind Arrow"].type, 0, 0, Main.myPlayer)   ; 
 Projectile.NewProjectile(playerposX, playerposY, speed, 0, Config.projDefs.byName["Icy Wind Arrow"].type, 0, 0, Main.myPlayer)   ; 
 Projectile.NewProjectile(playerposX, playerposY, speed, 0, Config.projDefs.byName["Icy Wind Arrow"].type, 0, 0, Main.myPlayer)   ; 
}
}