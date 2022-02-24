using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    private const string ANIMATOR_CLOSED_STATE = "Closed";

    private const string ANIMATOR_OPEN_STATE = "Open";

    private const string ANIMATOR_CLOSE_STATE = "Close";

    public DoorAnimationSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.animator.Value.GetCurrentAnimatorStateInfo(0).IsName(ANIMATOR_CLOSED_STATE))
            {
                entity.animator.Value.Play(ANIMATOR_OPEN_STATE);
            }
            else
            {
                entity.animator.Value.Play(ANIMATOR_CLOSE_STATE);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDoor && entity.hasAnimator;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Door);
    }
}
