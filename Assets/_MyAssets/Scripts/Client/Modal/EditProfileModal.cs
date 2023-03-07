using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Cysharp.Threading.Tasks;
using DeadMosquito.AndroidGoodies;
using System.Linq;

public class EditProfileModal : BaseModal
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TMP_InputField firstNameIF;
    [SerializeField] TMP_InputField lastNameIF;
    [SerializeField] Button birthdayButton;
    [SerializeField] TextMeshProUGUI birthdayText;
    [SerializeField] Button selectSexButton;
    [SerializeField] TextMeshProUGUI sexText;
    [SerializeField] Button selectBloodTypeButton;
    [SerializeField] TextMeshProUGUI bloodTypeText;
    [SerializeField] Button saveButton;
    bool isMe;
    Profile profile;
    public override void OnStart()
    {
        base.OnStart();
        base.isShowPopupOnClose = true;
        saveButton.onClick.AddListener(OnClickSaveButton);
        birthdayButton.onClick.AddListener(OnClickBirthdayButton);
        selectSexButton.onClick.AddListener(OnClickSelectSexButton);
        selectBloodTypeButton.onClick.AddListener(OnClickSelectBloodTypeButton);
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
        string sexName = Utils.GetSexNameDic()[profile.sex];
        sexText.text = sexName == "" ? "未選択" : sexName;
        bloodTypeText.text = Utils.GetBloodTypeNameDic()[profile.bloodType];



    }

    void OnClickSaveButton()
    {
        profile.firstName = firstNameIF.text;
        profile.lastName = lastNameIF.text;

        if (isMe)
        {
            SaveData.i.myProfile = profile;
        }
        else
        {
            SaveData.i.crushProfile = profile;
        }
        SaveDataManager.i.Save();
        base.Close();
    }

    void OnClickBirthdayButton()
    {
        NativeDatePicker.ShowDatePicker((dateTime) =>
        {
            DateTime? birthDay = dateTime;
            profile.birthDaySDT.dateTime = birthDay;
            birthdayText.text = birthDay.ToStringIncludeEmpty("yyyy年MM月dd日");
        });

        Debug.Log("日付ピッカー表示");
    }

    void OnClickSelectSexButton()
    {
        List<string> sexOptions = new List<string>(Utils.GetSexNameDic().Values);


        AGAlertDialog.ShowSingleItemChoiceDialog(
            "性別",
            sexOptions.ToArray(),
            0,
            (colorIndex) =>
            {
                profile.sex = (Sex)Enum.ToObject(typeof(Sex), colorIndex);
            },
            "選択",
            () =>
            {

            });
    }


    void OnClickSelectBloodTypeButton()
    {
        List<string> bloodTypeOptions = new List<string>(Utils.GetBloodTypeNameDic().Values);


        AGAlertDialog.ShowSingleItemChoiceDialog(
            "血液型",
            bloodTypeOptions.ToArray(),
            0,
            (colorIndex) =>
            {
                profile.bloodType = (BloodType)Enum.ToObject(typeof(BloodType), colorIndex);
            },
            "選択",
            () =>
            {

            });
    }

}
