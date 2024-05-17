using UnityEngine;

namespace MyShelterWin64.Economy {
    [CreateAssetMenu(menuName = "My Shelter/Economy/New Economy Gold")]
    public class GameEconomyGoldSO : ScriptableObject
    {
        public string Name;
        public string Description;
        public Sprite Icon;
    }
}