using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class WorldPositionSystem : ReactiveSystem<GameEntity>
{
    public WorldPositionSystem(IContext<GameEntity> context) : base(context)
    {
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            e.ReplaceWorldPosition(e.view.Value.transform.position);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasWorldPosition;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.WorldPosition);
    }
}
