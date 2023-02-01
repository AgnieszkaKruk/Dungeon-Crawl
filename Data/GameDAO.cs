using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.CompilerServices;

namespace DungeonCrawl {
    public class GameDAO
    {
        private readonly string _connectionstring;


        public GameDAO(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void SaveGameState()
        {
            string insert = @"INSERT INTO dbo.game_state (current_map, save_at,player_id )
                            values(@current_map, @save_at, @player_id )
                            SELECT SCOPE_IDENTITY()"
    

            try
            {
                using ((var connection = new SqlConnection(_connetionstring)) 
                {
                    var command = new SqlCommand(insert, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@current_map", dbo.game_state.id);
                    command.Parameters.AddWithValue("@save_at", dbo.game_state.save_at);
                    command.Parameters.AddWithValue("@player_id", dbo.game_state.);
                    dbo.game_state.id = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new RuntimeWrappedException(ex);
            }

        }
    }
}
