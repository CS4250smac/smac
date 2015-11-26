using System; 
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Collections.Generic;

namespace DataGenerator
{
	class DataGenerator
	{
		static Dictionary<string,List<Decimal>> makeValues(decimal latVal, decimal lonVal, decimal altOne, decimal latValTwo,
			decimal lonValTwo, decimal altTwo, int scenario, int currentIteration, int maxIteration, string table,
			Dictionary<string, List<Decimal>> values)
		{
			if (currentIteration == maxIteration)
			{
				return values;
			}
			else
			{
				switch(scenario)
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
					altOne = altOne + 250;
					break;
					case 2:
					latVal = latVal + (latVal * new Decimal(.003));
					latValTwo = latValTwo + (latValTwo * new Decimal(.003));
					lonVal = lonVal - (lonVal * new Decimal(.003));
					lonValTwo = lonValTwo - (lonValTwo * new Decimal(.003));
					altOne = altOne + 250;
					break;
					case 3:
					latVal = latVal + (latVal * new Decimal(.003));
					latValTwo = latValTwo + (latValTwo * new Decimal(.003));
					lonVal = lonVal + (lonVal * new Decimal(.003));
					lonValTwo = lonValTwo + (lonValTwo * new Decimal(.003));
					break;
					default:
					break;
				}

				values.Add(table, new List<Decimal>(new decimal[] {latVal, lonVal, altOne, latValTwo, lonValTwo, altTwo}));
				return makeValues(latVal, lonVal, altOne, latValTwo, lonValTwo, altTwo, scenario,
					++currentIteration, maxIteration, table + currentIteration, values);
			}
		}

		static void collectData(IDbConnection dbConnection)
		{
			//Vector crash table
			Dictionary<string, List<Decimal>> vectorCrashVals = makeValues(new Decimal(39.73929),
				new Decimal(104.99031), new Decimal(10000), new Decimal(40.73929), new Decimal(105.99031),
				new Decimal(15000), 0, 0, 30, "vector", new Dictionary<string, List<Decimal>>());
			writeData(dbConnection, vectorCrashVals);

			//Altitude crash table
			Dictionary<string, List<Decimal>> altCrashVals = makeValues(new Decimal(-39.73929),
				new Decimal(-104.99031), new Decimal (10000), new Decimal(40.73929), new Decimal(105.99031),
				new Decimal(15000), 1, 0, 30, "altitude", new Dictionary<string, List<Decimal>>());
			writeData(dbConnection, altCrashVals);

			//Both altitude and vector crash table
			Dictionary<string, List<Decimal>> altVectCrashVals = makeValues(new Decimal(39.73929),
				new Decimal(104.99031), new Decimal(10000), new Decimal(40.73929), new Decimal(105.99031),
				new Decimal(15000), 2, 0, 30, "alt_vct", new Dictionary<string, List<Decimal>>());
			writeData(dbConnection, altVectCrashVals);

			//Safe table
			Dictionary<string, List<Decimal>> safeVals = makeValues(new Decimal(-39.73929),
				new Decimal(-104.99031), new Decimal(10000), new Decimal(40.73929), new Decimal(105.99031),
				new Decimal(15000), 3, 0, 30, "safe_data", new Dictionary<string, List<Decimal>>());
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
				decimal altOne = valsList[2];
				decimal latTwo = valsList[3];
				decimal lonTwo = valsList[4];
				decimal altTwo = valsList[5];


				string table = null;
				if (key.StartsWith("altitude"))
				{
					table = "collision_altitude_data";
				}
				else if (key.StartsWith("vector"))
				{
					table = "collision_vector_data";
				}
				else if (key.StartsWith("alt_vct"))
				{
					table = "collision_altitude_vector_data";
				}
				else
				{
					table = "safe_data";
				}

				dbCommands.CommandText = String.Format("INSERT INTO {0}" +
					"(`id`, latitude_1, longitude_1, altitude_1, latitude_2, longitude_2, altitude_2)" +
					"VALUES (?ts, ?la_1, ?lo_1, ?alt_1, ?la_2, ?lo_2, ?alt_2);", table);

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

				var parameterAltitudeOne = dbCommands.CreateParameter();
				parameterAltitudeOne.ParameterName = "?alt_1";
				parameterAltitudeOne.Value = Decimal.ToInt32(altOne);
				parameterAltitudeOne.DbType = DbType.Int32;
				dbCommands.Parameters.Add(parameterAltitudeOne);

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

				var parameterAltitudeTwo = dbCommands.CreateParameter();
				parameterAltitudeTwo.ParameterName = "?alt_2";
				parameterAltitudeTwo.Value = Decimal.ToInt32(altTwo);
				parameterAltitudeTwo.DbType = DbType.Int32;
				dbCommands.Parameters.Add(parameterAltitudeTwo);

				dbCommands.ExecuteNonQuery();

				Random rnd = new Random();
				int randomSleep = rnd.Next(500, 1000);
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