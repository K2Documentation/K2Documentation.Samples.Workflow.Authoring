using System;
using System.Collections.Generic;
using System.Text;
using SourceCode.Workflow.Design;
using SourceCode.Workflow.Design.Mail;
using SourceCode.Workflow.Authoring;
using SourceCode.Workflow.Design.Outcome;
using SourceCode.Framework;
using SourceCode.Workflow.Design.SimpleRules;
using SourceCode.Workflow.Authoring.Sample.Factory;
using SourceCode.Framework.Deployment;
using SourceCode.ProjectSystem;
using System.IO;

namespace WorkflowAuthoringSample
{
    public class WorkflowAuthoringSamples
    {
        public static DefaultProcess CreateSampleProcess()
        {
            // Create new process
            DefaultProcess process = WorkflowFactory.CreateProcess<DefaultProcess>("Sample Approval Process", WizardNames.DefaultProcess);

            // Add some data fields with default values
            DataField fromEmailDataField = new DataField("From Email", "administrator@email.com");
            DataField toEmailDataField = new DataField("To Email", "user@email.com");
            process.DataFields.Add(fromEmailDataField);
            process.DataFields.Add(toEmailDataField);

            // Create 3 activities and add them to the process
            DefaultActivity awaitApprovalActivity = WorkflowFactory.CreateActivity<DefaultActivity>("Await approval", WizardNames.DefaultActivity);
            DefaultActivity approvedActivity = WorkflowFactory.CreateActivity<DefaultActivity>("Approved", WizardNames.DefaultActivity);
            DefaultActivity declinedActivity = WorkflowFactory.CreateActivity<DefaultActivity>("Declined", WizardNames.DefaultActivity);
            process.Activities.Add(awaitApprovalActivity);
            process.Activities.Add(approvedActivity);
            process.Activities.Add(declinedActivity);

            // Create a client event
            ClientEvent approvalClientEvent = WorkflowFactory.CreateEvent<ClientEvent>("Get client approval", WizardNames.DefaultClientEvent);
            SourceCode.Workflow.Design.DefaultClientWizardDefinition a = new DefaultClientWizardDefinition();
            
            
            // Configure the client event
            approvalClientEvent.EventItem.InternetPlatform = "ASP";
            approvalClientEvent.EventItem.SendToInternet = true;
            approvalClientEvent.EventItem.InternetUrl = K2FieldFactory.CreateK2Field(
                typeof(string),
                new ValueTypePart("http://webserver/page.aspx?"),
                new SerialNoFieldPart());

            // Add event to the activity so that the helper methods for generating
            // the default outcomes will work correctly
            awaitApprovalActivity.Events.Add(approvalClientEvent);

            // Add two actions for the client event
            EventAction approveAction = WorkflowFactory.CreateK2Object<EventAction>("Approve");
            approveAction.ActionItem = new DefaultOutcomeAction();
            EventAction declineAction = WorkflowFactory.CreateK2Object<EventAction>("Decline");
            declineAction.ActionItem = new DefaultOutcomeAction();
            approvalClientEvent.Actions.Add(approveAction);
            approvalClientEvent.Actions.Add(declineAction);

            // Set the activity succeeding rule to the outcome succeeding rule
            awaitApprovalActivity.SucceedingRule = new DefaultOutcomeSucceedingRule();

            // Find the default succeeding rule property wizard definition,
            // and replace it with the default outcome succeeding rule
            PropertyWizardDefinition propWizDefSimple = WorkflowHelpers.FindOfType<SimpleSucceedingRulePropertyWizardDefinition>(awaitApprovalActivity.WizardDefinition.PropertyWizardDefinitions);
            PropertyWizardDefinition propWizDefOutcome = WorkflowHelpers.FindOfType<OutcomeSucceedingRulePropertyWizardDefinition>(awaitApprovalActivity.WizardDefinition.PropertyWizardDefinitions);
            if (propWizDefSimple != null && propWizDefOutcome == null)
            {
                awaitApprovalActivity.WizardDefinition.PropertyWizardDefinitions.Remove(propWizDefSimple);
                awaitApprovalActivity.WizardDefinition.PropertyWizardDefinitions.Add(
                    WorkflowFactory.CreatePropertyWizardDefinition(PropertyWizardNames.OutcomeSucceedingRule));
            }
            SourceCode.Workflow.Design.Outcome.Common.GenerateDefaultOutcomesForActions(approvalClientEvent);
            SourceCode.Workflow.Design.Outcome.Common.GenerateDefaultLinesForOutcomes(awaitApprovalActivity.SucceedingRule as DefaultOutcomeSucceedingRule);

            // Add some destination users
            SimpleDestinationRule destinationRule = new SimpleDestinationRule();
            DestinationSet defaultDestinationSet = new DestinationSet();
            Destination destination1 = new Destination();
            destination1.Type = DestinationTypes.User;
            destination1.Value = K2FieldFactory.CreateK2Field("K2:Domain\\User1");
            Destination destination2 = new Destination();
            destination2.Type = DestinationTypes.User;
            destination2.Value = K2FieldFactory.CreateK2Field("K2:Domain\\User2");

            defaultDestinationSet.Destinations.Add(destination1);
            defaultDestinationSet.Destinations.Add(destination2);
            
            destinationRule.DestinationSets.Add(defaultDestinationSet);


            // Set the destination rule of the activity
            awaitApprovalActivity.DestinationRule = destinationRule;

            // Create the approved email event
            MailEvent approvedMail = WorkflowFactory.CreateEvent<MailEvent>("Send approved email", WizardNames.MailEvent);
            // Use string values for the email addresses
            approvedMail.EventItem.To = K2FieldFactory.CreateK2Field("john@email.com");
            approvedMail.EventItem.From = K2FieldFactory.CreateK2Field("administrator@email.com");
            approvedMail.EventItem.Subject = K2FieldFactory.CreateK2Field("Leave Approved");
            approvedMail.EventItem.Body = K2FieldFactory.CreateK2Field("Your leave has been approved.");

            // Create the declined email event
            MailEvent declinedMail = WorkflowFactory.CreateEvent<MailEvent>("Send declined email", WizardNames.MailEvent);
            // Use process data fields for the email addresses
            declinedMail.EventItem.To = K2FieldFactory.CreateK2Field(toEmailDataField);
            declinedMail.EventItem.From = K2FieldFactory.CreateK2Field(fromEmailDataField);
            declinedMail.EventItem.Subject = K2FieldFactory.CreateK2Field("Leave Declined");
            declinedMail.EventItem.Body = K2FieldFactory.CreateK2Field("Your leave has been declined.");

            // Add the events to the activities
            approvedActivity.Events.Add(approvedMail);
            declinedActivity.Events.Add(declinedMail);

            // Link the lines created by the "GenerateDefaultLinesForOutcomes" method to the approved and declined activities
            process.Lines["Approve"].FinishActivity = approvedActivity;
            process.Lines["Decline"].FinishActivity = declinedActivity;

            // Link the start activity with the await approval activity
            Line startLine = WorkflowFactory.CreateLine("StartLine");
            startLine.StartActivity = process.StartActivity;
            startLine.FinishActivity = awaitApprovalActivity;
            process.Lines.Add(startLine);

            // Position the activities and lines
            WorkflowHelpers.PositionActivity(process.StartActivity, 208, 16);
            WorkflowHelpers.PositionActivity(awaitApprovalActivity, 208, 112);
            WorkflowHelpers.PositionActivity(approvedActivity, 32, 224);
            WorkflowHelpers.PositionActivity(declinedActivity, 368, 224);

            // FinishLines are the lines that flows out from the activity
            // when the activity has finished
            WorkflowHelpers.AutoPositionLines(awaitApprovalActivity.FinishLines);

            return process;
        }

        public static DefaultProcess CreateIncompleteProcess()
        {
            // Create a process with two activities
            DefaultProcess process = WorkflowFactory.CreateProcess<DefaultProcess>("Sample Process", WizardNames.DefaultProcess);
            process.Activities.Add(WorkflowFactory.CreateK2Object<DefaultActivity>("Activity 1", WizardNames.DefaultActivity));
            process.Activities.Add(WorkflowFactory.CreateK2Object<DefaultActivity>("Activity 2", WizardNames.DefaultActivity));

            // Add an event to Activity 1 and set the status of the associated wizard
            // equal to Delayed. Holding the control key and dragging a wizard
            // from the toolbox in K2 for Visual Studio will also set the status
            // for that wizard to delayed. You will also not be able to export a
            // process with delayed wizards.
            process.Activities["Activity 1"].Events.Add(
                WorkflowFactory.CreateEvent<ClientEvent>("Client Event 1", WizardNames.DefaultClientEvent, WizardStatus.Delayed));

            // Position the activities
            WorkflowHelpers.PositionActivity(process.StartActivity, 208, 16);
            WorkflowHelpers.PositionActivity(process.Activities["Activity 1"], 32, 112);
            WorkflowHelpers.PositionActivity(process.Activities["Activity 2"], 368, 112);

            return process;
        }
    }
}
