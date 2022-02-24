using Entitas;
using UnityEngine;

public class Door : MonoBehaviour, IEntityView
{
    public GameEntity Entity { get; set; }

    [field: SerializeField] public Animator Animator { get; set; }

    [field: SerializeField] private Renderer Render { get; set; }

    public void SetColor(Color color)
    {
        Material newMaterial = new Material(Render.material);

        newMaterial.color = color;

        Render.material = newMaterial;
    }
}
