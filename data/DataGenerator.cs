using System; 
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace DataGenerator
{
	class DataGenerator
	{
		static void generateAndWriteData(IDbConnection dbConnection)
		{
			IDbCommand dbCommands = dbConnection.CreateCommand();

			Random rnd = new Random();

			int randomRows = rnd.Next(17, 360);
			for (int i = 0; i < randomRows; i++)
			{
				//Make the time stamp to use as row id (epoch time).
				TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
				int timeStamp = (int)t.TotalSeconds;

				//Make Latitude and longitude value.
				//If the a/c is moving 226 km/h than every second it would
				//travel approximately 1.25 meters.  The 5th decimal place
				//provides precision to about 1.1 meters.  This is accurate
				//enough for our purposes. 
				double latitude = 39.73929, longitude = 104.99031;
				double randomLatChange = rnd.NextDouble() * .0003;
				decimal lat = (decimal) (latitude + randomLatChange);
				double randomLonChange = rnd.NextDouble() * .0003;
				decimal lon = (decimal) (longitude + randomLonChange);


				//Write results to db
				string insertStatement =
					"INSERT INTO gps_data (id, latitude, longitude, x, y, z)" +
					"VALUES (" + timeStamp + ", " + lat + ", " + lon +
						", null, null, null)";
				
				dbCommands.CommandText = insertStatement;

				int randomSleep = rnd.Next(0, 3);
				Thread.Sleep(randomSleep);
			}
			dbCommands.Dispose();
			dbCommands = null;
		}

		static IDbConnection connectDb()
		{
			string connectionString =
				"Server=;" +
				"Database=;" +
				"User ID=;" +
				"Password=;" +
				"Pooling=false;";
			IDbConnection dbConnection = new MySqlConnection(connectionString);
			dbConnection.Open();
			return dbConnection;
		}

		static void run()
		{
			IDbConnection dbConnection = connectDb();
			generateAndWriteData(dbConnection);
			
			//Close down the DB connection
			dbConnection.Close();
			dbConnection = null;
		}

		static void Main(string[] args)
		{
			run();
		}
	}
}