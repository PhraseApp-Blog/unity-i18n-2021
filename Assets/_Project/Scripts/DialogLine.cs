using System;
using UnityEngine;

[Serializable]
public class DialogLine
{
    [SerializeField]
    private string _lineKey;
    public string LineKey => _lineKey;

    [SerializeField] private DialogLineUI _ui;
    public DialogLineUI UI => _ui;
}
