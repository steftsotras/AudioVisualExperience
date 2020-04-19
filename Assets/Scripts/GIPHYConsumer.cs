using Assets.Scripts;
using B83.Image.GIF;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;

public class GIPHYConsumer : MonoBehaviour
{
    [SerializeField]
    string _apiKey = "IvjIuPerpxyclVUqc4Tyi9uvIiJNyaNh";
    [SerializeField]
    GameObject _target;

    public string ApiKey
    {
        get { return _apiKey; }
        set { _apiKey = value; }
    }

    public GameObject Target
    {
        get { return _target; }
        set { _target = value; }
    }

    private GIPHYApi api;
    private GIFLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        loader = new GIFLoader();
        api = new GIPHYApi(ApiKey);
        StartCoroutine(api.Random(tag: "tsoukalas", onSuccess: (result) =>
        {
            StartCoroutine(LoadImage(result.data.images.original.url, result.data.images.original.width, result.data.images.original.height, result.data.images.original.frames));
        }));
    }

    IEnumerator LoadImage(string url, string width, string height, string frames)
    {
        Debug.LogError(url);
        var request = UnityWebRequest.Get(url);
        var w = int.Parse(width);
        var h = int.Parse(height);
        var f = int.Parse(frames);
        yield return request.SendWebRequest();
        GIFImage image;
        using (var ms = new MemoryStream(request.downloadHandler.data))
            image = loader.Load(ms);
        StartCoroutine(Render(image, Target));
    }

    IEnumerator Render(GIFImage image, GameObject target)
    {
        var texture = new Texture2D(image.screen.width, image.screen.height);
        var renderingBlocks = image.data.Where(d => d is IGIFRenderingBlock).Cast<IGIFRenderingBlock>().ToList();
        var idx = 0;
        while (true)
        {
            var colorArr = new Color32[texture.width * texture.height];
            if (idx >= renderingBlocks.Count)
            {
                idx = 0;
            }
            var data = renderingBlocks[idx];
            data.DrawTo(colorArr, texture.width, texture.height);
            texture.SetPixels32(colorArr);
            texture.Apply(true);

            var scale = (Screen.height / 2.0) / Camera.main.orthographicSize;
            target.transform.localScale.Set((float)(texture.width / scale), (float)(texture.height / scale), target.transform.localScale.z);
            target.GetComponent<Renderer>().material.mainTexture = texture;
            idx++;
            yield return new WaitForSeconds(0.013f);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
