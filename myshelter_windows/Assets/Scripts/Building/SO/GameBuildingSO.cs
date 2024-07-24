using MyShelterWin64.Game.Economy;
using UnityEngine;

namespace MyShelterWin64.Game.Building {
    /// <summary>
    /// GameBuilding data profile, delay, Entity link, ...
    /// </summary>
    [CreateAssetMenu(menuName = "My Shelter/New Building")]
    public class GameBuildingSO : ScriptableObject {
        [Tooltip("Each time the GenerationPerDelay will be achieved, the based economy container will be added or decreased")]
        public float GenerationPerDelay;

        [Tooltip("In seconds")]
        public int Delay;

        public EntitySO EntitySO;

        public GameEconomyObjectType EconomyGenerationType;
    }
}