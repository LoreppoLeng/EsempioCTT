using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TestCTT.Domain;

namespace TestCTT.DAL
{
    public static class MockRepository
    {
        public static List<User> Users = new List<User>()
        {
            new User(){id=1, nome="Mario" },
            new User(){id=2, nome="Renzo" },
            new User(){id=3, nome="Lucia" }
        };
        public static List<Voice> Voices = new List<Voice>()
        {
            new Voice{ id=1, descrizione="catalogo", azione="Catalogo", controller="Data"},
            new Voice{ id=2, descrizione="carrello", azione="Carrello", controller="Data"},
            new Voice{ id=3, descrizione="anagrafica", azione="Anagrafica", controller="Data"},
            new Voice{ id=4, descrizione="log", azione="Log", controller="Data"},
        };

        public static List<UserVoiceMap> UserVoiceMaps = new List<UserVoiceMap>()
        {
            new UserVoiceMap(){idUser=1, idVoice=1},
            new UserVoiceMap(){idUser=1, idVoice=2},
            new UserVoiceMap(){idUser=1, idVoice=3},
            new UserVoiceMap(){idUser=1, idVoice=4},
            new UserVoiceMap(){idUser=2, idVoice=2},
            new UserVoiceMap(){idUser=2, idVoice=4},
            new UserVoiceMap(){idUser=3, idVoice=1},
            new UserVoiceMap(){idUser=3, idVoice=3},
        };



        public static IEnumerable<User> GetAllUsers()
        {
            return Users;
        }
        public static IEnumerable<Voice> GetAllMenuVoices()
        {
            return Voices;
        }
        public static IEnumerable<UserVoiceMap> GetUserVoiceMapping()
        {
            return UserVoiceMaps;
        }

        public static User GetUserById(int id)
        {
            return Users.Where(u => u.id == id).FirstOrDefault();
        }

        public static void AddUser(User u)
        {
            Users.Add(u);
        }

    }
}
