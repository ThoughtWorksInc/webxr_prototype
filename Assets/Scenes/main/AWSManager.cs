using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
using System.Text;
using Amazon.S3.Util;
using System.Collections.Generic;
using Amazon.CognitoIdentity;
using Amazon;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


public class AWSManager : MonoBehaviour
{
    #region Singleton
    private static AWSManager _instance;

    private static string uniqueId;
    public static AWSManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("AWSManager is NULL");
            }
            return _instance;
        }
    }
    #endregion

    public string S3Region = RegionEndpoint.EUWest2.SystemName;
    private RegionEndpoint _S3Region
    {
        get { return RegionEndpoint.GetBySystemName(S3Region); }
    }

    private AmazonS3Client _s3Client;
    public AmazonS3Client S3Client
    {
        get
        {
            if (_s3Client == null)
            {
                // Initialize the Amazon Cognito credentials provider
                CognitoAWSCredentials credentials = new CognitoAWSCredentials(
                    "eu-west-1:edb69395-5f02-4c2f-a7a4-e740b9ff4f7f", // Identity pool ID
                    RegionEndpoint.EUWest1 // Region
                );
                _s3Client = new AmazonS3Client(credentials, _S3Region);
            }
            return _s3Client;
        }
    }

    private void Awake()
    {
        _instance = this;
        UnityInitializer.AttachToGameObject(this.gameObject);

        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

        uniqueId = (new System.Random().Next(1000000, 9999999)).ToString();

        // S3Client.ListBucketsAsync(new ListBucketsRequest(), (responseObject) => 
        // {
        //     if(responseObject.Exception == null)
        //     {
        //         responseObject.Response.Buckets.ForEach((s3b) => 
        //         {
        //             Debug.Log("Bucket Name: " + s3b.BucketName);
        //         });
        //     }
        //     else
        //     {
        //         Debug.Log("AWS Error: " + responseObject.Exception);
        //     }
        // });
    }

    public string saveJsonFileToS3(String json)
    {
        string target = "_" + uniqueId + ".json";

        MemoryStream stream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(json));

        PostObjectRequest request = new PostObjectRequest()
        {
            Bucket = "webxr-poc-data",
            Key = target,
            InputStream = stream,
            CannedACL = S3CannedACL.Private,
            Region = _S3Region
        };

        S3Client.PostObjectAsync(request, (responeobj) =>
        {
            if (responeobj.Exception == null)
            {
                Debug.Log("Successful upload");
            }
            else
            {
                Debug.Log("Upload exception:" + responeobj.Exception);
                throw responeobj.Exception;
            }
        });

        return uniqueId;
    }

    public void getDataFromS3()
    {
        // create a GET request for a list of objects. We try for now to retrieve everything from the bucket
        var request = new ListObjectsRequest()
        {
            BucketName = "webxr-poc-data"
        };

        S3Client.ListObjectsAsync(request, (responseObj) =>
        {
            if (responseObj.Exception == null)
            {
                // being here means GET request was successfull, no execptions thrown on AWS side
                Debug.Log("Can retrive objects from S3");
                responseObj.Response.S3Objects.ForEach((obj) =>
                {
                    // here we have access to all our S3 objects. For now we just print the KEY
                    Debug.Log("Found this object");
                    Debug.Log(obj.Key);
                });
            }

        });
    }
}
