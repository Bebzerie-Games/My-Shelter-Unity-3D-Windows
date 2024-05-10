using UnityEngine;

namespace MyShelterWin64.AI {
    public class AIAnimationSystem : MonoBehaviour {
        [SerializeField] Animator _animator;
        public void PlayAnimation(bool isHorizontal, float velocity) {
            if (!isHorizontal)
                _animator.SetFloat("Vertical", velocity);
            else
                _animator.SetFloat("Horizontal", velocity);
        }

        public void SetNoVelocity() {
            _animator.SetFloat("Vertical", 0);
            _animator.SetFloat("Horizontal", 0);
        }
    }
}