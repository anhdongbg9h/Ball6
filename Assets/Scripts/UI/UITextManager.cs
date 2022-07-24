using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    [SerializeField] Text showCoin;
    [SerializeField] Text showHeart;
    [SerializeField] Text showLv;

    const string LEVEL_TEXT = "Level ";

    private void OnValidate()
    {
        Common.Warning(showCoin != null, "Missing showCoin text");
        Common.Warning(showHeart != null, "Missing showHeart text");
        Common.Warning(showLv != null, "Missing showLv text");
    }

    private void Awake()
    {
        if (showCoin == null || showHeart == null || showLv == null)
        {
            DestroyImmediate(this);
        }
        this.RegisticListener(EventID.ShowCoin, (param) => ShowCoin());
        this.RegisticListener(EventID.ShowHeart, (param) => ShowHeart());
        this.RegisticListener(EventID.ShowLv, (param) => ShowLv());
    }
    void ShowCoin()
    {
        showCoin.text = DataPlayer.GetCoin().ToString();
    }
    void ShowHeart()
    {
        showHeart.text = DataPlayer.GetHeart().ToString();
    }
    void ShowLv()
    {
        showLv.text = LEVEL_TEXT + DataPlayer.GetIdRoom().ToString();
    }

}
