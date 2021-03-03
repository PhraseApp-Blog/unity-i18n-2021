using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Extensions;
using UnityEngine.Localization.SmartFormat.GlobalVariables;

public class PluralValueUpdater : MonoBehaviour
{
    [SerializeField] private int _matchTimer = 10;

    private IEnumerator Start()
    {
        var source = LocalizationSettings.StringDatabase.SmartFormatter
            .GetSourceExtension<GlobalVariablesSource>();

        var second = source["global"]["match-timer"] as 
                            IntGlobalVariable;

        for (int currentSecond = _matchTimer; 
            currentSecond >= 0; 
            currentSecond -= 1)
        {

            second.Value = currentSecond;
            
            yield return new WaitForSeconds(1);
        }
    }
}