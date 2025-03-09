using SharpEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine
{
#nullable disable
    public abstract class RigidBody : ICollidable
    {
        /// <summary>
        /// Gets or sets the position of this <see cref="RigidBody"/>
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets the velocity of this <see cref="RigidBody"/>
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets the mass of this <see cref="RigidBody"/>
        /// </summary>
        public float Mass { get; set; }

        /// <summary>
        /// Gets or sets the drag coefficient of this <see cref="RigidBody"/>
        /// </summary>
        public float DragCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the angular velocity of this <see cref="RigidBody"/>
        /// </summary>
        public float AngularVelocity { get; set; }

        /// <summary>
        /// Gets or sets the rotation of this <see cref="RigidBody"/>
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the acceleration of this <see cref="RigidBody"/>
        /// </summary>
        public Vector2 Acceleration { get; set; }

        /// <summary>
        /// Gets or sets inertia of this <see cref="RigidBody"/>
        /// </summary>
        public float Inertia { get; set; }

        /// <summary>
        /// Gets or sets the size of this <see cref="RigidBody"/>
        /// </summary>
        public Size Size { get; set; }

        public Rectangle Bounds
        {
            get => new Rectangle((int)Position.X, (int)Position.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Applys force to the body.
        /// </summary>
        /// <param name="force"></param>
        public abstract void ApplyForce(Vector2 force);

        /// <summary>
        /// Applys torque to the body.
        /// </summary>
        /// <param name="torque"></param>
        public abstract void ApplyTorque(float torque);

        /// <summary>
        /// Updates this rigid body.
        /// </summary>
        /// <param name="deltaTime"></param>
        public abstract void Update(float deltaTime);

        /// <summary>
        /// Resets the forces applied to the body.
        /// </summary>
        public abstract void ResetForces();


        /// <summary>
        /// Resolves collision with another rigid body.
        /// </summary>
        /// <param name="other"></param>
        public abstract void ResolveCollision(RigidBody other);

        public bool CollidesWith(ICollidable other)
        {
            return CollisionHelper.CheckRectanglePointCollision(Position, new Vector2(Size.Width, Size.Height), new Vector2(other.Bounds.X, other.Bounds.Y)) ||
                   CollisionHelper.CheckRectangleCollision(
                          Position,
                          new Vector2(Size.Width, Size.Height),
                          new Vector2(other.Bounds.X, other.Bounds.Y),
                          new Vector2(other.Bounds.Width, other.Bounds.Height)
                   );
        }
    }
}