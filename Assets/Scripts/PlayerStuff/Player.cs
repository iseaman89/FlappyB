using System;
using UnityEngine;

namespace PlayerStuff
{
    public class Player : MonoBehaviour, IUpdateListener
    {
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private PlayerConfig _playerConfig;
        private Updater _updater;
        private PlayerAnimator _playerAnimator;
        public Action OnCollision { get; set; }
        public Action OnTrigger { get; set; }
        public Action OnJump { get; set; }

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animator = gameObject.GetComponent<Animator>();
        }

        public void ResetPosition() => transform.position = _playerConfig.StartPosition;

        private void OnCollisionEnter2D() => OnCollision?.Invoke();

        private void OnTriggerExit2D(Collider2D other) => OnTrigger?.Invoke();

        public void Configurate(PlayerConfig playerConfig, Updater updater)
        {
            _playerConfig = playerConfig;
            _updater = updater;
            _playerAnimator = new PlayerAnimator(_animator, _rigidbody2D);
        }

        public void SetActive(bool status) => gameObject.SetActive(status);

        public void Activate()
        {
            _rigidbody2D.gravityScale = 1;
            _updater.AddListener(this);
            _updater.AddListener(_playerAnimator);
        }

        public void Deactivate()
        {
            _rigidbody2D.gravityScale = 0;
            _updater.RemoveListener(this);
            _updater.RemoveListener(_playerAnimator);
        }
        
        public void Updater(float deltaTime)
        {
#if UNITY_ANDROID
            
            if (Input.touchCount <= 0) return;
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _rigidbody2D.velocity = Vector2.up * _playerConfig.JumpForce;
                OnJump?.Invoke();
            }
#endif           
#if UNITY_EDITOR

            if (!Input.GetKeyDown(KeyCode.Space)) return;
            _rigidbody2D.velocity = Vector2.up * _playerConfig.JumpForce;
            OnJump?.Invoke();

#endif
        }
    }
}