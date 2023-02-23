using UnityEngine;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.S3;
using Amazon.S3.Model;

public class AWSTest : MonoBehaviour
{
    #region Singleton
    private static AWSTest _instance;

    public static AWSTest Instance
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

    public string S3Region = RegionEndpoint.EUWest1.SystemName;
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

    void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
    }

    void Start()
    {
        _instance = this;
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        Debug.Log("AWSManager start");
    }

    public void ListFilesFromS3()
    {
        // create a GET request for a list of objects. We try for now to retrieve everything from the bucket
        var request = new ListObjectsRequest() { BucketName = "webxr-poc-data" };

        S3Client.ListObjectsAsync(
            request,
            (responseObj) =>
            {
                if (responseObj.Exception == null)
                {
                    // being here means GET request was successfull, no execptions thrown on AWS side
                    Debug.Log("Can retrive objects from S3");
                    responseObj.Response.S3Objects.ForEach(
                        (obj) =>
                        {
                            // here we have access to all our S3 objects. For now we just print the KEY
                            Debug.Log("Found this object");
                            Debug.Log(obj.Key);
                        }
                    );
                }
            }
        );
    }
}
