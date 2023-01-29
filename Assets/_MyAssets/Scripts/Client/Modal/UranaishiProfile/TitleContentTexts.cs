using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleContentTexts : MonoBehaviour
{
    public ReadOnlyValue<Text> titleTxt;
    public ReadOnlyValue<Text> contentTxt;
    public ReadOnlyValue<Image[]> starImages;
    public ReadOnlyValue<Image> pickUpImage;

    public void HighlightStars(int starCount)
    {
        for (int i = 0; i < starImages.value.Length; i++)
        {
            starImages.value[i].color = i < starCount ? Color.white : Color.clear;
        }
    }

}
