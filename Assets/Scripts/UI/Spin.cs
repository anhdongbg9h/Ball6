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
            uiSpinBtn.interactable = false;
            //uiSpinText.text = "Spinning...";

            pickerWheel.OnSpinStart(() => Debug.Log("Spin Starting...."));

            pickerWheel.OnSpinEnd(WheelPiece => {
                Debug.Log("Spin End: Label: " + WheelPiece.Label + ", Amount: " + WheelPiece.Amount);
                uiSpinBtn.interactable = true;
                //uiSpinText.text = "Spin";
            });

            pickerWheel.Spin();
        });
    }

}
