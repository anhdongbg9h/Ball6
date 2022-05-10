using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    [SerializeField] private Button uiSpinBtn;
    [SerializeField] private Text uiSpinText;


    [SerializeField] private PickerWheel pickerWheel;

    private void Start()
    {
        uiSpinBtn.onClick.AddListener(() =>
        {
            uiSpinText.text = "Spinning...";
            pickerWheel.Spin();
        });
    }

}
