using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EventDataAccess
    {
        #region Add - if eventId is already existed, update timestamp, else create a new event.
        public bool Add(Event eventData)
        {
            bool result;
            try
            {
                using (WebAPITestEntities entities = new WebAPITestEntities())
                {
                    Event tmpEvent = entities.Events.FirstOrDefault(e => e.EventId == eventData.EventId);
                    if (tmpEvent != null)
                    {
                        //Update existing event
                        tmpEvent.EventTimestamp = eventData.EventTimestamp;
                        entities.Events.Attach(tmpEvent);
                        entities.Entry(tmpEvent).State = EntityState.Modified;
                    }
                    else
                    {
                        //Create a new event
                        entities.Events.Add(eventData);
                    }
                    entities.SaveChanges();
                }
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
        #endregion

        
    }
}
