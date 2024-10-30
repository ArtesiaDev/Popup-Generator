using System.Threading.Tasks;
using _Project.Scripts.Configs;
using _Project.Scripts.Popup;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Generation
{
    public class PopupCreator : MonoBehaviour
    {
        [SerializeField] private PopupConfig _config;
        private PopupFactory _popupFactory;
        private SpriteFactory _spriteFactory;
        private RectTransform _canvas;

        [Inject]
        private void Construct(PopupFactory popupFactory, SpriteFactory spriteFactory)
        {
            _popupFactory = popupFactory;
            _spriteFactory = spriteFactory;
        }

        public PopupView Popup { get; private set; }

        private async void Start()
        {
            await _spriteFactory.Prepare(_config.MainImage);
            await _popupFactory.Prepare();
            _canvas = gameObject.GetComponent<RectTransform>();
            Debug.Log("Creator Start");
        }

        private void OnDisable()
        {
            _spriteFactory.Clear(_config.MainImage);
            _popupFactory.Clear();
        }

        public async Task<PopupModel> CreatePopup()
        {
            Popup = await _popupFactory.Create(_canvas, _canvas.localPosition);
            return new PopupModel(_config.HeaderText, _config.DescriptionText, _config.MainImage);
        }

        public async Task<Sprite> CreateSprite() => 
            await _spriteFactory.Create(_config.MainImage);
    }
}