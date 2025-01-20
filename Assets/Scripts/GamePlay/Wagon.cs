using System;
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
        private Rigidbody2D _rigidbody;
        private Action _onFinished;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            IsReversed = false;
        }

        public void Initialize(Action onFinished, Action onCoin, Action onEnemy)
        {
            _onFinished = onFinished;
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
            Vector3 rotation;
            int gravity;
            if (IsReversed)
            {
                position = new Vector3(transform.position.x, transform.position.y+reversePosDistance, transform.position.z);
                rotation = Vector3.zero;
                gravity = 1;
            }
            else
            {
                position = new Vector3(transform.position.x, transform.position.y-reversePosDistance, transform.position.z);
                rotation = new Vector3(0,0,180);
                gravity = -1;
            }
            
            transform.position = position;
            transform.rotation = Quaternion.Euler(rotation);

            _rigidbody.gravityScale = gravity;
            _rigidbody.angularVelocity = 0f;
            
            
            IsReversed = !IsReversed;
            
            foreach (var wheel in _wheels)
            {
               wheel.gravityScale = gravity;
               wheel.angularVelocity = 0f;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Final final))
            {
                _onFinished?.Invoke();
            }

            if (other.TryGetComponent(out Coin coin))
            {
                
            }
        }
    }
}