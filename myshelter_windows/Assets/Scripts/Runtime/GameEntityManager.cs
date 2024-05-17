using MyShelterWin64.Game.Manager;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace MyShelterWin64.Game {
    public class GameEntityManager : MonoBehaviour {
        public GameEntityDatabaseSO Entities;

        public Dictionary<int, Entity> EntityDatabase = new();

        public ReadOnlyDictionary<int, Entity> RL_EntityDatabase;

        void Start() {
            for (int i = 0; i < Entities.EntityDatabase.Length; i++) {
                AddNewEntity(Entities.EntityDatabase[i], Entities.EntityDatabase[i].EntitySO.EntityID);
            }

            RL_EntityDatabase = new ReadOnlyDictionary<int, Entity>(EntityDatabase);

#if MS_DEBUGGING_ONLY
            GameManager.MS_PRINT(typeof(GameEntityManager), "readonly dictionnary entity database is made");
#endif
        }

        public void AddNewEntity(Entity entity, int id) {
            EntityDatabase.Add(id, entity);
        }

        public Entity GetByID(int id) {
            return EntityDatabase[id];
        }
    }
}