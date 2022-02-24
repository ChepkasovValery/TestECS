using Entitas;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimationSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    private readonly IGroup<GameEntity> _movers;

    private const string ANIMATOR_SPEED_NAME = "Speed";

    public PlayerAnimationSystem(Contexts contexts)
    {
        _contexts = contexts;

        _movers = _contexts.game.GetGroup(GameMatcher.PlayerAnimation);
    }

    public void Execute()
    {
        foreach(var entity in _movers.GetEntities())
        {
            NavMeshAgent navMeshAgent = entity.playerAnimation.NavMeshAgent;

            Animator animator = entity.playerAnimation.Animator;

            animator.SetFloat(ANIMATOR_SPEED_NAME, navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        }
    }
}
