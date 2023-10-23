using UnityEngine;

namespace PlayerStuff
{
    public class PlayerAnimator : IUpdateListener
    {
        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody;

        public PlayerAnimator(Animator animator, Rigidbody2D rigidbody)
        {
            _animator = animator;
            _rigidbody = rigidbody;
        }

        private void Play(string name) => _animator.Play(name);
        
        public void Updater(float deltaTime)
        {
            switch (_rigidbody.velocity.y)
            {
                case > 0:
                    Play("Up");
                    break;
                case < 0:
                    Play("Down");
                    break;
                default:
                    Play("Idle");
                    break;
            }
        }
    }
}