using Entitas;
using UnityEngine;

[Game]
public class MoverToTargetComponent : IComponent
{
    public Transform Target;

    public Vector3 Offset;

    public float Speed;
}
