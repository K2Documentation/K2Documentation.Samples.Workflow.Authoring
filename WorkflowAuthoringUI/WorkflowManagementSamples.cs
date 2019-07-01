using System;
using System.Collections.Generic;
using System.Text;
using SourceCode.Workflow.Management;
using SourceCode.Hosting.Client.BaseAPI;
using System.ComponentModel;

namespace WorkflowAuthoringSample
{
    public class WorkflowManagementSamples : IDisposable
    {
        private WorkflowManagementServer _workflowManagementServer;
        private string _host;
        private int _port;

        public WorkflowManagementSamples()
        {
            _host = "localhost";
            _port = 5555;
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }


        public void UpdateAdminPermissions(string userName, bool admin, bool export, bool canImpersonate)
        {
            bool isNewUser = true;
            AdminPermission newPermission = null;

            // Get the current permissions
            AdminPermissions permissions = ManagementServer.GetAdminPermissions();

            // Check for existing permissions of the given user
            foreach (AdminPermission permission in permissions)
            {
                if (string.Compare(permission.UserName, userName, true) == 0)
                {
                    isNewUser = false;
                    newPermission = permission;
                    break;
                }
            }

            // If it is a new user, add new permissions to the collection
            if (isNewUser)
            {
                newPermission = new AdminPermission();
                newPermission.UserName = userName;
                permissions.Add(newPermission);
            }

            newPermission.Admin = admin;
            newPermission.Export = export;
            newPermission.CanImpersonate = canImpersonate;

            bool updated = ManagementServer.UpdateAdminUsers(permissions);
        }

        public void UpdateProcessPermissions(string userName)
        {
            // Create instance of the Permissions and ProcSetPermissions class
            Permissions permissions = new Permissions();
            ProcSetPermissions procPermissions = new ProcSetPermissions();

            // Set the required permission properties
            procPermissions.ProcSetID = 1;
            procPermissions.UserName = userName;
            procPermissions.Admin = true;
            procPermissions.Start = true;
            procPermissions.View = false;
            procPermissions.ViewPart = false;
            procPermissions.ServerEvent = false;

            // Add the ProcSetPermissions object to the Permissions object
            permissions.Add(procPermissions);

            // Multiple permissions can also be added
            // for other process sets
            ProcSetPermissions procPerms2 = new ProcSetPermissions();
            procPerms2.ProcSetID = 2;
            procPerms2.UserName = userName;
            procPerms2.Admin = true;
            procPerms2.Start = true;
            procPerms2.View = false;
            procPerms2.ViewPart = false;
            procPerms2.ServerEvent = false;

            permissions.Add(procPerms2);

            // Update the permissions
            bool updated = ManagementServer.UpdateUserPermissions(userName, permissions);
        }

        public void ProcessData()
        {
            // Get the specified process set
            ProcessSet procSet = ManagementServer.GetProcSet(1);
            //Load the processes in the process set
            procSet.Processes = ManagementServer.GetProcessVersions(procSet.ProcSetID);
            // Gets the Process of the procset based on the ProcID/Index
            Process process = procSet.Processes[1];
            //OR
            Processes processes = ManagementServer.GetProcesses(procSet.ProcSetID);

            // Gets all the Process Instances for this process
            ProcessInstances processInstances = ManagementServer.GetProcessInstances(process.ProcID);
            
        }

        public void WorklistItems()
        {
            // Gets all the worklist items for the authenticated user
            WorklistItems worklistItems = ManagementServer.GetWorklistItems("", "", "", "", "", "", "");
            foreach (WorklistItem worklistItem in worklistItems)
            {
                Console.WriteLine("WorklistItem: {0}", worklistItem.ID);
            }

            int procInstId = 1;
            int actInstDestId = 1;
            int worklistItemId = 1;

            //If ID = 0, it means that the items' state is "available" and it will redirect the available item.
            //If ID != 0, it means the items' state = "Open" and it will redirect it retaining it's "Open" state.
            bool redirect = ManagementServer.RedirectWorklistItem("K2:Domain\\User1", "K2:Domain\\User2", procInstId, actInstDestId, worklistItemId);

            //If item not in "Open" state, an exception will be thrown.
            bool released = ManagementServer.ReleaseWorklistItem(worklistItemId);
        }

        public void ActionInstanceRights()
        {
            //Get and iterate through Action Instance Rights
            ActionInstanceRights actionInstanceRights = ManagementServer.GetActionInstanceRights();
            foreach (ActionInstanceRight right in actionInstanceRights)
            {
                string actionName = right.Name;
            }

            //Prepare Action Instance Right for saving
            ActionInstanceRight actionInstanceRight = new ActionInstanceRight();
            actionInstanceRight.Name = "Finish"; //name must correlate directly to the name of the Action as determined in DB/Process designer
            actionInstanceRight.ActID = 1; //Action ID;
            actionInstanceRight.ActInstDestID = 1;//Action Instance Destination ID
            actionInstanceRight.ActInstID = 1; //Action Instance ID

            // Create an actioner
            Actioner act = new Actioner();
            act.Name = "K2:Domain\\User";
            act.ActionerType = ActionerType.User; //Or Role

            actionInstanceRight.Actioner = act;

            actionInstanceRight.EventID = 1; //Event ID
            actionInstanceRight.Execute = true;//Can execute the Action;
            actionInstanceRight.ProcInstID = 1; //Process Instance ID

            actionInstanceRights.Add(actionInstanceRight);

            //Save new Action Instance Rights
            ManagementServer.SaveActionInstanceRights(actionInstanceRights);
        }

        //Security Per Process. I.e. on a global level thus being applied to each new Process Instance being started.
        public void ActionRights()
        {
            //Route to get to Action Rights. If Event ID not known.
            Activities activities = ManagementServer.GetProcInstActivities(1); //Process Instance ID
            foreach (Activity activity in activities)
            {
                Events events = ManagementServer.GetActivityEvents(activity.ID);

                foreach (Event ev in events)
                {
                    ActionRights actionRightsToSave = new ActionRights();

                    //Get all Action Rights
                    ActionRights eventActionRights = ManagementServer.GetActionRights(ev.ID);
                    foreach (ActionRight actionRight in eventActionRights)
                    {
                        actionRight.Denied = false;
                        actionRight.Execute = true;

                        actionRightsToSave.Add(actionRight);
                    }

                    //Save Action Rights
                    ManagementServer.SaveActionRights(actionRightsToSave);
                }
            }
        }

        #region - Private Helper Methods and Properties -

        public WorkflowManagementServer ManagementServer
        {
            get
            {
                if (_workflowManagementServer == null)
                {
                    _workflowManagementServer = GetWorkflowManagementServer();
                }
                if (!_workflowManagementServer.Connection.IsConnected)
                {
                    ConnectWorkflowManagementServer(_workflowManagementServer, CreateConnectionString());
                }

                return _workflowManagementServer;
            }
        }

        private WorkflowManagementServer GetWorkflowManagementServer()
        {
            return GetWorkflowManagementServer(CreateConnectionString());
        }

        private WorkflowManagementServer GetWorkflowManagementServer(string connectionString)
        {
            //Create instance of the workfow management class
            WorkflowManagementServer workflowManagementServer = new WorkflowManagementServer();
            ConnectWorkflowManagementServer(workflowManagementServer, connectionString);
            return workflowManagementServer;
        }
        private void ConnectWorkflowManagementServer(WorkflowManagementServer workflowManagementServer, string connectionString)
        {
            if (workflowManagementServer.Connection == null)
            {
                workflowManagementServer.CreateConnection();
            }

            if (!workflowManagementServer.Connection.IsConnected)
            {
                workflowManagementServer.Connection.Open(connectionString);
            }
        }

        private string CreateConnectionString()
        {
            // Create a connection string using default values
            return CreateConnectionString(_host, _port);
        }
        private string CreateConnectionString(string host, int port)
        {
            SCConnectionStringBuilder connBuilder = new SCConnectionStringBuilder();
            connBuilder.Host = host;
            connBuilder.Port = (uint)port;
            connBuilder.IsPrimaryLogin = true;
            connBuilder.Integrated = true;
            return connBuilder.ConnectionString;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_workflowManagementServer != null)
            {
                if (_workflowManagementServer.Connection.IsConnected)
                {
                    _workflowManagementServer.Connection.Close();
                    _workflowManagementServer.Connection.Dispose();
                }
                _workflowManagementServer = null;
            }
        }

        #endregion
    }
}
