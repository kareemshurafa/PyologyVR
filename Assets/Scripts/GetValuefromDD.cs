using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetValuefromDD : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;


    [SerializeField] private List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();


    public void GetDropdownValue()
    {
        int pickedEntryIndex = dropdown.value;
        string selectedOption = dropdown.options[pickedEntryIndex].text;
        Debug.Log(pickedEntryIndex);
    }


    private void AddNewLocation()
    {
        dropdown.options.Add(item: new TMP_Dropdown.OptionData(text: "Cardiac Selector", image: null));

        dropdown.AddOptions(options);

        dropdown.RefreshShownValue();
    }

}
