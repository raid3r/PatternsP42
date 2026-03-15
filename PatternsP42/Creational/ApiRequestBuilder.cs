using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Creational;


public interface IReadOnlyApiRequest : ICloneable {
    public string Url { get; }
    public string Method { get; }
    public string Body { get; }
}


public class ApiRequest: IReadOnlyApiRequest, ICloneable
{
    public object Clone()
    {
        return new ApiRequest
        {
            Url = this.Url,
            Method = this.Method,
            Body = this.Body
        };
    }

    public string Url { get; set; }
    public string Method { get; set; }
    public string Body { get; set; }

    public override string ToString()
    {
        return $"URL: {Url}, Method: {Method}, Body: {Body}";
    }

    //public class ApiRequestBuilder
    //{
    //    private ApiRequest _request;

    //    public ApiRequestBuilder()
    //    {
    //        _request = new ApiRequest();
    //    }

    //    public ApiRequestBuilder SetBaseUrl(string url)
    //    {
    //        _request.Url = url;
    //        return this;
    //    }

    //    public ApiRequestBuilder SetMethod(string method)
    //    {
    //        _request.Method = method;
    //        return this;
    //    }

    //    public ApiRequestBuilder SetBody(string body)
    //    {
    //        _request.Body = body;
    //        return this;
    //    }

    //    public ApiRequestBuilder FromRequest(ApiRequest request)
    //    {
    //        _request.Url = request.Url;
    //        _request.Method = request.Method;
    //        _request.Body = request.Body;
    //        return this;
    //    }

    //    public ApiRequest Build()
    //    {
    //        return _request;
    //    }

    //}
}


public class ApiRequestBuilder
{
    private ApiRequest _request;

    public ApiRequestBuilder()
    {
        _request = new ApiRequest();
    }

    public ApiRequestBuilder SetBaseUrl(string url)
    {
        _request.Url = url;
        return this;
    }

    public ApiRequestBuilder SetMethod(string method)
    {
        _request.Method = method;
        return this;
    }

    public ApiRequestBuilder SetBody(string body)
    {
        _request.Body = body;
        return this;
    }

    public ApiRequestBuilder FromRequest(IReadOnlyApiRequest request)
    {
        _request = request.Clone() as ApiRequest;
        return this;
    }

    public IReadOnlyApiRequest Build()
    {
        return _request as IReadOnlyApiRequest;
    }

}