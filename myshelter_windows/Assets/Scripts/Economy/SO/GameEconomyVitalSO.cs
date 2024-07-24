using UnityEngine;

namespace MyShelterWin64.Game.Economy {
    [CreateAssetMenu(menuName = "My Shelter/Economy/New Economy Vital")]
    public sealed class GameEconomyVitalSO : ScriptableObject {
        public string Name;
        public string Description;
        public Sprite Icon;
    }
}