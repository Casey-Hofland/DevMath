namespace DevMath
{
    public class Rigidbody
    {
        public Vector2 Velocity
        {
            get; private set;
        }

        public float mass = 1.0f;
        public float force = 150.0f;
        public float dragCoefficient = .47f;

        public void AddForce(Vector2 forceDirection, float deltaTime)
        {
            Velocity -= forceDirection * deltaTime * mass;  // Apply force
            Velocity *= (1 - deltaTime * dragCoefficient);  // Apply drag
        }
    }
}
