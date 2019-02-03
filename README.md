# Commitment Database Connector

This application is a proof of concept for digesting commitment data from DynamoDb in AWS.

###How to generate AWS credentials
* Create user in IAM with rights to at least DynamoDb. User must have "programmatic access" to AWS.
* Note the Access Key Id and Secret Key that are shown when completeing the user setup.
* Perform one of the following to apply the credentials to your project (additional details: https://github.com/aws/aws-sdk-net/issues/499#issuecomment-266675131).
* If you have the AWS CLI (https://aws.amazon.com/cli/) installed simply perform 'aws configure' from a command prompt and follow the instructions. Skip the remain steps.
* Alternatively, create a credential.json file in a folder called '~/.aws/credentials'.
* This json file should have the following format:
```
{
    "AWS": {
        "Region": "us-west-2",
        "AccessKey": "xxx",
        "SecretKey": "yyy"
    }
}
```

This should configure your project for AWS IAM authentication and allow you to access your DynamoDb content.
