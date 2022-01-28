using System.Net;

namespace MailGun.Net.Tools
{
    public class MgStatusCodes
    {
        public HttpStatusCode[] StatusCodes { get; set; }
        public string ErrorMessage { get; set; }

        private MgStatusCodes(string errorMessage, params HttpStatusCode[] statusCode)
        {
            this.ErrorMessage = errorMessage;
            this.StatusCodes = statusCode;
        }

        public static MgStatusCodes Ok = new MgStatusCodes("Everything works as expected", HttpStatusCode.OK);
        public static MgStatusCodes BadRequest = new MgStatusCodes("Check for missing parameters", HttpStatusCode.BadRequest);
        public static MgStatusCodes Unauthorized = new MgStatusCodes("No Valid API key provided", HttpStatusCode.Unauthorized);
        public static MgStatusCodes RequestFailed = new MgStatusCodes("Parameters Valid but request has failed", (HttpStatusCode)402);
        public static MgStatusCodes NotFound = new MgStatusCodes("The requested item doesn't exist", HttpStatusCode.NotFound);
        public static MgStatusCodes RequestEntityTooLarge = new MgStatusCodes("Attachment size is too big", HttpStatusCode.RequestEntityTooLarge);
        public static MgStatusCodes TooManyRequests = new MgStatusCodes("An API request limit has been reached", (HttpStatusCode)429);

        public static MgStatusCodes ServerError = new MgStatusCodes(
            "Something is wrong on Mailgun's end",
            HttpStatusCode.InternalServerError, //500
            HttpStatusCode.ServiceUnavailable, //503
            HttpStatusCode.BadGateway, //502
            HttpStatusCode.GatewayTimeout //504
        );

        // 200 	Everything worked as expected
        // 400 	Bad Request - Often missing a required parameter
        // 401 	Unauthorized - No valid API key provided
        // 402 	Request Failed - Parameters were valid but request failed
        // 404 	Not Found - The requested item doesn’t exist
        // 413 	Request Entity Too Large - Attachment size is too big
        // 429 	Too many requests - An API request limit has been reached
        // 500, 502, 503, 504 	Server Errors - Something is wrong on Mailgun’s end
    }
}