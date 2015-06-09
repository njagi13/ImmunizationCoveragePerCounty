using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ImmunizationCoverage.Controllers
{
  

    [RoutePrefix("api/immunizationcoverage")]
    public class ImmunizationCoverageController : ApiController
    {
       
     //    public static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "\\CSVFiles/CountyFullImmunizationCoverageRate.csv");

      //  public static string FilePath = System.IO.Path.Combine(Environment.CurrentDirectory,
          //  @"CSVFiles\CountyFullImmunizationCoverageRate.csv");
        
        [Route("counties")]
        public object GetCounties()
        {
  
            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var path = baseDirectory + "CSVFiles\\CountyFullImmunizationCoverageRate.csv";

            var iop = File.ReadAllLines(path).Skip(1).Select(line => new { line, columns = line.Split(','), rows = line.Split(';') }).Select(@t => new
            {
                County = @t.columns[0],
               /* year1 = @t.columns[1],
                year2 = @t.columns[2],
                year3 = @t.columns[3]*/
            }).ToList();

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(iop);
            return json;
        }



        [Route("coverage")]
        public object GetCoverage()
        {

            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var path = baseDirectory + "CSVFiles\\CountyFullImmunizationCoverageRate.csv";

            var iop = File.ReadAllLines(path).Skip(1).Select(line => new { line, columns = line.Split(','), rows = line.Split(';') }).Select(@t => new
            {
               // County = @t.columns[0],
                 year1 = @t.columns[1],
                 year2 = @t.columns[2],
                 year3 = @t.columns[3]
            }).ToList();

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(iop);
            return json;
        }

        [Route("period")]
        public object GetPeriod()
        {

            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var path = baseDirectory + "CSVFiles\\CountyFullImmunizationCoverageRate.csv";

            var iop = File.ReadAllLines(path).Take(1).Select(line => new { line, rows = line.Split(';') }).Select(@t => new
            {
                Header = @t.rows[0],
               
            }).ToList();

            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(iop);
            return json;
        }

    }
}
