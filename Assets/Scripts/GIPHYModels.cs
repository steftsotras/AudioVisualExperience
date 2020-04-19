using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    [Serializable]
    public class Still
    {
        public string height;
        public string size;
        public string url;
        public string width;
    }

    [Serializable]
    public class Original
    {
        public string frames;
        public string hash;
        public string height;
        public string mp4;
        public string mp4_size;
        public string size;
        public string url;
        public string webp;
        public string webp_size;
        public string width;
    }

    [Serializable]
    public class Mp4
    {
        public string height;
        public string mp4;
        public string mp4_size;
        public string width;
    }

    [Serializable]
    public class Downsampled
    {
        public string height;
        public string size;
        public string url;
        public string webp;
        public string webp_size;
        public string width;
    }

    [Serializable]
    public class Looping
    {
        public string mp4;
        public string mp4_size;
    }

    [Serializable]
    public class Fixed
    {
        public string height;
        public string mp4;
        public string mp4_size;
        public string size;
        public string url;
        public string webp;
        public string webp_size;
        public string width;
    }

    [Serializable]
    public class __invalid_type__480wStill
    {
        public string url;
        public string width;
        public string height;
    }

    [Serializable]
    public class Images
    {
        public Mp4 hd;
        public Still downsized_large;
        public Still fixed_height_small_still;
        public Original original;
        public Downsampled fixed_height_downsampled;
        public Still downsized_still;
        public Still fixed_height_still;
        public Still downsized_medium;
        public Still downsized;
        public Still preview_webp;
        public Mp4 original_mp4;
        public Fixed fixed_height_small;
        public Fixed fixed_height;
        public Mp4 downsized_small;
        public Mp4 preview;
        public Downsampled fixed_width_downsampled;
        public Still fixed_width_small_still;
        public Fixed fixed_width_small;
        public Still original_still;
        public Still fixed_width_still;
        public Looping looping;
        public Fixed fixed_width;
        public Still preview_gif;
        public __invalid_type__480wStill __invalid_name__480w_still;
    }

    [Serializable]
    public class User
    {
        public string avatar_url;
        public string banner_image;
        public string banner_url;
        public string profile_url;
        public string username;
        public string display_name;
        public bool is_verified;
    }

    [Serializable]
    public class Onload
    {
        public string url;
    }

    [Serializable]
    public class Onclick
    {
        public string url;
    }

    [Serializable]
    public class Onsent
    {
        public string url;
    }

    [Serializable]
    public class Analytics
    {
        public Onload onload;
        public Onclick onclick;
        public Onsent onsent;
    }

    [Serializable]
    public class RootImage
    {
        public string type;
        public string id;
        public string url;
        public string slug;
        public string bitly_gif_url;
        public string bitly_url;
        public string embed_url;
        public string username;
        public string source;
        public string title;
        public string rating;
        public string content_url;
        public string source_tld;
        public string source_post_url;
        public int is_sticker;
        public string import_datetime;
        public string trending_datetime;
        public Images images;
        public User user;
        public string analytics_response_payload;
        public Analytics analytics;
    }

    [Serializable]
    public class Pagination
    {
        public int total_count;
        public int count;
        public int offset;
    }

    [Serializable]
    public class Meta
    {
        public int status;
        public string msg;
        public string response_id;
    }

    [Serializable]
    public class GIPHYCollectionObject
    {
        public List<RootImage> data;
        public Pagination pagination;
        public Meta meta;
    }

    [Serializable]
    public class GIPHYSingleObject
    {
        public RootImage data;
        public Meta meta;
    }
}
