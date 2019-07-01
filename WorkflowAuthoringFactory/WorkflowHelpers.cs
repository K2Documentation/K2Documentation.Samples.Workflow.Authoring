using System;
using System.Collections.Generic;
using System.Text;
using SourceCode.Workflow.Authoring;
using SourceCode.Workflow.Design;

namespace SourceCode.Workflow.Authoring.Sample.Factory
{
    public sealed class WorkflowHelpers
    {
        public static T FindOfType<T>(System.Collections.ICollection collection)
        {
            foreach (object item in collection)
            {
                if (item is T)
                {
                    return (T)item;
                }
            }
            return default(T);
        }

        public static void PositionActivity(Activity activity, int x, int y)
        {
            if (activity.Process == null)
            {
                throw new InvalidOperationException("Add the activity to a process before setting its position.");
            }

            ProcessView processView = EnsureProcessView(activity.Process);

            processView.ActivityLayoutData(activity).Location = new System.Drawing.Point(x, y);
        }

       
        public static void AutoPositionLines(ActivityLineCollection lines)
        {
            if (lines.Count == 0)
                return;

            Activity activity = lines[0].StartActivity;
            ProcessView processView = EnsureProcessView(activity.Process);

            ProcessViewActivityLayoutData layout = processView.ActivityLayoutData(activity);
            int lineSpacing = layout.UserSize.Width / lines.Count;
            int offset = lineSpacing / 2;

            for (int i = 0; i < lines.Count; i++)
            {
                Line line = lines[i];
                processView.LineLayoutData(line).StartOffsetMaximized =
                    new System.Drawing.Point(offset, processView.LineLayoutData(line).StartOffsetMaximized.Y);
                offset += lineSpacing;
            }
        }

        private static ProcessView EnsureProcessView(Process process)
        {
            ProcessView processView = FindOfType<ProcessView>(process.Views);
            if (processView == null)
            {
                processView = new ProcessView();
                process.Views.Add(processView);
            }
            return processView;
        }
    }
}
