using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Orion.GamePlay
{
    public class FireDestroyer : MonoBehaviour
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private Tween _tween;
        private void OnDestroy()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
                _cts = null;
            }
        }

        public async void Fire(int time)
        {
            transform.localScale = Vector3.one;
            _tween.Kill();
            gameObject.SetActive(true);
            _tween = transform.DOPunchScale(new Vector3(1.2f,1.2f,1.2f), 0.1f).SetLoops(-1,LoopType.Restart);
            await UniTask.Delay(time * 1000);
            transform.localScale = Vector3.one;
            gameObject.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                enemy.Recycle();
            }
        }
    }
}