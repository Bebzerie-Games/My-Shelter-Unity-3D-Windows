using MyShelterWin64.Game.Economy;
using MyShelterWin64.Game.Manager;
using System;
using UnityEngine;

namespace MyShelterWin64.Game {

    public abstract class Entity : MonoBehaviour, IEntity {
        [SerializeField] EntitySO _entitySO;

        public EntitySO EntitySO => _entitySO;

        public abstract event Action OnInteractionEnter;
        public abstract event Action OnInteractionExit;
        public abstract event Action OnEntitySpawn;

        [Header("AI Entity Only :")]
        [SerializeField] GameObject _npcCallbacks;

        // TODO : refacto le code et utiliser la fonction Get() de la class en priorité sur l'accès des data du entity
        public Entity Get() {
            return this;
        }

        public override string ToString() {
            return EntitySO.EntityName;
        }

        public GameObject GetNPCCallbacks() {
            return _npcCallbacks;
        }

        public abstract void OnSpawn();

        public abstract void DoInteractionEnter();

        public abstract void DoInteractionExit();

        public void DoSpawn() {
            throw new NotImplementedException();
        }
    }
}