﻿using System.ComponentModel;
using TNRD.Zeepkist.WorkshopApi.Backend.RequestModels;

namespace TNRD.Zeepkist.WorkshopApi.Backend.Endpoints.Levels.GetAll;

public class RequestModel : LimitOffsetRequestModel
{
    [QueryParam, DefaultValue(false)] public bool IncludeReplaced { get; set; } = false;
}
