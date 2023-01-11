using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestManager : MonoBehaviour {

    private const string Url = "http://127.0.0.0/edsa-Project_One_/Game-API-Unity.php"; // Put here your own HTTP URL

    [SerializeField] private ServerVersionResponse serverVersionResponse; //UI
    [SerializeField] private MessageOfTheDayResponse messageOfTheDayResponse; //UI
    [SerializeField] private RandomCharacterResponse randomCharacterResponse; //Player string
    [SerializeField] private RandomGoldPilesResponse randomGoldPilesResponse; //Player int
    [SerializeField] private RandomSpawnPositionsResponse randomSpawnPositionsResponse; //Player float not added Yet

    public void RequestServerVersion() {
        StartCoroutine(RequestServerVersionAsync());
	}

    public void MessageOfTheDay()
    {
        StartCoroutine(RequestTimeAndMSGAsync());
    }

    public void RequestRandomCharecter()
    {
        StartCoroutine(RequestRandomCharecterInfoAsync());
    }

    public void ButtonRequestGoldInBack()
    {
        StartCoroutine(RequestGoldInBackAsync());
    }

    private IEnumerator RequestServerVersionAsync() {
        ServerVersionRequest serverVersionRequest = new ServerVersionRequest();
        serverVersionRequest.action = "GetServerVersion";

        WWWForm form = new WWWForm();
        form.AddField("request", JsonUtility.ToJson(serverVersionRequest));

        using (UnityWebRequest www = UnityWebRequest.Post(Url, form)) {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            } else {
                Debug.Log(www.downloadHandler.text);
                serverVersionResponse = JsonUtility.FromJson<ServerVersionResponse>(www.downloadHandler.text);
            }
        }
    }

    private IEnumerator RequestTimeAndMSGAsync()
    {
        MessageOfTheDayRequest MessageOfTheDayRequest = new MessageOfTheDayRequest();
        MessageOfTheDayRequest.action = "gettimeofday";


        WWWForm form = new WWWForm();
        form.AddField("request", JsonUtility.ToJson(MessageOfTheDayRequest));

        using (UnityWebRequest www = UnityWebRequest.Post(Url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                messageOfTheDayResponse = JsonUtility.FromJson<MessageOfTheDayResponse>(www.downloadHandler.text);
            }
        }
    }

    private IEnumerator RequestRandomCharecterInfoAsync()
    {
        RandomCharacterRequest randomCharacterRequest = new RandomCharacterRequest();
        randomCharacterRequest.action = "RandomCharacter";
        randomCharacterRequest.minimumLevel = 1;
        randomCharacterRequest.maximumLevel = 10;

        WWWForm form = new WWWForm();
        form.AddField("request", JsonUtility.ToJson(randomCharacterRequest));

        using (UnityWebRequest www = UnityWebRequest.Post(Url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                randomCharacterResponse = JsonUtility.FromJson<RandomCharacterResponse>(www.downloadHandler.text);
            }
        }
    }

    private IEnumerator RequestGoldInBackAsync()
    {
        RandomGoldPilesRequest randomGoldPilesRequest = new RandomGoldPilesRequest();
        randomGoldPilesRequest.action = "GoldInBag";
        randomGoldPilesRequest.amount = 10;

         WWWForm form = new WWWForm();
        form.AddField("request", JsonUtility.ToJson(randomGoldPilesRequest));

        using (UnityWebRequest www = UnityWebRequest.Post(Url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                randomGoldPilesResponse = JsonUtility.FromJson<RandomGoldPilesResponse>(www.downloadHandler.text);
            }
        }
    }


}
