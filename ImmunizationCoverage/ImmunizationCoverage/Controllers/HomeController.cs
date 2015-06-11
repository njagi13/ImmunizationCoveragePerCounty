using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ImmunizationCoverage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public string GetCounties()
        {

            var csvitems =
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("ImmunizationCoverage.CSVFiles.CountyFullImmunizationCoverageRate.csv");
            if (csvitems != null)
                using (var reader = new StreamReader(csvitems))
                {

                    var listA = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(';');
                            listA.AddRange(values.Select(value => value.Split(',')).Select(x => x[0]));
                        }

                    }
                    var counties = listA.Skip(1);
                    var jsonSerialiser = new JavaScriptSerializer();
                    foreach (var c in counties)
                    {
                        var json = jsonSerialiser.Serialize(c);
                    }
                    var json1 = jsonSerialiser.Serialize(counties);
                    return json1;
                }
            return null;
        }


        public string GetCoverage()
        {

            var csvitems =
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("ImmunizationCoverage.CSVFiles.CountyFullImmunizationCoverageRate.csv");
            if (csvitems != null)
                using (var reader = new StreamReader(csvitems))
                {

                    var listA = new List<float>();
                    var listB = new List<float>();
                    var listC = new List<float>();
                    var coverage = new List<List<float>>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(';');
                            // var values = v1.Skip(1);
                            listA.AddRange(values.Select(v => v.Split(',')).Select(cols => float.Parse(cols[1])));
                            listB.AddRange(values.Select(v => v.Split(',')).Select(cols => float.Parse(cols[2])));
                            listC.AddRange(values.Select(v => v.Split(',')).Select(cols => float.Parse(cols[3])));
                        }

                    }
                    //skip header

                    listA.RemoveAt(0);
                    listB.RemoveAt(0);
                    listC.RemoveAt(0);

                    coverage.Add(listA);
                    coverage.Add(listB);
                    coverage.Add(listC);
                    var jsonSerialiser = new JavaScriptSerializer();
                    var json1 = jsonSerialiser.Serialize(coverage);
                    return json1;

                }
            return null;
        }
    }
}