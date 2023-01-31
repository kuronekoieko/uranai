using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleContentTexts : MonoBehaviour
{
    public ReadOnlyValue<Text> titleTxt;
    public ReadOnlyValue<Text> contentTxt;
    public ReadOnlyValue<Image> pickUpImage;
    public ReviewStarHighlight reviewStarHighlight;

    public void SetTexts(string title, string content)
    {
        titleTxt.value.text = title;
        contentTxt.value.text = content;
        gameObject.SetActive(true);
    }

    public void SetTexts(string title, string content, int lineLimit)
    {
        titleTxt.value.text = title;
        contentTxt.value.SetLimitedText(content, lineLimit);
        gameObject.SetActive(true);
    }
}
