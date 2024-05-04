using UnityEngine;
using UnityEngine.Events;

namespace MyShelterWin64.Game {
    public class Entity : MonoBehaviour {
        [SerializeField] EntityType _entityType;
        public EntityType EntityType => _entityType;

        public UnityEvent<string> OnInteractionEnter;
    }
}