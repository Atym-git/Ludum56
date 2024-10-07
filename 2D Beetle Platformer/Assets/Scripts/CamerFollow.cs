using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField] float _followSpeed;
    [SerializeField] float _cameraHeight = 1f;
    [SerializeField] Transform _player;
    [SerializeField] Camera _camera;

    void Update()
    {
        Vector3 newPos = new Vector3(_player.position.x, _player.position.y + _cameraHeight, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, _followSpeed * Time.deltaTime);

        float _valueOfWheel = Input.GetAxis("Mouse ScrollWheel");
        if (_valueOfWheel > 0)
        {
            _camera.orthographicSize = _valueOfWheel * Time.deltaTime;
        }
        else if (_valueOfWheel < 0)
        {
            _camera.orthographicSize = -_valueOfWheel * Time.deltaTime;
        }
    }
}
