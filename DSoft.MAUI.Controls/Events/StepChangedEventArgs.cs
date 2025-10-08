using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoft.Maui.Controls.Events
{
    public class StepChangedEventArgs : EventArgs
    {
        public StepChangedEventArgs(int previousStepIndex, int stepIndex)
            : base()
        {
            PreviousStepIndex = previousStepIndex;
            StepIndex = stepIndex;
        }

        public int PreviousStepIndex { get; }

        public int StepIndex { get; }
    }

}
