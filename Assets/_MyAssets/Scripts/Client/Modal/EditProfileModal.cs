using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Cysharp.Threading.Tasks;

public class EditProfileModal : BaseModal
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TMP_InputField firstNameIF;
    [SerializeField] TMP_InputField lastNameIF;
    [SerializeField] Button birthdayButton;
    [SerializeField] TextMeshProUGUI birthdayText;
    [SerializeField] TMP_Dropdown sexDropdown;
    [SerializeField] TMP_Dropdown bloodTypeDropdown;
    [SerializeField] Button saveButton;
    bool isMe;
    Profile profile;
    public override void OnStart()
    {
        base.OnStart();
        base.isShowPopupOnClose = true;
        saveButton.onClick.AddListener(OnClickSaveButton);

        List<string> sexOptions = new List<string>();
        sexOptions.Add("男性");
        sexOptions.Add("女性");
        sexOptions.Add("未選択");
        sexDropdown.ClearOptions();
        sexDropdown.AddOptions(sexOptions);

        List<string> bloodTypeOptions = new List<string>();
        bloodTypeOptions.Add("A型");
        bloodTypeOptions.Add("B型");
        bloodTypeOptions.Add("AB型");
        bloodTypeOptions.Add("O型");
        bloodTypeOptions.Add("未選択");
        bloodTypeDropdown.ClearOptions();
        bloodTypeDropdown.AddOptions(bloodTypeOptions);


    }

    public void Open(bool isMe)
    {

        base.OpenAnim();
        this.isMe = isMe;

        profile = isMe ? SaveData.i.myProfile : SaveData.i.crushProfile;

        titleText.text = (isMe ? "自分" : "相手") + "の情報";
        firstNameIF.text = profile.firstName;
        lastNameIF.text = profile.lastName;
        DateTime? birthDay = profile.birthDaySDT.dateTime;

        birthdayText.text = birthDay == null ?
            "選択する" : birthDay.ToStringIncludeEmpty("yyyy年MM月dd日");
        sexDropdown.value = (int)profile.sex;
        bloodTypeDropdown.value = (int)profile.bloodType;



    }

    void OnClickSaveButton()
    {
        profile.firstName = firstNameIF.text;
        profile.lastName = lastNameIF.text;
        // profile.birthDaySDT.dateTime =
        profile.sex = (Sex)Enum.ToObject(typeof(Sex), sexDropdown.value);
        profile.bloodType = (BloodType)Enum.ToObject(typeof(BloodType), bloodTypeDropdown.value);

        if (isMe)
        {
            SaveData.i.myProfile = profile;
        }
        else
        {
            SaveData.i.crushProfile = profile;
        }
        SaveDataManager.i.Save();

    }

}
