using System;
using UnityEngine;

[Serializable]
public class DialogLine
{
    [SerializeField]
    [TextArea]
    private string _line;
    public string Line => _line;

    [SerializeField] private DialogLineUI _ui;
    public DialogLineUI UI => _ui;
}
