using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class API
{
    IEnumerator Get<T>(string url, Action<T> onSuccess, Action<string> onError = null)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            onError?.Invoke(request.error);
        }
        else
        {
            try
            {
                T result = JsonUtility.FromJson<T>(request.downloadHandler.text);
                onSuccess(result);
            }
            catch (Exception e)
            {
                onError?.Invoke(e.Message);
                throw;
            }
        }
    }
}
