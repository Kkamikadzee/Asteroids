using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemInput
{
    private InputModel _inputModel;
    public SystemInput(InputModel inputModel)
    {
        _inputModel = inputModel;
    }
    public void Update()
    {
        _inputModel.Horizontal = Input.GetAxis("Horizontal");
        _inputModel.Vertical = Input.GetAxis("Vertical");
        _inputModel.Cannon = Input.GetAxisRaw("Cannon");
        _inputModel.Laser = Input.GetAxisRaw("Laser");
    }
}
