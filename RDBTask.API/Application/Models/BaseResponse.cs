namespace RDBTask.API.Application.Models;

using System.Net;

public class BaseResponse : BaseResponse<ErrorModel>
{
    public BaseResponse(HttpStatusCode statusCode, params ErrorModel[] errors) : base(errors)
    {
    }
    public static BaseResponse Success() => new BaseResponse(HttpStatusCode.OK);
    public static BaseResponse Fail(params ErrorModel[] errors) => new BaseResponse(HttpStatusCode.BadRequest, errors);
}

public class BaseResponse<TMessage>
{
    public IList<TMessage> Errors { get; set; }

    public BaseResponse(params TMessage[] errors)
    {
        Errors = errors?.ToList() ?? new List<TMessage>();
    }
}
