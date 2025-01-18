using System;
using UniRx;
using UnityEngine;

namespace Orion.GamePlay
{
    public class InputTouch : IDisposable
    {
        private CompositeDisposable _disposable = new();
        private Vector2 _startPos;
        private Vector2 _endPos;
        private float _swipeThreshold = 20;
        private Action _onSwipe;
        private bool _isBomb;

        public void Initialize(Action onSwipe)
        {
            _onSwipe = onSwipe;
            TouchInput();
        }
        public void SetBomb()=>_isBomb = true;
        private void TouchInput()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    var touchPoint = Camera.main.ScreenToWorldPoint(touch.position);
                    RaycastHit2D hit = Physics2D.Raycast(touchPoint, Camera.main.transform.forward);

                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            if (hit.collider != null)
                            {
                
                            }

                            break;

                        case TouchPhase.Ended:

                            break;
                    }
                }
            }).AddTo(_disposable);
        }

        private MoveDirection DetectSwipeDirection(Vector2 swipeDirection)
        {
            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                if (swipeDirection.x > 0)
                {
                    return MoveDirection.Right;
                }
                else
                {
                    return MoveDirection.Left;
                }
            }
            else
            {
                if (swipeDirection.y > 0)
                {
                    return MoveDirection.Up;
                }
                else
                {
                    return MoveDirection.Down;
                }
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}