using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using LinqToExcel;

namespace WMOOSCARClient
{

    public class ConnexionExcel : IDisposable
    {
        public string _pathExcelFile;
        public ExcelQueryFactory _urlConnexion;
        public ConnexionExcel(string path)
        {
            this._pathExcelFile = path;
            this._urlConnexion = new ExcelQueryFactory(_pathExcelFile);
        }
        public string PathExcelFile
        {
            get
            {
                return _pathExcelFile;
            }
        }
        public ExcelQueryFactory UrlConnexion
        {
            get
            {
                return _urlConnexion;
            }
        }

        void IDisposable.Dispose()
        {
            this._urlConnexion.Dispose();
        }
    }

    public class OSCARclient
    {
        /// <summary>
        ///  Read Data from selected excel file into DataTable
        /// </summary>
        /// <param name="filename">Excel File Path</param>
        /// <returns></returns>
        private List<Station> ReadExcelFile(string filename)
        {

            List<Station> stations = new List<Station>();

            try
            {
                // Use SpreadSheetDocument class of Open XML SDK to open excel file
                using (ConnexionExcel ConxObject = new ConnexionExcel(filename))
                {

                    Dictionary<string, int[]> _type2variables = new Dictionary<string, int[]>();

                    var query0 = from b in ConxObject.UrlConnexion.Worksheet<StationType>("Definitions")
                                 select b;
                    foreach (var result in query0)
                    {
                        _type2variables.Add(result.MyType, result.StationVariables);
                    }

                    Station.type2variable = _type2variables;

                    var query1 = from a in ConxObject.UrlConnexion.Worksheet<Station>("Stations")
                                 select a;
                    foreach (var result in query1)
                    {
                        string text = "StationID : {0}, Name: {1}";
                        Console.WriteLine(string.Format(text, result.Wigosid, result.Name));
                        stations.Add(result);
                    }

                }


            }
            catch (IOException ex)
            {
                throw new IOException(ex.Message);
            }
            return stations;
        }


       


        /// <summary>
        /// Convert DataTable to Xml format
        /// </summary>
        /// <param name="filename">Excel File Path</param>
        /// <returns>Xml format string</returns>
        public String GetXML(string filename , string outputdir)
        {
            String ret = "";

            try
            {
                XmlSerializer serializer = new XmlSerializer( typeof(Station) );

                XslCompiledTransform xslTransform = new XslCompiledTransform(); ;
                XmlReader r = XmlReader.Create("resources/observing_facility.xslt");
                xslTransform.Load(r);

                foreach (Station station in this.ReadExcelFile(filename))
                {
                    Console.WriteLine(string.Format("serializing and transforming {0}", station.Wigosid));
                    using (StringWriter sw = new StringWriter())
                    {
                        using (XmlTextWriter tw = new XmlTextWriter(sw))
                        {
                            serializer.Serialize( tw, station);
                            using (StringReader sr = new StringReader(sw.ToString()))
                            {
                                using (XmlReader xr = XmlReader.Create(sr))
                                {
                                    String outputfile = string.Format(@"{0}\{1}.xml", outputdir, station.Wigosid);
                                    using (XmlTextWriter xtw = new XmlTextWriter(outputfile, null))
                                    {
                                        xtw.Formatting = Formatting.Indented;
                                        xtw.Indentation = 4;
                                        
                                        Console.WriteLine(string.Format("writing out {0} to file {1}", station.Wigosid, outputfile));
                                        xslTransform.Transform(xr, xtw);

                                        ret += String.Format("processed station {0} ok {1}", station.Wigosid, Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

            return ret;
            
        }
    }
}
