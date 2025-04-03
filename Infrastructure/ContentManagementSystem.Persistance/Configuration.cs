﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ContentManagementSystem.Persistance
{
    static class Configuration
    {
        static public string ConncetString
        {
            get
            {
                ConfigurationManager configuration = new();
                configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ContentManagementSystem.API"));
                configuration.AddJsonFile("appsettings.json");

                return configuration.GetConnectionString("PostgreSQL");
            }
        }
    }
}
