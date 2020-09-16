using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace View.UI.ImageUi
{
    public class ImageLimitedResourceLimitedFromAboveView: LimitedResourceLimitedFromAboveView
    {
        private GameObject _resourcePrefab;
        private GameObject[] _displayedResources;
        
        private Transform _instantiateParent;
        
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
                _displayedResources[i] = Object.Instantiate(_resourcePrefab, _instantiateParent); //TODO: Смещать последующие объекты
            }

            _changeDisplayedAmountResource(displayedAmountResource);
        }

        private void _changeDisplayedAmountResource(int amountResource)
        {
            if (_displayedAmountResource < amountResource)
            {
                while (_displayedAmountResource < amountResource)
                {
                    _displayedResources[_displayedAmountResource].SetActive(true);
                }
            }
            else
            {
                while (_displayedAmountResource >= amountResource)
                {
                    _displayedResources[_displayedAmountResource--].SetActive(false);
                }
            }
        }
        
        public override void SetAmountResource(int amountResource)
        {
            _changeDisplayedAmountResource(_displayedAmountResource);
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
                    _displayedResources[i] = Object.Instantiate(_resourcePrefab, _instantiateParent); //TODO: Смещать последующие объекты
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