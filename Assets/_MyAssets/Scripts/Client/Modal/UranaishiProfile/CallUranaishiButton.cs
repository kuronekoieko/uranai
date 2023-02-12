using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CallUranaishiButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Text text;
    [SerializeField] CallingManager callingManager;


    Uranaishi uranaishi;

    public void OnStart()
    {
        callingManager.OnStart();
    }




    public void OnOpen(Uranaishi uranaishi)
    {
        this.uranaishi = uranaishi;
        button.onClick.AddListener(OnClickReserveButton);
        text.text = $"今すぐ予約する\n({uranaishi.GetChareText()})";

        switch (uranaishi.status)
        {
            case UranaishiStatus.Counseling:
                break;
            case UranaishiStatus.Free:
                button.onClick.AddListener(OnClickCallButton);
                text.text = $"電話で占う\n({uranaishi.GetChareText()})";
                break;
            case UranaishiStatus.Closed:
                break;
            case UranaishiStatus.DatTime:
                break;
            default:
                break;
        }

    }

    void OnClickCallButton()
    {
        callingManager.Open(uranaishi);
    }

    void OnClickReserveButton()
    {

    }
}
