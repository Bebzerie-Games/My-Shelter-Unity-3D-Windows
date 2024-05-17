using UnityEngine;

namespace MyShelterWin64.Game {

    [CreateAssetMenu(menuName = "My Shelter/New Entity Database")]
    public class GameEntityDatabaseSO : ScriptableObject {
        public Entity[] EntityDatabase;
    }
}