﻿using Microsoft.SharePoint.Client;

namespace OfficeDevPnP.Core.Framework.ObjectHandlers.TokenDefinitions
{
    public class DefaultTermGroupSiteCollectionToken : TokenDefinition
    {
        public DefaultTermGroupSiteCollectionToken(Web web)
            : base(web, "~termgroupsite", "{termgroupsite}")
        {
        }

        public override string GetReplaceValue()
        {
            if (CacheValue == null)
            {
                Web.Context.Load(Web, w => w.ServerRelativeUrl);
                Web.Context.ExecuteQueryRetry();
                CacheValue = Web.Url.Substring(Web.Url.IndexOf("://", System.StringComparison.Ordinal) + 3).TrimEnd('/').Replace('/', '-');
            }
            return CacheValue;
        }
    }
}