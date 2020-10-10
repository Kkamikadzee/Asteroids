using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace View.UI.ImageUi
{
    public class ImageLimitedResourceView: LimitedResourceView
    {
        private GameObject _resourcePrefab;
        private List<GameObject> _displayedResourceList;

        private int _currentDisplayedAmountResource;
        
        private Transform _instantiateParent;
        
        private float _paddingBetweenObjects = 32f;

        public override event Action DisconnectFromObserver;
        public override event Action Refresh;

        public ImageLimitedResourceView(Vector3 position, int displayedAmountResource,
            GameObject resourcePrefab, Transform instantiateParent) : base(position, displayedAmountResource)
        {
            _resourcePrefab = resourcePrefab;

            _displayedResourceList = new List<GameObject>();
            
            _instantiateParent = instantiateParent;

            _currentDisplayedAmountResource = 0;
            _changeCurrentDisplayedAmountResource(displayedAmountResource);
        }

        private void _changeCurrentDisplayedAmountResource(int amountResource)
        {
            if (_currentDisplayedAmountResource < amountResource)
            {
                while (_currentDisplayedAmountResource < amountResource)
                {
                    if (_displayedResourceList.Count <= _currentDisplayedAmountResource)
                    {
                        _displayedResourceList.Add(
                            Object.Instantiate(_resourcePrefab, _instantiateParent));
                        _displayedResourceList[_currentDisplayedAmountResource].transform.position = new Vector3(
                            _displayedResourceList[_currentDisplayedAmountResource].transform.position.x + _currentDisplayedAmountResource * _paddingBetweenObjects,
                            _displayedResourceList[_currentDisplayedAmountResource].transform.position.y, _displayedResourceList[_currentDisplayedAmountResource].transform.position.z);
                        _displayedResourceList[_currentDisplayedAmountResource].SetActive(true);
                    }
                    else
                    {
                        _displayedResourceList[(_currentDisplayedAmountResource)].SetActive(true);
                    }
                    _currentDisplayedAmountResource++;
                }
            }
            else
            {
                while (_currentDisplayedAmountResource > amountResource)
                {
                    _displayedResourceList[(--_currentDisplayedAmountResource)].SetActive(false);
                }
            }
            
        }
        
        public override void SetAmountResource(int amountResource)
        {
            _displayedAmountResource = amountResource;
            _changeCurrentDisplayedAmountResource(_displayedAmountResource);
        }

        public override void Update(float deltaTime)
        {
            Refresh?.Invoke();
        }

        public override void Destroy()
        {
            DisconnectFromObserver?.Invoke();

            foreach (var resource in _displayedResourceList)
            {
                Object.Destroy(resource);
            }
            
            _displayedResourceList.Clear();
        }
    }
}