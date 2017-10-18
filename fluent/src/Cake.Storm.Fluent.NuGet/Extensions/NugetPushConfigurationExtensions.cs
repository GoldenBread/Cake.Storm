﻿using Cake.Common;
using Cake.Storm.Fluent.InternalExtensions;
using Cake.Storm.Fluent.NuGet.Common;
using Cake.Storm.Fluent.NuGet.Interfaces;
using Cake.Storm.Fluent.Resolvers;

namespace Cake.Storm.Fluent.NuGet.Extensions
{
	public static class NugetPushConfigurationExtensions
	{
		public static INugetPushConfiguration WithSource(this INugetPushConfiguration configuration, string source)
		{
			configuration.Configuration.AddSimple(NuGetConstants.NUGET_PUSH_SOURCE_KEY, source);
			return configuration;
		}
		
		public static INugetPushConfiguration WithApiKey(this INugetPushConfiguration configuration, string apiKey)
		{
			configuration.Configuration.AddSimple(NuGetConstants.NUGET_PUSH_APIKEY_KEY, ValueResolver.FromConstant(apiKey));
			return configuration;
		}

		public static INugetPushConfiguration WithApiKeyFromArgument(this INugetPushConfiguration configuration, string argumentName)
		{
			configuration.Configuration.AddSimple(NuGetConstants.NUGET_PUSH_APIKEY_KEY, ValueResolver.FromConstant(configuration.Configuration.Context.CakeContext.Argument<string>(argumentName)));
			return configuration;
		}
		
		public static INugetPushConfiguration WithApiKeyFromEnvironment(this INugetPushConfiguration configuration)
		{
			configuration.Configuration.AddSimple(NuGetConstants.NUGET_PUSH_APIKEY_KEY, ValueResolver.FromConstant(NuGetConstants.ENVIRONMENT_PARAMETER));
			return configuration;
		}
	}
}