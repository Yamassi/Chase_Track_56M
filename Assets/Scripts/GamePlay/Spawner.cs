using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Orion.GamePlay
{
    public class Spawner : MonoBehaviour
    {
        
        
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Effect _effect1Prefab;
        [SerializeField] private Effect _effect2Prefab;
        [SerializeField] private Effect _effect3Prefab;
        [SerializeField] private Enemy _enemy1Prefab;
        [SerializeField] private Enemy _enemy2Prefab;
        [SerializeField] private Final _finalPrefab;
        private LineRenderer _lineRenderer;
        private Factory<Coin> _coinFactory;
        private Factory<Effect> _effect1Factory;
        private Factory<Effect> _effect2Factory;
        private Factory<Effect> _effect3Factory;
        private Factory<Enemy> _enemy1Factory;
        private Factory<Enemy> _enemy2Factory;
        private Final _final;
        private Action _onFinish;
        
        private int _currentPoint;

        public void Clear()
        {
            if (_coinFactory != null)
            {
                _coinFactory.ClearFactory();
            }
            
            if (_effect1Factory != null)
            {
                _effect1Factory.ClearFactory();
            }
            
            if (_effect2Factory != null)
            {
                _effect2Factory.ClearFactory();
            }
            
            if (_effect3Factory != null)
            {
                _effect3Factory.ClearFactory();
            }
            
            if (_enemy1Factory != null)
            {
                _enemy1Factory.ClearFactory();
            }
            
            if (_enemy2Factory != null)
            {
                _enemy2Factory.ClearFactory();
            }

            if (_final != null)
            {
                Destroy(_final.gameObject);
            }
        }

        public void Initialize(LineRenderer lineRenderer)
        {
            _lineRenderer = lineRenderer;
        }
        public void RandomSpawn()
        {
            _coinFactory = new Factory<Coin>(_coinPrefab,3);
            _effect1Factory = new Factory<Effect>(_effect1Prefab,3);
            _effect2Factory = new Factory<Effect>(_effect2Prefab,3);
            _effect3Factory = new Factory<Effect>(_effect3Prefab,3);
            _enemy1Factory = new Factory<Enemy>(_enemy1Prefab,3);
            _enemy2Factory = new Factory<Enemy>(_enemy2Prefab,3);
            
            List<Vector3> edges = new List<Vector3>();
            for (int i = 0; i < _lineRenderer.positionCount; i++)
            {
                Vector3 lineRendererPoint = _lineRenderer.GetPosition(i);
                edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
            }
            Spawn(edges);
        }
        
        private void Spawn(List<Vector3> points)
        {
            for (var i = 0; i < points.Count; i++)
            {
                
                if (i != points.Count - 1)
                {
                    RandomPoint(points[i], points[i + 1],false);
                    
                    RandomPoints(points[i], points[i + 1]);
                }

                if (i == points.Count - 1)
                {
                    _final = Instantiate(_finalPrefab, points[i], Quaternion.identity);
                }
                    
            }
        }

        private void CreateEffect(Vector3 position, int effectNumber)
        {
            Effect effect = null;
            switch (effectNumber)
            {
                case 0:
                    effect = _effect1Factory.Create();
                    break;
                case 1:
                    effect = _effect2Factory.Create();
                    break;
                case 2:
                    effect = _effect3Factory.Create();
                    break;
            }

            if (effect != null)
            {
                effect.transform.position = position;
            }
            
        }

        private void CreateEnemy(Vector3 position, int enemyNumber)
        {
            Enemy enemy = enemyNumber == 1 ? _enemy1Factory.Create() : _enemy2Factory.Create();
            enemy.transform.position = position;
        }

        private void CreateCoin(Vector3 position)
        {
            Coin coin = _coinFactory.Create();
            coin.transform.position = position;
        }

        private void RandomPoints(Vector3 point, Vector3 nextPoint)
        {
            bool isUp = Random.Range(0, 2) == 0;
            
            var points = GetPositions(point, nextPoint, isUp);
            
            for (var i = 0; i < points.Count; i++)
            {
                CreateCoin(points[i]);
            }
            
            var position = GetPosition(point, nextPoint, 2, !isUp);
            
            CreateRandomEntity(position,true);
        }

        private void RandomPoint(Vector3 point,Vector3 nextPoint,bool isGuaranteed)
        {
            bool isUp = Random.Range(0, 2) == 0;
            var position =  GetPosition(point, nextPoint, 0, isUp);

            CreateRandomEntity(position,isGuaranteed);
        }

        private void CreateRandomEntity(Vector3 position, bool isGuaranteed)
        {
            int randomNumber = Random.Range(0, 2);

            switch (randomNumber)
            {
                case 0:
                    CreateEnemy(position,Random.Range(0, 2));
                    break;
                case 1:
                    if (isGuaranteed)
                    {
                        CreateEffect(position,Random.Range(0, 3));
                    }
                    else
                    {
                        bool isEffect = Random.Range(0, 2) == 0;
                        if(isEffect)
                            CreateEffect(position,Random.Range(0, 3));
                    }
                    
                    break;
            }
        }

        private List<Vector3> GetPositions(Vector3 point, Vector3 nextPoint, bool isUp)
        {
            List<Vector3> points = new List<Vector3>()
            {
                GetPosition(point, nextPoint, 1,isUp),
                GetPosition(point, nextPoint, 2,isUp),
                GetPosition(point, nextPoint, 3,isUp),
            };
            return points;
        }
        private Vector3 GetPosition(Vector3 point, Vector3 nextPoint, float step, bool isUp)
        {
            float stepSize = 1.5f;
            float x = point.x + stepSize * step; 
            
            float progress = Mathf.Clamp01((x - point.x) / (nextPoint.x - point.x));
            
            float y = Mathf.Lerp(point.y, nextPoint.y, progress);
            return new Vector3(x, isUp ? y +1 : y -1, 0);
        }
        
    }
}
