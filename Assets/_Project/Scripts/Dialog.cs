using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Transform _lineUIContainer;
    [SerializeField] private Vector2 _uiActivePosition = new Vector2(0, 82);
    [SerializeField] private float _offScreenXPosition = 270;
    [SerializeField] private float _slidingAnimationDuration = 0.5f;
    [SerializeField] private float _textAnimationDuration = 0.05f;

    [SerializeField] private DialogLine[] _lines;

    private int _index = 0;
    private DialogLineUI _currentLineUI;

    private int _direction = 1;

    private bool _isAnimating = false;

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
        if (_isAnimating) { return; }
        
        if (_index < _lines.Length)
        {
            StartCoroutine(MoveLineUIs(_lines[_index]));

            _index += 1;
        }
    }

    private IEnumerator MoveLineUIs(DialogLine incomingLine)
    {
        _isAnimating = true;
        
        if (_currentLineUI)
        {
            _currentLineUI.transform.DOLocalMoveX(
                _offScreenXPosition * _direction, 
                _slidingAnimationDuration);
        }
        
        var incomingLineUI = InstantiateLineUI(_lines[_index]);
        incomingLineUI.Text = string.Empty;
        incomingLineUI.transform.DOLocalMoveX(
            _uiActivePosition.x, _slidingAnimationDuration);
        
        yield return new WaitForSeconds(_slidingAnimationDuration);
    
        if (_currentLineUI)
        {
            Destroy(_currentLineUI.gameObject);
        }

        _currentLineUI = incomingLineUI;

        yield return StartCoroutine(AnimateText(
            _currentLineUI, incomingLine.Line));
        
        _direction *= -1;

        _isAnimating = false;
    }

    private DialogLineUI InstantiateLineUI(DialogLine line)
    { 
        var ui = Instantiate(line.UI, _lineUIContainer, true);
        
        var lineUITransform = ui.transform;
        
        lineUITransform.localPosition = new Vector2(
            _offScreenXPosition * -_direction, _uiActivePosition.y);
        lineUITransform.localScale = Vector3.one;
        
        return ui;
    }
    
    private IEnumerator AnimateText(
        DialogLineUI currentLineUI, string incomingLine)
    {
        foreach (var character in incomingLine.ToCharArray())
        {
            currentLineUI.Text += character.ToString();
            
            yield return new WaitForSeconds(_textAnimationDuration);
        }
    }
}
