using UnityEngine;

namespace MyShelterWin64.Game {
    [CreateAssetMenu(menuName = "My Shelter/New Entity")]
    public sealed class EntitySO : ScriptableObject {

        [SerializeField] EntityType _type;
        [SerializeField] Vector2Int _cellsDimension;
        [SerializeField] int _entityID;
        [SerializeField] string _entityName;
        [SerializeField] string _entityDescription;

        public EntityType Type => _type;
        public Vector2Int CellsDimension => _cellsDimension;
        public int EntityID => _entityID;
        public string EntityName => _entityName;
        public string EntityDescription => _entityDescription;
    }
}