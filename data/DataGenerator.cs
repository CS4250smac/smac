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
			dbCommands.CommandType = CommandType.Text;
			Random rnd = new Random();

			int randomRows = rnd.Next(17, 36);
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
				Console.WriteLine("Iteration: " + i + "\n\tTS: " + timeStamp + "\n\tLat: " + lat +
					"\n\tLon: " + lon);

			    dbCommands.CommandText = String.Format("INSERT INTO {0} (`id`, latitude, longitude, x, y, `z`)" +
					"VALUES (?ts, ?la, ?lo, null, null, null);", "data");

				var parameterTimeStamp = dbCommands.CreateParameter();
				parameterTimeStamp.ParameterName = "?ts";
				parameterTimeStamp.Value = timeStamp;
				parameterTimeStamp.DbType = DbType.Int32;
				dbCommands.Parameters.Add(parameterTimeStamp);

				var parameterLatitude = dbCommands.CreateParameter();
				parameterLatitude.ParameterName = "?la";
				parameterLatitude.Value = lat;
				parameterLatitude.DbType = DbType.Decimal;
				dbCommands.Parameters.Add(parameterLatitude);

				var parameterLongitude = dbCommands.CreateParameter();
				parameterLongitude.ParameterName = "?lo";
				parameterLongitude.Value = lon;
				parameterLongitude.DbType = DbType.Decimal;
				dbCommands.Parameters.Add(parameterLongitude);

				dbCommands.ExecuteNonQuery();

				int randomSleep = rnd.Next(500, 2000);
				Thread.Sleep(randomSleep);

				dbCommands.Parameters.Clear();
			}
			dbCommands.Dispose();
			dbCommands = null;
		}

		static IDbConnection connectDb()
		{
			string connectionString =
				"Server=localhost;" +
				"Database=gps_data;" +
				"User ID=smackers;" +
				"Password=1234;" +
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