using System;
using KMK.Model.Updater;
using UnityEngine;

namespace Input
{
    public class SystemInput: IUpdatable
    {   
        public event Action HorizontalLeft;
        public event Action HorizontalRight;
        public event Action Vertical;
        public event Action Cannon;
        public event Action Laser;

        public event Action ChangeView;
        
        public event Action DisconnectFromObserver;

        public SystemInput() { }

        public void Update(float deltaTime)
        {
            if (UnityEngine.Input.GetAxis("Horizontal") > 0.001f)
            {
                HorizontalLeft?.Invoke();
            }      
            else if (UnityEngine.Input.GetAxis("Horizontal") < -0.001f)
            {
                HorizontalRight?.Invoke();
            }      
            
            if (Math.Abs(UnityEngine.Input.GetAxis("Vertical")) > 0.001f)
            {
                Vertical?.Invoke();
            }    
            
            if (Math.Abs(UnityEngine.Input.GetAxis("Cannon")) > 0.001f)
            {
                Cannon?.Invoke();
            }  
            
            if (Math.Abs(UnityEngine.Input.GetAxis("Laser")) > 0.001f)
            {    
                Laser?.Invoke();
            }
            
            if (UnityEngine.Input.GetButtonDown("ChangeView"))
            {
                ChangeView?.Invoke();
            }
        }
    }
    
}
