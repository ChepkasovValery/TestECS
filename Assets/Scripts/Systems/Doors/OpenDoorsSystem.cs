using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorsSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public OpenDoorsSystem(Contexts context) : base(context.game)
    {
        _context = context.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            GameEntity button = null;

            if (entity.collision.FirstEntity.hasFloorButton)
            {
                button = entity.collision.FirstEntity;
            }
            else if (entity.collision.SecondEntity.hasFloorButton)
            {
                button = entity.collision.SecondEntity;
            }

            button.ReplaceFloorButton(true);

            TryOpenDoor(button.relatedGameEntity.Value);

            entity.Destroy();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }

    private void TryOpenDoor(GameEntity doorEntity)
    {
        if (doorEntity.hasDoor)
        {
            if (!doorEntity.door.Open)
            {
                doorEntity.ReplaceDoor(true);
            }
        }
    }
}
