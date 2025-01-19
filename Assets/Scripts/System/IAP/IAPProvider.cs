using Orion.Data;
using UnityEngine;
using UnityEngine.Purchasing;
using Zenject;

namespace Orion.System.IAP
{
    public class IAPService : MonoBehaviour
    {
        private DataService _dataService;
        
        [Inject]
        public void Construct(DataService data)
        {
            _dataService = data;
        }

        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void PurschaseComplete(Product product)
        {
            if (product.definition.id == IAPNames.Belzak)
            {
                _dataService.PlayerData.Characters.SelectWithRefresh(4);
            }
        }
    }
}