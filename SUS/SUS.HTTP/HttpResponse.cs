﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            if (body==null)
            {
                //throw new ArgumentNullException(nameof(body)); // or
                body = new byte[0];
            }
            this.StatusCode = statusCode;
            this.Body = body;
            this.Headers = new List<Header> 
            {
                { new Header("Content-Type", contentType) },
                { new Header("Content-Length", body.Length.ToString()) }
            };

            //this.Cookies = new List<ResponseCookie>(); //- за полиморфизма даваме само Cookie:
            this.Cookies = new List<Cookie>();
        }

        public override string ToString()
        {
            StringBuilder responseBuilder = new StringBuilder();
            responseBuilder.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}{HttpConstants.NewLine}");
            foreach (var header in this.Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            foreach (var cookie in this.Cookies)
            {
                responseBuilder.Append($"Set-Cookie: {cookie}{HttpConstants.NewLine}");
            }

            responseBuilder.Append(HttpConstants.NewLine);

            return responseBuilder.ToString();
        }
        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        //public ICollection<ResponseCookie> Cookies { get; set; } //- за полиморфизма даваме само Cookie:
        public ICollection<Cookie> Cookies { get; set; }

        public byte[] Body { get; set; }
    }
}
