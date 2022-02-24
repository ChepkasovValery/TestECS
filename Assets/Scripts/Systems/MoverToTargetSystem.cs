using Entitas;
using UnityEngine;

public class MoverToTargetSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    private readonly IGroup<GameEntity> _toTargetMovers;

    public MoverToTargetSystem(Contexts contexts)
    {
        _contexts = contexts;

        _toTargetMovers = _contexts.game.GetGroup(GameMatcher.MoverToTarget);
    }

    public void Execute()
    {
        foreach(var entity in _toTargetMovers.GetEntities())
        {
            Transform entityTransform = entity.view.Value.transform;

            Transform targetTransform = entity.moverToTarget.Target;

            Vector3 targetPos = targetTransform.position + entity.moverToTarget.Offset;

            Vector3 newPos = Vector3.Lerp(entityTransform.position, targetPos, Time.deltaTime * entity.moverToTarget.Speed);

            entityTransform.position = newPos;
        }
    }
}
