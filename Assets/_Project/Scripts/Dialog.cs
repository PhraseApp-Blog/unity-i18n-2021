using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Transform _lineUIContainer;
    [SerializeField] private Vector2 _uiPosition = new Vector2(0, 82);
    
    [SerializeField] private DialogLine[] _lines;

    private int _index = 0;
    private DialogLineUI _lineUI;

    private void Awake()
    {
        EmptyLineUIContainer();
        NextLine();
    }

    private void EmptyLineUIContainer()
    {
        foreach (Transform child in _lineUIContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public void NextLine()
    {
        if (_index < _lines.Length)
        {
            RemoveCurrentLine();
            ShowNextLine();
            _index += 1;
        }
    }

    private void RemoveCurrentLine()
    {
        if (_lineUI)
        {
            Destroy(_lineUI.gameObject);
        }
    }

    private void ShowNextLine()
    {
        var line = _lines[_index];
        
        _lineUI = Instantiate(line.UI, _lineUIContainer, true);
        var lineUITransform = _lineUI.transform;
        lineUITransform.localPosition = _uiPosition;
        lineUITransform.localScale = Vector3.one;

        _lineUI.SetLine(line.Line);
    }
}
