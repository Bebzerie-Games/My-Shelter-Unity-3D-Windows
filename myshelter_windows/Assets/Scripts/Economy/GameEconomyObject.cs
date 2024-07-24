using UnityEngine;
using System.Collections;
using MyShelterWin64.Game.Building;
using System;

namespace MyShelterWin64.Game.Economy {

    public class GameEconomyObject : Entity, IGameEconomyObject {
        public GameBuildingSO BuildingSO;

        WaitForSeconds Wait;

        public override event Action OnInteractionEnter;
        public override event Action OnInteractionExit;
        public override event Action OnEntitySpawn;

        public void SetDelay() {
            Wait = new(BuildingSO.Delay);
        }

        public virtual IEnumerator Add() {
            yield return Wait;
        }

        public override void OnSpawn() {
            throw new NotImplementedException();
        }

        public override void DoInteractionEnter() {
            throw new NotImplementedException();
        }

        public override void DoInteractionExit() {
            throw new NotImplementedException();
        }
    }
}