using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vv.models
{
    public class EventTemp
    {
        public Guid eventId { get; set; }
        public string eventTitle { get; set; }
        public string eventDesc { get; set; }
        public DateTime eventDate { get; set; }
        public DateTime eventTime { get; set; }
        public string eventLocation { get; set; }
        public string eventRoom { get; set; }
        public string eventLink { get; set; }
        public UserProfile eventOrganizer { get; set; }
        public List<UserProfile> eventParticipants { get; set; }
        public string eventPic { get; set; }


        public EventTemp()
        {
            eventId = Guid.Empty;
            eventTitle = "";
            eventDesc = "";
            eventDate = DateTime.MinValue;
            eventTime = DateTime.MinValue;
            eventLocation = "";
            eventRoom = "";
            eventLink = "";
            eventOrganizer = new UserProfile();
            eventParticipants = new List<UserProfile>();
            eventPic = "";
        }
    }
}