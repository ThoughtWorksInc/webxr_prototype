using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
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
    public static AWSManager Instance 
    {
        get
        {
            if(_instance == null)
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
            if(_s3Client == null)
            {   
                // Initialize the Amazon Cognito credentials provider
                CognitoAWSCredentials credentials = new CognitoAWSCredentials (
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

    public void saveJsonFileToS3() 
    {   
        // for now we find the file from our local. Later we want to create file from scene data and store without this step
        FileStream stream = new FileStream(Application.dataPath + "/Scenes/main/MyOverlaysData.json", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

        // create request to the right bucket, the key can be used to retrieve later, to name the object. Does not have to be
        // same as file name we create, but its easier
        PostObjectRequest request = new PostObjectRequest()
        {
            Bucket = "webxr-poc-data",
            Key = "MyOverlaysData.json",
            InputStream = stream,
            CannedACL = S3CannedACL.Private,
            Region = _S3Region
        };
        
        // create post request, this will print success if the S3 save was possible
        S3Client.PostObjectAsync(request, (responeobj) =>
        {
            if (responeobj.Exception == null)
            {
                Debug.Log("Successful upload");
            }
            else 
            {
                Debug.Log("Upload exception:" + responeobj.Exception);
            }
        });
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
            if(responseObj.Exception == null)
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

