using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marek.Application.Models.FixturesDataModels
{
    public class FixtureDataModel
    {
        
        public Fixture Fixture { get; set; }
        public League league { get; set; }
        public Teams teams { get; set; }
        public Goals goals { get; set; }
        public Score score { get; set; }
    }

    public class Modified
    {

        public Fixture Fixture { get; set; }
        public Teams teams { get; set; }
        public Goals goals { get; set; }
    }
    public class Fixture
    {
        public string id { get; set; }
        public string referee { get; set; }
        public string timezone { get; set; }
        public string date { get; set; }
        public int timestamp { get; set; }
        public Periods periods { get; set; }

        public Venue venue { get; set; }

        public Status status { get; set; }


    }
    public class Periods
    {
        public string first { get; set; }
        public string second { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
    }

    public class Status
    {
        public string @long { get; set; }
        public string @short { get; set; }
        public string elapsed { get; set; }
    }

    public class League
    {
        public string id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }
        public string season { get; set; }
        public string round { get; set; }
    }

    public class Teams
    {
        public Home home { get; set; }
        public Away away { get; set; }
    }

    public class Home
    {
        public string id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string winner { get; set; }
    }

    public class Away
    {
        public string id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string winner { get; set; }
    }

    public class Goals
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    public class Score
    {
        public Halftime halftime { get; set; }
        public Fulltime fulltime { get; set; }
        public Extratime extratime { get; set; }
        public Penalty penalty { get; set; }
    }

    public class Halftime
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    public class Fulltime
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    public class Extratime
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    public class Penalty
    {
        public string home { get; set; }
        public string away { get; set; }
    }

    public class ApiResponse
    {
        public List<FixtureDataModel> response { get; set; }
    }

    public class Api2Response
    {
        public List<Modified> response { get; set; }
    }
}
