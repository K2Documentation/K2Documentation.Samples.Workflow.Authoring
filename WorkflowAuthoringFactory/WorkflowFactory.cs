using System;
using System.Collections.Generic;
using System.Text;
using SourceCode.Workflow.Design;
using SourceCode.Framework;
using SourceCode.Configuration;
using SourceCode.Workflow.Authoring;

namespace SourceCode.Workflow.Authoring.Sample.Factory
{
    public sealed class WorkflowFactory
    {
        #region - Process Factory -

        public static SourceCode.Workflow.Authoring.Process CreateProcess(string name)
        {
            return CreateK2Object<DefaultProcess>(name);
        }

        public static T CreateProcess<T>(string name) where T : SourceCode.Workflow.Authoring.Process
        {
            return CreateK2Object<T>(name);
        }

        public static T CreateProcess<T>(string name, string registeredWizardName) where T : SourceCode.Workflow.Authoring.Process
        {
            return CreateK2Object<T>(name, registeredWizardName);
        }

        public static T CreateProcess<T>(string name, string registeredWizardName, WizardStatus wizardStatus) where T : SourceCode.Workflow.Authoring.Event
        {
            return CreateK2Object<T>(name, registeredWizardName, wizardStatus);
        }


        #endregion

        #region - Activity Factory -

        public static SourceCode.Workflow.Authoring.Activity CreateActivity(string name)
        {
            return CreateK2Object<DefaultActivity>(name);
        }

        public static T CreateActivity<T>(string name) where T : SourceCode.Workflow.Authoring.Activity
        {
            return CreateK2Object<T>(name);
        }

        public static T CreateActivity<T>(string name, string registeredWizardName) where T : SourceCode.Workflow.Authoring.Activity
        {
            return CreateK2Object<T>(name, registeredWizardName);
        }

        public static T CreateActivity<T>(string name, string registeredWizardName, WizardStatus wizardStatus) where T : SourceCode.Workflow.Authoring.Event
        {
            return CreateK2Object<T>(name, registeredWizardName, wizardStatus);
        }

        #endregion

        #region - Event Factory -

        public static SourceCode.Workflow.Authoring.Event CreateServerEvent(string name)
        {
            return CreateK2Object<ServerEvent>(name, WizardNames.DefaultWindowsWorkflowServerEvent);
        }
        public static SourceCode.Workflow.Authoring.Event CreateClientEvent(string name)
        {
            return CreateK2Object<ClientEvent>(name, WizardNames.DefaultClientEvent);
        }

        public static T CreateEvent<T>(string name) where T : SourceCode.Workflow.Authoring.Event
        {
            return CreateK2Object<T>(name);
        }
        public static T CreateEvent<T>(string name, string registeredWizardName) where T : SourceCode.Workflow.Authoring.Event
        {
            return CreateK2Object<T>(name, registeredWizardName);
        }
        public static T CreateEvent<T>(string name, string registeredWizardName, WizardStatus wizardStatus) where T : SourceCode.Workflow.Authoring.Event
        {
            return CreateK2Object<T>(name, registeredWizardName, wizardStatus);
        }

        #endregion

        #region - Line Factory -

        public static SourceCode.Workflow.Authoring.Line CreateLine(string name)
        {
            return CreateK2Object<DefaultLine>(name, WizardNames.DefaultLine);
        }

        public static T CreateLine<T>(string name) where T : SourceCode.Workflow.Authoring.Line
        {
            return CreateK2Object<T>(name);
        }
        public static T CreateLine<T>(string name, string registeredWizardName) where T : SourceCode.Workflow.Authoring.Line
        {
            return CreateK2Object<T>(name, registeredWizardName);
        }
        public static T CreateLine<T>(string name, string registeredWizardName, WizardStatus wizardStatus) where T : SourceCode.Workflow.Authoring.Event
        {
            return CreateK2Object<T>(name, registeredWizardName, wizardStatus);
        }

        #endregion

        #region - WizardDefinition and PropertyWizardDefinition Factory -

        public static WizardDefinition CreateWizardDefinition(string registeredWizardName)
        {
            return CreateWizardDefinition(registeredWizardName, WizardStatus.Executed);
        }
        public static WizardDefinition CreateWizardDefinition(string registeredWizardName, WizardStatus wizardStatus)
        {
            WizardElement registeredWizard = ConfigurationManager.Wizards[registeredWizardName];

            IWizard wizardInstance = (IWizard)registeredWizard.CreateInstance();
            WizardDefinition wizardDefinition = wizardInstance.Definition;
            wizardDefinition.Status = wizardStatus;
            if (wizardInstance is IDisposable)
            {
                (wizardInstance as IDisposable).Dispose();
            }
            return wizardDefinition;
        }


        public static T CreateWizardDefinition<T>(string registeredWizardName) where T : WizardDefinition
        {
            return CreateWizardDefinition<T>(registeredWizardName, WizardStatus.Executed);
        }
        public static T CreateWizardDefinition<T>(string registeredWizardName, WizardStatus wizardStatus) where T : WizardDefinition
        {
            T wizardDefinition = Activator.CreateInstance<T>();
            wizardDefinition.Status = wizardStatus;

            WizardElement registeredWizard = ConfigurationManager.Wizards[registeredWizardName];
            wizardDefinition.RegisteredItem = registeredWizard;

            PopulatePropertyWizards(wizardDefinition);

            return wizardDefinition;
        }

        private static void PopulatePropertyWizards(WizardDefinition wizardDefinition)
        {
            foreach (NamedElement propertyWizard in wizardDefinition.RegisteredItem.PropertyWizards)
            {
                wizardDefinition.PropertyWizardDefinitions.Add(CreatePropertyWizardDefinition(propertyWizard.Name));
            }
        }

        public static PropertyWizardDefinition CreatePropertyWizardDefinition(string registeredPropertyWizardName)
        {
            PropertyWizardElement registeredPropertyWizard = ConfigurationManager.PropertyWizards[registeredPropertyWizardName];

            IPropertyWizard propertyWizardInstance = (IPropertyWizard)registeredPropertyWizard.CreateInstance();
            PropertyWizardDefinition propertyWizardDefinition = propertyWizardInstance.Definition;

            if (propertyWizardInstance is IDisposable)
            {
                (propertyWizardInstance as IDisposable).Dispose();
            }

            propertyWizardDefinition.RegisteredItem = registeredPropertyWizard;
            return propertyWizardDefinition;
        }

        public static T CreatePropertyWizardDefinition<T>(string registeredPropertyWizardName) where T : PropertyWizardDefinition
        {
            T propertyWizardDefinition = Activator.CreateInstance<T>();
            propertyWizardDefinition.RegisteredItem = ConfigurationManager.PropertyWizards[registeredPropertyWizardName];
            return propertyWizardDefinition;
        }

        #endregion

        #region - K2Object Factory -

        public static T CreateK2Object<T>(string name) where T : SourceCode.Workflow.Authoring.K2Object
        {
            T k2Object = Activator.CreateInstance<T>();
            k2Object.Name = name;
            return k2Object;
        }

        public static T CreateK2Object<T>(string name, string registeredWizardName) where T : SourceCode.Workflow.Authoring.K2Object, IWizardConfigurable
        {
            return CreateK2Object<T>(name, registeredWizardName, WizardStatus.Executed);
        }

        public static T CreateK2Object<T>(string name, string registeredWizardName, WizardStatus wizardStatus) where T : SourceCode.Workflow.Authoring.K2Object, IWizardConfigurable
        {
            T obj = CreateK2Object<T>(name);
            obj.WizardDefinition = CreateWizardDefinition(registeredWizardName, wizardStatus);
            return obj;
        }

        #endregion
    }
}
