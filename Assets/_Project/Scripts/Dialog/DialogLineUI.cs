using TMPro;
using UnityEngine;

public class DialogLineUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;

    public string Text
    {
        get => _label.text;
        set => _label.text = value;
    }
}
