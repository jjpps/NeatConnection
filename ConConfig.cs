using NeatConnection.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NeatConnection
{
    public class ConConfig
    {

        private string server { get; set; }
        private string database { get; set; }
        private string uid { get; set; }
        private string pass { get; set; }
        public string connectionString { get; set; }


        public ConConfig(ConConfig config)
        {
            connectionString = string.Format("SERVER={0};user={2};PASSWORD={3};DATABASE={1};", config.server, config.database, config.uid, CriptoHash.Decrypt(config.pass, true));
        }
        public ConConfig() { }
        public static ConConfig MontaJson()
        {
            string json = File.ReadAllText("Host.json", Encoding.UTF8);
            JsonClass c = JsonConvert.DeserializeObject<JsonClass>(json);
            return new ConConfig { server=c.server,database=c.database,uid=c.uid,pass=c.pass };
        }
    }
}
