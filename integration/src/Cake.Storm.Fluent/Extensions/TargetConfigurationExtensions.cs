﻿using System;
using Cake.Storm.Fluent.Interfaces;
using Cake.Storm.Fluent.Models;

namespace Cake.Storm.Fluent.Extensions
{
    public static class TargetConfigurationExtensions
    {
	    public static TConfiguration UsePlatform<TConfiguration>(this TConfiguration configuration, string name, Action<IConfiguration> action)
			where TConfiguration : ITargetConfiguration
	    {
			IPlatformConfiguration platformConfiguration = new PlatformConfiguration(configuration.Context);
		    action(platformConfiguration);
			configuration.AddPlatform(name, platformConfiguration);

			return configuration;
	    }
    }
}
