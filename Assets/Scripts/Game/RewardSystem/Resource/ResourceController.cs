using Tool;
using UnityEngine;

namespace Game.RewardSystem.Resource
{
    internal class ResourceController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Rewards/CurrencyView");
        private readonly ResourceModel _model;
        private readonly ResourceView _view;

        public ResourceController(ResourceModel currencyModel, Transform placeForUi)
        {
            _model = currencyModel;

            _view = LoadView(placeForUi);
            _view.Init(_model.Wood, _model.Diamond);

            Subscribe(_model);
        }

        protected override void OnDispose()
        {
            Unsubscribe(_model);
            base.OnDispose();
        }


        private ResourceView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<ResourceView>();
        }


        private void Subscribe(ResourceModel model)
        {
            model.WoodChanged += OnWoodChanged;
            model.DiamondChanged += OnDiamondChanged;
        }

        private void Unsubscribe(ResourceModel model)
        {
            model.WoodChanged -= OnWoodChanged;
            model.DiamondChanged -= OnDiamondChanged;
        }

        private void OnWoodChanged() => _view.SetWood(_model.Wood);
        private void OnDiamondChanged() => _view.SetDiamond(_model.Diamond);
    
    }
}