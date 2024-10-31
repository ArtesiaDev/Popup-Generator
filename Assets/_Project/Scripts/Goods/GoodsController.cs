using System;
using Scripts.EventSignals;
using Scripts.Generation;
using UnityEngine;
using Zenject;

namespace Scripts.Goods
{
    public class GoodsController : IInitializable, IDisposable
    {
        private PopupCreator _creator;
        private IPopupSignals _popupSignals;

        private GoodsView _view;
        private GoodsModel _model;

        [Inject]
        private void Construct(PopupCreator creator, IPopupSignals popupSignals)
        {
            _creator = creator;
            _popupSignals = popupSignals;
        }

        public void Initialize() =>
            _popupSignals.PopupGenerated += GenerateGoods;

        public void Dispose() =>
            _popupSignals.PopupGenerated -= GenerateGoods;

        private async void GenerateGoods()
        {
            var half = Mathf.Min(3, _creator.GoodsLength);

            for (var i = 0; i < _creator.GoodsLength; i++)
            {
                var parentRow = i < half ? _creator.Popup.TopRowLayout : _creator.Popup.BottomRowLayout;

                _model = await _creator.CreateGoods(parentRow);
                _view = _creator.Goods;

                var goodsIcon = await _creator.CreateSprite(_model.GoodsIcon);
                var backgroundIcon = await _creator.CreateSprite(_model.BackgroundIcon);
                _view.Draw(goodsIcon, backgroundIcon, _model.Quantity, _model.QuantityBackColor);
            }
            _creator.Popup.gameObject.SetActive(true);
        }
    }
}