using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSystem
{
    private InputModel _inputModel;
    private PlayerModel _playerModel;

    private Vector3 _fieldBoundary;
    private Vector3 _currentSpeed;
    public PlayerMoveSystem(InputModel inputModel, PlayerModel playerModel, Vector2 fieldBoundary)
    {
        _inputModel = inputModel;
        _playerModel = playerModel;
        _fieldBoundary = fieldBoundary;
    }
    public void FixedUpdate()
    {        
        if(_inputModel.Vertical > 0) //Прибавляем значение скорости
        {
            float angle = _playerModel.Direction.eulerAngles.z * Mathf.Deg2Rad; //Угол, под которым повёрнут корабль
            Vector3 newSpeed = _currentSpeed;
            newSpeed.x += Mathf.Cos(angle) * (_inputModel.Vertical * _playerModel.Description.Acceleration) * Time.deltaTime;
            newSpeed.y += Mathf.Sin(angle) * (_inputModel.Vertical * _playerModel.Description.Acceleration) * Time.deltaTime;
            _currentSpeed = Vector3.ClampMagnitude(newSpeed, _playerModel.Description.MaxSpeed);
        }
        else
        {
            if(_currentSpeed.magnitude > 0)
            {
                float angle = _playerModel.Direction.eulerAngles.z * Mathf.Deg2Rad;
                Vector3 newSpeed = _currentSpeed;
                newSpeed.x -= Mathf.Cos(angle) * (_playerModel.Description.Deceleration) * Time.deltaTime;
                newSpeed.y -= Mathf.Sin(angle) * (_playerModel.Description.Deceleration) * Time.deltaTime;
                if(Vector3.Angle(_currentSpeed, newSpeed) > 45f)
                {
                    _currentSpeed = newSpeed;
                }
                else
                {
                    _currentSpeed = Vector3.zero;
                }
            }
        }
    }
    public void Update()
    {
        if (_inputModel.Horizontal != 0) //Поворачиваем ракету
        {
            float angle = _inputModel.Horizontal * _playerModel.Description.RotateSpeed * Time.deltaTime;
            RotatePlayer(angle);
        }

        if (_currentSpeed.magnitude > 0)
        {
            if(!_playerModel.State)
            {
                _playerModel.SetState(true);
            }

            if (_playerModel.Position.x > _fieldBoundary.x)
            {
                Vector3 newPos = _playerModel.Position;
                newPos.x -= 2 * _fieldBoundary.x;
                _playerModel.SetNewLocation(newPos, _playerModel.Direction);
            }
            else if (_playerModel.Position.x < -_fieldBoundary.x)
            {
                Vector3 newPos = _playerModel.Position;
                newPos.x += 2 * _fieldBoundary.x;
                _playerModel.SetNewLocation(newPos, _playerModel.Direction);
            }
            if (_playerModel.Position.y > _fieldBoundary.y)
            {
                Vector3 newPos = _playerModel.Position;
                newPos.y -= 2 * _fieldBoundary.y;
                _playerModel.SetNewLocation(newPos, _playerModel.Direction);
            }
            else if (_playerModel.Position.y < -_fieldBoundary.y)
            {
                Vector3 newPos = _playerModel.Position;
                newPos.y += 2 * _fieldBoundary.y;
                _playerModel.SetNewLocation(newPos, _playerModel.Direction);
            }

            Vector3 deltaNewPos = _currentSpeed * Time.deltaTime;
            _playerModel.SetNewLocation(_playerModel.Position + deltaNewPos, _playerModel.Direction);
        }
        else
        {
            if (_playerModel.State)
            {
                _playerModel.SetState(false);
            }

        }
    }
    private void RotatePlayer(float angle)
    {
        Vector3 eulerNewDir = _playerModel.Direction.eulerAngles;
        eulerNewDir.z += angle;
        Quaternion newDir = Quaternion.Euler(eulerNewDir);
        _playerModel.SetNewLocation(_playerModel.Position, newDir);
    }
}
