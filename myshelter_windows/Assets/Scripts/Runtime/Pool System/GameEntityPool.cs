using MyShelterWin64.Game.Manager;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace MyShelterWin64.Game.Pooling {

    public sealed class GameEntityPool : MonoBehaviour {
        public ObjectPool<Entity> EntityPool;

        public GameEntityPoolSO PoolSO;

        [SerializeField] Transform[] _poolObjectsParent;

        public Dictionary<GameObject, Entity> SpawnedEntity = new();

        private void Start() {
            EntityPool = new ObjectPool<Entity>(() => {
                return Spawn();
            },
            entityOnSpawn => {
                entityOnSpawn.gameObject.SetActive(true);
            },
            entityOnRelease => {
                entityOnRelease.gameObject.SetActive(false);
            },
            entityOnPoolFilled => {
                Destroy(entityOnPoolFilled.gameObject);
            },
            true // TODO : Vérifier le collisionCheck du pool afin de sauver du cpu cycle
            );
        }

        public Entity Spawn(int entityID = 0) {
            print(entityID);
            Entity newEntity = GameManager.Instance.EntityManager.GetByID(entityID);

            return Instantiate(newEntity, Vector3.zero, Quaternion.identity);
        }
    }
}