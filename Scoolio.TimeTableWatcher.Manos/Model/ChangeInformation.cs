using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Scoolio.TimeTableWatcher.Manos.Model
{
    [DebuggerDisplay("Class = {ClassString}, Sub = {Subject}, Desc = {Description}")]
    public class ChangeInformation
    {
        public int ClassLevel { get; set; }
        public string ClassAddition { get; set; }

        public string ClassString;

        public int HourNumber;
        public string Subject;
        public string Teacher;
        public string Description;
        public string Room;
    }
}
