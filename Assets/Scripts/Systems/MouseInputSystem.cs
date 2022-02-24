using Entitas;
using UnityEngine;

public class MouseInputSystem : IExecuteSystem
{
    private readonly Contexts _context;

    private Camera _mainCamera;

    private IGroup<GameEntity> _entitesWithPositions;

    public MouseInputSystem(Contexts context, Camera mainCamera)
    {
        _context = context;

        _mainCamera = mainCamera;

        _entitesWithPositions = context.game.GetGroup(GameMatcher.MouseWorldRayPosition);
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;

            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                foreach(var entity in _entitesWithPositions)
                {
                    entity.mouseWorldRayPosition.Value = hit.point;
                }
            }
        }
    }
}
