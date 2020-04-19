using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Assets.Scripts;
public class GIPHYMp4Consumer : MonoBehaviour
{

    [SerializeField]
    string _apiKey = "IvjIuPerpxyclVUqc4Tyi9uvIiJNyaNh";

    public string ApiKey
    {
        get { return _apiKey; }
        set { _apiKey = value; }
    }

    public VideoPlayer videoPlayer;

    private GIPHYApi api;

    void Start()
    {
        api = new GIPHYApi(ApiKey);
        StartCoroutine(api.Random(tag: "lofi", onSuccess: (result) =>
        {
            StartCoroutine(playVideo(result.data.images.original.mp4));
        }));
    }

    IEnumerator playVideo(string videoUrl, bool firstRun = true)
    {
        //Set video Clip To Play 
        videoPlayer.url = videoUrl;

        //Prepare video
        videoPlayer.Prepare();

        //Wait until this video is prepared
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing video");
            yield return null;
        }
        Debug.LogWarning("Finished preparing current video");

        //Assign the Texture from Video to RawImage to be displayed
        //image.texture = videoPlayerList[videoIndex].texture;

        //Play first video
        videoPlayer.Play();

        //Wait while the current video is playing
        /*bool reachedHalfWay = false;
        int nextIndex = (videoIndex + 1);
        while (videoPlayerList[videoIndex].isPlaying)
        {
            Debug.Log("Playing time: " + videoPlayerList[videoIndex].time + " INDEX: " + videoIndex);

            //(Check if we have reached half way)
            if (!reachedHalfWay && videoPlayerList[videoIndex].time >= (videoPlayerList[videoIndex].clip.length / 2))
            {
                reachedHalfWay = true; //Set to true so that we don't evaluate this again

                //Make sure that the NEXT VideoPlayer index is valid. Othereise Exit since this is the end
                if (nextIndex >= videoPlayerList.Count)
                {
                    Debug.LogWarning("End of All Videos: " + videoIndex);
                    yield break;
                }

                //Prepare the NEXT video
                Debug.LogWarning("Ready to Prepare NEXT Video Index: " + nextIndex);
                videoPlayerList[nextIndex].Prepare();
            }
            yield return null;
        }
        Debug.Log("Done Playing current Video Index: " + videoIndex);

        //Wait until NEXT video is prepared
        while (!videoPlayerList[nextIndex].isPrepared)
        {
            Debug.Log("Preparing NEXT Video Index: " + nextIndex);
            yield return null;
        }

        Debug.LogWarning("Done Preparing NEXT Video Index: " + videoIndex);

        //Increment Video index
        videoIndex++;

        //Play next prepared video. Pass false to it so that some codes are not executed at-all
        StartCoroutine(playVideo(false));*/
    }
}
