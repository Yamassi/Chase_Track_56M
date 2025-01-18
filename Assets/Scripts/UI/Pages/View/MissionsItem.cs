using System;
using Orion.System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Orion.UI.Pages.View
{
    public class MissionsItem : MonoBehaviour
    {
        [SerializeField] private Image[] _frames;
        [SerializeField] private TextMeshProUGUI _amount,_reward, _state;
        [SerializeField] private Button _get;
        
        public void Initialize(int id, Action<int> onGet,int amount, int maxAmount, int reward)
        {
            _get.onClick.RemoveAllListeners();
            _get.onClick.AddListener(() => onGet?.Invoke(id));
            _reward.text = reward.ToString();
            _amount.text = $"{amount}/{maxAmount}";
        }

        public void SetUncomplete()
        {
            _frames.SetActiveOneElement(0);
            _state.text = "Soon";
        }

        public void SetComplete()
        {
            _frames.SetActiveOneElement(1);
            _state.text = "Get Reward";
        }

        public void SetTaked()
        {
            _frames.SetActiveOneElement(2);
            _state.text = "Done";
        }
    }
}