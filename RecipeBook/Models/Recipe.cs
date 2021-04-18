﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using RecipeBook.Models;
//
//    var response = Response.FromJson(jsonString);

namespace RecipeBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Response
    {
        [JsonProperty("results")]
        public List<Recipe> Results { get; set; }

        [JsonProperty("baseUri")]
        public Uri BaseUri { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("processingTimeMs")]
        public long ProcessingTimeMs { get; set; }

        [JsonProperty("expires")]
        public long Expires { get; set; }

        [JsonProperty("isStale")]
        public bool IsStale { get; set; }
    }

    public partial class Recipe
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("readyInMinutes")]
        public long ReadyInMinutes { get; set; }

        [JsonProperty("servings")]
        public long Servings { get; set; }

        [JsonProperty("sourceUrl")]
        public Uri SourceUrl { get; set; }

        [JsonProperty("openLicense")]
        public long OpenLicense { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

}
