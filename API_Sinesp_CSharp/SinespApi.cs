using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Security.Cryptography;

public class SinespApi
{
    private string _placa;
    private string _secret = "#8.1.0#0KnlVSWHxOih3zKXBWlo";
    private string _securityToken;
    private string _androidId;

    public SinespApi(string placa)
    {
        _placa = placa;    
    }

    private dynamic FireCheckin()
    {
        var request = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new
        {
            userSerialNumber = 0,
            checkin = new { type = 1 },
            version = 49
        }));

        var content = new ByteArrayContent(request);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

        HttpClient client = new HttpClient();
        HttpResponseMessage response = client
        .PostAsync("https://android.clients.google.com/checkin", content)
        .Result;

        response.EnsureSuccessStatusCode();

        var r = response.Content.ReadAsStringAsync().Result;

        return JsonConvert.DeserializeObject(r);
    }

    private string RandomString(int length)
    {
        string result = "";
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        Random r = new Random();

        for (int i = 0; i < length; i++) {    
            result += new string(characters.ToCharArray().OrderBy(s => (r.Next(2) % 2) == 0)
                .ToArray())
                .Substring(0, 1);
        }
        return result;
    }

    private string ByteToString(byte[] buff)
    {
        string sbinary = "";

        for (int i = 0; i < buff.Length; i++)
        {
            sbinary += buff[i].ToString("X2"); // hex format
        }
        return (sbinary);
    }

    private string GeraToken()
    {
        string key = _placa + _secret;
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] keyByte = encoding.GetBytes(key);
        HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
        byte[] messageBytes = encoding.GetBytes(_placa);
        byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
        return ByteToString(hashmessage).ToLower();
    }

    private string FirebaseAuth()
    {
        string randomHash = RandomString(11);
        string encoded = $"sender=905942954488&app=br.gov.sinesp.cidadao.android&device={_androidId}&cert=daf1d792d60867c52e39c238d9f178c42f35dd98&X-appid={randomHash}&X-subtype=905942954488&X-app_ver=49&app_ver=49";
        var request = Encoding
            .UTF8
            .GetBytes(encoded);

        var content = new ByteArrayContent(request);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        content.Headers.ContentType.CharSet = "UTF-8";

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("app", "br.gov.sinesp.cidadao.android");
        client.DefaultRequestHeaders.Add("Authorization", $"AidLogin { _androidId }:{ _securityToken }");
        client.DefaultRequestHeaders.Add("Connection", "Keep-alive");
        client.Timeout = TimeSpan.FromSeconds(10);

        HttpResponseMessage response = client
        .PostAsync("https://android.clients.google.com/c2dm/register3", content)
        .Result;

        response.EnsureSuccessStatusCode();

        var result = response.Content.ReadAsStringAsync().Result;

        return result.Replace("token=", "");
    }

    private byte[] GeraXml(string fToken)
    {
        StringBuilder body = new StringBuilder();
        body.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
        body.Append("<v:Envelope xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:d=\"http://www.w3.org/2001/XMLSchema\" xmlns:c=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:v=\"http://schemas.xmlsoap.org/soap/envelope/\" >");
        body.Append("<v:Header>");
        body.Append("<b>motorola XT1635-02</b>");
        body.Append("<c>ANDROID</c>");
        body.Append("<d>8.1.0</d>");
        body.Append("<e>5.1</e>");
        body.Append("<f>192.168.0.100</f>");
        body.Append("<g>" + GeraToken() + "</g>");
        body.Append("<h>0</h>");
        body.Append("<i>0</i>");
        body.Append("<k/>");
        body.Append("<l>" + string.Format("{0:yyyy-MM-dd H:mm:ss}", DateTime.Now) + "</l>");
        body.Append("<m>8797e74f0d6eb7b1ff3dc114d4aa12d3</m>");
        body.Append("<n>" + fToken + "</n>");
        body.Append("</v:Header>");
        body.Append("<v:Body>");
        body.Append("<n0:getStatus xmlns:n0=\"http://soap.ws.placa.service.sinesp.serpro.gov.br/\" > ");
        body.Append("<a>" + _placa + "</a>");
        body.Append("</n0:getStatus>");
        body.Append("</v:Body>");
        body.Append("</v:Envelope>");

        return Encoding.UTF8.GetBytes(body.ToString());
    }

    public async Task Consulta()
    {
        dynamic checkin = FireCheckin();
        _androidId = checkin.android_id;
        _securityToken = checkin.security_token;

        // É necessário um delay entre o checkin e o firebaseAuth
        await Task.Delay(10000);

        var firebaseAuth = FirebaseAuth().Split(':');

        var fToken = (firebaseAuth.First().Length == 11) ? firebaseAuth.First() : firebaseAuth.ElementAt(1);

        var content = new ByteArrayContent(GeraXml(fToken));

        content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "SinespCidadao / 3.0.2.1 CFNetwork / 758.2.8 Darwin / 15.0.0");
        client.DefaultRequestHeaders.Add("Authorization", $"Token { fToken }:{ firebaseAuth.Last() }");

        HttpResponseMessage response = client
        .PostAsync("https://cidadao.sinesp.gov.br/sinesp-cidadao/mobile/consultar-placa/v5", content)
        .Result;

        response.EnsureSuccessStatusCode();

        var result = response.Content.ReadAsStringAsync().Result;
    }
}