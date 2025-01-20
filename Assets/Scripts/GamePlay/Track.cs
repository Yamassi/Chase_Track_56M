using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Orion.GamePlay
{
    [RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
    public class Track : MonoBehaviour
    {
        public LineRenderer LineRenderer { get;private set; }
        private EdgeCollider2D _edgeCollider;
        private Vector3 _startPosition = Vector3.zero;
        private Vector3 _previousPosition;
        private Vector3 _positionY;
        private int _currentPointNumber = 1;
        private const int MaxPoints = 12;
        private bool _isUpward;
        private void Awake()
        {
            LineRenderer = GetComponent<LineRenderer>();
            _edgeCollider = GetComponent<EdgeCollider2D>();
            
            _previousPosition = _startPosition;
            
            _isUpward = false;
        }
        [Button]
        public void GenerateTracks()
        {
            for (int i = 0; i < MaxPoints; i++)
            {
                GenerateTrack();
            }

            RefreshEdgeCollider();
        }
        [Button]
        public void ClearTracks()
        {
            _startPosition = transform.position;
            LineRenderer.positionCount = 1;
            Vector3 offset = new Vector3(-3, 0, 0);
            LineRenderer.SetPosition(0, _previousPosition+offset);
        }

        private void GenerateTrack()
        {
            if (_currentPointNumber <= MaxPoints)
            {
                _currentPointNumber++;
                CreateLine();
            }
            else
            {
                _currentPointNumber = 0;
            }

            int reverse = 3;
            if (_currentPointNumber == reverse)
            {
                _isUpward = !_isUpward;
            }
        }

        private void CreateLine()
        {
            float min = 0;
            float max = _isUpward ? 1.5f : -1.5f;
            float y = Random.Range(_startPosition.y + min,_startPosition.y + max);

            float step = 6;
            float x = _previousPosition.x + step;
            Vector3 nextPosition = new Vector3(x, y, 0);
            LineRenderer.positionCount++;
            LineRenderer.SetPosition(LineRenderer.positionCount - 1, nextPosition);
            _previousPosition = nextPosition;
        }

        private void RefreshEdgeCollider()
        {
            List<Vector2> edges = new List<Vector2>();

            for (int i = 0; i < LineRenderer.positionCount; i++)
            {
                Vector3 lineRendererPoint = LineRenderer.GetPosition(i);
                edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
            }

            _edgeCollider.SetPoints(edges);
        }
        
        
    }
}
