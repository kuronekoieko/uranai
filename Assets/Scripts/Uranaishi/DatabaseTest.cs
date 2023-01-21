using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DatabaseTest : MonoBehaviour
{

    [SerializeField] InputField userNameIF;
    [SerializeField] Button sendButton;



    void Start()
    {
        sendButton.onClick.AddListener(SendData);
    }

    void SendData()
    {
        Uranaishi uranaishi = new Uranaishi();
        //uranaishi.id = Random.Range(100, 999).ToString();
        uranaishi.id = "901";

        uranaishi.name = userNameIF.text;
        FirebaseDatabaseManager.i.SetUserData(uranaishi);
    }

}
