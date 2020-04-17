namespace DevMath
{
    public class Circle
    {
        public Vector2 Position
        {
            get; set;
        }

        public float Radius
        {
            get; set;
        }

        public bool CollidesWith(Circle circle) => Vector2.Distance(this.Position, circle.Position) < this.Radius + circle.Radius;
    }
}
