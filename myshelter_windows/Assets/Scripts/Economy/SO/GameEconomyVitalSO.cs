using MyShelterWin64.Game.Manager;
using System.Collections;
using UnityEngine;

namespace MyShelterWin64.Economy {
    [CreateAssetMenu(menuName = "My Shelter/Economy/New Economy Vital")]
    public class GameEconomyVitalSO : ScriptableObject {
        public string Name;
        public string Description;
        public Sprite Icon;
    }
}