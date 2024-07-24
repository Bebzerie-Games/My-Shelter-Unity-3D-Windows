using MyShelterWin64.Game;
using MyShelterWin64.Game.Manager;
using UnityEngine;

public class ForceAddTodb : MonoBehaviour
{
    [SerializeField] Entity _entity;

    private void Start() {
        GameManager.Instance.GamePoolManager.GetPool().SpawnedEntity.Add(gameObject, _entity);
    }
}