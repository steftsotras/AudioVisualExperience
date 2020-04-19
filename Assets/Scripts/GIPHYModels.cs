using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Still
    {
        public string height { get; set; }
        public string size { get; set; }
        public string url { get; set; }
        public string width { get; set; }
    }

    public class Original
    {
        public string frames { get; set; }
        public string hash { get; set; }
        public string height { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
        public string size { get; set; }
        public string url { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
        public string width { get; set; }
    }

    public class Mp4
    {
        public string height { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
        public string width { get; set; }
    }

    public class Downsampled
    {
        public string height { get; set; }
        public string size { get; set; }
        public string url { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
        public string width { get; set; }
    }

    public class Looping
    {
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
    }

    public class Fixed
    {
        public string height { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
        public string size { get; set; }
        public string url { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
        public string width { get; set; }
    }

    public class __invalid_type__480wStill
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Images
    {
        public Mp4 hd { get; set; }
        public Still downsized_large { get; set; }
        public Still fixed_height_small_still { get; set; }
        public Original original { get; set; }
        public Downsampled fixed_height_downsampled { get; set; }
        public Still downsized_still { get; set; }
        public Still fixed_height_still { get; set; }
        public Still downsized_medium { get; set; }
        public Still downsized { get; set; }
        public Still preview_webp { get; set; }
        public Mp4 original_mp4 { get; set; }
        public Fixed fixed_height_small { get; set; }
        public Fixed fixed_height { get; set; }
        public Mp4 downsized_small { get; set; }
        public Mp4 preview { get; set; }
        public Downsampled fixed_width_downsampled { get; set; }
        public Still fixed_width_small_still { get; set; }
        public Fixed fixed_width_small { get; set; }
        public Still original_still { get; set; }
        public Still fixed_width_still { get; set; }
        public Looping looping { get; set; }
        public Fixed fixed_width { get; set; }
        public Still preview_gif { get; set; }
        public __invalid_type__480wStill __invalid_name__480w_still { get; set; }
    }

    public class User
    {
        public string avatar_url { get; set; }
        public string banner_image { get; set; }
        public string banner_url { get; set; }
        public string profile_url { get; set; }
        public string username { get; set; }
        public string display_name { get; set; }
        public bool is_verified { get; set; }
    }

    public class Onload
    {
        public string url { get; set; }
    }

    public class Onclick
    {
        public string url { get; set; }
    }

    public class Onsent
    {
        public string url { get; set; }
    }

    public class Analytics
    {
        public Onload onload { get; set; }
        public Onclick onclick { get; set; }
        public Onsent onsent { get; set; }
    }

    public class RootImage
    {
        public string type { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string slug { get; set; }
        public string bitly_gif_url { get; set; }
        public string bitly_url { get; set; }
        public string embed_url { get; set; }
        public string username { get; set; }
        public string source { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public string content_url { get; set; }
        public string source_tld { get; set; }
        public string source_post_url { get; set; }
        public int is_sticker { get; set; }
        public string import_datetime { get; set; }
        public string trending_datetime { get; set; }
        public Images images { get; set; }
        public User user { get; set; }
        public string analytics_response_payload { get; set; }
        public Analytics analytics { get; set; }
    }

    public class Pagination
    {
        public int total_count { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
    }

    public class Meta
    {
        public int status { get; set; }
        public string msg { get; set; }
        public string response_id { get; set; }
    }

    public class GIPHYCollectionObject
    {
        public List<RootImage> data { get; set; }
        public Pagination pagination { get; set; }
        public Meta meta { get; set; }
    }

    public class GIPHYSingleObject
    {
        public RootImage data { get; set; }
        public Meta meta { get; set; }
    }
}
