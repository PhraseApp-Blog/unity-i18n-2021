using System;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private DialogLine[] _lines;

    [SerializeField] private Vector2 _uiPosition = new Vector2(0, 82);
    
    private void Awake()
    {
        var ui = Instantiate(_lines[0].UI, transform, true);
        ui.transform.localPosition = _uiPosition;

        ui.SetLine(_lines[0].Line);
    }
}
