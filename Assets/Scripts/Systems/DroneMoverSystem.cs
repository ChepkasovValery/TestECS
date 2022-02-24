using Entitas;
using UnityEngine;
using System;

public class DroneMoverSystem : IExecuteSystem
{
    private readonly GameContext _context;

    private Transform _player;

    private DateTime _lastTimeChangePoint;

    private float _lastPositionValue;

    public DroneMoverSystem(Contexts contexts)
    {
        _context = contexts.game;

        _lastTimeChangePoint = DateTime.Now;

        _player = _context.playerEntity.view.Value.transform;
    }

    public void Execute()
    {
        if(_player == null)
        {
            return;
        }

        Vector3 nextPos = GetNextPos();

        _context.droneEntity.ReplaceNavMeshTargetPosition(nextPos);
    }

    private Vector3 GetNextPos()
    {
        if (DateTime.Now.Subtract(_lastTimeChangePoint).TotalSeconds > 1)
        {
            _lastPositionValue = UnityEngine.Random.Range(0, 2 * Mathf.PI);

            _lastTimeChangePoint = DateTime.Now;
        }

        float radius = 2;

        float x = radius * Mathf.Cos(_lastPositionValue) + _player.position.x;

        float y = _context.droneEntity.view.Value.transform.position.y;

        float z = radius * Mathf.Sin(_lastPositionValue) + _player.position.z;

        return new Vector3(x, y, z);
    }
}
