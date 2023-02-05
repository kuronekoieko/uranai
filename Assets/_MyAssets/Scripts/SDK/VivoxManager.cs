using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Vivox;
using VivoxUnity;
using System;
using System.ComponentModel;


/// <summary>
/// https://docs.vivox.com/v5/general/unity/15_1_190000/ja-jp/Default.htm#Unity/developer-guide/vivox-unity-sdk-basics/initialize-voice-client-object.htm?TocPath=Vivox%2520Unity%2520SDK%2520%25E3%2581%25AE%25E3%2583%2589%25E3%2582%25AD%25E3%2583%25A5%25E3%2583%25A1%25E3%2583%25B3%25E3%2583%2588%257CVivox%2520Unity%2520%25E9%2596%258B%25E7%2599%25BA%25E8%2580%2585%25E3%2582%25AC%25E3%2582%25A4%25E3%2583%2589%257CClient%2520SDK%2520%25E3%2581%25AE%25E5%259F%25BA%25E6%259C%25AC%257C_____1
/// </summary>
public class VivoxManager : MonoBehaviour
{
    Client _client;
    Uri _serverUri = new Uri("https://unity.vivox.com/appconfig/15668-___-35308-udash");
    ILoginSession _loginSession;
    [SerializeField] string userName;

    public async void Initialize()
    {


    }


    private async void Awake()
    {
        // _client.Uninitialize();
        _client = new Client();
        _client.Initialize();



        await UnityAuthenticationManager.i.Initialize();
        VivoxService.Instance.Initialize();
        LoginUser(userName);
        JoinChannel("channel-001");
    }

    void LoginUser(string userName)
    {
        // この例では、クライアントが初期化されています。
        var account = new Account(userName);
        _loginSession = _client.GetLoginSession(account);
        _loginSession.BeginLogin(_serverUri, _loginSession.GetLoginToken(), ar =>
        {
            Debug.Log("aaaaaaaaaaaaa");
            try
            {
                _loginSession.EndLogin(ar);
            }
            catch (Exception e)
            {
                // エラー処理
                return;
            }
            // この時点でログインは成功しており、他の操作を実行できます。

        });

        _loginSession.PropertyChanged += onLoginSessionPropertyChanged;
    }

    private void onLoginSessionPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        if ("State" == propertyChangedEventArgs.PropertyName)
        {
            switch ((sender as ILoginSession).State)
            {
                case LoginState.LoggingIn:
                    // 必要に応じて操作 
                    break;

                case LoginState.LoggedIn:
                    // 必要に応じて操作 
                    break;

                case LoginState.LoggedOut:
                    // 必要に応じて操作 
                    break;
                default:
                    break;
            }
        }
    }

    void LogOut()
    {
        // この例では、_loginSession が ILoginSession になると見なされます。
        _loginSession.Logout();
    }

    void OnApplicationQuit()
    {
        LogOut();
        _client.Uninitialize();
    }


    void JoinChannel(string channelName)
    {
        var channel = new Channel(channelName, ChannelType.NonPositional);
        var channelSession = _loginSession.GetChannelSession(channel);

        // すべてのチャンネルのプロパティの変更にサブスクライブする。
        channelSession.PropertyChanged += SourceOnChannelPropertyChanged;

        // チャンネルに接続する
        channelSession.BeginConnect(true, true, true, channelSession.GetConnectToken(), ar =>
        {
            try
            {
                channelSession.EndConnect(ar);
            }
            catch (Exception e)
            {
                // エラー処理
                return;
            }

            // この点に到達することはエラーが発生していないことを示しますが、AudioState か TextState（またはその両方）が ConnectionState.Connected になるまでユーザーが「チャンネルにいる」ことにはなりません。
        });
    }

    void SourceOnChannelPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        var channelSession = (IChannelSession)sender;

        // この例では、AudioState の変更のみをチェックしています。
        if (propertyChangedEventArgs.PropertyName == "AudioState")
        {
            switch (channelSession.AudioState)
            {
                case ConnectionState.Connecting:
                    Debug.Log("Audio connecting in " + channelSession.Key.Name);
                    break;

                case ConnectionState.Connected:
                    Debug.Log("Audio connected in " + channelSession.Key.Name);
                    break;

                case ConnectionState.Disconnecting:
                    Debug.Log("Audio disconnecting in " + channelSession.Key.Name);
                    break;

                case ConnectionState.Disconnected:
                    Debug.Log("Audio disconnected in " + channelSession.Key.Name);
                    break;
            }
        }
    }

    void LeaveChannel(ChannelId channelIdToLeave)
    {

        var channelSession = _loginSession.GetChannelSession(channelIdToLeave);
        if (channelSession != null)
        {
            // チャンネルから切断
            channelSession.Disconnect();
            //（必要に応じて）チャンネルリストからチャンネルエントリを削除
            _loginSession.DeleteChannelSession(channelIdToLeave);
        }

    }
}

