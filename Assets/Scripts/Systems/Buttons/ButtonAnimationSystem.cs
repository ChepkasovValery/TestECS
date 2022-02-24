using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationSystem : ReactiveSystem<GameEntity>
{
    private GameContext _context;

    private const string ANIMATOR_IDLE_STATE = "Idle";

    private const string ANIMATOR_PUSH_STATE = "Push";

    public ButtonAnimationSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;       
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.animator.Value.GetCurrentAnimatorStateInfo(0).IsName(ANIMATOR_IDLE_STATE))
            {
                entity.animator.Value.Play(ANIMATOR_PUSH_STATE);
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasFloorButton && entity.hasAnimator;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.FloorButton);
    }
}
