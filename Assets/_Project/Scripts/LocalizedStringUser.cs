using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public class LocalizedStringUser : MonoBehaviour
{
    [SerializeField] private LocalizedStringTable _localizedStringTable;
    [SerializeField] private string _simpleStringKey;
    [SerializeField] private string _interpolatedStringKey;
    [SerializeField] private Values _interpolatedValues;

    private StringTable _currentStringTable;
    
    private IEnumerator Start()
    {
        var tableLoading = _localizedStringTable.GetTable();
        yield return tableLoading;
        _currentStringTable = tableLoading.Result;
        
        var simpleString = _currentStringTable[_simpleStringKey].LocalizedValue;

        Debug.Log($"Simple string: {simpleString}");
        
        var interpolatedString = 
            _currentStringTable[_interpolatedStringKey].GetLocalizedString(
                LocalizationSettings.SelectedLocale.Formatter,
                _interpolatedValues);
        
        Debug.Log($"Interpolated string: {interpolatedString}");
    }
}