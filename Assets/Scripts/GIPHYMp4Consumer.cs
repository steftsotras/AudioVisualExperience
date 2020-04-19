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

    [SerializeField]
    string _tag = "lofi";
    public string Tag
    {
        get { return _tag; }
        set { _tag = value; }
    }

    public VideoPlayer videoPlayer;

    private GIPHYApi api;

    private RootImage current = null;

    void Start()
    {
        api = new GIPHYApi(ApiKey);
        LoadNextVideo();
    }

    public void LoadNextVideo()
    {
        StartCoroutine(api.Random(Tag, onSuccess: (result) =>
        {
            if (result == null)
            {
                return;
            }
            current = result.data;
            StartCoroutine(PlayVideo());
        }));
    }

    IEnumerator PlayVideo()
    {
        while (current == null)
        {
            Debug.Log("No video in queue");
            yield return null;
        }
        VideoPlayer clone = null;
        if (videoPlayer.isPlaying)
        {
            //clone so it will load the next video silently
            clone = Instantiate(videoPlayer);
        }

        var vp = clone ?? videoPlayer;

        //Set video Clip To Play 
        vp.url = current.images.original.mp4;

        //Prepare video
        vp.Prepare();

        //Wait until this video is prepared
        while (!vp.isPrepared)
        {
            Debug.Log("Preparing video");
            yield return null;
        }
        Debug.LogWarning("Finished preparing current video");

        //Assign the Texture from Video to RawImage to be displayed
        //image.texture = videoPlayerList[videoIndex].texture;

        //Play first video
        vp.Play();

        if (clone != null)
        {
            Destroy(videoPlayer);
            videoPlayer = clone;
        }

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
