using System.Threading.Tasks;
using Scripts.Configs;
using Scripts.Goods;
using Scripts.Popup;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Scripts.Generation
{
    public class PopupCreator : MonoBehaviour
    {
        [SerializeField] private PopupConfig _config;
        private PopupFactory _popupFactory;
        private SpriteFactory _spriteFactory;
        private GoodsFactory _goodsFactory;
        private RectTransform _canvas;

        private int _currentGoods;

        [Inject]
        private void Construct(PopupFactory popupFactory, SpriteFactory spriteFactory, GoodsFactory factory)
        {
            _popupFactory = popupFactory;
            _spriteFactory = spriteFactory;
            _goodsFactory = factory;
        }

        public PopupView Popup { get; private set; }
        public GoodsView Goods { get; private set; }
        public int GoodsLength => _config.GoodsData.Length;

        private async void OnEnable()
        {
            await _spriteFactory.Prepare(_config.MainImage);
            foreach (var goods in _config.GoodsData)
            {
                await _spriteFactory.Prepare(goods.GoodsConfig.GoodsIcon);
                await _spriteFactory.Prepare(goods.GoodsConfig.BackgroundIcon);
            }

            await _popupFactory.Prepare();
            await _goodsFactory.Prepare();
            _canvas = gameObject.GetComponent<RectTransform>();
        }

        private void OnDisable()
        {
            _spriteFactory.Clear(_config.MainImage);
            foreach (var goods in _config.GoodsData)
            {
                _spriteFactory.Clear(goods.GoodsConfig.GoodsIcon);
                _spriteFactory.Clear(goods.GoodsConfig.BackgroundIcon);
            }

            _goodsFactory.Clear();
            _popupFactory.Clear();
            _currentGoods = 0;
        }

        public async Task<PopupModel> CreatePopup()
        {
            while (_canvas == null)
                await Task.Delay(50);

            Popup = await _popupFactory.Create(_canvas, _canvas.localPosition);
            return new PopupModel(_config.HeaderText, _config.DescriptionText, _config.MainImage, _config.PriceData);
        }

        public async Task<GoodsModel> CreateGoods(Transform parentRow)
        {
            Goods = await _goodsFactory.Create(parentRow);
            var model = new GoodsModel(_config.GoodsData[_currentGoods]);
            _currentGoods++;

            return model;
        }

        public async Task<Sprite> CreateSprite(AssetReferenceSprite sprite) =>
            await _spriteFactory.Create(sprite);
    }
}