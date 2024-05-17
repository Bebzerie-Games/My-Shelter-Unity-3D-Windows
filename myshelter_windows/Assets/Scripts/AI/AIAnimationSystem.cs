using UnityEngine;
using UnityEngine.AI;

namespace MyShelterWin64.AI {
    public class AIAnimationSystem : MonoBehaviour {
        [SerializeField] Animator _animator;
        [SerializeField] NPC _ai;
        [SerializeField] Transform _aiTransform;

        public void PlayAnimation(float velocity) {
            _animator.SetFloat("Walk Speed", velocity);
        }

        public void SetNoVelocity() {
            _animator.SetFloat("Walk Speed", 0);
        }

        public void SyncRotation() {
            if (_ai.Agent.velocity.sqrMagnitude > Mathf.Epsilon) {
                //_aiTransform.rotation = Quaternion.Slerp(_aiTransform.rotation, Quaternion.LookRotation(_ai.Agent.velocity.normalized), .5f * Time.deltaTime);
            }

        }

        private void FixedUpdate() {
            SyncRotation();
        }
    }
}