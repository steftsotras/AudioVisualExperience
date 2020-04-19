using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIPHYConsumer : MonoBehaviour
{
    [SerializeField]
    string _api_key = "IvjIuPerpxyclVUqc4Tyi9uvIiJNyaNh";

    public string ApiKey
    {
        get { return _api_key; }
        set { _api_key = value; }
    }

    private GIPHYApi api;
    // Start is called before the first frame update
    void Start()
    {
        api = new GIPHYApi(ApiKey);
        StartCoroutine(api.Random(tag: "lofi", onSuccess: (result) =>
        {
            Debug.LogError(result.data);
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
