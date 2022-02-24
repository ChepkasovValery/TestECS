using Entitas;
using System.Collections.Generic;

public class NavMeshMoverSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _contexts;

    private readonly IGroup<GameEntity> _movers;

    public NavMeshMoverSystem(Contexts contexts) : base (contexts.game)
    {
        _contexts = contexts.game;

        _movers = _contexts.GetGroup(GameMatcher.NavMeshTargetPosition);
    }


    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.navMeshMover.NavMeshAgent.SetDestination(entity.navMeshTargetPosition.Value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasNavMeshMover && entity.hasNavMeshTargetPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.NavMeshTargetPosition);
    }
}
