using MyShelterWin64.Economy;
using MyShelterWin64.Game.Manager;
using System.Collections;

namespace MyShelterWin64.Building {
    public class GameBuilding : GameEconomyObject
    {
        public override IEnumerator Add() {
            SetDelay();

            do {
                yield return base.Add();
            }
            while (gameObject.activeSelf);
        }
    }
}