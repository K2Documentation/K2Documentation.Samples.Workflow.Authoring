using System;
using System.Collections.Generic;
using System.Text;
using SourceCode.Framework.Deployment;
using SourceCode.ProjectSystem;
using SourceCode.Workflow.Authoring;
using System.IO;

namespace SourceCode.Workflow.Authoring.Sample.Factory
{
    public sealed class DeploymentManager
    {
        private string _smartObjectConnectionString;
        private string _workflowManagementConnectionString;

        public DeploymentManager()
        {
        }

        public string WorkflowManagementConnectionString
        {
            get { return _workflowManagementConnectionString; }
            set { _workflowManagementConnectionString = value; }
        }

        public string SmartObjectConnectionString
        {
            get { return _smartObjectConnectionString; }
            set { _smartObjectConnectionString = value; }
        }

        public DeploymentResults Deploy(Project project)
        {
            DeploymentPackage package = null;
            DeploymentEnvironment environment = null;

            try
            {
                // Compile the project first before we attempt to deploy it.
                DeploymentResults compileResults = project.Compile();
                if (!compileResults.Successful)
                {
                    // Is the compile was unsuccesfull, return the results
                    return compileResults;
                }

                // Create a logger that is required by the deployment package
                ProjectLogger logger = new ProjectLogger();
                logger.Verbosity = Microsoft.Build.Framework.LoggerVerbosity.Diagnostic;
                project.SetOutputLogger(logger);

                // Create a new deployment package
                package = project.CreateDeploymentPackage();

                // The deployment package requires at least one environment, so add a default one.
                // When deployment is done via VisualStudio, the environments are automatically set
                // up from the ones available in the Environment Library.
                environment = package.AddEnvironment("Default");
                package.SelectedEnvironment = environment.Name;
                package.SmartObjectConnectionString = _smartObjectConnectionString;
                package.WorkflowManagementConnectionString = _workflowManagementConnectionString;

                // Start the deployment
                return project.Deploy(package);
            }
            finally
            {
                if (package != null)
                {
                    package.Dispose();
                    package = null;
                }
                if (environment != null)
                {
                    environment.Dispose();
                    environment = null;
                }
            }
        }

        public DeploymentResults Deploy(params Process[] processes)
        {
            return Deploy("K2Project", processes);
        }

        public DeploymentResults Deploy(string tempProjectName, params Process[] processes)
        {
            Project project = null;

            try
            {
                // Create a temporary project
                project = CreateTempProject(tempProjectName);
                
                // Add the given processes
                foreach (Process process in processes)
                {
                    // Create a new project file for each process
                    ProjectFile file = (ProjectFile)project.CreateNewFile();
                    file.FileName = process.FileName;
                    file.Content = process;
                    project.Files.Add(file);
                }

                // We have to save the project before we can deploy
                project.SaveAll();

                // Diploy the project
                return Deploy(project);
            }
            finally
            {
                if (project != null)
                {
                    string pathToCleanUp = project.FolderPath;

                    try
                    {
                        project.Delete();
                        project.Dispose();
                        project = null;
                        if (Directory.Exists(pathToCleanUp))
                        {
                            Directory.Delete(pathToCleanUp, true);
                        }
                    }
                    finally
                    {
                    }
                }
            }

        }

        private Project CreateTempProject(string projectName)
        {
            string tmpPath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetTempFileName()));
            Project proj = new Project(projectName, tmpPath);
            return proj;
        }
    }
}
