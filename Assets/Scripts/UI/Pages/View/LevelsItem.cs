using System;
using Orion.System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class LevelsItem : MonoBehaviour
    {
        [SerializeField] private Image[] _frames;
        [SerializeField] private Image[] _stars;
        [SerializeField] private TextMeshProUGUI[] _name;
        [SerializeField] private Button _play;
        
        public void Initialize(int id, Action<int> onGet, int stars)
        {
            for (var i = 0; i < _name.Length; i++)
            {
                _name[i].text = $"{id+1}";
            }
            
            
            _play.onClick.RemoveAllListeners();
            _play.onClick.AddListener(() => onGet?.Invoke(id));
            
            _stars.SetActiveLowerElements(stars);
        }
        
        public void SetOpen()
        {
            _frames.SetActiveOneElement(0);
            _play.gameObject.SetActive(true);
        }

        public void SetCurrent()
        {
            _frames.SetActiveOneElement(1);
            _play.gameObject.SetActive(true);
        }

        public void SetLock()
        {
            _frames.SetActiveOneElement(2);
            _play.gameObject.SetActive(false);
        }
    }
}