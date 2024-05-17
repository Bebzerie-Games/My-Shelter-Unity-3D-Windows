using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;
using System;
using System.Collections;
using MyShelterWin64.Game.Manager;
using MyShelterWin64.Building;

namespace MyShelterWin64.Economy {

    public partial class GameEconomyObject : MonoBehaviour, IGameEconomyObject {
        public GameBuildingSO BuildingSO;

        WaitForSeconds Wait;
        public void SetDelay() {
            Wait = new(BuildingSO.Delay);
        }

        public virtual IEnumerator Add() {
            yield return Wait;
        }
    }
}