using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WMOOSCARClient
{
    [XmlType("station")]
    public class Station
    {

        public static Dictionary<string, int[]> type2variable ;

        public Station()
        {
            MyLocation = new Location();
        }

        [ExcelColumn("WIGOS ID")]
        [XmlElement("wigosid")]
        public string Wigosid
        {
            get;
            set;
        }


        [XmlElement("name")]
        public string Name
        {
            get;
            set;
        }


        [XmlElement("location")]
        public Location MyLocation; 

        [XmlIgnore]
        public double Latitude
        {
            set
            {
                this.MyLocation.Latitude = value;
            }
        }

        [XmlIgnore]
        public double Longitude
        {
            set
            {
                this.MyLocation.Longitude = value;
            }
        }

        [XmlIgnore]
        public double Elevation
        {
            set
            {
                this.MyLocation.Elevation = value;
            }
        }

        [XmlElement("dateestablished",DataType = "date")]
        [ExcelColumn("Date established")]
        public DateTime DateEstablished
        {
            get;
            set;
        }

        [XmlIgnore]
        [ExcelColumn("Station type")]
        public String StationType
        {
            get;
            set;
        }


        [XmlArray("observations")]
        public List<Observation> MyObservation
        {
            get {

                List<Observation> obs = new List<Observation>();

                if ( ! Station.type2variable.ContainsKey(StationType) )
                {
                    throw new ArgumentException(string.Format("station type {0 }not supported",StationType));
                }
  
                int[] variables = Station.type2variable[this.StationType];
                bool isAWS = this.StationType == "AWS";
                
                foreach (int v in variables)
                {
                    obs.Add(
                        new Observation
                        {
                            Variable = v,
                            Observationsource =  isAWS ? "automaticReading" : "manualReading",
                            MySchedule = MySchedule.FromType(this.Schedule, this.International)
                        }
                    );
                }

                if (!isAWS && HasAnAWS())
                {
                    foreach (int v in Station.type2variable["AWS"])
                    {
                        obs.Add(
                            new Observation
                            {
                                Variable = v,
                                Observationsource = "automaticReading",
                                MySchedule = MySchedule.FromType(this.Schedule, false)
                            }
                        );

                    }
                }

                return obs;
            }
        }

        [XmlIgnore]
        public String AWS
        {
            get;
            set;
        }

        public bool HasAnAWS()
        {
            return bool.Parse(AWS);
        }

        [XmlIgnore]
        public Boolean International
        {
            get;
            set;
        }

        [XmlIgnore]
        public String Schedule
        {
            get;
            set;
        }

        [XmlElement("country")]
        public String Country
        {
            get;
            set;
        }

        [XmlElement("region")]
        [ExcelColumn("WMO Region")]
        public String WMORegion
        {
            get;
            set;
        }
    }

    public class MySchedule
    {
        public static MySchedule FromType(String type, bool international)
        {
            switch(type) {
                case "7/24 1h":
                    return new MySchedule
                    {
                        Monthfrom = 1,
                        Monthto = 12,
                        Dayfrom = 1,
                        Dayto = 7,
                        Hourfrom = 0,
                        Hourto = 23,
                        Minutefrom = 0,
                        Minuteto = 59,
                        Interval = 60,
                        Interational = international
                    };
            }
            throw new ArgumentException(string.Format("{0} not supported for schedule", type)); 
            
        }

        [XmlElement("monthfrom")]
        public int Monthfrom;
        [XmlElement("monthto")]
        public int Monthto;
        [XmlElement("dayfrom")]
        public int Dayfrom;
        [XmlElement("dayto")]
        public int Dayto;
        [XmlElement("hourfrom")]
        public int Hourfrom;
        [XmlElement("hourto")]
        public int Hourto;
        [XmlElement("minutefrom")]
        public int Minutefrom;
        [XmlElement("minuteto")]
        public int Minuteto;
        [XmlElement("interval")]
        public int Interval;
        [XmlElement("international")]
        public Boolean Interational;

    }


    [XmlType("observation")]
    public class Observation
    {
        [XmlElement("variable")]
        public int Variable
        {
            get;
            set;
        }

        [XmlElement("observationsource")]
        public string Observationsource
        {
            get;
            set;
        }

        [XmlElement("schedule")]
        public MySchedule MySchedule
        {
            get;
            set;
        }
    }

    public class Location
    {
        [XmlElement("latitude")]
        public double Latitude
        {
            get;
            set;
        }

        [XmlElement("longitude")]
        public double Longitude
        {
            get;
            set;
        }

        [XmlElement("elevation")]
        public double Elevation
        {
            get;
            set;
        }

}

}
