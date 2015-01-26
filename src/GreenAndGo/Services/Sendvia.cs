using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenAndGo.Properties;

namespace GreenAndGo.Services
{
    public class Sendvia
    {
        private static Net.Sendvia.Client client;

        public static Net.Sendvia.Client Client
        {
            get
            {
                return client ?? (client = new Net.Sendvia.Client(Settings.Default.Client_Id, Settings.Default.Client_Secret));
            }
        }
    }
}