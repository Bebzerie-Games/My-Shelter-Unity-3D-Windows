using MyShelterWin64.Economy;
using MyShelterWin64.Game;
using MyShelterWin64.Game.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUDCtrl : MonoBehaviour
{
    [Header("Economy TMP:")]
    [SerializeField] TextMeshProUGUI _goldTextTMP;
    [SerializeField] TextMeshProUGUI _vitalTextTMP;

    [Header("Builder Mod :")]
    [SerializeField] GameObject _builderModParent;

    public void UpdateGoldValueText() {
        _goldTextTMP.text = $"Gold : {GameManager.Instance.GameEconomy.Gold}";
    }

    public void DisplayBuilderMod(bool active) {
        _builderModParent.SetActive(active);
    }

    public void UpdateVitalValueText() {
        _vitalTextTMP.text = $"Vital : {GameManager.Instance.GameEconomy.Vital}";
    }

    public static void DoOpenAIPannel(Entity entity) {
        entity.DoInteractionEnter();
    }
}