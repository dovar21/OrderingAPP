﻿namespace RDBTask.API.Application.Models;

using RDBTask.API.Application.Enums;

public class ErrorModel
{
    public ErrorCode Code { get; set; }
    public String Description { get; set; }

    public ErrorModel(string description)
    {
        Description = description;
    }
    public ErrorModel(string code, string description)
    {
        Code = (ErrorCode)Enum.Parse(typeof(ErrorCode), code);
        Description = description;
    }
    public ErrorModel(ErrorCode code)
    {
        Code = code;
        Description = code.ToString();//X?
    }
}
