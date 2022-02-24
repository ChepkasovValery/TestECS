using Entitas;
using UnityEngine;

public class PlayerMoverSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public PlayerMoverSystem(Contexts context)
    {
        _context = context.game;
    }

    public void Execute()
    {
        GameEntity player = _context.playerEntity;

        if (player.hasNavMeshTargetPosition && player.hasMouseWorldRayPosition)
        {
            player.ReplaceNavMeshTargetPosition(player.mouseWorldRayPosition.Value);
        }
    }
}
