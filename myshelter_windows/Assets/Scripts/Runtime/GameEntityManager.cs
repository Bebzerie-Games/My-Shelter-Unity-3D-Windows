using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace MyShelterWin64.Game.Manager {
    public sealed class GameEntityManager : MonoBehaviour {
        public GameEntityDatabaseSO EntityStore;

        public ReadOnlyDictionary<int, Entity> RL_EntityDatabase;

        void Start() {
            Dictionary<int, Entity> EntityDatabase = new();

            for (int i = 0; i < EntityStore.EntityDatabase.Length; i++) {
                EntityDatabase.Add(EntityStore.EntityDatabase[i].EntitySO.EntityID, EntityStore.EntityDatabase[i]);
            }

            RL_EntityDatabase = new ReadOnlyDictionary<int, Entity>(EntityDatabase);

#if MS_DEBUGGING_ONLY
            GameManager.MS_PRINT(typeof(GameEntityManager), "readonly dictionnary entity database is made");
#endif
        }

        public Entity GetByID(int id) {
            return RL_EntityDatabase[id];
        }
    }
}