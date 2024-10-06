using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{



    public Vector2 cpPosition;
    [SerializeField] int _cpIndex;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI2;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI3;



    private void OnTriggerEnter2D(Collider2D player)
    {
        _textMeshProUGUI3.text = "1000";
        if (player.gameObject.CompareTag("Player"))
        {

            var obj = FindObjectOfType<PlayerMovement>();

            _textMeshProUGUI3.text = "2000";
            _textMeshProUGUI.text = _cpIndex.ToString();
            _textMeshProUGUI2.text = obj.prevCpIndex.ToString();


            if (_cpIndex > obj.prevCpIndex)
            {
                _textMeshProUGUI3.text = "3000";
                obj.x = player.transform.position.x;
                obj.y = player.transform.position.y;

                cpPosition = new Vector2(obj.x, obj.y);
                obj.prevCpIndex = _cpIndex;

            }
        }
        
    }
}
