using System;
using System.Collections.Generic;
using System.Text;

namespace RestShape.Model
{
   public class CameraExClass
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class AddParam
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class ScheduleTask
        {
            public int bitrateKbps { get; set; }
            public int dayOfWeek { get; set; }
            public int endTime { get; set; }
            public int fps { get; set; }
            public string recordingType { get; set; }
            public int startTime { get; set; }
            public string streamQuality { get; set; }
        }

        public class Root
        {
            public List<AddParam> addParams { get; set; }
            public bool audioEnabled { get; set; }
            public string backupType { get; set; }
            public bool controlEnabled { get; set; }
            public string dewarpingParams { get; set; }
            public bool disableDualStreaming { get; set; }
            public string failoverPriority { get; set; }
            public string groupId { get; set; }
            public string groupName { get; set; }
            public string id { get; set; }
            public bool licenseUsed { get; set; }
            public string logicalId { get; set; }
            public string mac { get; set; }
            public bool manuallyAdded { get; set; }
            public int maxArchiveDays { get; set; }
            public int minArchiveDays { get; set; }
            public string model { get; set; }
            public string motionMask { get; set; }
            public string motionType { get; set; }
            public string name { get; set; }
            public string parentId { get; set; }
            public string physicalId { get; set; }
            public string preferredServerId { get; set; }
            public int recordAfterMotionSec { get; set; }
            public int recordBeforeMotionSec { get; set; }
            public bool scheduleEnabled { get; set; }
            public List<ScheduleTask> scheduleTasks { get; set; }
            public string status { get; set; }
            public string statusFlags { get; set; }
            public string typeId { get; set; }
            public string url { get; set; }
            public string userDefinedGroupName { get; set; }
            public string vendor { get; set; }
        }




    }
}
