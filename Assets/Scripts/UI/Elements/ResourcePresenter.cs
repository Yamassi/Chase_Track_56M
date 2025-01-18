using System;
using Orion.Data;

namespace Orion.UI.Elements
{
    public class ResourcePresenter : IDisposable
    {
        private Currency _currency;
        private ResourceData _resourceData;
        public void Initialize(Currency currency, ResourceData resourceData)
        {
            _resourceData = resourceData;
            _currency = currency;
            _currency.SetCurrency(_resourceData.Value);
           
            _resourceData.OnAdd += _currency.AddCurrency;
            _resourceData.OnRemove += _currency.RemoveCurrency;
        }
        public void Dispose()
        {
            _resourceData.OnAdd -= _currency.AddCurrency;
            _resourceData.OnRemove -= _currency.RemoveCurrency;
        }
    }
}