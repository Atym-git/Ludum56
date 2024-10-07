using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField] float _followSpeed;
    [SerializeField] float _cameraHeight = 1f;
    [SerializeField] Transform _player;
    [SerializeField] Camera _camera;
    [SerializeField] TextMeshProUGUI TextMeshPro;


    void Update()
    {
        Vector3 newPos = new Vector3(_player.position.x, _player.position.y + _cameraHeight, -10f);

        transform.position = Vector3.Slerp(transform.position, newPos, _followSpeed * Time.deltaTime);


    }
}
