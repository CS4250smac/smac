using System; 
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Collections.Generic;

namespace DataGenerator
{
	class DataGenerator
	{
		static Dictionary<string,List<Decimal>> makeValues(decimal latVal, decimal lonVal, decimal latValTwo,
			decimal lonValTwo, int operation, int currentIteration, int maxIteration, string table,
			Dictionary<string, List<Decimal>> values)
		{
			if (currentIteration == maxIteration)
			{
				return values;
			}
			else
			{
				switch(operation)
				{
					case 0:
						latVal = latVal + (latVal * new Decimal(.003));
						latValTwo = latValTwo + (latValTwo * new Decimal(.003));
						lonVal = lonVal - (lonVal * new Decimal(.003));
						lonValTwo = lonValTwo - (lonValTwo * new Decimal(.003));
						break;
					case 1:
						latVal = latVal + (latVal * new Decimal(.003));
						latValTwo = latValTwo + (latValTwo * new Decimal(.003));
						lonVal = lonVal + (lonVal * new Decimal(.003));
						lonValTwo = lonValTwo + (lonValTwo * new Decimal(.003));
						break;
					default:
						break;
				}

				values.Add(table, new List<Decimal>(new decimal[] {latVal, lonVal, latValTwo, lonValTwo}));
				return makeValues(latVal, lonVal, latValTwo, lonValTwo, operation,
					++currentIteration, maxIteration, table + currentIteration, values);
			}
		}

		static void collectData(IDbConnection dbConnection)
		{
			//Crash table
			Dictionary<string, List<Decimal>> crashVals = makeValues(new Decimal(39.73929),
				new Decimal(104.99031), new Decimal(40.73929), new Decimal(105.99031), 0, 0, 30, 
				"collision_data", new Dictionary<string, List<Decimal>>());
			writeData(dbConnection, crashVals);

			//Safe table
			Dictionary<string, List<Decimal>> safeVals = makeValues(new Decimal(-39.73929),
				new Decimal(-104.99031), new Decimal(40.73929), new Decimal(105.99031), 1, 0, 30,
				"safe_data", new Dictionary<string, List<Decimal>>());
			writeData(dbConnection, safeVals);
		}

		static void writeData(IDbConnection dbConnection, Dictionary<String, List<Decimal>> values)
		{
			IDbCommand dbCommands = dbConnection.CreateCommand();
			dbCommands.CommandType = CommandType.Text;
			
			foreach (string key in values.Keys)
			{
					//Make the time stamp to use as row id (epoch time).
				TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
				int timeStamp = (int)t.TotalSeconds;

				List<Decimal> valsList = values[key];
				decimal lat = valsList[0];
				decimal lon = valsList[1];
				decimal latTwo = valsList[2];
				decimal lonTwo = valsList[3];


				string table = key.StartsWith("collision") ? "collision_data" : "safe_data";
				
				dbCommands.CommandText = String.Format("INSERT INTO {0}" +
					"(`id`, latitude_1, longitude_1, latitude_2, longitude_2)" +
					"VALUES (?ts, ?la_1, ?lo_1, ?la_2, ?lo_2);", table);

				var parameterTimeStamp = dbCommands.CreateParameter();
				parameterTimeStamp.ParameterName = "?ts";
				parameterTimeStamp.Value = timeStamp;
				parameterTimeStamp.DbType = DbType.Int32;
				dbCommands.Parameters.Add(parameterTimeStamp);

				var parameterLatitude = dbCommands.CreateParameter();
				parameterLatitude.ParameterName = "?la_1";
				parameterLatitude.Value = lat;
				parameterLatitude.DbType = DbType.Decimal;
				dbCommands.Parameters.Add(parameterLatitude);

				var parameterLongitude = dbCommands.CreateParameter();
				parameterLongitude.ParameterName = "?lo_1";
				parameterLongitude.Value = lon;
				parameterLongitude.DbType = DbType.Decimal;
				dbCommands.Parameters.Add(parameterLongitude);

				var parameterLatitudeTwo = dbCommands.CreateParameter();
				parameterLatitudeTwo.ParameterName = "?la_2";
				parameterLatitudeTwo.Value = latTwo;
				parameterLatitudeTwo.DbType = DbType.Decimal;
				dbCommands.Parameters.Add(parameterLatitudeTwo);

				var parameterLongitudeTwo = dbCommands.CreateParameter();
				parameterLongitudeTwo.ParameterName = "?lo_2";
				parameterLongitudeTwo.Value = lonTwo;
				parameterLongitudeTwo.DbType = DbType.Decimal;
				dbCommands.Parameters.Add(parameterLongitudeTwo);

				dbCommands.ExecuteNonQuery();

				Random rnd = new Random();
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
			collectData(dbConnection);
			
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