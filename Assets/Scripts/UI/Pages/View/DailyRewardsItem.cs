using System;
using Orion.System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class DailyRewardsItem : MonoBehaviour
    {
        [SerializeField] private Image[] _frames;
        [SerializeField] private TextMeshProUGUI _reward,_day;
        [SerializeField] private Button _get;

        public void Initialize(int id, Action<int> onGet, int reward)
        {
            _get.onClick.AddListener(() => onGet?.Invoke(id));
            _reward.text = reward.ToString();
            _day.text = $"{id + 1} day";
        }

        public void SetUncomplete()
        {
            _frames.SetActiveOneElement(0);
        }

        public void SetComplete()
        {
            _frames.SetActiveOneElement(1);
        }

        public void SetTaked()
        {
            _frames.SetActiveOneElement(2);
        }
    }
}