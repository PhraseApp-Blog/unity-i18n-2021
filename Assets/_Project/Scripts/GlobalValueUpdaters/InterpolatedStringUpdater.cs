using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Extensions;
using UnityEngine.Localization.SmartFormat.GlobalVariables;
using Random = UnityEngine.Random;

public class InterpolatedStringUpdater : MonoBehaviour
{
    [SerializeField] private string[] _characterNames;

    private void Start()
    {
        var source = LocalizationSettings
            .StringDatabase
            .SmartFormatter
            .GetSourceExtension<GlobalVariablesSource>();

        var characterName = 
            source["global"]["character"] as StringGlobalVariable;

        var randomCharacterName = _characterNames[
            Random.Range(0, _characterNames.Length)
        ];

        characterName.Value = randomCharacterName;
    }
}