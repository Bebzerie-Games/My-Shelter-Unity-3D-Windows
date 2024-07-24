using MyShelterWin64.Game;
using MyShelterWin64.Game.Manager;
using System.Text;
using TMPro;
using UnityEngine;

namespace MyShelterWin64.Game.Player {
    public sealed class GameHUDCtrl : MonoBehaviour {
        [Header("Economy TMP:")]
        [SerializeField] TextMeshProUGUI _goldTextTMP;
        [SerializeField] TextMeshProUGUI _vitalTextTMP;

        [Header("Builder Mod :")]
        [SerializeField] GameObject _builderModParent;

        readonly StringBuilder _sbGoldText = new("Gold : "),
            _sbVitalText = new("Vital : ");

        public void UpdateGoldValueText() {
            _sbGoldText.Clear();
            _goldTextTMP.text = _sbGoldText.Append($"Gold : {GameManager.Instance.GameEconomy.Gold}").ToString();
        }

        public void DisplayBuilderMod(bool active) {
            _builderModParent.SetActive(active);
        }

        public void UpdateVitalValueText() {
            _sbVitalText.Clear();
            _vitalTextTMP.text = _sbVitalText.Append($"Vital : {GameManager.Instance.GameEconomy.Vital}").ToString();
        }

        public static void DoOpenAIPannel(Entity entity) {
            entity.DoInteractionEnter();
        }
    }
}