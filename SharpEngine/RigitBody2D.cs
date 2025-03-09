using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine;

#nullable disable
public class RigitBody2D : RigidBody
{
    private Vector2 _force;
    private float _torque;

    public override void ApplyForce(Vector2 force)
    {
        _force = new Vector2(_force.X + force.X, _force.Y + force.Y);
    }

    public override void ApplyTorque(float torque)
    {
        _torque += torque;
    }

    public override void ResetForces()
    {
        _force = Vector2.Zero;
        _torque = 0;
    }

    public override void ResolveCollision(RigidBody other)
    {
        Vector2 relativeVelocity = other.Velocity - this.Velocity;
        Vector2 collisionNormal = (other.Position - this.Position).Normalized;
        float velocityAlongNormal = Vector2.Dot(relativeVelocity, collisionNormal);

        if (velocityAlongNormal > 0)
            return;

        float restitution = 1.0f;
        float impulseScalar = -(1 + restitution) * velocityAlongNormal;
        impulseScalar /= (1 / this.Mass) + (1 / other.Mass);

        Vector2 impulse = impulseScalar * collisionNormal;
        this.Velocity -= (1 / this.Mass) * impulse;
        other.Velocity += (1 / other.Mass) * impulse;
    }

    public override void Update(float deltaTime)
    {
        // Update linear motion
        Acceleration = _force / Mass;
        Velocity += Acceleration * deltaTime;
        Position += Velocity * deltaTime;

        // Update angular motion
        float angularAcceleration = _torque / Inertia;
        AngularVelocity += angularAcceleration * deltaTime;
        Rotation += AngularVelocity * deltaTime;

        // Apply drag
        Velocity *= (1 - DragCoefficient * deltaTime);
        AngularVelocity *= (1 - DragCoefficient * deltaTime);

        // Reset forces after update
        ResetForces();
    }
}
