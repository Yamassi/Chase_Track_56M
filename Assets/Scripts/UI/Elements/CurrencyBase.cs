using System;
using Orion.Data;
using UnityEngine;
using Zenject;

namespace Orion.UI.Elements
{
    public abstract class CurrencyBase : MonoBehaviour
    {
        protected DataService _dataService;
        protected Currency _currency;
        protected ResourcePresenter _resource;
        
        [Inject]
        public void Construct(DataService dataService)
        {
            _dataService = dataService;
        }
        protected virtual void Awake()
        {
            _currency = GetComponent<Currency>();
            _resource = new();
        }

        protected virtual void OnDestroy()
        {
            _resource.Dispose();
        }
    }
}