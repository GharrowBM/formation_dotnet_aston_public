using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TP03.Models;

namespace TP03.ViewModels.Services
{
    public class CognitiveService
    {
        private static readonly string API_KEY = "API_KEY";
        private static readonly string ENDPOINT_URL = "ENDPOINT_URL" + "face/v1.0/";
        public static async Task<FaceDetectResult> FaceDetect(MediaFile file)
        {

            if (file == null) return null;

            var stream = file.GetStreamWithImageRotatedForExternalStorage();

            var url = ENDPOINT_URL + "detect" + "?returnFaceAttributes=age,gender";

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/octet-stream";
                    webClient.Headers.Add("Ocp-Apim-Subscription-Key", API_KEY);

                    var data = ReadStream(stream);

                    var result = await Task.Run(() =>
                    {
                       return webClient.UploadData(url, data);

                    });

                    if (result == null) return null;

                    string json = Encoding.UTF8.GetString(result, 0, result.Length);

                    var faceResult = JsonConvert.DeserializeObject<FaceDetectResult[]>(json);

                    if (faceResult.Length == 1)
                    {
                        return faceResult[0];
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception : " + ex.Message);
                }
            }

            return null;
        }

        private static byte[] ReadStream(Stream stream)
        {
            BinaryReader b = new BinaryReader(stream);
            byte[] data = b.ReadBytes((int)stream.Length);
            return data;

        }
    }
}
