using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_RealEstate
{
    // WHERE TO START?
    // 1. Complete the RealEstateType enumeration
    // 2. Complete the RealEstateSale object.  Fill in all properties, then create the constructor.
    // 3. Complete the GetRealEstateSaleList() function.  This is the function that actually reads in the .csv document and extracts a single row from the document and passes it into the RealEstateSale constructor to create a list of RealEstateSale Objects.
    // 4. Start by displaying the the information in the Main() function by creating lambda expressions.  After you have acheived your desired output, then translate your logic into the function for testing.
    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstateSale> realEstateSaleList = GetRealEstateSaleList();
            
            //Display the average square footage of a Condo sold in the city of Sacramento, 
            //Use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
            Console.WriteLine("Average of {0} at {1} is {3}", "Condo", "Sacramento", GetAverageSquareFootageByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo, "Sacramento"));

            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function for testing.

            //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function for testing.

            //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function for testing.

            //Display the average price per square foot for a condo in Sacramento. Round to 2 decimal places. Use the GetAveragePricePerSquareFootByRealEstateTypeAndCity() function for testing.

            //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function for testing.


            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000.  Round to 2 decimal places.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function for testing.

            //Extra Credit:
            //Display top 5 cities by the number of homes sold (using the GroupBy extension)
            // Use the GetTop5CitiesByNumberOfHomesSold() function for testing.

        }

        public static List<RealEstateSale> GetRealEstateSaleList()
        {
            List<RealEstateSale> RealEstateSaleList = new List<RealEstateSale>();
            //read in the realestatedata.csv file.  As you process each row, you'll add a new 
            // RealEstateData object to the list for each row of the document, excluding the first.  bool skipFirstLine = true;
            StreamReader reader = new StreamReader("realestatedata.csv");
            
            string dumper = reader.ReadLine();  // skip the first line b/c it's the column titles
            while (!reader.EndOfStream)
            {
                RealEstateSaleList.Add(new RealEstateSale(reader.ReadLine()));
            }

            return RealEstateSaleList;
        }

        /// <summary>
        /// Finds the average of the square footage of a certain set of data based on the type of real estate property and the city.
        /// </summary>
        /// <param name="realEstateDataList">The listing</param>
        /// <param name="realEstateType">Type of real estate property</param>
        /// <param name="city">A city to search with</param>
        /// <returns>The Average of the square footage</returns>
        public static double GetAverageSquareFootageByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city) 
        {
            return realEstateDataList.Where(x => x.ReType == realEstateType && x.City.ToLower() == city.ToLower()).Average(x => x.Sqft);
        }

        public static decimal GetTotalSalesByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return (decimal)realEstateDataList.Where(x => x.ReType == realEstateType && x.City.ToLower() == city.ToLower()).Sum(x=>x.Price);
        }

        public static int GetNumberOfSalesByRealEstateTypeAndZip(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string zipcode)
        {
            return 0;
        }

        
        public static decimal GetAverageSalePriceByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return 0.0m;
        }
        public static decimal GetAveragePricePerSquareFootByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return 0.0m;
        }

        public static int GetNumberOfSalesByDayOfWeek(List<RealEstateSale> realEstateDataList, DayOfWeek dayOfWeek)
        {
            return 0;
        }

        public static double GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city, decimal price)
        {
            //Must round to 2 decimal points
            return 0.0;
        }

        public static List<string> GetTop5CitiesByNumberOfHomesSold(List<RealEstateSale> realEstateDataList)
        {
            return new List<string>();
        }
    }

    /// <summary>
    /// an enumaution of the different real estate types
    /// </summary>
    public enum RealEstateType
    {
        //fill in with enum types: Residential, MultiFamily, Condo, Lot
        Residential, MultiFamily, Condo, Lot
    }

    /// <summary>
    /// For each listing or line of data in the database is this object with the corresponding columns to variables with data types
    /// </summary>
    class RealEstateSale
    {
        //Create properties, using the correct data types (not all are strings) for all columns of the CSV
        private string _street;
        public string Street { get; set; }
        private string _city;
        public string City { get; set; }
        private string _state;
        public string State { get; set; }
        private int _zip;
        public int Zip { get; set; }
        private int _beds;
        public int Beds { get; set; }
        private int _baths;
        public int Baths { get; set; }
        private double _sqft;
        public double Sqft { get; set; }
        private RealEstateType _reType;
        public RealEstateType ReType { get; set;}
        private string _sale_date;
        public string Sale_date { get; set; }
        private int _price;
        public int Price { get; set; }
        private double _latitude;
        public double Latitude { get; set; }
        private double _longitude;
        public double Longitude { get; set; }

        //The constructor will take a single string arguement.  This string will be one line of the real estate data.
        // Inside the constructor, you will seperate the values into their corrosponding properties, and do the necessary conversions
        public RealEstateSale(string listing)
        {
            List<string> data = listing.Split(',').ToList();
            // our columns
            //street,city,zip,state,beds,baths,sq__ft,type,sale_date,price,latitude,longitude
            this.Street = data[0];
            this.City = data[1];
            this.Zip = int.Parse(data[2]);
            this.State = data[3];
            this.Beds = int.Parse(data[4]);
            this.Baths = int.Parse(data[5]);
            this.Sqft = double.Parse(data[6]);
            if (this.Sqft == 0)
            {
                this.ReType = RealEstateType.Lot;
            }
            if (data[7] == "Multi-Family")
            {
                this.ReType = RealEstateType.MultiFamily;
            }
            if (data[7] == "Condo")
            {
                this.ReType = RealEstateType.Condo;
            }
            if (data[7] == "Residential")
            {
                this.ReType = RealEstateType.Residential;
            }
            this.Sale_date = data[8];
            this.Price = int.Parse(data[9]);
            this.Latitude = double.Parse(data[10]);
            this.Longitude = double.Parse(data[11]);
        }

        //When computing the RealEstateType, if the square footage is 0, then it is of the Lot type, otherwise, use the string
        // value of the "Type" column to determine its corresponding enumeration type.
    }
}
