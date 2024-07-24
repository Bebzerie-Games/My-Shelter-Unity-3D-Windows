using UnityEngine;
using System;

namespace MyShelterWin64.Game {

    [CreateAssetMenu(menuName = "My Shelter/New Entity Database")]
    public sealed class GameEntityDatabaseSO : ScriptableObject {
        public Entity[] EntityDatabase;
    }
}