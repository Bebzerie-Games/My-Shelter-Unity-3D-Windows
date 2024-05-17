using UnityEngine;

namespace MyShelterWin64.Game {
    [CreateAssetMenu(menuName = "My Shelter/New Entity")]
    public class EntitySO : ScriptableObject {
        public EntityType Type;
        public int EntityID;
    }
}