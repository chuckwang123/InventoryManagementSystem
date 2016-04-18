﻿using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http.Routing;
using Newtonsoft.Json;

namespace InventoryManagementSystem.Models
{
    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        private IHttpRouteData _route;

        public BrowserJsonFormatter(JsonSerializerSettings settings)
        {
            if (settings == null) { throw new ArgumentNullException(nameof(settings)); }

            SupportedMediaTypes.Clear();
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SerializerSettings = settings;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);

            if (headers == null) { throw new ArgumentNullException(nameof(headers)); }
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}