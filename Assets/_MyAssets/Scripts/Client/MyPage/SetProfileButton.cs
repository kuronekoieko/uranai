using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetProfileButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI subText;

    bool isMe;
    public void OnStart(bool isMe)
    {
        button.onClick.AddListener(OnClickButton);
        this.isMe = isMe;

        Profile profile = isMe ? SaveData.i.myProfile : SaveData.i.crushProfile;

        Set(profile);
    }

    void Set(Profile profile)
    {
        if (profile.firstName.Length > 0)
        {
            nameText.text = profile.firstName + " " + profile.lastName;
        }
        else
        {
            nameText.text = (isMe ? "自分" : "相手") + "の名前";
        }

        string sexName = "性別";
        if (profile.sex != Sex.None)
        {
            sexName = Utils.GetSexName(profile.sex);
        }

        string birthdayName = profile.birthDaySDT.dateTime.ToStringIncludeEmpty("yyyy年MM月dd日");

        if (birthdayName == "n/a") birthdayName = "生年月日";

        subText.text = sexName + "・" + birthdayName;
    }


    void OnClickButton()
    {
        UIManager.i.GetModal<EditProfileModal>().Open(isMe);
    }


}