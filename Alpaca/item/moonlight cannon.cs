public void UseStyle(Player P)
{
	float HalfPi = (float)(Math.PI / 2f);
	P.itemRotation -= 0.05f * P.direction;
	P.itemLocation.X -= P.direction * (P.width / 2) * (1f - (float)Math.Abs(P.itemRotation) / HalfPi);
}