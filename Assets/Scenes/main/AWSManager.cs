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

        S3Client.ListBucketsAsync(new ListBucketsRequest(), (responseObject) => 
        {
            if(responseObject.Exception == null)
            {
                responseObject.Response.Buckets.ForEach((s3b) => 
                {
                    Debug.Log("Bucket Name: " + s3b.BucketName);
                });
            }
            else
            {
                Debug.Log("AWS Error: " + responseObject.Exception);
            }
        });
    }

}
