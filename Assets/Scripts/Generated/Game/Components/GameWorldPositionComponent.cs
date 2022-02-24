//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public WorldPositionComponent worldPosition { get { return (WorldPositionComponent)GetComponent(GameComponentsLookup.WorldPosition); } }
    public bool hasWorldPosition { get { return HasComponent(GameComponentsLookup.WorldPosition); } }

    public void AddWorldPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.WorldPosition;
        var component = (WorldPositionComponent)CreateComponent(index, typeof(WorldPositionComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceWorldPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.WorldPosition;
        var component = (WorldPositionComponent)CreateComponent(index, typeof(WorldPositionComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveWorldPosition() {
        RemoveComponent(GameComponentsLookup.WorldPosition);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWorldPosition;

    public static Entitas.IMatcher<GameEntity> WorldPosition {
        get {
            if (_matcherWorldPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WorldPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWorldPosition = matcher;
            }

            return _matcherWorldPosition;
        }
    }
}