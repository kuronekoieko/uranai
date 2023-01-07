
using System;
using Twilio;
using Twilio.TwiML;
using Twilio.Rest.Api.V2010.Account;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;


public class TwilioTest
{
    /// <summary>
    /// TwilioSID
    /// </summary>
    private readonly string m_twilioAccountSid;

    /// <summary>
    /// Twilioトークン
    /// </summary>
    private readonly string m_twilioAuthToken;

    /// <summary>
    /// Twilio電話番号
    /// </summary>
    private readonly string m_twilioPhoneNo;

    /// <summary>
    /// 通話中のCallResource
    /// </summary>
    private CallResource m_callResource;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="twilioAccountSid">TwilioSID</param>
    /// <param name="twilioAuthToken">Twilioトークン</param>
    /// <param name="twilioPhoneNo">Twilio電話番号</param>
    public TwilioTest(string twilioAccountSid, string twilioAuthToken, string twilioPhoneNo)
    {
        m_twilioAccountSid = twilioAccountSid;
        m_twilioAuthToken = twilioAuthToken;
        m_twilioPhoneNo = twilioPhoneNo;
    }


    /// <summary>
    /// 発信
    /// </summary>
    /// <param name="text">通話時のテキスト</param>
    /// <param name="phoneNo">発信先</param>
    public void Call(string text, string phoneNo)
    {
        callAsync(text, phoneNo).Forget();
    }



    /// <summary>
    /// 発信
    /// </summary>
    /// <param name="text">通話時のテキスト</param>
    /// <param name="phoneNo">発信先</param>
    private async UniTask callAsync(string text, string phoneNo)
    {
        //Client初期化
        TwilioClient.Init(m_twilioAccountSid, m_twilioAuthToken);

        //発信
        m_callResource = await CallResource.CreateAsync(
            url: new Uri("http://twimlets.com/echo?Twiml=" + makeTwiML(text)),
            to: new Twilio.Types.PhoneNumber(phoneNo),
            from: new Twilio.Types.PhoneNumber(m_twilioPhoneNo)
        );
    }


    /// <summary>
    /// 任意のテキストをTwiML形式に加工する
    /// </summary>
    /// <param name="text">通話で流すテキスト</param>
    /// <returns>URLエンコード済みTwiML</returns>
    private string makeTwiML(string text)
    {
        var response = new VoiceResponse();
        response.Say("テストメッセージ", voice: "alice", language: "ja-JP");

        return Uri.EscapeUriString(response.ToString());
    }

    public void Dial(string phoneNo)
    {
        var response = new VoiceResponse();
        // response.Dial("415-123-4567");
        // Twilio では、Dial の中で callerId パラメータ を省略すると、相手に「非通知」として発信します。
        response.Dial(
            callerId: m_twilioPhoneNo,// 中継するtwilioの番号
            number: phoneNo);// 占い師の番号
        response.Say("Goodbye");

        Console.WriteLine(response.ToString());
    }
}