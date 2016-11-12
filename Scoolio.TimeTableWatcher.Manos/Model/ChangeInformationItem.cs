using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Scoolio.TimeTableWatcher.Manos.Model
{
    [DebuggerDisplay("Class = {ClassString}, Sub = {Subject}, Desc = {Description}")]
    public class ChangeInformationItem
    {
        public int ClassLevel { get; set; }
        public string ClassAddition { get; set; }

        public string ClassString;

        public int HourNumber;
        public string Subject;
        public string Teacher;
        public string Description;
        public string Room;

        internal ChangeInformationItem Clone()
        {
            var result = new ChangeInformationItem();
            result.ClassLevel = this.ClassLevel;
            result.ClassAddition = this.ClassAddition;
            result.HourNumber = this.HourNumber;
            result.Subject = this.Subject;
            result.Teacher = this.Teacher;
            result.Description = this.Description;
            result.Room = this.Room;
            return result;
        }
    }
}
