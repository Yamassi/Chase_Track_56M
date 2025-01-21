using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

namespace Orion.GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Wagon : MonoBehaviour
    {
        public bool IsReversed {get; private set;}
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D[] _wheels;
        [SerializeField] private FireDestroyer _fire;
        private Rigidbody2D _rigidbody;
        private Action _onFinished;
        private Action _onCoin;
        private Action _onEnemy;
        private Action<int> _onEffect;
        private EffectsDuration _effectsDuration;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private bool _isShieldActive;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            IsReversed = false;
        }

        public void Initialize(Action onFinished, Action onCoin, Action onEnemy, Action<int> onEffect,EffectsDuration effectsDuration)
        {
            _effectsDuration = effectsDuration;
            _onEffect = onEffect;
            _onEnemy = onEnemy;
            _onCoin = onCoin;
            _onFinished = onFinished;
        }

        private void OnDestroy()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }

        private void FixedUpdate()
        {
            Vector2 forceDirection = IsReversed ? -transform.right : transform.right;
            _rigidbody.AddForce(forceDirection * _speed, ForceMode2D.Force);
            
            if (_rigidbody.velocity.magnitude > _speed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
            }
        }

        [Button]
        public void Reverse()
        {
            float reversePosDistance = 1.5f;
            Vector3 position;
            Quaternion rotation;
            int gravity;
            if (IsReversed)
            {
                position = new Vector3(transform.position.x, transform.position.y+reversePosDistance, transform.position.z);
                rotation = Quaternion.Euler(0, 0, 0);
                gravity = 1;
            }
            else
            {
                position = new Vector3(transform.position.x, transform.position.y-reversePosDistance, transform.position.z);
                rotation = Quaternion.Euler(0, 0, 180);
                gravity = -1;
            }
            
            transform.position = position;
            transform.rotation = rotation;
            
            Vector2 velocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector2(velocity.x, velocity.y * -1); 

            _rigidbody.gravityScale = gravity;
            _rigidbody.angularVelocity = 0f;

            foreach (var wheel in _wheels)
            {
                wheel.gravityScale = gravity;
                wheel.angularVelocity = 0f;
            }

            IsReversed = !IsReversed;
            
            _fire.transform.localRotation = Quaternion.Euler(0, IsReversed ? 180:0, 56);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Final final))
            {
                _onFinished?.Invoke();
            }

            if (other.TryGetComponent(out Coin coin))
            {
                _onCoin?.Invoke();
                coin.Recycle();
            }
            
            if (other.TryGetComponent(out Enemy enemy))
            {
                if (!_isShieldActive)
                    _onEnemy?.Invoke();
            }
            
            if (other.TryGetComponent(out Lighting lighting))
            {
                _onEffect?.Invoke(0);
                lighting.Recycle();
                Lighting();
            }
            
            if (other.TryGetComponent(out Shield shield))
            {
                _onEffect?.Invoke(1);
                Shield(shield);
            }
            
            if (other.TryGetComponent(out Fire fire))
            {
                _onEffect?.Invoke(2);
                fire.Recycle();
                _fire.Fire(_effectsDuration.FireDuration);
            }
        }

        private async void Shield(Shield shield)
        {
            shield.Recycle();
            _isShieldActive = true;
            await UniTask.Delay(_effectsDuration.ShieldDuration * 1000);
            _isShieldActive = false;
        }

        private async void Lighting()
        {
            var oldSpeed = _speed;
            _speed = 8;
            await UniTask.Delay(_effectsDuration.LightingDuration * 1000);
            _speed = 6;
        }
    }
}