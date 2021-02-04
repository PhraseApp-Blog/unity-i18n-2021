using TMPro;
using UnityEngine;

public class DialogLineUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;

    public void SetLine(string line) => _label.text = line;
}
