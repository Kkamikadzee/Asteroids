using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace View.UI.ImageUi
{
    public class ImageLimitedResourceLimitedFromAboveView: LimitedResourceLimitedFromAboveView
    {
        private GameObject _resourcePrefab;
        private GameObject[] _displayedResources;
        
        private Transform _instantiateParent;
        
        private float _paddingBetweenObjects = 32f;

        public override event Action DisconnectFromObserver;
        public override event Action Refresh;
        
        public ImageLimitedResourceLimitedFromAboveView(Vector3 position, int displayedAmountResource, 
            int displayedMaxAmountResource, GameObject resourcePrefab, 
            Transform instantiateParent) : base(position, displayedAmountResource, displayedMaxAmountResource)
        {
            _resourcePrefab = resourcePrefab;

            _displayedResources = new GameObject[displayedMaxAmountResource];
            
            _instantiateParent = instantiateParent;

            for (int i = 0; i < displayedMaxAmountResource; i++)
            {
                _displayedResources[i] = Object.Instantiate(_resourcePrefab, _instantiateParent);
                _displayedResources[i].transform.position = new Vector3(_displayedResources[i].transform.position.x + i * _paddingBetweenObjects,
                    _displayedResources[i].transform.position.y, _displayedResources[i].transform.position.z);
                _displayedResources[i].SetActive(false);
            }

            _changeDisplayedAmountResource(displayedAmountResource);
        }

        private void _changeDisplayedAmountResource(int amountResource)
        {
            if (_displayedAmountResource < amountResource)
            {
                while (_displayedAmountResource < amountResource)
                {
                    _displayedResources[(_displayedAmountResource++)].SetActive(true);
                }
            }
            else
            {
                while (_displayedAmountResource > amountResource)
                {
                    _displayedResources[(_displayedAmountResource-- - 1)].SetActive(false);
                }
            }
        }
        
        public override void SetAmountResource(int amountResource)
        {
            _changeDisplayedAmountResource(amountResource);
        }

        public override void SetMaxAmountResource(int maxAmountResource)
        {
            var tmp = _displayedResources;

            _displayedMaxAmountResource = maxAmountResource < _displayedAmountResource 
                ? maxAmountResource : _displayedAmountResource; //Количество старых объектов, которое останется

            _displayedResources = new GameObject[maxAmountResource];

            for (int i = 0; i < _displayedMaxAmountResource; i++)
            {
                _displayedResources[i] = tmp[i];
            }

            if (_displayedMaxAmountResource < maxAmountResource)
            {
                for (int i = _displayedAmountResource; i < maxAmountResource; i++)
                {
                    _displayedResources[i] = Object.Instantiate(_resourcePrefab, _instantiateParent);
                    _displayedResources[i].transform.position = new Vector3(_displayedResources[i].transform.position.x + i * _paddingBetweenObjects,
                        _displayedResources[i].transform.position.y, _displayedResources[i].transform.position.z);
                    _displayedResources[i].SetActive(false);
                }
            }
            else
            {
                for (int i = _displayedAmountResource; i < tmp.Length; i++)
                {
                    Object.Destroy(tmp[i]);
                }
            }
            
            _displayedMaxAmountResource = maxAmountResource;
        }
        
        public override void Update(float deltaTime)
        {
            Refresh?.Invoke();
        }

        public override void Destroy()
        {
            DisconnectFromObserver?.Invoke();

            foreach (var resource in _displayedResources)
            {
                Object.Destroy(resource);
            }

            _displayedResources = null;
        }
    }
}