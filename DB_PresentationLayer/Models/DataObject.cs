using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_PresentationLayer.Models
{
    public class DataObject
    {
        public string loginUsername;
        public string travelTime;
        public string travelcost;
        public string pickUpLocationName;
        public string dropLocationName;
        public string vendorName;
        public bool isRequestSuccess;
    }
    public class DataObjectList
    {
        public List<DataObject> dataObjList;
        public bool isRequestSuccess;
    }
}