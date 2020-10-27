﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

public class Payment
{
    private string GatewaySend = "https://pay.ir/payment/send";
    private string GatewayResult = "https://pay.ir/payment/verify";

    private string Api = "7a28f6e01c8ca825ccc29374cc0a5769";
    private string Redirect = "http://landofart.ir/bazar/very.aspx";

    public string pay(String Amount)
    {
        string result = "";
        String post_string = "";
        Dictionary<string, string> post_values = new Dictionary<string, string>();
        post_values.Add("api", Api);
        post_values.Add("amount", Amount);
        post_values.Add("redirect", Redirect);

        foreach (KeyValuePair<string, string> post_value in post_values)
        {
            post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
        }
        post_string = post_string.TrimEnd('&');
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewaySend);
        objRequest.Method = "POST";
        objRequest.ContentLength = post_string.Length;
        objRequest.ContentType = "application/x-www-form-urlencoded";

        StreamWriter myWriter = null;
        myWriter = new StreamWriter(objRequest.GetRequestStream());
        myWriter.Write(post_string);
        myWriter.Close();

        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
        {
            result = responseStream.ReadToEnd();
            responseStream.Close();
        }
        return result;
    }
    public string verify(String TransID)
    {
        string result = "";
        String post_string = "";
        Dictionary<string, string> post_values = new Dictionary<string, string>();
        post_values.Add("api", Api);
        post_values.Add("transId", TransID);

        foreach (KeyValuePair<string, string> post_value in post_values)
        {
            post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
        }
        post_string = post_string.TrimEnd('&');
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(GatewayResult);
        objRequest.Method = "POST";
        objRequest.ContentLength = post_string.Length;
        objRequest.ContentType = "application/x-www-form-urlencoded";

        StreamWriter myWriter = null;
        myWriter = new StreamWriter(objRequest.GetRequestStream());
        myWriter.Write(post_string);
        myWriter.Close();

        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
        {
            result = responseStream.ReadToEnd();
            responseStream.Close();
        }
        return result;
    }
}