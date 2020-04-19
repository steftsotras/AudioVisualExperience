using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class GIPHYApi
    {
        private const string RANDOM_ENDPOINT = "https://api.giphy.com/v1/gifs/random";
        private const string SEARCH_ENDPOINT = "https://api.giphy.com/v1/gifs/search";
        private const string TRANSLATE_ENDPOINT = "https://api.giphy.com/v1/gifs/translate";
        private const string TRENDING_ENDPOINT = "https://api.giphy.com/v1/gifs/trending";

        private const string DEFAULT_STRING = "";
        private const string DEFAULT_RATING = "";
        private const int DEFAULT_OFFSET = 0;
        private const int DEFAULT_WEIRDNESS = 0;
        private const int DEFAULT_LIMIT = 25;

        private string api_key = "";

        public GIPHYApi(string api_key)
        {
            this.api_key = api_key;
        }

        public IEnumerator Random(string tag = DEFAULT_STRING, string rating = DEFAULT_STRING, Action<GIPHYSingleObject> onSuccess = null, Action<string> onError = null)
        {
            var qCollection = ToQueryCollection(
                new QueryParam<string> { name = "api_key", value = api_key },
                new QueryParam<string> { name = "tag", value = tag, defaultValue = DEFAULT_STRING },
                new QueryParam<string> { name = "rating", value = rating, defaultValue = DEFAULT_STRING }
            );
            return _request(RANDOM_ENDPOINT, qCollection, onSuccess, onError);
        }

        public IEnumerator Search(string query, int limit = DEFAULT_LIMIT, int offset = DEFAULT_OFFSET, string rating = DEFAULT_STRING, string lang = DEFAULT_STRING, Action<GIPHYCollectionObject> onSuccess = null, Action<string> onError = null)
        {
            var qCollection = ToQueryCollection(
               new QueryParam<string> { name = "api_key", value = api_key },
               new QueryParam<string> { name = "limit", value = limit.ToString(), defaultValue = DEFAULT_LIMIT.ToString() },
               new QueryParam<string> { name = "offset", value = offset.ToString(), defaultValue = DEFAULT_OFFSET.ToString() },
               new QueryParam<string> { name = "rating", value = rating, defaultValue = DEFAULT_STRING }
            );
            return _request(SEARCH_ENDPOINT, qCollection, onSuccess, onError);
        }

        public IEnumerator Trending(int limit = DEFAULT_LIMIT, int offset = DEFAULT_OFFSET, string rating = DEFAULT_RATING, string lang = DEFAULT_STRING, Action<GIPHYCollectionObject> onSuccess = null, Action<string> onError = null)
        {
            var qCollection = ToQueryCollection(
                new QueryParam<string> { name = "api_key", value = api_key },
                new QueryParam<string> { name = "limit", value = limit.ToString(), defaultValue = DEFAULT_LIMIT.ToString() },
                new QueryParam<string> { name = "offset", value = offset.ToString(), defaultValue = DEFAULT_OFFSET.ToString() },
                new QueryParam<string> { name = "rating", value = rating, defaultValue = DEFAULT_STRING },
                new QueryParam<string> { name = "lang", value = lang, defaultValue = DEFAULT_STRING }
            );
            return _request(TRENDING_ENDPOINT, qCollection, onSuccess, onError);
        }

        public IEnumerator Translate(string s, int weirdness = DEFAULT_WEIRDNESS, Action<GIPHYSingleObject> onSuccess = null, Action<string> onError = null)
        {
            var qCollection = ToQueryCollection(
                new QueryParam<string> { name = "api_key", value = api_key },
                new QueryParam<string> { name = "s", value = s },
                new QueryParam<string> { name = "weirdness", value = weirdness.ToString(), defaultValue = DEFAULT_WEIRDNESS.ToString() }
            );
            return _request(TRANSLATE_ENDPOINT, qCollection, onSuccess, onError);
        }

        private IEnumerator _request<T>(string url, Action<T> onSuccess, Action<string> onError)
        {
            return _request(url, null, onSuccess, onError);
        }

        private IEnumerator _request<T>(string url, NameValueCollection queryParams, Action<T> onSuccess, Action<string> onError)
        {

            if (queryParams != null && queryParams.Count > 0)
            {
                url += ToQueryString(queryParams);
            }

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError(request.error);
                onError(request.error);
            }
            var result = JsonUtility.FromJson<T>(request.downloadHandler.text);
            onSuccess(result);
        }

        private NameValueCollection ToQueryCollection(params QueryParam<string>[] queryParams)
        {
            var nvc = new NameValueCollection();
            foreach (var q in queryParams)
            {
                if (q.defaultValue != q.value)
                {
                    nvc.Add(q.name, q.value);
                }
            }
            return nvc;
        }

        private string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select string.Format(
            "{0}={1}",
            UnityWebRequest.EscapeURL(key),
            UnityWebRequest.EscapeURL(value))
                ).ToArray();
            return "?" + string.Join("&", array);
        }

    }

    public class QueryParam<T>
    {
        public string name { get; set; }
        public T value { get; set; }
        public T defaultValue { get; set; }
    }
}
