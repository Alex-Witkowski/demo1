using System;
using System.Collections.Generic;
using System.Text;

namespace Scoolio.TimeTableWatcher.Manos.Model
{
    public class ChangeInformation
    {
        public List<ChangeInformationItem> Changes { get; set; }
        public DateTime Date { get; set; }
    }
}
