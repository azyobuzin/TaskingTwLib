﻿using System.Linq;
using Azyobuzi.TaskingTwLib.DataModels;

namespace Azyobuzi.TaskingTwLib.Util
{
    static class ResponseParser
    {
        public static Status ParseStatus(string json)
        {
            return Status.Create(json);
        }

        public static Status[] ParseStatuses(string json)
        {
            return SerializationHelper.JsonToXml(json)
                .Elements()
                .Select(Status.Create)
                .ToArray();
        }
    }
}
