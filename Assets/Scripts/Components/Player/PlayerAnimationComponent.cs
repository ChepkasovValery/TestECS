using Entitas;
using UnityEngine;
using UnityEngine.AI;

[Game]
public class PlayerAnimationComponent : IComponent
{
    public Animator Animator;

    public NavMeshAgent NavMeshAgent;
}
