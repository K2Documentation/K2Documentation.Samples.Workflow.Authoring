using System;
using System.Collections.Generic;
using System.Text;
using SourceCode.Workflow.Authoring.Sample.Factory;
using SourceCode.Workflow.Authoring;
using SourceCode.Framework.Deployment;
using SourceCode.Hosting.Client.BaseAPI;

namespace WorkflowAuthoringSample
{
    public class WorkflowDeploymentSamples
    {
        public static DeploymentResults DeployProcess(Process process)
        {
            // Create a connection string
            SCConnectionStringBuilder connBuilder = new SCConnectionStringBuilder();
            connBuilder.Host = "localhost";
            connBuilder.Port = 5555;
            connBuilder.IsPrimaryLogin = true;
            connBuilder.Integrated = true;

            // Set up the deployment manager
            DeploymentManager deploymentMng = new DeploymentManager();

            // The workflow management connection string points to the workflow server.
            // The SmartObject connection string points to the SmartObject server and is
            // required by the deployment because a SmartObject is created from the process.
            deploymentMng.WorkflowManagementConnectionString = connBuilder.ConnectionString;
            deploymentMng.SmartObjectConnectionString = connBuilder.ConnectionString;
            return deploymentMng.Deploy(process);
        }

    }
}
