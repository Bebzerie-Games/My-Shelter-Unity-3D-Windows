using MyShelterWin64.Economy;
using MyShelterWin64.Game;
using UnityEngine;

namespace MyShelterWin64.Building {
    [CreateAssetMenu(menuName = "My Shelter/New Building")]
    public class GameBuildingSO : ScriptableObject {
        public string Name;

        [Tooltip("Each time the GenerationPerDelay will be achieved, the based economy container will be added or decreased")]
        public float GenerationPerDelay;

        [Tooltip("In seconds (value^10)")]
        public float Delay;

        public Vector2 CellsDimension = new();

        public EntitySO EntitySO;

        public GameEconomyObjectType EconomyGenerationType;
    }
}